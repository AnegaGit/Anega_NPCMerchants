using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anega_NPCMerchants
{
    static class Database
    {

        public static SQLiteConnection CreateConnection(string fileName)
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(string.Format("Data Source= {0}; Version = 3; ", fileName));
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public static List<ItemInfo> ReadItemInfos(SQLiteConnection conn)
        {
            List<ItemInfo> returnData = new List<ItemInfo>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT name, baseprice FROM ang_item_info";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string itemName = sqlite_datareader.GetString(0);
                int basePrice = sqlite_datareader.GetInt32(1);
                returnData.Add(new ItemInfo(itemName, basePrice));
            }
            return returnData;
        }

        public static List<MerchantInfo> ReadMerchantInfos(SQLiteConnection conn)
        {
            List<MerchantInfo> returnData = new List<MerchantInfo>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT name, buyallsellitems FROM ang_npcmerchant_info";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string npcName = sqlite_datareader.GetString(0);
                bool buyallsellitems = Convert.ToBoolean(sqlite_datareader.GetInt32(1));
                returnData.Add(new MerchantInfo(npcName, buyallsellitems));
            }
            return returnData;
        }

        public static List<BuySellGroup> ReadBuySellGroups(SQLiteConnection conn)
        {
            List<BuySellGroup> returnData = new List<BuySellGroup>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT id, name, npcmerchant, sort, isbuy, pricelevel FROM ang_buysellgroup";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int id = sqlite_datareader.GetInt32(0);
                string name = sqlite_datareader.GetString(1);
                string npcmerchant = sqlite_datareader.GetString(2);
                int sort = sqlite_datareader.GetInt32(3);
                bool isbuy = Convert.ToBoolean(sqlite_datareader.GetInt32(4));
                float pricelevel = sqlite_datareader.GetFloat(5);
                returnData.Add(new BuySellGroup(id, name, npcmerchant, sort, isbuy, pricelevel));
            }
            return returnData;
        }
        public static void WriteBuySellGroups(SQLiteConnection conn, List<BuySellGroup> buySellGroups)
        {
            SQLiteCommand sqlite_cmd;

            // empty table first
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "DELETE FROM ang_buysellgroup";
            sqlite_cmd.ExecuteNonQuery();

            foreach (BuySellGroup buySellGroup in buySellGroups)
            {
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = string.Format("INSERT INTO ang_buysellgroup (id, name, npcmerchant, sort, isbuy, pricelevel) VALUES ({0},'{1}','{2}',{3},{4},{5}); "
                    , buySellGroup.id
                    , buySellGroup.name
                    , buySellGroup.merchant
                    , buySellGroup.sort
                    , Convert.ToInt32(buySellGroup.isBuy)
                    , buySellGroup.priceLevel);
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public static List<BuySellItem> ReadBuySellItems(SQLiteConnection conn)
        {
            List<BuySellItem> returnData = new List<BuySellItem>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT id, buysellgroup, itemname,durability, quality, pricelevel FROM ang_buysellitems";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int id = sqlite_datareader.GetInt32(0);
                int group = sqlite_datareader.GetInt32(1);
                string name = sqlite_datareader.GetString(2);
                int durability = sqlite_datareader.GetInt32(3);
                int quality = sqlite_datareader.GetInt32(4);
                float pricelevel = sqlite_datareader.GetFloat(5);
                returnData.Add(new BuySellItem(id, group, name, durability, quality, pricelevel));
            }
            return returnData;
        }
        public static void WriteBuySellItems(SQLiteConnection conn, List<BuySellItem> buySellItems)
        {
            SQLiteCommand sqlite_cmd;

            // empty table first
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "DELETE FROM ang_buysellitems";
            sqlite_cmd.ExecuteNonQuery();

            foreach (BuySellItem buySellItem in buySellItems)
            {
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = string.Format("INSERT INTO ang_buysellitems (id, buysellgroup, itemname, durability, quality, pricelevel) VALUES ({0},{1},'{2}',{3},{4},{5}); "
                    , buySellItem.id
                    , buySellItem.buySellGroup
                    , buySellItem.name
                    , buySellItem.durability
                    , buySellItem.quality
                    , buySellItem.priceLevel);
                sqlite_cmd.ExecuteNonQuery();
            }
        }
    }
}
