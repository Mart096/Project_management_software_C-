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
    public partial class CreateRisk : Form
    {
        private string projdir;
        private string projname;

        public CreateRisk(string projectdir, string projectname)
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

                    var query1 = from c in doc.Element("Project").Element("Risks").Elements("Risk")
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

                    XElement new_risk = new XElement("Risk",
                                            new XElement("Id", indeks),
                                            new XElement("Risk_entry", entryDetName.Text),
                                            new XElement("Consequences", riskDetConsequences.Text),
                                            new XElement("Add_date", DateTime.Now.ToString("dd/MM/yyyy")),
                                            new XElement("Probability", riskDetProbability.Value.ToString()),
                                            new XElement("Impact", riskDetImpact.Value.ToString())
                                        );

                    try
                    {
                        doc.Element("Project").Element("Risks").Add(new_risk);
                        doc.Save(project);
                        this.Close();
                        break;
                    }
                    catch (Exception exceptionE)
                    {
                        ShowMessage(1, exceptionE);
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowMessage(int val, Exception e)
        {
            if (val == 1)
            {
                MessageBox.Show("Error occured during risk creation - " + e.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
