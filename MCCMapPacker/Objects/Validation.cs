using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MCCMapPacker.Objects.Helpers;

namespace MCCMapPacker.Objects
{

    public delegate void MapValidatedDelegate(string  mapName, bool passed);
    public delegate void ValidationCancelled();
    public delegate void ValidationComplete(int successcount);

    class Validation
    {
        StockMapData data;

        ConfigData config;

        CancellationTokenSource cancellationSource;

        public event MapValidatedDelegate MapValidated;
        public event ValidationCancelled OnValidationCancelled;
        public event ValidationComplete OnValidationComplete;

        private int SuccessCount;

        [Flags]
        public enum GamesToValidate : short
        {
            None = 0,
            HaloCE = 1,
            Halo2C = 2,
            Halo2A = 4,
            Halo3 = 8,
            HaloODST = 16,
            HaloReach = 32,
            Halo4 = 64
        }

        public Validation()
        {   
            if(StockMapDataExists())
            {
                data = GetStockMapData();
            }
            config = Config.LoadConfig();
        }

        public async Task ValidateMaps(GamesToValidate games)
        {
            cancellationSource = new CancellationTokenSource();
            try
            {
                await Task.Run(() => ValidationLoop(games, cancellationSource.Token), cancellationSource.Token);
            }
            catch
            {
                MessageBox.Show("Validation was cancelled.");
                OnValidationCancelled.Invoke();
            }
        }

        public void CancelValidation()
        {
            cancellationSource.Cancel();
        }

        public async Task<bool> ValidationLoop(GamesToValidate games, CancellationToken token)
        {
            foreach (MapInfo map in data.maps)
            {
                token.ThrowIfCancellationRequested();
                if (games.HasFlag(MapToGameFlag(map)))
                {
                    string fp = config.GamePath + map.MapPath + map.MapFileName;

                    if (File.Exists(fp))
                    {
                        if (await CalculateMD5(fp) == map.MapHash)
                        {
                            MapValidated?.Invoke(map.MapNameUI, true);
                            SuccessCount++;
                            continue;
                        }
                    }
                    MapValidated?.Invoke(map.MapNameUI, false);
                }
            }
            OnValidationComplete?.Invoke(SuccessCount);
            return true;
        }

        public int GetNumFilesToValidate(GamesToValidate g)
        {
            int i = 0;
            foreach (MapInfo map in data.maps)
            {
                if (g.HasFlag(MapToGameFlag(map)))
                {
                    i++;
                }
            }
            return i;
        }

        public GamesToValidate MapToGameFlag(MapInfo map)
        {
            switch(map.Game)
            {
                case Data.Games.Halo1:
                    return GamesToValidate.HaloCE;
                case Data.Games.Halo2C:
                    return GamesToValidate.Halo2C;
                case Data.Games.Halo2A:
                    return GamesToValidate.Halo2A;
                case Data.Games.Halo3:
                    return GamesToValidate.Halo3;
                case Data.Games.HaloODST:
                    return GamesToValidate.HaloODST;
                case Data.Games.HaloReach:
                    return GamesToValidate.HaloReach;
                case Data.Games.Halo4:
                    return GamesToValidate.Halo4;
            }
            return GamesToValidate.None;
        }
    }
}
