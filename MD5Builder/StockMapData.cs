using MCCMapPacker.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MCCMapPacker.Objects
{
    public struct MapInfo
    {
        public string MapNameUI { get; set; }
        public string MapFileName { get; set; }
        public string MapHash { get; set; }
        public string MapPath { get; set; }
        public Games Game { get; set; }

    }

    public class StockMapData
    {
        public string version;

        public List<MapInfo> maps;

        public StockMapData()
        {
            maps = new List<MapInfo>();
        }
    }
}
