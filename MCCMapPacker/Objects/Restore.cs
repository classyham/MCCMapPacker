using MCCMapPacker.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MCCMapPacker.Objects.Helpers;

//A class to handle restoring stock maps from ###.map.bak providing the MD5 matches stock. 
namespace MCCMapPacker
{
    class Restore
    {
        StockMapData data;

        ConfigData config;

        public Restore()
        {
            config = Config.LoadConfig();

            if(StockMapDataExists())
            {
                data = GetStockMapData();
            }
        }

        public async Task<bool> RestoreMaps()
        {
            foreach(MapInfo map in data.maps)
            {
                string bakfp = config.GamePath + map.MapPath + map.MapFileName + ".bak";
                if (File.Exists(bakfp))
                {
                    if (await CalculateMD5(bakfp) == map.MapHash)
                    {
                        File.Delete(config.GamePath + map.MapPath + map.MapFileName);
                        File.Move(bakfp, config.GamePath + map.MapPath + map.MapFileName);
                    }
                }
            }
            MessageBox.Show("Maps restored");
            return true;
        }


    }
}
