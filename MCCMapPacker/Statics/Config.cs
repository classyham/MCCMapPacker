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
using static MCCMapPacker.Objects.Globals;

namespace MCCMapPacker
{

    public static class Config
    {
        public static string configPath = Path.GetDirectoryName(ConfigFile);

        public static bool CheckConfig()
        {
            if (!File.Exists(ConfigFile))
            {
                Directory.CreateDirectory(configPath);
                ConfigData c = new ConfigData();
                string configstring = JsonConvert.SerializeObject(c, Formatting.Indented);
                File.WriteAllText(ConfigFile, configstring);
                return false;
            }

            ConfigData con = JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(ConfigFile));
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
                return JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(ConfigFile));
            }
               catch (Exception)
            {
                MessageBox.Show(@"Config file not found! Please check Appdata\Roaming\MCCMapPacker");
                return new ConfigData();
            }
        }

    }
}
