namespace Anega_NPCMerchants
{
    partial class EditItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditItem));
            this.LabelItemName = new System.Windows.Forms.Label();
            this.labelBasePrice = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ioDurability = new System.Windows.Forms.NumericUpDown();
            this.ioQuality = new System.Windows.Forms.NumericUpDown();
            this.ioPriceLevel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ioDurability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ioQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ioPriceLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelItemName
            // 
            this.LabelItemName.AutoSize = true;
            this.LabelItemName.Location = new System.Drawing.Point(12, 9);
            this.LabelItemName.Name = "LabelItemName";
            this.LabelItemName.Size = new System.Drawing.Size(79, 13);
            this.LabelItemName.TabIndex = 0;
            this.LabelItemName.Text = "item name here";
            // 
            // labelBasePrice
            // 
            this.labelBasePrice.AutoSize = true;
            this.labelBasePrice.Location = new System.Drawing.Point(12, 32);
            this.labelBasePrice.Name = "labelBasePrice";
            this.labelBasePrice.Size = new System.Drawing.Size(81, 13);
            this.labelBasePrice.TabIndex = 0;
            this.labelBasePrice.Text = "Base price here";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(124, 149);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 149);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 23);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Price Level:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Durability:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Quality:";
            // 
            // ioDurability
            // 
            this.ioDurability.Location = new System.Drawing.Point(81, 87);
            this.ioDurability.Name = "ioDurability";
            this.ioDurability.Size = new System.Drawing.Size(61, 20);
            this.ioDurability.TabIndex = 7;
            // 
            // ioQuality
            // 
            this.ioQuality.Location = new System.Drawing.Point(81, 61);
            this.ioQuality.Name = "ioQuality";
            this.ioQuality.Size = new System.Drawing.Size(61, 20);
            this.ioQuality.TabIndex = 8;
            // 
            // ioPriceLevel
            // 
            this.ioPriceLevel.DecimalPlaces = 2;
            this.ioPriceLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ioPriceLevel.Location = new System.Drawing.Point(81, 113);
            this.ioPriceLevel.Name = "ioPriceLevel";
            this.ioPriceLevel.Size = new System.Drawing.Size(61, 20);
            this.ioPriceLevel.TabIndex = 9;
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 184);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ioDurability);
            this.Controls.Add(this.ioQuality);
            this.Controls.Add(this.ioPriceLevel);
            this.Controls.Add(this.labelBasePrice);
            this.Controls.Add(this.LabelItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Item";
            ((System.ComponentModel.ISupportInitialize)(this.ioDurability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ioQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ioPriceLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelItemName;
        private System.Windows.Forms.Label labelBasePrice;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ioDurability;
        private System.Windows.Forms.NumericUpDown ioQuality;
        private System.Windows.Forms.NumericUpDown ioPriceLevel;
    }
}