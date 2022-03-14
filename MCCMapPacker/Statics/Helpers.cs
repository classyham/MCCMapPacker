using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCCMapPacker.Objects
{
    public static class Helpers
    {
        public static string GameSelectionToEnumString(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation -1);
                }
            }

            return String.Empty;
        }

        public static string GameSelectionToMapName(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(charLocation + 2, text.Length-(charLocation+2));
                }
            }

            return String.Empty;
        }

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

        public static StockMapData GetStockMapData()
        {
            string fp = Path.GetDirectoryName(Application.ExecutablePath) + @"\Data\StockMapData.json";
            return JsonConvert.DeserializeObject<StockMapData>(File.ReadAllText(fp));
        }

        public static bool StockMapDataExists()
        {
            string fp = Path.GetDirectoryName(Application.ExecutablePath) + @"\Data\StockMapData.json";
            if(File.Exists(fp))
            {
                return true;
            }
            return false;
        }

        public static async Task<string> CalculateMD5(string filename)
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
}
