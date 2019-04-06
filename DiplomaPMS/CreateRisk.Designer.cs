namespace DiplomaPMS
{
    partial class CreateRisk
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
            this.riskDetImpact = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.riskDetProbability = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.entryName = new System.Windows.Forms.Label();
            this.entryDetName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.riskDetConsequences = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.riskDetImpact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riskDetProbability)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.riskDetImpact);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.riskDetProbability);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.entryName);
            this.panel1.Controls.Add(this.entryDetName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.riskDetConsequences);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 322);
            this.panel1.TabIndex = 63;
            // 
            // riskDetImpact
            // 
            this.riskDetImpact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.riskDetImpact.Location = new System.Drawing.Point(197, 279);
            this.riskDetImpact.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.riskDetImpact.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.riskDetImpact.Name = "riskDetImpact";
            this.riskDetImpact.Size = new System.Drawing.Size(180, 26);
            this.riskDetImpact.TabIndex = 45;
            this.riskDetImpact.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(193, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Impact (1 - 5)";
            // 
            // riskDetProbability
            // 
            this.riskDetProbability.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.riskDetProbability.Location = new System.Drawing.Point(7, 279);
            this.riskDetProbability.Name = "riskDetProbability";
            this.riskDetProbability.Size = new System.Drawing.Size(180, 26);
            this.riskDetProbability.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "Probability %";
            // 
            // entryName
            // 
            this.entryName.AutoSize = true;
            this.entryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryName.Location = new System.Drawing.Point(3, 0);
            this.entryName.Name = "entryName";
            this.entryName.Size = new System.Drawing.Size(40, 20);
            this.entryName.TabIndex = 45;
            this.entryName.Text = "Risk";
            // 
            // entryDetName
            // 
            this.entryDetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryDetName.Location = new System.Drawing.Point(7, 23);
            this.entryDetName.Multiline = true;
            this.entryDetName.Name = "entryDetName";
            this.entryDetName.Size = new System.Drawing.Size(387, 99);
            this.entryDetName.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Consequences";
            // 
            // riskDetConsequences
            // 
            this.riskDetConsequences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.riskDetConsequences.Location = new System.Drawing.Point(7, 148);
            this.riskDetConsequences.Multiline = true;
            this.riskDetConsequences.Name = "riskDetConsequences";
            this.riskDetConsequences.Size = new System.Drawing.Size(387, 105);
            this.riskDetConsequences.TabIndex = 43;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(127, 340);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 32);
            this.cancelButton.TabIndex = 47;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 340);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(109, 32);
            this.CreateButton.TabIndex = 46;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateRisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 417);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(462, 456);
            this.MinimumSize = new System.Drawing.Size(462, 456);
            this.Name = "CreateRisk";
            this.Text = "CreateRisk";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.riskDetImpact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riskDetProbability)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown riskDetImpact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown riskDetProbability;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label entryName;
        private System.Windows.Forms.TextBox entryDetName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox riskDetConsequences;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button CreateButton;
    }
}