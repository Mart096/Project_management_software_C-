using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DiplomaPMS
{
    public partial class CreateFinance : Form
    {
        /*public CreateFinance()
        {
            InitializeComponent();
        }*/

        private string projdir;
        private string projname;

        public CreateFinance(string projectdir, string projectname)
        {
            InitializeComponent();
            this.projdir = projectdir;
            this.projname = projectname;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
            {
                XDocument doc = XDocument.Load(project);

                string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                              select qr.Element("Name").Value).First();

                //Czy to ten projekt?
                if (this.projname == tpn)
                {

                    var query1 = from c in doc.Element("Project").Element("Finances").Element("Costs").Elements("Entry")
                                 select c;

                    int indeks = 0;
                    int id_temp;
                    foreach (var elem in query1)
                    {
                        id_temp = Convert.ToInt32(elem.Element("Id").Value);
                        if (indeks <= id_temp)
                        {
                            indeks = id_temp + 1;
                        }

                    }

                    XElement new_entry = new XElement("Entry",
                                            new XElement("Id", indeks),
                                            new XElement("Name", financeEntryName.Text),
                                            new XElement("Amount", entryAmount.Value.ToString()),
                                            new XElement("Add_date", DateTime.Now.ToString("dd/MM/yyyy")),
                                            new XElement("Description", entryDescription.Text)
                                        );

                    try
                    {
                        doc.Element("Project").Element("Finances").Element("Costs").Add(new_entry);
                        doc.Save(project);
                        this.Close();
                        //ShowMessage(0);
                        break;
                    }
                    catch (Exception)
                    {
                        ShowMessage(1);
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowMessage(int val)
        {
            if (val == 0) 
            {
                MessageBox.Show("Risk entry was saved successfully!", "Information");
            }
            if (val == 1)
            {
                MessageBox.Show("Error occured during entry creation. Risk entry was NOT saved!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
