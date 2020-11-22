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
    public partial class EditItem : Form
    {
        private int iniQuality;
        private int iniDurability;
        private float iniPriceLevel;

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
        public bool valuesChanged
        {
            get { return (iniQuality != quality || iniDurability != durability || iniPriceLevel != priceLevel); }
        }

        public EditItem(string name, int basePrice, int quality, int durability, float priceLevel)
        {
            InitializeComponent();
            LabelItemName.Text = name;
            labelBasePrice.Text = string.Format("Base price: " + Global.PriceText(basePrice));

            ioQuality.Value = quality;
            iniQuality = quality;
            ioDurability.Value = durability;
            iniDurability = durability;
            ioPriceLevel.Value = (decimal)priceLevel;
            iniPriceLevel = priceLevel;
        }

    }
}
