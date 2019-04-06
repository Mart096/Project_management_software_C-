namespace DiplomaPMS
{
    partial class ProjectList
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.workspaceDir_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.create_new_button = new System.Windows.Forms.Button();
            this.customerColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.projectList1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.projectDetDuration = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.duplicateProjectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.budgetValue)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // budgetValue
            // 
            this.budgetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.budgetValue.Location = new System.Drawing.Point(3, 611);
            this.budgetValue.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.budgetValue.Name = "budgetValue";
            this.budgetValue.ReadOnly = true;
            this.budgetValue.Size = new System.Drawing.Size(269, 26);
            this.budgetValue.TabIndex = 21;
            // 
            // customerEmail
            // 
            this.customerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerEmail.Location = new System.Drawing.Point(3, 507);
            this.customerEmail.Name = "customerEmail";
            this.customerEmail.ReadOnly = true;
            this.customerEmail.Size = new System.Drawing.Size(387, 26);
            this.customerEmail.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(-1, 484);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Customer\'s e-mail";
            // 
            // customersTelephone
            // 
            this.customersTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customersTelephone.Location = new System.Drawing.Point(3, 559);
            this.customersTelephone.Mask = "(+00) 000 00 00 00";
            this.customersTelephone.Name = "customersTelephone";
            this.customersTelephone.ReadOnly = true;
            this.customersTelephone.Size = new System.Drawing.Size(387, 26);
            this.customersTelephone.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(-1, 536);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Customer\'s telephone";
            // 
            // customerAddress
            // 
            this.customerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerAddress.Location = new System.Drawing.Point(3, 455);
            this.customerAddress.Name = "customerAddress";
            this.customerAddress.ReadOnly = true;
            this.customerAddress.Size = new System.Drawing.Size(387, 26);
            this.customerAddress.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(-1, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Customer\'s address";
            // 
            // customerName
            // 
            this.customerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerName.Location = new System.Drawing.Point(3, 403);
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            this.customerName.Size = new System.Drawing.Size(387, 26);
            this.customerName.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(-1, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 27;
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
            this.description.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(-1, 588);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Budget";
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endDate.Location = new System.Drawing.Point(131, 75);
            this.endDate.Mask = "00/00/0000";
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            this.endDate.Size = new System.Drawing.Size(105, 26);
            this.endDate.TabIndex = 14;
            this.endDate.ValidatingType = typeof(System.DateTime);
            // 
            // startDate
            // 
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startDate.Location = new System.Drawing.Point(7, 75);
            this.startDate.Mask = "00/00/0000";
            this.startDate.Name = "startDate";
            this.startDate.ReadOnly = true;
            this.startDate.Size = new System.Drawing.Size(105, 26);
            this.startDate.TabIndex = 13;
            this.startDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(127, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "End date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Start date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name";
            // 
            // projectName
            // 
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectName.Location = new System.Drawing.Point(7, 23);
            this.projectName.Name = "projectName";
            this.projectName.ReadOnly = true;
            this.projectName.Size = new System.Drawing.Size(387, 26);
            this.projectName.TabIndex = 12;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(511, 157);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 29);
            this.deleteButton.TabIndex = 36;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(511, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 34);
            this.button1.TabIndex = 38;
            this.button1.Text = "Change directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.changedir_button_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Enabled = false;
            this.loadButton.Location = new System.Drawing.Point(511, 122);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(102, 29);
            this.loadButton.TabIndex = 35;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Project list";
            // 
            // workspaceDir_textbox
            // 
            this.workspaceDir_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workspaceDir_textbox.Location = new System.Drawing.Point(7, 382);
            this.workspaceDir_textbox.Name = "workspaceDir_textbox";
            this.workspaceDir_textbox.Size = new System.Drawing.Size(498, 20);
            this.workspaceDir_textbox.TabIndex = 37;
            this.workspaceDir_textbox.Click += new System.EventHandler(this.workspaceTextBox_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Workspace directory";
            // 
            // create_new_button
            // 
            this.create_new_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.create_new_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.create_new_button.Location = new System.Drawing.Point(511, 23);
            this.create_new_button.Name = "create_new_button";
            this.create_new_button.Size = new System.Drawing.Size(102, 29);
            this.create_new_button.TabIndex = 33;
            this.create_new_button.Text = "Create new";
            this.create_new_button.UseVisualStyleBackColor = true;
            this.create_new_button.Click += new System.EventHandler(this.create_new_button_Click);
            // 
            // customerColumn
            // 
            this.customerColumn.Text = "Customer";
            this.customerColumn.Width = 111;
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 58;
            // 
            // endDateColumn
            // 
            this.endDateColumn.Text = "End date";
            this.endDateColumn.Width = 68;
            // 
            // startDateColumn
            // 
            this.startDateColumn.Text = "Start date";
            this.startDateColumn.Width = 74;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Project name";
            this.nameColumn.Width = 118;
            // 
            // projectList1
            // 
            this.projectList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.startDateColumn,
            this.endDateColumn,
            this.statusColumn,
            this.customerColumn});
            this.projectList1.Location = new System.Drawing.Point(7, 23);
            this.projectList1.MultiSelect = false;
            this.projectList1.Name = "projectList1";
            this.projectList1.Size = new System.Drawing.Size(498, 340);
            this.projectList1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.projectList1.TabIndex = 32;
            this.projectList1.UseCompatibleStateImageBehavior = false;
            this.projectList1.View = System.Windows.Forms.View.Details;
            this.projectList1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnHeaderClick);
            this.projectList1.SelectedIndexChanged += new System.EventHandler(this.ProjectListIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.projectDetDuration);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.budgetValue);
            this.panel1.Controls.Add(this.customerEmail);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.customersTelephone);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.customerAddress);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.customerName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.description);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.endDate);
            this.panel1.Controls.Add(this.startDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.projectName);
            this.panel1.Location = new System.Drawing.Point(619, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 379);
            this.panel1.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(248, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "Duration (days)";
            // 
            // projectDetDuration
            // 
            this.projectDetDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectDetDuration.Location = new System.Drawing.Point(252, 75);
            this.projectDetDuration.Name = "projectDetDuration";
            this.projectDetDuration.ReadOnly = true;
            this.projectDetDuration.Size = new System.Drawing.Size(143, 26);
            this.projectDetDuration.TabIndex = 15;
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
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // duplicateProjectButton
            // 
            this.duplicateProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateProjectButton.Enabled = false;
            this.duplicateProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.duplicateProjectButton.Location = new System.Drawing.Point(511, 59);
            this.duplicateProjectButton.Name = "duplicateProjectButton";
            this.duplicateProjectButton.Size = new System.Drawing.Size(102, 57);
            this.duplicateProjectButton.TabIndex = 34;
            this.duplicateProjectButton.Text = "Create new using existing project";
            this.duplicateProjectButton.UseVisualStyleBackColor = true;
            this.duplicateProjectButton.Click += new System.EventHandler(this.duplicateProjectButton_Click);
            // 
            // ProjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.duplicateProjectButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workspaceDir_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.create_new_button);
            this.Controls.Add(this.projectList1);
            this.Controls.Add(this.panel1);
            this.Name = "ProjectList";
            this.Size = new System.Drawing.Size(1070, 410);
            ((System.ComponentModel.ISupportInitialize)(this.budgetValue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox workspaceDir_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button create_new_button;
        private System.Windows.Forms.ColumnHeader customerColumn;
        private System.Windows.Forms.ColumnHeader statusColumn;
        private System.Windows.Forms.ColumnHeader endDateColumn;
        private System.Windows.Forms.ColumnHeader startDateColumn;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ListView projectList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox projectDetDuration;
        private System.Windows.Forms.Button duplicateProjectButton;
    }
}
