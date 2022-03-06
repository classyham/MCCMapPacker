using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCCMapPacker.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MCCMapPacker
{

    public static class Config
    {
        public static string configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MCCMapPacker\config\";

        public static string configFile = configPath + @"\config.json";

        public static bool CheckConfig()
        {
            if (!File.Exists(configFile))
            {
                Directory.CreateDirectory(configPath);
                ConfigData c = new ConfigData();
                string configstring = JsonConvert.SerializeObject(c, Formatting.Indented);
                File.WriteAllText(configFile, configstring);
                return false;
            }

            ConfigData con = JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(configFile));
            if(!(Directory.Exists(con.GamePath) || Directory.Exists(con.BackupPath)))
            {
                return false;
            }
            return true;
        }

        public static ConfigData LoadConfig()
        {
            try
            {
                return JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(configFile));
            }
               catch (Exception)
            {
                MessageBox.Show(@"Config file not found! Please check Appdata\Roaming\MCCMapPacker");
                return new ConfigData();
            }
        }

    }
}
