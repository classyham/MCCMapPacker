using MCCMapPacker.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5Builder
{

    //this tool is not meant for public use. It's to scrape the md5 hashes and build the json file in the case a new game update changes the files. 
    public partial class MainForm : Form
    {
        public StockMapData stock;

        public string gamepath = @"C:\Program Files (x86)\Steam\steamapps\common\Halo The Master Chief Collection";

        Control control;

        public string version;

        public MainForm()
        {
            InitializeComponent();

            control = listBox1;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            stock = JsonConvert.DeserializeObject<StockMapData>(File.ReadAllText("StockMapData.Json"));

            version = File.ReadAllText(gamepath + @"\build_tag.txt").GetUntilOrEmpty();
            stock.version = version;



            await HashAllMaps();

        }

        private async Task<bool> HashAllMaps()
        {
            List<MapInfo> updatedMaps = new List<MapInfo>();


            foreach(MapInfo m in stock.maps)
            {
                string mp;
                if(m.Game == MCCMapPacker.Data.Games.Halo4)
                {
                    mp = "\\halo4\\maps\\";
                }
                else
                {
                    mp = m.MapPath;
                }

                string hashString = await CalculateMD5(gamepath + mp + m.MapFileName);

                MapInfo mi = new MapInfo();
                mi.Game = m.Game;
                mi.MapFileName = m.MapFileName;
                mi.MapNameUI = m.MapNameUI;
                mi.MapPath = mp;
                mi.MapHash = hashString;
                updatedMaps.Add(mi);

                UpdateUI(mi.MapNameUI + " - " + mi.MapHash);
            }

            stock.maps = updatedMaps;

            string jsonString = JsonConvert.SerializeObject(stock,Formatting.Indented);
            File.WriteAllText("Updatedhashes.json", jsonString);

            return true;
        }

        private void UpdateUI(string item)
        {
            control.BeginInvoke((MethodInvoker)delegate ()
            {
                listBox1.Items.Add(item);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            });
        }

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
    }
    static class Helper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }
}
