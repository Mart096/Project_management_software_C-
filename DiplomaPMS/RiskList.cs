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
using System.Xml;
using System.Xml.Linq;

namespace DiplomaPMS
{
    public partial class RiskList : UserControl
    {
        private string projdir = null;
        private string projname = null;
        private string currentID = null;
        public event EventHandler<CustomEventArgs> ListItemSelected;

        public RiskList()
        {
            InitializeComponent();
        }

        public void Pass_data(string projectname, string projectdir) 
        {
            this.projdir = projectdir; 
            this.projname = projectname;
        }

        public void Populate_list() 
        {
            riskList1.Items.Clear();

            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    var currPName = (from xml in doc.Element("Project").Descendants("Project_details")
                                     select xml.Element("Name").Value).First();

                    if (currPName == projname)
                    {

                        var query = from result in doc.Element("Project").Element("Risks").Elements("Risk")
                                    select result;

                        if (query.Count() != 0)
                        {

                            string Id;
                            string riskentry;
                            string consequence;
                            string addDate;
                            int rProbability;
                            int rImpact;
                            string rPriority;


                            foreach (var fv in query)
                            {
                                Id = fv.Element("Id").Value;
                                riskentry = fv.Element("Risk_entry").Value;
                                consequence= fv.Element("Consequences").Value;
                                addDate = fv.Element("Add_date").Value;
                                rProbability = Convert.ToInt32(fv.Element("Probability").Value);
                                rImpact = Convert.ToInt32(fv.Element("Impact").Value);
                                rPriority = Convert.ToString(rProbability*rImpact);

                                List<string> row2 = new List<string>();
                                row2.Add(riskentry); row2.Add(consequence); row2.Add(Id); row2.Add(addDate); row2.Add(rProbability.ToString()); row2.Add(rImpact.ToString()); row2.Add(rPriority);
                                string[] r2 = { row2[1], row2[2], row2[3], row2[4], row2[5], row2[6] };
                                riskList1.Items.Add(row2[0]).SubItems.AddRange(r2);
                            }
                            break;
                        }
                        break;
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                ShowMessage(0, null);
            }
            catch (XmlException)
            {
                ShowMessage(1, null);
            }
            catch (Exception e)
            {
                ShowMessage(2, e);
            }
        }

        public void CreateNewRisk()
        {
            CreateRisk createRform = new CreateRisk(this.projdir, this.projname);
            createRform.ShowDialog();
            createRform.Tag = this;
            Populate_list();
        }

        private void ColumnHeaderClick(object sender, ColumnClickEventArgs e)
        {
            this.riskList1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show("Column header clicked!");
        }

        public void EditModeSwitch(int val)
        {
            if(val == 1)
            { 
                this.riskList1.Enabled = false;
                this.entryDetName.ReadOnly = false;
                this.riskDetConsequences.ReadOnly = false;
                this.riskDetProbability.ReadOnly = false;
                this.riskDetImpact.ReadOnly = false;
            }
            else if (val == 0) 
            {
                this.riskList1.Enabled = true;
                this.entryDetName.ReadOnly = true;
                this.riskDetConsequences.ReadOnly = true;
                this.riskDetProbability.ReadOnly = true;
                this.riskDetImpact.ReadOnly = true;
            }
        }

        public void SaveChanges() 
        {
            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                                  select qr.Element("Name").Value).First();

                    if (this.projname == tpn)
                    {
                        var query1 = from result in doc.Element("Project").Element("Risks").Elements("Risk")
                                     select result;

                        foreach (var query in query1)
                        {
                            if (query.Element("Id").Value == this.currentID)
                            {
                                query.Element("Risk_entry").Value = this.entryDetName.Text;
                                query.Element("Consequences").Value = this.riskDetConsequences.Text;
                                query.Element("Probability").Value = this.riskDetProbability.Value.ToString();
                                query.Element("Impact").Value = this.riskDetImpact.Value.ToString();
                                doc.Save(project);
                                //this.currentID = null;
                                Populate_list();
                                break;
                            }
                        }
                    }
                }
            }
            catch (XmlException e) { ShowMessage(0, e); }
            catch (Exception e) { ShowMessage(1, e); }
        }

        public void DeleteRisk()
        {
            if (ShowMessageWResult(0) == DialogResult.Yes)
            {

                try
                {
                    foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                    {
                        XDocument doc = XDocument.Load(project);

                        string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                                      select qr.Element("Name").Value).First();

                        if (this.projname == tpn)
                        {
                            var query1 = from result in doc.Element("Project").Element("Risks").Elements("Risk")
                                         select result;

                            foreach (var query in query1)
                            {
                                if (query.Element("Id").Value == this.currentID)
                                {
                                    query.Remove();
                                    doc.Save(project);
                                    this.riskList1.SelectedItems.Clear();
                                    this.currentID = null;
                                }
                            }
                            Populate_list();
                            break;
                        }
                    }
                }
                catch (XmlException e) { ShowMessage(0, e); }
                catch (Exception e) { ShowMessage(1, e); }
            }
        }

        private void riskListSelectedIdChanged(object sender, EventArgs e)
        {
            if (this.riskList1.SelectedItems.Count != 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(0));
                this.currentID = null;

            }
            else if (this.riskList1.SelectedItems.Count == 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(1));
                
                //Sprawdzanie indeksu zaznaczonego zadania
                int i = 0;
                int max = this.riskList1.Items.Count;

                while (i < max)
                {
                    if (this.riskList1.Items[i].Selected == true)
                    {
                        break;
                    }
                    i += 1;
                }

                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                                  select qr.Element("Name").Value).First();

                    //Czy to ten projekt?
                    if (this.projname == tpn)
                    {
                        var query = from result in doc.Element("Project").Element("Risks").Elements("Risk")
                                    select result;

                        foreach (var fv in query)
                        {
                            if (fv.Element("Id").Value == this.riskList1.Items[i].SubItems[2].Text)
                            {
                                this.currentID = fv.Element("Id").Value;
                                this.entryDetName.Text = fv.Element("Risk_entry").Value;
                                this.riskDetConsequences.Text = fv.Element("Consequences").Value;
                                this.riskDetProbability.Value = Convert.ToInt32(fv.Element("Probability").Value);
                                this.riskDetImpact.Value = Convert.ToInt32(fv.Element("Impact").Value);
                                break;
                            }
                        }
                    }
                }
                //}
            }
            else
            {
                /*this.loadButton.Enabled = false;
                this.deleteButton.Enabled = false;*/


            }
        }

        public void ShowMessage(int val, Exception e)
        {
            if (val == 0)
            {
                MessageBox.Show("Failed to load risks - directory not found", "Warning!");
            }
            else if (val == 1)
            {
                MessageBox.Show("Failed to load risks - XML error related", "Warning!");
            }
            else if (val == 2)
            {
                MessageBox.Show("Failed to load risks - " + e.Message, "Warning!");
            }
        }

        public DialogResult ShowMessageWResult(int val)
        {
            if (val == 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this risk?", "Delete risk!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }
    }
}
