namespace DiplomaPMS
{
    partial class CreateResource
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
            this.reesourceQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.resourceNamelabel = new System.Windows.Forms.Label();
            this.resourceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resourceDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reesourceQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.reesourceQuantity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.resourceNamelabel);
            this.panel1.Controls.Add(this.resourceName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.resourceDescription);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 290);
            this.panel1.TabIndex = 64;
            // 
            // reesourceQuantity
            // 
            this.reesourceQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reesourceQuantity.Location = new System.Drawing.Point(7, 75);
            this.reesourceQuantity.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.reesourceQuantity.Minimum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            -2147483648});
            this.reesourceQuantity.Name = "reesourceQuantity";
            this.reesourceQuantity.Size = new System.Drawing.Size(398, 26);
            this.reesourceQuantity.TabIndex = 43;
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
            // resourceName
            // 
            this.resourceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resourceName.Location = new System.Drawing.Point(7, 23);
            this.resourceName.Name = "resourceName";
            this.resourceName.Size = new System.Drawing.Size(398, 26);
            this.resourceName.TabIndex = 42;
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
            // resourceDescription
            // 
            this.resourceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resourceDescription.Location = new System.Drawing.Point(7, 127);
            this.resourceDescription.Multiline = true;
            this.resourceDescription.Name = "resourceDescription";
            this.resourceDescription.Size = new System.Drawing.Size(398, 237);
            this.resourceDescription.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(254, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 17);
            this.label10.TabIndex = 63;
            this.label10.Text = "* - field required";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(127, 308);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 32);
            this.cancelButton.TabIndex = 62;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 308);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(109, 32);
            this.CreateButton.TabIndex = 61;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 349);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.CreateButton);
            this.MaximumSize = new System.Drawing.Size(475, 388);
            this.MinimumSize = new System.Drawing.Size(475, 388);
            this.Name = "CreateResource";
            this.Text = "CreateResource";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reesourceQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown reesourceQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label resourceNamelabel;
        private System.Windows.Forms.TextBox resourceName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox resourceDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button CreateButton;
    }
}