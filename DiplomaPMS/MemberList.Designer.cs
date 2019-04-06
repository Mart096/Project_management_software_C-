namespace DiplomaPMS
{
    partial class MemberList
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
            this.memberList1 = new System.Windows.Forms.ListView();
            this.fullnameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.globalMemberListID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.specialisation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memberDetails1 = new DiplomaPMS.MemberDetails();
            this.SuspendLayout();
            // 
            // memberList1
            // 
            this.memberList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memberList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fullnameColumn,
            this.idColumn,
            this.globalMemberListID,
            this.addDate,
            this.specialisation});
            this.memberList1.Location = new System.Drawing.Point(0, 0);
            this.memberList1.Name = "memberList1";
            this.memberList1.Size = new System.Drawing.Size(502, 305);
            this.memberList1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.memberList1.TabIndex = 4;
            this.memberList1.UseCompatibleStateImageBehavior = false;
            this.memberList1.View = System.Windows.Forms.View.Details;
            this.memberList1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnHeaderClick);
            this.memberList1.SelectedIndexChanged += new System.EventHandler(this.memberListSelectedIdChanged);
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
            // globalMemberListID
            // 
            this.globalMemberListID.Text = "Global list ID";
            this.globalMemberListID.Width = 77;
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
            // memberDetails1
            // 
            this.memberDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memberDetails1.AutoScroll = true;
            this.memberDetails1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memberDetails1.Location = new System.Drawing.Point(508, 0);
            this.memberDetails1.Name = "memberDetails1";
            this.memberDetails1.Size = new System.Drawing.Size(418, 305);
            this.memberDetails1.TabIndex = 5;
            // 
            // MemberList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.memberDetails1);
            this.Controls.Add(this.memberList1);
            this.Name = "MemberList";
            this.Size = new System.Drawing.Size(929, 305);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView memberList1;
        private System.Windows.Forms.ColumnHeader fullnameColumn;
        private System.Windows.Forms.ColumnHeader idColumn;
        private System.Windows.Forms.ColumnHeader addDate;
        private System.Windows.Forms.ColumnHeader specialisation;
        private System.Windows.Forms.ColumnHeader globalMemberListID;
        private MemberDetails memberDetails1;
    }
}
