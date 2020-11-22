using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Anega_NPCMerchants
{
    public partial class MainForm : Form
    {

        public SQLiteConnection sqlite_conn;

        public List<ItemInfo> itemInfos = new List<ItemInfo>();
        public List<MerchantInfo> merchantInfos = new List<MerchantInfo>();
        public List<BuySellGroup> buySellGroups = new List<BuySellGroup>();
        public List<BuySellItem> buySellItems = new List<BuySellItem>();

        bool isEdited;

        public MainForm()
        {
            InitializeComponent();
            textBoxDatabase.Enabled = false;
        }

        //Read / write data
        private void OpenFileDb()
        {
            openDatabaseDialog.FileName = "";
            if (openDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                ReadDataFromDb(openDatabaseDialog.FileName);
            }
        }

        private void ReadDataFromDb(string fileName)
        {
            sqlite_conn = Database.CreateConnection(fileName);
            textBoxDatabase.Text = (fileName);
            textBoxDatabase.Enabled = true;

            itemInfos = Database.ReadItemInfos(sqlite_conn);
            ItemTableUpdate();
            merchantInfos = Database.ReadMerchantInfos(sqlite_conn);
            buySellGroups = Database.ReadBuySellGroups(sqlite_conn);
            buySellItems = Database.ReadBuySellItems(sqlite_conn);

            RebuildTree();
            sqlite_conn.Close();

            toolStripStatusLabel.Text = string.Format("Database loaded: {0} Items; {1} NPC with {2} items in {3} groups"
                , itemInfos.Count, merchantInfos.Count, buySellItems.Count, buySellGroups.Count);
            statusStrip.Refresh();
            isEdited = false;
        }

        private void SaveAsFileDb()
        {
            openDatabaseDialog.FileName = textBoxDatabase.Text;
            if (openDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                WriteDataToDb(openDatabaseDialog.FileName);
            }
        }
        private void WriteDataToDb(string fileName)
        {
            sqlite_conn = Database.CreateConnection(fileName);
            textBoxDatabase.Text = (fileName);
            textBoxDatabase.Enabled = true;

            Database.WriteBuySellGroups(sqlite_conn, buySellGroups);
            Database.WriteBuySellItems(sqlite_conn, buySellItems);

            sqlite_conn.Close();

            toolStripStatusLabel.Text = string.Format("Data saved to data base: {0} Items; {1} NPC with {2} items in {3} groups"
                , itemInfos.Count, merchantInfos.Count, buySellItems.Count, buySellGroups.Count);
            statusStrip.Refresh();
            isEdited = false;
        }

        //treeViewOrganization
        private void RebuildTree()
        {
            int snLevel = -1;
            string snName = "";
            string snParentName = "";
            if (treeViewTrade.SelectedNode != null)
            {
                snLevel = treeViewTrade.SelectedNode.Level;
                snName = treeViewTrade.SelectedNode.Name;
                if (snLevel > 0)
                {
                    snParentName = treeViewTrade.SelectedNode.Parent.Name;
                }
                else
                {
                    snParentName = "";
                }
            }

            treeViewTrade.Nodes.Clear();

            // sort the lists
            buySellGroups = buySellGroups.OrderBy(x => x.isBuy).ThenBy(x => x.sort).ToList();
            buySellItems = buySellItems.OrderBy(x => x.name).ToList();

            foreach (MerchantInfo merchant in merchantInfos)
            {
                TreeNode merchantNode = new TreeNode("");
                merchantNode.Name = merchant.name;
                merchantNode.Text = merchant.name + (merchant.buyallsellitems ? "  (buy all sold items)" : "  (don't sell all bought items");
                merchantNode.Tag = NodeLevel.Merchant;
                treeViewTrade.Nodes.Add(merchantNode);

                for (int buy = 1; buy >= 0; buy--)
                {
                    TreeNode buyNode = new TreeNode((buy == 1 ? "buy" : "sell"));
                    buyNode.Tag = NodeLevel.BuySell;
                    buyNode.Name = buy.ToString();
                    buyNode.ContextMenuStrip = contextMenuBuySell;
                    treeViewTrade.SelectedNode = merchantNode;
                    treeViewTrade.SelectedNode.Nodes.Add(buyNode);

                    foreach (BuySellGroup group in buySellGroups)
                    {
                        if (group.merchant == merchant.name && group.isBuy == (buy == 1))
                        {
                            TreeNode groupNode = new TreeNode("");
                            groupNode.Name = group.id.ToString();
                            groupNode.Text = string.Format("{0}", group.name);
                            groupNode.ToolTipText = string.Format("{0}", (group.isBuy ? "Price level:" + group.priceLevel.ToString() : ""));
                            groupNode.Tag = NodeLevel.Group;
                            groupNode.ContextMenuStrip = contextMenuGroup;
                            treeViewTrade.SelectedNode = buyNode;
                            treeViewTrade.SelectedNode.Nodes.Add(groupNode);

                            foreach (BuySellItem item in buySellItems)
                            {
                                if (item.buySellGroup == group.id)
                                {
                                    TreeNode itemNode = new TreeNode("");
                                    itemNode.Name = item.id.ToString();
                                    itemNode.Text = item.name;
                                    if (!group.isBuy)
                                    {
                                        itemNode.ToolTipText = string.Format("Quality: {0}" + Environment.NewLine + "Durability:{1}" + Environment.NewLine + "Price level: {2}", item.quality, item.durability, item.priceLevel);
                                        itemNode.ContextMenuStrip = contextMenuItemSell;
                                    }
                                    else
                                    {
                                        itemNode.ContextMenuStrip = contextMenuItemBuy;
                                    }
                                    itemNode.Tag = NodeLevel.Item;
                                    treeViewTrade.SelectedNode = groupNode;
                                    treeViewTrade.SelectedNode.Nodes.Add(itemNode);
                                }
                            }
                        }
                    }
                }
            }

            foreach (TreeNode node in treeViewTrade.Nodes)
            {
                if (FindLastActiveNode(node, snLevel, snName, snParentName))
                {
                    break;
                }
            }

            TreeNode lastSelected = treeViewTrade.SelectedNode;
            treeViewTrade.CollapseAll();
            if (lastSelected != null)
            {
                treeViewTrade.SelectedNode = lastSelected;
                treeViewTrade.SelectedNode.Expand();
            }

        }
        private bool FindLastActiveNode(TreeNode node, int level, string name, string parentName)
        {
            string nodeParent = "";
            if (node.Level > 0)
            {
                nodeParent = node.Parent.Name;
            }
            if ((node.Level == level && node.Name == name && nodeParent == parentName) || level == -1)
            {
                treeViewTrade.SelectedNode = node;
                return true;
            }
            else
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (FindLastActiveNode(childNode, level, name, parentName))
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        private void treeViewTrade_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBoxNodeInfo.Text = "";
            TreeNode currentNode = treeViewTrade.SelectedNode;
            if (currentNode.Tag.Equals(NodeLevel.Item))
            {
                string newText = currentNode.Text;
                BuySellItem item = buySellItems.Find(x => x.id == Convert.ToInt32(currentNode.Name));
                BuySellGroup parentGroup = buySellGroups.Find(x => x.id == Convert.ToInt32(currentNode.Parent.Name));
                if (!parentGroup.isBuy)
                {
                    newText += string.Format(" :: Quality: {0}, Durability: {1}, Price level: {2}"
                        , item.quality
                        , item.durability
                        , item.priceLevel);
                }
                textBoxNodeInfo.Text = Environment.NewLine + newText;
                currentNode = currentNode.Parent;
            }
            if (currentNode.Tag.Equals(NodeLevel.Group))
            {
                string newText = "";
                BuySellGroup currentGroup = buySellGroups.Find(x => x.id == Convert.ToInt32(currentNode.Name));
                MerchantInfo currentMerchant = merchantInfos.Find(x => x.name == currentNode.Parent.Parent.Name);

                if (currentGroup.isBuy)
                {
                    newText = string.Format("{0} (buy with price level {1})", currentGroup.name, currentGroup.priceLevel);
                }
                else if(currentMerchant.buyallsellitems)
                {
                    newText = string.Format("{0} (sell, buy with price level {1})", currentGroup.name, currentGroup.priceLevel);
                }
                else
                {
                    newText = string.Format("{0} (sell only)", currentGroup.name);
                }
                textBoxNodeInfo.Text = Environment.NewLine + newText + textBoxNodeInfo.Text;
                currentNode = currentNode.Parent;
            }
            if (currentNode.Tag.Equals(NodeLevel.BuySell))
            {
                currentNode = currentNode.Parent;
            }
            if (currentNode.Tag.Equals(NodeLevel.Merchant))
            {
                string newText = string.Format("{0}", currentNode.Name);
                MerchantInfo currentMerchant = merchantInfos.Find(x => x.name == currentNode.Name);
                if (currentMerchant.buyallsellitems)
                {
                    newText += "  (buy all sold items as well)";
                }
                textBoxNodeInfo.Text = newText + textBoxNodeInfo.Text;
            }
        }

        private void ItemTableUpdate()
        {
            dataGridViewItems.Rows.Clear();
            foreach (ItemInfo item in itemInfos)
            {
                if (filterItem.Text == "" || item.name.IndexOf(filterItem.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridViewItems);
                    newRow.Cells[0].Value = item.name;
                    newRow.Cells[1].Value = Global.PriceText(item.price);
                    dataGridViewItems.Rows.Add(newRow);
                }
            }
        }

        // context Menue Group
        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;

            EditGroup editDialog = new EditGroup("new", clickedNode.Name == "1");
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                int maxId = buySellGroups.Max(x => x.id);
                BuySellGroup newGroup = new BuySellGroup(maxId + 1, editDialog.groupName, clickedNode.Parent.Name, 9999, editDialog.isBuy, editDialog.priceLevel);
                buySellGroups.Add(newGroup);
                ResortGroup(clickedNode);
                RebuildTree();
                toolStripStatusLabel.Text = string.Format("Group {0} added", newGroup.name);
                statusStrip.Refresh();
                isEdited = true;
            }
        }

        private void editGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;

            BuySellGroup group = buySellGroups.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            EditGroup editDialog = new EditGroup(group.name, group.isBuy, group.priceLevel);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                if (editDialog.groupName != group.name || editDialog.priceLevel != group.priceLevel)
                {
                    group.name = editDialog.groupName;
                    group.priceLevel = editDialog.priceLevel;
                    RebuildTree();
                    toolStripStatusLabel.Text = string.Format("Group {0} edited", group.name);
                    statusStrip.Refresh();
                    isEdited = true;
                }
            }
        }

        private void deleteGroupWillAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            TreeNode clickedNode = treeViewTrade.SelectedNode;
            treeViewTrade.SelectedNode = treeViewTrade.SelectedNode.Parent;
            foreach (BuySellItem itemToRemove in buySellItems.Where(x => x.buySellGroup == Convert.ToInt32(clickedNode.Name)).ToList<BuySellItem>())
            {
                buySellItems.Remove(itemToRemove);
                iCount++;
            }
            BuySellGroup groupToRemove = buySellGroups.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            toolStripStatusLabel.Text = string.Format("Group {0} with {1} items removed", groupToRemove.name, iCount);
            buySellGroups.Remove(groupToRemove);
            RebuildTree();
            statusStrip.Refresh();
            isEdited = true;
        }

        //resort groups
        private void firstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;

            BuySellGroup currentGroup = buySellGroups.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            currentGroup.sort = 0;
            ResortGroup(clickedNode.Parent);
            RebuildTree();
        }
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;

            BuySellGroup currentGroup = buySellGroups.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            currentGroup.sort -= 3;
            ResortGroup(clickedNode.Parent);
            RebuildTree();
        }
        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;

            BuySellGroup currentGroup = buySellGroups.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            currentGroup.sort += 3;
            ResortGroup(clickedNode.Parent);
            RebuildTree();
        }
        private void lastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;

            BuySellGroup currentGroup = buySellGroups.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            currentGroup.sort = 9999;
            ResortGroup(clickedNode.Parent);
            RebuildTree();
        }
        private void ResortGroup(TreeNode node)
        {
            int iSort = 1;
            foreach (BuySellGroup group in buySellGroups.Where(x => x.merchant == node.Parent.Name).Where(x => x.isBuy == (node.Name == "1")).OrderBy(x => x.sort))
            {
                group.sort = iSort;
                iSort += 2;
            }
            isEdited = true;
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;
            List<string> itemList = new List<string>();
            foreach (DataGridViewRow row in dataGridViewItems.SelectedRows)
            {
                itemList.Add(row.Cells[0].Value.ToString());
            }

            if (clickedNode.Parent.Name == "1")
            {
                // buy this items(s)
                EditAddItemBuy editDialog = new EditAddItemBuy(itemList);
                if (editDialog.ShowDialog() == DialogResult.OK)
                {
                    int maxId = buySellItems.Max(x => x.id);
                    foreach (string item in itemList)
                    {
                        maxId++;
                        buySellItems.Add(new BuySellItem(maxId, Convert.ToInt32(clickedNode.Name), item, 100, 100, 1));
                    }
                    RebuildTree();
                    toolStripStatusLabel.Text = string.Format("{0} items added", itemList.Count);
                    statusStrip.Refresh();
                    isEdited = true;
                }
            }
            else
            {
                // sell this item(s)
                EditAddItemSell editDialog = new EditAddItemSell(itemList, 33, 66, 1);
                if (editDialog.ShowDialog() == DialogResult.OK)
                {
                    int maxId = buySellItems.Max(x => x.id);
                    foreach (string item in itemList)
                    {
                        maxId++;
                        buySellItems.Add(new BuySellItem(maxId, Convert.ToInt32(clickedNode.Name), item, editDialog.quality, editDialog.durability, editDialog.priceLevel));
                    }
                    RebuildTree();
                    toolStripStatusLabel.Text = string.Format("{0} items added", itemList.Count);
                    statusStrip.Refresh();
                    isEdited = true;
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;
            treeViewTrade.SelectedNode = treeViewTrade.SelectedNode.Parent;
            BuySellItem itemToRemove = buySellItems.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            toolStripStatusLabel.Text = string.Format("{0} removed", itemToRemove.name);
            buySellItems.Remove(itemToRemove);
            RebuildTree();
            statusStrip.Refresh();
            isEdited = true;
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode clickedNode = treeViewTrade.SelectedNode;
            BuySellItem itemToEdit = buySellItems.Find(x => x.id == Convert.ToInt32(clickedNode.Name));
            ItemInfo itemInfo = itemInfos.Find(x => x.name == itemToEdit.name);
            EditItem editDialog = new EditItem(itemToEdit.name, itemInfo.price, itemToEdit.quality, itemToEdit.durability, itemToEdit.priceLevel);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                if (editDialog.valuesChanged)
                {
                    itemToEdit.quality = editDialog.quality;
                    itemToEdit.durability = editDialog.durability;
                    itemToEdit.priceLevel = editDialog.priceLevel;
                    RebuildTree();
                    toolStripStatusLabel.Text = string.Format("{0} edited", itemToEdit.name);
                    statusStrip.Refresh();
                    isEdited = true;
                }
            }
        }

        //  Context Menue basics
        private void treeViewTrade_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // only need to change selected note during right-click - otherwise tree does fine by itself
            if (e.Button == MouseButtons.Right)
            {
                Point pt = new Point(e.X, e.Y);
                treeViewTrade.PointToClient(pt);

                TreeNode Node = treeViewTrade.GetNodeAt(pt);
                if (Node != null)
                {
                    if (Node.Bounds.Contains(pt))
                    {
                        treeViewTrade.SelectedNode = Node;
                    }
                }
            }
        }

        //Main Menue
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDb();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxDatabase.Enabled)
            {
                WriteDataToDb(textBoxDatabase.Text);
            }
            else
            {
                toolStripStatusLabel.Text = "Warning: No data base selected!";
                statusStrip.Refresh();
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxDatabase.Enabled)
            {
                SaveAsFileDb();
            }
            else
            {
                toolStripStatusLabel.Text = "Warning: No data available!";
                statusStrip.Refresh();
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox dialogMessage = new AboutBox();
            dialogMessage.ShowDialog();
        }

        // global
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isEdited)
            {
                EndSaveDialog dialogMessage = new EndSaveDialog();
                DialogResult result = dialogMessage.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    SaveAsFileDb();
                }
            }
        }

        //filter context menue
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterItem.Text = "";
            ItemTableUpdate();
        }
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemTableUpdate();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            ItemTableUpdate();
        }
        private void filterItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                ItemTableUpdate();
            }
        }
    }
}
