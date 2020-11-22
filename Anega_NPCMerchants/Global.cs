using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anega_NPCMerchants
{
    class Global
    {
        public static string PriceText(int price)
        {
            int gold = price / 10000;
            int silver = (price - gold * 10000) / 100;
            int copper = price - gold * 10000 - silver * 100;
            string text = "";
            if (gold > 0)
            {
                text += gold.ToString() + " g";
            }
            if (silver > 0)
            {
                text += (text.Length > 1 ? " " : "") + silver.ToString() + " s";
            }
            if (copper > 0)
            {
                text += (text.Length > 1 ? " " : "") + copper.ToString() + " c";
            }
            return text;
        }
    }

}
