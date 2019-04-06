namespace DiplomaPMS
{
    partial class ProjectDetails
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
            this.label11 = new System.Windows.Forms.Label();
            this.budgetValue = new System.Windows.Forms.NumericUpDown();
            this.customerEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.customersTelephone = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.customerAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.MaskedTextBox();
            this.startDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.ListBox();
            this.projectStatus = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.budgetValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(3, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 41;
            this.label11.Text = "Description";
            // 
            // budgetValue
            // 
            this.budgetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.budgetValue.Location = new System.Drawing.Point(7, 611);
            this.budgetValue.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.budgetValue.Name = "budgetValue";
            this.budgetValue.ReadOnly = true;
            this.budgetValue.Size = new System.Drawing.Size(269, 26);
            this.budgetValue.TabIndex = 50;
            // 
            // customerEmail
            // 
            this.customerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerEmail.Location = new System.Drawing.Point(7, 507);
            this.customerEmail.Name = "customerEmail";
            this.customerEmail.ReadOnly = true;
            this.customerEmail.Size = new System.Drawing.Size(387, 26);
            this.customerEmail.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(3, 484);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 56;
            this.label9.Text = "Customer\'s e-mail";
            // 
            // customersTelephone
            // 
            this.customersTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customersTelephone.Location = new System.Drawing.Point(7, 559);
            this.customersTelephone.Mask = "(+00) 000 00 00 00";
            this.customersTelephone.Name = "customersTelephone";
            this.customersTelephone.ReadOnly = true;
            this.customersTelephone.Size = new System.Drawing.Size(387, 26);
            this.customersTelephone.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(3, 536);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 20);
            this.label8.TabIndex = 54;
            this.label8.Text = "Customer\'s telephone";
            // 
            // customerAddress
            // 
            this.customerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerAddress.Location = new System.Drawing.Point(7, 455);
            this.customerAddress.Name = "customerAddress";
            this.customerAddress.ReadOnly = true;
            this.customerAddress.Size = new System.Drawing.Size(387, 26);
            this.customerAddress.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 20);
            this.label7.TabIndex = 52;
            this.label7.Text = "Customer\'s address";
            // 
            // customerName
            // 
            this.customerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerName.Location = new System.Drawing.Point(7, 403);
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            this.customerName.Size = new System.Drawing.Size(387, 26);
            this.customerName.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 50;
            this.label6.Text = "Customer\'s full name";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.description.Location = new System.Drawing.Point(7, 127);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.description.Size = new System.Drawing.Size(388, 250);
            this.description.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(3, 588);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 48;
            this.label10.Text = "Budget";
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endDate.Location = new System.Drawing.Point(141, 75);
            this.endDate.Mask = "00/00/0000";
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            this.endDate.Size = new System.Drawing.Size(105, 26);
            this.endDate.TabIndex = 44;
            this.endDate.ValidatingType = typeof(System.DateTime);
            this.endDate.Leave += new System.EventHandler(this.EndDateInput_Leave);
            // 
            // startDate
            // 
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startDate.Location = new System.Drawing.Point(7, 75);
            this.startDate.Mask = "00/00/0000";
            this.startDate.Name = "startDate";
            this.startDate.ReadOnly = true;
            this.startDate.Size = new System.Drawing.Size(105, 26);
            this.startDate.TabIndex = 43;
            this.startDate.ValidatingType = typeof(System.DateTime);
            this.startDate.Leave += new System.EventHandler(this.StartDateInput_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(137, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "End date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Start date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "Name";
            // 
            // projectName
            // 
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectName.Location = new System.Drawing.Point(7, 23);
            this.projectName.Name = "projectName";
            this.projectName.ReadOnly = true;
            this.projectName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.projectName.Size = new System.Drawing.Size(387, 26);
            this.projectName.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 640);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "Status";
            // 
            // statusBox
            // 
            this.statusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusBox.FormattingEnabled = true;
            this.statusBox.ItemHeight = 20;
            this.statusBox.Items.AddRange(new object[] {
            "New",
            "In progress",
            "On hold",
            "Complete"});
            this.statusBox.Location = new System.Drawing.Point(202, 661);
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollAlwaysVisible = true;
            this.statusBox.Size = new System.Drawing.Size(143, 24);
            this.statusBox.TabIndex = 52;
            this.statusBox.Visible = false;
            // 
            // projectStatus
            // 
            this.projectStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectStatus.Location = new System.Drawing.Point(7, 662);
            this.projectStatus.Name = "projectStatus";
            this.projectStatus.ReadOnly = true;
            this.projectStatus.Size = new System.Drawing.Size(189, 26);
            this.projectStatus.TabIndex = 51;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(0, 104);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 62;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.calendar_Leave);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(132, 104);
            this.monthCalendar2.MaxSelectionCount = 1;
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 63;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendar2_DateSelected);
            this.monthCalendar2.Leave += new System.EventHandler(this.calendar_Leave);
            // 
            // ProjectDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.projectStatus);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.budgetValue);
            this.Controls.Add(this.customerEmail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.customersTelephone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.customerAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.projectName);
            this.Controls.Add(this.label11);
            this.Name = "ProjectDetails";
            this.Size = new System.Drawing.Size(381, 430);
            ((System.ComponentModel.ISupportInitialize)(this.budgetValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown budgetValue;
        private System.Windows.Forms.TextBox customerEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox customersTelephone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox customerAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox endDate;
        private System.Windows.Forms.MaskedTextBox startDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox statusBox;
        private System.Windows.Forms.TextBox projectStatus;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
    }
}
