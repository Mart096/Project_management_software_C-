using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DiplomaPMS
{
    public partial class LicenseRead : UserControl
    {
        public LicenseRead()
        {
            InitializeComponent();
            this.Visible = false;
        }

        public void ReadLicenseFromFile(string path)
        {
            this.Visible = true;
            try
            {
                string lcontent = File.ReadAllText(path);
                licenseContent.Text = lcontent;
            }
            catch 
            {
                this.Visible = false;
                MessageBox.Show("License file missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
