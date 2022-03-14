using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static MCCMapPacker.Objects.Helpers;
using static MCCMapPacker.Objects.Globals;

namespace MCCMapPacker.Objects
{
    class VersionCheck
    {
        private ConfigData config;
        StockMapData data;

        public VersionCheck()
        {
            config = Config.LoadConfig();

            if(StockMapDataExists())
            {
                data = GetStockMapData();
            }
            CheckMapData();
            
            
        }

        public bool CheckVersion()
        {
            string buildTag = config.GamePath + @"\build_tag.txt";

            if (!File.Exists(buildTag))
            {
                MessageBox.Show("The build_tag.txt file could not be found. Do you have the right install directory?");
                return false;
            }
            string mccVersion = File.ReadAllText(buildTag).GetUntilOrEmpty();

            if(mccVersion == data.version)
            {
                //versions match, correct data - woo
                return true;
            }
            else
            {
                //version's don't match, probably needs an update!
                return false;
            }
        }

        public void GetUpdate()
        {
            StockMapData webMapData;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://raw.githubusercontent.com/classyham/MCCStockMapHashes/main/StockMapData.json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if(response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Http error: " + response.StatusCode + " | " + response.StatusDescription + " If you see this please message @Classyham#0001 on Discord or @Classyham on twitter. Please do not use the application until you have a response from me. ");
            }
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                webMapData = JsonConvert.DeserializeObject<StockMapData>(reader.ReadToEnd());
            } 

            if (File.Exists(StockMapDataPath))
            {
                if (webMapData.version == data.version)
                {
                    MessageBox.Show("Server currently has the same version number as the local data. Please contact Classyham#0001 on Discord as it is likely the game has been patched and new stock hashes need to be generated. Please do NOT use the tool until you have contacted me.");
                    return;
                }
            }
            File.WriteAllText(StockMapDataPath, JsonConvert.SerializeObject(webMapData,Formatting.Indented));
        }

        public void CheckMapData()
        {
            if(!StockMapDataExists())
            {
                DialogResult dialogResult = MessageBox.Show("ERROR: StockMapData.json does not exist. The software will not run without this file. Download it?", "StockMapData Missing", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GetUpdate();
                    MessageBox.Show("Data acquired. Starting tool");
                }
                else
                {
                    Application.Exit();
                    return;
                }
            }
        }
    }
}
