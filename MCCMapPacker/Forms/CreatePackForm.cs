using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCCMapPacker.Window;
using MCCMapPacker.Data;
using MCCMapPacker.Objects;
using Newtonsoft.Json;
using System.IO;
using Ionic.Zip;
using System.Diagnostics;
using static MCCMapPacker.Objects.Helpers;

namespace MCCMapPacker.Forms
{
    public partial class CreatePackForm : Form
    {
        private StockMapData data;

        private MapReplaceData mapReplaceData;

        public MainForm mainForm;

        Control Prog;
        public CreatePackForm()
        {
            InitializeComponent();

            if(StockMapDataExists())
            {
                data = GetStockMapData();
            }
            

            mapReplaceData = new MapReplaceData();

            Prog = PackCreateProgress;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
        #region Drag
        private void CreatePackForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }

        private void ReplaceMapListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }
        #endregion

        private void UpdateMapCombo(Games g)
        {
            List<MapInfo> found = data.maps.FindAll(MapInfo => MapInfo.Game == g);

            foreach(MapInfo m in found.ToArray())
            {
                MapCombo.Items.Add(m.MapNameUI);
            }
            
            MapCombo.SelectedIndex = 0;
        }

        private void GameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Games index = (Games)Enum.ToObject(typeof(Games), GameCombo.SelectedIndex);
            UpdateMapCombo(index);
        }

        private void AddStockMapBtn_Click(object sender, EventArgs e)
        {

            Games index = (Games)Enum.ToObject(typeof(Games), GameCombo.SelectedIndex);
            if (mapReplaceData.CheckDupe(index, MapCombo.Text))
            {
                MessageBox.Show("Map is already in the list Try a different map.");
                return;
            }

            string[] row = { GameCombo.SelectedItem + " - " + MapCombo.SelectedItem, "No map selected" };
            ListViewItem l = new ListViewItem(row);
            ReplaceMapListView.Items.Add(l);


            ReplaceData newMapData = new ReplaceData
            {
                game = index,
                overridenMapName = MapCombo.Text
            };
            mapReplaceData.data.Add(newMapData);
        }

        private void RemoveMapBtn_Click(object sender, EventArgs e)
        {

            Games g = (Games)Enum.ToObject(typeof(Games), GameCombo.FindString(ReplaceMapListView.SelectedItems[0].Text.GameSelectionToEnumString()));

            if (mapReplaceData.RemoveByData(g, ReplaceMapListView.SelectedItems[0].Text.GameSelectionToMapName()))
            {
                ReplaceMapListView.Items.Remove(ReplaceMapListView.SelectedItems[0]);
            }

        }

        private void OverrideMapBtn_Click(object sender, EventArgs e)
        {
            if (ReplaceMapListView.Items.Count == 0)
            {
                MessageBox.Show("Add some maps first.");
                return;
            }
            if(ReplaceMapListView.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem item = ReplaceMapListView.SelectedItems[0];
            
            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = "map";
            fd.Filter = "Halo map files (*.map)|*.map|All files (*.*)|*.*";
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                item.SubItems[1].Text = Path.GetFileName(fd.FileName);

                Games g = (Games)Enum.ToObject(typeof(Games), GameCombo.FindString(item.SubItems[0].Text.GameSelectionToEnumString()));
                mapReplaceData.addReplaceFilePathByData(g, item.SubItems[0].Text.GameSelectionToMapName(), fd.FileName);
            }

        }

        private async void CreatePackButton_Click(object sender, EventArgs e)
        {
            //sanity checks!
            if (PackName.Text.Length < 1)
            {
                MessageBox.Show("Please add a pack name");
                return;
            }
            if (ReplaceMapListView.Items.Count < 1)
            {
                MessageBox.Show("Please add some maps to be replaced");
                return;
            }
            if (!ValidateMaps())
            {
                MessageBox.Show("One or more maps does not have a replacement specified. Please add a reaplacement ot remove the entry");
                return;
            }

            PackCreateProgress.Visible = true;
            CreatePackButton.Enabled = false;
            AddStockMapBtn.Enabled = false;
            RemoveMapBtn.Enabled = false;
            OverrideMapBtn.Enabled = false;
            CloseButton.Enabled = false;


            Dictionary<string, string> maps = new Dictionary<string, string>();
            foreach(ListViewItem i in ReplaceMapListView.Items)
            {
                maps.Add(i.SubItems[0].Text, i.SubItems[1].Text);
            }

            await Task.Run(() => CreateZipEntry(maps));

            PackCreateProgress.Visible = false;
            CreatePackButton.Enabled = true;
            AddStockMapBtn.Enabled = true;
            RemoveMapBtn.Enabled = true;
            OverrideMapBtn.Enabled = true;
            CloseButton.Enabled = true;
        }

        private void CreateZipEntry(Dictionary<string,string> maps)
        {

            string outputDir = AppDomain.CurrentDomain.BaseDirectory + "output";

            Directory.CreateDirectory(outputDir);

            using (ZipFile z = new ZipFile())
                {
                    foreach (var v in maps)
                    {

                        //get game enum and replacement map filepath
                        Games g = (Games)Enum.ToObject(typeof(Games), GameCombo.FindString(v.Key.GameSelectionToEnumString()));
                        string fp = mapReplaceData.GetReplacePathByData(g, v.Key.GameSelectionToMapName());

                        string rn = v.Key.GameSelectionToMapName();

                        if (!z.ContainsEntry(GetMapGamePathFromEnum(g) + "/"))
                        {
                            z.AddDirectoryByName(GetMapGamePathFromEnum(g));
                        }

                        ZipEntry zi = z.AddFile(fp);
                        zi.FileName = GetMapGamePathFromEnum(g) + @"\" + data.MapFileFromFriendly(g, rn);
                    }
                    z.Save(Path.Combine(outputDir, PackName.Text + ".zip"));
                }            
        }

        private string GetMapGamePathFromEnum(Games g)
        {
            switch(g)
            {
                case Games.Halo1:
                    return @"\halo1\maps";
                case Games.Halo2C:
                    return @"\halo2\h2_maps_win64_dx11";
                case Games.Halo2A:
                    return @"\groundhog\maps";
                case Games.Halo3:
                    return @"\halo3\maps";
                case Games.HaloODST:
                    return @"\halo3odst\maps";
                case Games.HaloReach:
                    return @"\haloreach\maps";
                case Games.Halo4:
                    return @"\halo4\maps";
            }
            return "";
        }

        private bool ValidateMaps()
        {
            foreach (ListViewItem i in ReplaceMapListView.Items)
            {
                if (i.SubItems[1].Text == "No map selected")
                {
                    return false;
                }
            }
            return true;
        }


        //prevent any unsafe characters being added in.
        private void PackName_TextChanged(object sender, EventArgs e)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            PackName.Text = string.Join("", PackName.Text.Split(invalidChars));
            PackName.SelectionStart = PackName.Text.Length + 1;
        }

        private void OutputFolderButton_Click(object sender, EventArgs e)
        {
            string outDir = AppDomain.CurrentDomain.BaseDirectory + "output";

            Directory.CreateDirectory(outDir);

            if (Directory.Exists(outDir))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = outDir,
                    FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }
    else
    {
        MessageBox.Show(string.Format("{0} Directory does not exist!", outDir));
    }
}

        private void CreatePackForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }
    }
}
