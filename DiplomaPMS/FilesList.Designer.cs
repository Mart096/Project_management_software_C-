namespace DiplomaPMS
{
    partial class FilesList
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
            this.fileList1 = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // fileList1
            // 
            this.fileList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.fileDirectory});
            this.fileList1.Location = new System.Drawing.Point(3, 7);
            this.fileList1.MultiSelect = false;
            this.fileList1.Name = "fileList1";
            this.fileList1.Size = new System.Drawing.Size(664, 329);
            this.fileList1.TabIndex = 0;
            this.fileList1.UseCompatibleStateImageBehavior = false;
            this.fileList1.View = System.Windows.Forms.View.Details;
            this.fileList1.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
            // 
            // fileName
            // 
            this.fileName.Text = "File name";
            // 
            // fileDirectory
            // 
            this.fileDirectory.Text = "Directory";
            this.fileDirectory.Width = 65;
            // 
            // FilesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileList1);
            this.Name = "FilesList";
            this.Size = new System.Drawing.Size(670, 339);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView fileList1;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader fileDirectory;
    }
}
