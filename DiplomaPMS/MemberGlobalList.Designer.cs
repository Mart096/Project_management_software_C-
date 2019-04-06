namespace DiplomaPMS
{
    partial class MemberGlobalList
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
            this.memberGlobalList1 = new System.Windows.Forms.ListView();
            this.fullnameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.specialisation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memberDeleteButton = new System.Windows.Forms.Button();
            this.memberDetCancelEditButton = new System.Windows.Forms.Button();
            this.memberDetSaveChangesButton = new System.Windows.Forms.Button();
            this.editMemberButton = new System.Windows.Forms.Button();
            this.CreateNewMemberButton = new System.Windows.Forms.Button();
            this.addToProjectButton = new System.Windows.Forms.Button();
            this.memberDetails1 = new DiplomaPMS.MemberDetails();
            this.SuspendLayout();
            // 
            // memberGlobalList1
            // 
            this.memberGlobalList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memberGlobalList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memberGlobalList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fullnameColumn,
            this.idColumn,
            this.addDate,
            this.specialisation});
            this.memberGlobalList1.Location = new System.Drawing.Point(12, 12);
            this.memberGlobalList1.Name = "memberGlobalList1";
            this.memberGlobalList1.Size = new System.Drawing.Size(536, 400);
            this.memberGlobalList1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.memberGlobalList1.TabIndex = 6;
            this.memberGlobalList1.UseCompatibleStateImageBehavior = false;
            this.memberGlobalList1.View = System.Windows.Forms.View.Details;
            this.memberGlobalList1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnHeaderClick);
            this.memberGlobalList1.SelectedIndexChanged += new System.EventHandler(this.memberListSelectedIdChanged);
            // 
            // fullnameColumn
            // 
            this.fullnameColumn.Text = "Full name";
            this.fullnameColumn.Width = 185;
            // 
            // idColumn
            // 
            this.idColumn.Text = "ID";
            this.idColumn.Width = 45;
            // 
            // addDate
            // 
            this.addDate.Text = "Add date";
            this.addDate.Width = 70;
            // 
            // specialisation
            // 
            this.specialisation.Text = "Specialisation";
            this.specialisation.Width = 97;
            // 
            // memberDeleteButton
            // 
            this.memberDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.memberDeleteButton.Enabled = false;
            this.memberDeleteButton.Location = new System.Drawing.Point(554, 97);
            this.memberDeleteButton.Name = "memberDeleteButton";
            this.memberDeleteButton.Size = new System.Drawing.Size(115, 29);
            this.memberDeleteButton.TabIndex = 16;
            this.memberDeleteButton.Text = "Delete";
            this.memberDeleteButton.UseVisualStyleBackColor = true;
            this.memberDeleteButton.Click += new System.EventHandler(this.memberDeleteButton_Click);
            // 
            // memberDetCancelEditButton
            // 
            this.memberDetCancelEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.memberDetCancelEditButton.Location = new System.Drawing.Point(618, 47);
            this.memberDetCancelEditButton.Name = "memberDetCancelEditButton";
            this.memberDetCancelEditButton.Size = new System.Drawing.Size(50, 44);
            this.memberDetCancelEditButton.TabIndex = 15;
            this.memberDetCancelEditButton.Text = "Cancel";
            this.memberDetCancelEditButton.UseVisualStyleBackColor = true;
            this.memberDetCancelEditButton.Visible = false;
            this.memberDetCancelEditButton.Click += new System.EventHandler(this.memberDetCancelEditButton_Click);
            // 
            // memberDetSaveChangesButton
            // 
            this.memberDetSaveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.memberDetSaveChangesButton.Location = new System.Drawing.Point(554, 47);
            this.memberDetSaveChangesButton.Name = "memberDetSaveChangesButton";
            this.memberDetSaveChangesButton.Size = new System.Drawing.Size(61, 44);
            this.memberDetSaveChangesButton.TabIndex = 14;
            this.memberDetSaveChangesButton.Text = "Save changes";
            this.memberDetSaveChangesButton.UseVisualStyleBackColor = true;
            this.memberDetSaveChangesButton.Visible = false;
            this.memberDetSaveChangesButton.Click += new System.EventHandler(this.memberDetSaveChangesButton_Click);
            // 
            // editMemberButton
            // 
            this.editMemberButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editMemberButton.Enabled = false;
            this.editMemberButton.Location = new System.Drawing.Point(553, 47);
            this.editMemberButton.Name = "editMemberButton";
            this.editMemberButton.Size = new System.Drawing.Size(115, 44);
            this.editMemberButton.TabIndex = 13;
            this.editMemberButton.Text = "Edit";
            this.editMemberButton.UseVisualStyleBackColor = true;
            this.editMemberButton.Click += new System.EventHandler(this.editMemberButton_Click);
            // 
            // CreateNewMemberButton
            // 
            this.CreateNewMemberButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateNewMemberButton.Location = new System.Drawing.Point(554, 12);
            this.CreateNewMemberButton.Name = "CreateNewMemberButton";
            this.CreateNewMemberButton.Size = new System.Drawing.Size(115, 29);
            this.CreateNewMemberButton.TabIndex = 11;
            this.CreateNewMemberButton.Text = "Create new member";
            this.CreateNewMemberButton.UseVisualStyleBackColor = true;
            this.CreateNewMemberButton.Click += new System.EventHandler(this.CreateNewMember);
            // 
            // addToProjectButton
            // 
            this.addToProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addToProjectButton.Enabled = false;
            this.addToProjectButton.Location = new System.Drawing.Point(554, 12);
            this.addToProjectButton.Name = "addToProjectButton";
            this.addToProjectButton.Size = new System.Drawing.Size(115, 42);
            this.addToProjectButton.TabIndex = 17;
            this.addToProjectButton.Text = "Add to current project";
            this.addToProjectButton.UseVisualStyleBackColor = true;
            this.addToProjectButton.Visible = false;
            this.addToProjectButton.Click += new System.EventHandler(this.AddMemberToProject);
            // 
            // memberDetails1
            // 
            this.memberDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memberDetails1.AutoScroll = true;
            this.memberDetails1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memberDetails1.Location = new System.Drawing.Point(677, 12);
            this.memberDetails1.Name = "memberDetails1";
            this.memberDetails1.Size = new System.Drawing.Size(417, 400);
            this.memberDetails1.TabIndex = 7;
            // 
            // MemberGlobalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 424);
            this.Controls.Add(this.memberDeleteButton);
            this.Controls.Add(this.memberDetCancelEditButton);
            this.Controls.Add(this.memberDetSaveChangesButton);
            this.Controls.Add(this.editMemberButton);
            this.Controls.Add(this.CreateNewMemberButton);
            this.Controls.Add(this.memberDetails1);
            this.Controls.Add(this.memberGlobalList1);
            this.Controls.Add(this.addToProjectButton);
            this.MinimizeBox = false;
            this.Name = "MemberGlobalList";
            this.Text = "Members\' global list";
            this.ResumeLayout(false);

        }

        #endregion

        private MemberDetails memberDetails1;
        private System.Windows.Forms.ListView memberGlobalList1;
        private System.Windows.Forms.ColumnHeader fullnameColumn;
        private System.Windows.Forms.ColumnHeader idColumn;
        private System.Windows.Forms.ColumnHeader addDate;
        private System.Windows.Forms.ColumnHeader specialisation;
        private System.Windows.Forms.Button memberDeleteButton;
        private System.Windows.Forms.Button memberDetCancelEditButton;
        private System.Windows.Forms.Button memberDetSaveChangesButton;
        private System.Windows.Forms.Button editMemberButton;
        private System.Windows.Forms.Button CreateNewMemberButton;
        private System.Windows.Forms.Button addToProjectButton;
    }
}