using Ionic.Zip;
using MCCMapPacker.Data;
using MCCMapPacker.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCCMapPacker
{
    class Loader
    {
        ConfigData config;

        StockMapHashes hashes;

        public event EventHandler LoadComplete = delegate { };

        public event EventHandler LoadCancelled = delegate { };

        public Loader()
        {
            hashes = JsonConvert.DeserializeObject<StockMapHashes>(File.ReadAllText("StockMaps.Json"));
        }


        public async void LoadZip()
        {
            config = Config.LoadConfig();

            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = "zip";
            fd.Filter = "MCC Map Packer Archive (*.zip)|*.zip|All files (*.*)|*.*";
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Pack loading, please do not close the program until loading has completed.");

                await Task.Run(() => UnzipPack(fd.FileName));
            }
            else
            {
                this.LoadCancelled(this, new EventArgs());
            }
        }

        private void UnzipPack(string file)
        {
            using (var zip = ZipFile.Read(file))
            {
                foreach (ZipEntry z in zip)
                {
                    string mapPath = config.GamePath + @"\" + z.FileName.Replace("/", @"\");

                    if (Path.HasExtension(mapPath))
                    {
                        if (CheckStockMap(mapPath).Result)
                        {
                            if (BackupStock(mapPath))
                            {
                                z.Extract(config.GamePath);
                            }
                        }
                        else
                        {
                            //if we have a modded / no map then just write the file.
                            File.Delete(mapPath);
                            z.Extract(config.GamePath);
                        }
                    }

                }
            }
            this.LoadComplete(this, new EventArgs());
        }

        private bool BackupStock(string filePath)
        {
            //checks everywhere!
            if (!File.Exists(filePath))
            {
                return false;
            }

            string backupPath = filePath + ".bak";

            if (File.Exists(backupPath))
            {
                return false;
            }

            File.Move(filePath, backupPath);

            if (File.Exists(backupPath))
            {
                return true;
            }

            MessageBox.Show("Unable to back up stock map: " + filePath + " This map will not be replaced");
            return false;
        }

        private async Task<bool> CheckStockMap(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            if (Path.HasExtension(filePath))
            {
                Games g = GetGameFromPath(filePath);
                string stockHash = hashes.GetMapHashFromName(g, Path.GetFileName(filePath));

                string hash = await CalculateMD5(filePath);

                if (hash == stockHash)
                {
                    return true;
                }

                return false;
            }


            return true;
        }
        //Get MD5 as one continuous string for easy comparison
        private async Task<string> CalculateMD5(string filename)
        {
            return await Task.Run(() =>
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    }
                }
            });

        }

        private Games GetGameFromPath(string path)
        {
            DirectoryInfo d = Directory.GetParent(path);
            string dir = d.Parent.ToString();

            switch (dir)
            {
                case "halo1":
                    return Games.Halo1;
                case "halo2":
                    return Games.Halo2C;
                case "groundhog":
                    return Games.Halo2A;
                case "halo3":
                    return Games.Halo3;
                case "halo3odst":
                    return Games.HaloODST;
                case "haloreach":
                    return Games.HaloReach;
                case "halo4":
                    return Games.Halo4;
            }
            return Games.Halo1;
        }
        
    }
}


