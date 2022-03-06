using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCMapPacker.Data;
using Newtonsoft.Json;

namespace MCCMapPacker.Objects
{
    public struct MapData
    {
        public string MapNameUI { get; set; }
        public string MapFileName { get; set; }
        public string MapHash { get; set; }
    }
    class StockMapHashes
    {
        public List<MapData> ReachMaps;
        public List<MapData> CEMaps;
        public List<MapData> H2CMaps;
        public List<MapData> H2AMaps;
        public List<MapData> H3Maps;
        public List<MapData> ODSTMaps;
        public List<MapData> H4Maps;

        public StockMapHashes()
        {
            ReachMaps = new List<MapData>();
            CEMaps = new List<MapData>();
            H2CMaps = new List<MapData>();
            H2AMaps = new List<MapData>();
            H3Maps = new List<MapData>();
            ODSTMaps = new List<MapData>();
            H4Maps = new List<MapData>();
        }

        public string GetMapNameFromFriendly(Games g, string friendly)
        {
            switch (g)
            {
                case Games.Halo1:
                    return CEMaps.FindAll(CEMaps => CEMaps.MapNameUI == friendly)[0].MapFileName;
                case Games.Halo2C:
                    return H2CMaps.FindAll(H2CMaps => H2CMaps.MapNameUI == friendly)[0].MapFileName;
                case Games.Halo2A:
                    return H2AMaps.FindAll(H2AMaps => H2AMaps.MapNameUI == friendly)[0].MapFileName;
                case Games.Halo3:
                    return H3Maps.FindAll(H3Maps => H3Maps.MapNameUI == friendly)[0].MapFileName;
                case Games.HaloODST:
                    return ODSTMaps.FindAll(ODSTMaps => ODSTMaps.MapNameUI == friendly)[0].MapFileName;
                case Games.HaloReach:
                    return ReachMaps.FindAll(ReachMaps => ReachMaps.MapNameUI == friendly)[0].MapFileName;
                case Games.Halo4:
                    return H4Maps.FindAll(H4Maps => H4Maps.MapNameUI == friendly)[0].MapFileName;
            }
            return "";
        }

        public string GetMapHashFromName(Games g, string mapName)
        {
            switch (g)
            {
                case Games.Halo1:
                    return CEMaps.FindAll(CEMaps => CEMaps.MapFileName == mapName)[0].MapHash;
                case Games.Halo2C:
                    return H2CMaps.FindAll(H2CMaps => H2CMaps.MapFileName == mapName)[0].MapHash;
                case Games.Halo2A:
                    return H2AMaps.FindAll(H2AMaps => H2AMaps.MapFileName == mapName)[0].MapHash;
                case Games.Halo3:
                    return H3Maps.FindAll(H3Maps => H3Maps.MapFileName == mapName)[0].MapHash;
                case Games.HaloODST:
                    return ODSTMaps.FindAll(ODSTMaps => ODSTMaps.MapFileName == mapName)[0].MapHash;
                case Games.HaloReach:
                    return ReachMaps.FindAll(ReachMaps => ReachMaps.MapFileName == mapName)[0].MapHash;
                case Games.Halo4:
                    return H4Maps.FindAll(H4Maps => H4Maps.MapFileName == mapName)[0].MapHash;
            }
            return "";
        }
    }
}
