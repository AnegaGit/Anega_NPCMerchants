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
    public partial class EditAddItemBuy : Form
    {
        public EditAddItemBuy(List<string> itemList)
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
            if (itemList.Count == 0)
            {
                buttonOK.Enabled = false;
            }
        }
    }
}
