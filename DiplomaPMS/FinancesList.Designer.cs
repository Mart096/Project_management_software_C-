namespace DiplomaPMS
{
    partial class FinancesList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.projectTotalBudget = new System.Windows.Forms.NumericUpDown();
            this.financeList1 = new System.Windows.Forms.ListView();
            this.entryText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entryCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remainingBudget = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entryDetAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.entryName = new System.Windows.Forms.Label();
            this.entryDetName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.entryDetDescription = new System.Windows.Forms.TextBox();
            this.tasksTotalCost = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.projectTotalBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainingBudget)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryDetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTotalCost)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project budget";
            // 
            // projectTotalBudget
            // 
            this.projectTotalBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectTotalBudget.Location = new System.Drawing.Point(7, 23);
            this.projectTotalBudget.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.projectTotalBudget.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.projectTotalBudget.Name = "projectTotalBudget";
            this.projectTotalBudget.ReadOnly = true;
            this.projectTotalBudget.Size = new System.Drawing.Size(280, 26);
            this.projectTotalBudget.TabIndex = 2;
            // 
            // financeList1
            // 
            this.financeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.financeList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.entryText,
            this.entryID,
            this.addDate,
            this.entryCost});
            this.financeList1.Location = new System.Drawing.Point(7, 55);
            this.financeList1.Name = "financeList1";
            this.financeList1.Size = new System.Drawing.Size(527, 312);
            this.financeList1.TabIndex = 1;
            this.financeList1.UseCompatibleStateImageBehavior = false;
            this.financeList1.View = System.Windows.Forms.View.Details;
            this.financeList1.SelectedIndexChanged += new System.EventHandler(this.financeListSelectedIdChanged);
            // 
            // entryText
            // 
            this.entryText.Text = "Entry";
            this.entryText.Width = 244;
            // 
            // entryID
            // 
            this.entryID.Text = "ID";
            this.entryID.Width = 51;
            // 
            // addDate
            // 
            this.addDate.Text = "Add date";
            this.addDate.Width = 82;
            // 
            // entryCost
            // 
            this.entryCost.Text = "Cost";
            this.entryCost.Width = 143;
            // 
            // remainingBudget
            // 
            this.remainingBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.remainingBudget.Location = new System.Drawing.Point(540, 23);
            this.remainingBudget.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.remainingBudget.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.remainingBudget.Name = "remainingBudget";
            this.remainingBudget.ReadOnly = true;
            this.remainingBudget.Size = new System.Drawing.Size(237, 26);
            this.remainingBudget.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(536, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Remaining budget";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.entryDetAmount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.entryName);
            this.panel1.Controls.Add(this.entryDetName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.entryDetDescription);
            this.panel1.Location = new System.Drawing.Point(540, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 312);
            this.panel1.TabIndex = 61;
            // 
            // entryDetAmount
            // 
            this.entryDetAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryDetAmount.Location = new System.Drawing.Point(7, 75);
            this.entryDetAmount.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.entryDetAmount.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.entryDetAmount.Name = "entryDetAmount";
            this.entryDetAmount.ReadOnly = true;
            this.entryDetAmount.Size = new System.Drawing.Size(387, 26);
            this.entryDetAmount.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "Amount";
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
            // entryDetName
            // 
            this.entryDetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryDetName.Location = new System.Drawing.Point(7, 23);
            this.entryDetName.Name = "entryDetName";
            this.entryDetName.ReadOnly = true;
            this.entryDetName.Size = new System.Drawing.Size(387, 26);
            this.entryDetName.TabIndex = 5;
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
            // entryDetDescription
            // 
            this.entryDetDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryDetDescription.Location = new System.Drawing.Point(7, 127);
            this.entryDetDescription.Multiline = true;
            this.entryDetDescription.Name = "entryDetDescription";
            this.entryDetDescription.ReadOnly = true;
            this.entryDetDescription.Size = new System.Drawing.Size(388, 237);
            this.entryDetDescription.TabIndex = 7;
            // 
            // tasksTotalCost
            // 
            this.tasksTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tasksTotalCost.Location = new System.Drawing.Point(297, 23);
            this.tasksTotalCost.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.tasksTotalCost.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.tasksTotalCost.Name = "tasksTotalCost";
            this.tasksTotalCost.ReadOnly = true;
            this.tasksTotalCost.Size = new System.Drawing.Size(237, 26);
            this.tasksTotalCost.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(293, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Tasks\' total cost";
            // 
            // FinancesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tasksTotalCost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.remainingBudget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.financeList1);
            this.Controls.Add(this.projectTotalBudget);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(580, 260);
            this.Name = "FinancesList";
            this.Size = new System.Drawing.Size(968, 370);
            ((System.ComponentModel.ISupportInitialize)(this.projectTotalBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainingBudget)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryDetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTotalCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown projectTotalBudget;
        private System.Windows.Forms.ListView financeList1;
        private System.Windows.Forms.ColumnHeader entryText;
        private System.Windows.Forms.ColumnHeader entryID;
        private System.Windows.Forms.ColumnHeader entryCost;
        private System.Windows.Forms.NumericUpDown remainingBudget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader addDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown entryDetAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label entryName;
        private System.Windows.Forms.TextBox entryDetName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox entryDetDescription;
        private System.Windows.Forms.NumericUpDown tasksTotalCost;
        private System.Windows.Forms.Label label5;
    }
}
