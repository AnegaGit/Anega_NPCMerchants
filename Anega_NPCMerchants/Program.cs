using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anega_NPCMerchants
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }

    enum NodeLevel
    {
        Merchant,
        BuySell,
        Group,
        Item
    }

    public class ItemInfo
    {
        public string name { get; set; }
        public int price { get; set; }

        public ItemInfo(string _name, int _price)
        {
            name = _name;
            price = _price;
        }
    }
    public class MerchantInfo
    {
        public string name { get; set; }
        public bool buyallsellitems { get; set; }

        public MerchantInfo(string _name, bool _buyallsellitems)
        {
            name = _name;
            buyallsellitems = _buyallsellitems;
        }
    }
    public class BuySellGroup
    {
        public int id { get; set; }
        public string name { get; set; }
        public string merchant { get; set; }
        public int sort { get; set; }
        public bool isBuy { get; set; }
        public float priceLevel { get; set; }

        public BuySellGroup(int _id, string _name, string _merchant, int _sort, bool _isBuy, float _priceLevel)
        {
            id = _id;
            name = _name;
            merchant = _merchant;
            sort = _sort;
            isBuy = _isBuy;
            priceLevel = _priceLevel;
        }
    }
    public class BuySellItem
    {
        public int id { get; set; }
        public int buySellGroup { get; set; }
        public string name { get; set; }
        public int durability { get; set; }
        public int quality { get; set; }
        public float priceLevel { get; set; }

        public BuySellItem(int _id, int _buySellGroup, string _name, int _durability, int _quality, float _priceLevel)
        {
            id = _id;
            buySellGroup = _buySellGroup;
            name = _name;
            durability = _durability;
            quality = _quality;
            priceLevel = _priceLevel;
        }
    }
}
