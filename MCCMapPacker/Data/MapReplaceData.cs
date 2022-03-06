using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCMapPacker.Data
{
    public struct ReplaceData
    {
        public Games game { get; set; }

        public string overridenMapName { get; set; }

        public string overriderFilePath { get; set; }

    }
    class MapReplaceData
    {
        public List<ReplaceData> data;

        public MapReplaceData()
        {
            data = new List<ReplaceData>();
        }

        public bool CheckDupe(Games a_game, string mapname)
        {
            if(data.FindAll(ReplaceData => ReplaceData.game == a_game && ReplaceData.overridenMapName == mapname).Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveByData(Games a_game, string mapname)
        {
            if(data.RemoveAll(ReplaceData => ReplaceData.game == a_game && ReplaceData.overridenMapName == mapname) > 0)
            {
                return true;
            }
            return false;
        }
        public bool addReplaceFilePathByData(Games a_game, string mapname, string OverridePath)
        {
            int i = data.FindIndex(ReplaceData => ReplaceData.game == a_game && ReplaceData.overridenMapName == mapname);

            if (i != -1)
            {
                data[i] = new ReplaceData
                {
                    game = data[i].game,
                    overridenMapName = data[i].overridenMapName,
                    overriderFilePath = OverridePath
                };
                return true;
            }

            return false;
        }

        public string GetReplacePathByData(Games a_game, string mapname)
        {
            int i = data.FindIndex(ReplaceData => ReplaceData.game == a_game && ReplaceData.overridenMapName == mapname);

            if (i != -1)
            {
                return data[i].overriderFilePath;
            }

            return "";
        }
    }
}
