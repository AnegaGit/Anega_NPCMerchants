namespace Anega_NPCMerchants
{
    partial class EditGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGroup));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBoxBuy = new System.Windows.Forms.CheckBox();
            this.checkBoxSell = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownPriceLevel = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelIfSell = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriceLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(77, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(254, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // checkBoxBuy
            // 
            this.checkBoxBuy.AutoSize = true;
            this.checkBoxBuy.Enabled = false;
            this.checkBoxBuy.Location = new System.Drawing.Point(77, 35);
            this.checkBoxBuy.Name = "checkBoxBuy";
            this.checkBoxBuy.Size = new System.Drawing.Size(44, 17);
            this.checkBoxBuy.TabIndex = 4;
            this.checkBoxBuy.Text = "Buy";
            this.checkBoxBuy.UseVisualStyleBackColor = true;
            // 
            // checkBoxSell
            // 
            this.checkBoxSell.AutoSize = true;
            this.checkBoxSell.Enabled = false;
            this.checkBoxSell.Location = new System.Drawing.Point(127, 35);
            this.checkBoxSell.Name = "checkBoxSell";
            this.checkBoxSell.Size = new System.Drawing.Size(43, 17);
            this.checkBoxSell.TabIndex = 4;
            this.checkBoxSell.Text = "Sell";
            this.checkBoxSell.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Price level:";
            // 
            // numericUpDownPriceLevel
            // 
            this.numericUpDownPriceLevel.DecimalPlaces = 2;
            this.numericUpDownPriceLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPriceLevel.Location = new System.Drawing.Point(77, 58);
            this.numericUpDownPriceLevel.Name = "numericUpDownPriceLevel";
            this.numericUpDownPriceLevel.Size = new System.Drawing.Size(93, 20);
            this.numericUpDownPriceLevel.TabIndex = 6;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(15, 105);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(155, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(176, 105);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(155, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelIfSell
            // 
            this.labelIfSell.AutoSize = true;
            this.labelIfSell.Location = new System.Drawing.Point(175, 63);
            this.labelIfSell.Name = "labelIfSell";
            this.labelIfSell.Size = new System.Drawing.Size(67, 13);
            this.labelIfSell.TabIndex = 8;
            this.labelIfSell.Text = "if bouht only!";
            // 
            // EditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 140);
            this.ControlBox = false;
            this.Controls.Add(this.labelIfSell);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericUpDownPriceLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxSell);
            this.Controls.Add(this.checkBoxBuy);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Group";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriceLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.CheckBox checkBoxBuy;
        private System.Windows.Forms.CheckBox checkBoxSell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownPriceLevel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelIfSell;
    }
}