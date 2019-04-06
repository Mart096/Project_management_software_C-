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
    public partial class CreateResource : Form
    {
        private string projdir;
        private string projname;

        public CreateResource(string projectdir, string projectname)
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

                    var query1 = from c in doc.Element("Project").Element("Resources").Elements("Resource")
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

                    XElement new_resource = new XElement("Resource",
                                                new XElement("Id", indeks),
                                                new XElement("Name", resourceName.Text),
                                                new XElement("Quantity", reesourceQuantity.Value.ToString()),
                                                new XElement("Add_date", DateTime.Now.ToString("dd/MM/yyyy")),
                                                new XElement("Description", resourceDescription.Text)
                                        );

                    try
                    {
                        doc.Element("Project").Element("Resources").Add(new_resource);
                        doc.Save(project);
                        this.Close();
                        //ShowMessage(1);//MessageBox.Show("Project was saved successfully!", "Information");
                        break;
                    }
                    catch (Exception exceptionDescrp)
                    {
                        ShowMessage(1, exceptionDescrp);// MessageBox.Show("Error occured during project creation. Project was NOT saved!", "Warning!");
                    }
                }
                /*else
                {
                    ShowMessage(3);//MessageBox.Show("Project with this name already exists! Change project\'s name to something else.", "Warning!");
                }*/
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowMessage(int val, Exception e) 
        {
            if (val == 1) 
            {
                MessageBox.Show("Error occured during resource creation - " + e.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
