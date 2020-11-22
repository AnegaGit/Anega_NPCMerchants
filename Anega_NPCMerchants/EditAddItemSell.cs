using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anega_NPCMerchants
{
    public partial class EditAddItemSell : Form
    {
        public int quality
        {
            get { return (int)ioQuality.Value; }
        }
        public int durability
        {
            get { return (int)ioDurability.Value; }
        }
        public float priceLevel
        {
            get { return (float)ioPriceLevel.Value; }
        }

        public EditAddItemSell(List<string> itemList,int quality, int durability, float priceLevel)
        {
            InitializeComponent();
            foreach (string item in itemList)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridViewItems);
                newRow.Cells[0].Value = item;
                dataGridViewItems.Rows.Add(newRow);
            }
            itemCountText.Text = itemList.Count.ToString() + " items in list";
            ioQuality.Value = quality;
            ioDurability.Value = durability;
            ioPriceLevel.Value = (decimal)priceLevel;
            if (itemList.Count == 0)
            {
                buttonOK.Enabled = false;
                ioQuality.Enabled = false;
                ioDurability.Enabled = false;
                ioPriceLevel.Enabled = false;
            }
        }
    }
}
