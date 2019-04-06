namespace DiplomaPMS
{
    partial class ResourceList
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
            this.resourceList1 = new System.Windows.Forms.ListView();
            this.resourceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resourceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resourceQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.resourceDetQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.resourceNamelabel = new System.Windows.Forms.Label();
            this.resourceDetName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resourceDetDescription = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourceDetQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // resourceList1
            // 
            this.resourceList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.resourceName,
            this.resourceID,
            this.addDate,
            this.resourceQuantity});
            this.resourceList1.Location = new System.Drawing.Point(3, 3);
            this.resourceList1.Name = "resourceList1";
            this.resourceList1.Size = new System.Drawing.Size(503, 378);
            this.resourceList1.TabIndex = 1;
            this.resourceList1.UseCompatibleStateImageBehavior = false;
            this.resourceList1.View = System.Windows.Forms.View.Details;
            this.resourceList1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnHeaderClick);
            this.resourceList1.SelectedIndexChanged += new System.EventHandler(this.resourceListSelectedIdChanged);
            // 
            // resourceName
            // 
            this.resourceName.Text = "Name";
            this.resourceName.Width = 241;
            // 
            // resourceID
            // 
            this.resourceID.Text = "ID";
            // 
            // addDate
            // 
            this.addDate.Text = "Add date";
            this.addDate.Width = 87;
            // 
            // resourceQuantity
            // 
            this.resourceQuantity.Text = "Quantity";
            this.resourceQuantity.Width = 103;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.resourceDetQuantity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.resourceNamelabel);
            this.panel1.Controls.Add(this.resourceDetName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.resourceDetDescription);
            this.panel1.Location = new System.Drawing.Point(510, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 381);
            this.panel1.TabIndex = 65;
            // 
            // resourceDetQuantity
            // 
            this.resourceDetQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resourceDetQuantity.Location = new System.Drawing.Point(7, 75);
            this.resourceDetQuantity.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.resourceDetQuantity.Name = "resourceDetQuantity";
            this.resourceDetQuantity.ReadOnly = true;
            this.resourceDetQuantity.Size = new System.Drawing.Size(398, 26);
            this.resourceDetQuantity.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Quantity";
            // 
            // resourceNamelabel
            // 
            this.resourceNamelabel.AutoSize = true;
            this.resourceNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resourceNamelabel.Location = new System.Drawing.Point(3, 0);
            this.resourceNamelabel.Name = "resourceNamelabel";
            this.resourceNamelabel.Size = new System.Drawing.Size(51, 20);
            this.resourceNamelabel.TabIndex = 45;
            this.resourceNamelabel.Text = "Name";
            // 
            // resourceDetName
            // 
            this.resourceDetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resourceDetName.Location = new System.Drawing.Point(7, 23);
            this.resourceDetName.Name = "resourceDetName";
            this.resourceDetName.ReadOnly = true;
            this.resourceDetName.Size = new System.Drawing.Size(398, 26);
            this.resourceDetName.TabIndex = 2;
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
            // resourceDetDescription
            // 
            this.resourceDetDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resourceDetDescription.Location = new System.Drawing.Point(7, 127);
            this.resourceDetDescription.Multiline = true;
            this.resourceDetDescription.Name = "resourceDetDescription";
            this.resourceDetDescription.ReadOnly = true;
            this.resourceDetDescription.Size = new System.Drawing.Size(398, 237);
            this.resourceDetDescription.TabIndex = 4;
            // 
            // ResourceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resourceList1);
            this.Name = "ResourceList";
            this.Size = new System.Drawing.Size(948, 384);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourceDetQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView resourceList1;
        private System.Windows.Forms.ColumnHeader resourceName;
        private System.Windows.Forms.ColumnHeader resourceID;
        private System.Windows.Forms.ColumnHeader resourceQuantity;
        private System.Windows.Forms.ColumnHeader addDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown resourceDetQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label resourceNamelabel;
        private System.Windows.Forms.TextBox resourceDetName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox resourceDetDescription;
    }
}
