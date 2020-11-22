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
    public partial class EditGroup : Form
    {
        private string _groupName ="";
        public string groupName
        {
            get { return _groupName; }
        }

        private bool _isBuy;
        public bool isBuy
        {
            get { return _isBuy; }
        }

        private float _priceLevel;
        public float priceLevel
        {
            get { return _priceLevel; }
        }

        public EditGroup(string groupName="", bool isBuy = true, float priceLevel = 1)
        {
            InitializeComponent();
            _groupName = groupName;
            _isBuy = isBuy;
            _priceLevel = priceLevel;

            textBoxName.Text = _groupName;
            checkBoxBuy.Checked = _isBuy;
            checkBoxSell.Checked = !isBuy;

            labelIfSell.Visible = !_isBuy;
            numericUpDownPriceLevel.Value = (decimal) _priceLevel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _groupName = textBoxName.Text;
            _priceLevel = (float)numericUpDownPriceLevel.Value;
        }
    }
}
