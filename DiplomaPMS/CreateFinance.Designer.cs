namespace DiplomaPMS
{
    partial class CreateFinance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.entryAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.entryName = new System.Windows.Forms.Label();
            this.financeEntryName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.entryDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.entryAmount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.entryName);
            this.panel1.Controls.Add(this.financeEntryName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.entryDescription);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 290);
            this.panel1.TabIndex = 60;
            // 
            // entryAmount
            // 
            this.entryAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryAmount.Location = new System.Drawing.Point(7, 75);
            this.entryAmount.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.entryAmount.Minimum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            -2147483648});
            this.entryAmount.Name = "entryAmount";
            this.entryAmount.Size = new System.Drawing.Size(387, 26);
            this.entryAmount.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Amount";
            // 
            // entryName
            // 
            this.entryName.AutoSize = true;
            this.entryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryName.Location = new System.Drawing.Point(3, 0);
            this.entryName.Name = "entryName";
            this.entryName.Size = new System.Drawing.Size(46, 20);
            this.entryName.TabIndex = 45;
            this.entryName.Text = "Entry";
            // 
            // financeEntryName
            // 
            this.financeEntryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.financeEntryName.Location = new System.Drawing.Point(7, 23);
            this.financeEntryName.Name = "financeEntryName";
            this.financeEntryName.Size = new System.Drawing.Size(387, 26);
            this.financeEntryName.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "Description";
            // 
            // entryDescription
            // 
            this.entryDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryDescription.Location = new System.Drawing.Point(7, 127);
            this.entryDescription.Multiline = true;
            this.entryDescription.Name = "entryDescription";
            this.entryDescription.Size = new System.Drawing.Size(388, 237);
            this.entryDescription.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(245, 309);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 17);
            this.label10.TabIndex = 59;
            this.label10.Text = "* - field required";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(118, 309);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 32);
            this.cancelButton.TabIndex = 58;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 309);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(100, 32);
            this.CreateButton.TabIndex = 57;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 353);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.CreateButton);
            this.MaximumSize = new System.Drawing.Size(458, 392);
            this.MinimumSize = new System.Drawing.Size(458, 392);
            this.Name = "CreateFinance";
            this.Text = "Create new entry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label entryName;
        private System.Windows.Forms.TextBox financeEntryName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox entryDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown entryAmount;

    }
}