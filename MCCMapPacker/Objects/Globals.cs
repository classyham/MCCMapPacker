using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCCMapPacker.Objects
{
    public static class Globals
    {
        public static string StockMapDataPath { get; } = Path.GetDirectoryName(Application.ExecutablePath) + @"\Data\StockMapData.json";

        public static string ConfigFile { get; } = Path.GetDirectoryName(Application.ExecutablePath) + @"\config\config.json";
    }
}
