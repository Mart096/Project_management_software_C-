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
    public partial class FinancesList : UserControl
    {
        private string projdir = null;
        private string projname = null;
        private string currentID = null;
        public event EventHandler<CustomEventArgs> ListItemSelected;

        public FinancesList()
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
            decimal totalcost = 0;
            tasksTotalCost.Value = 0;
            financeList1.Items.Clear();

            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    var currPName = (from xml in doc.Element("Project").Descendants("Project_details")
                                     select xml.Element("Name").Value).First();

                    if (currPName == projname)
                    {
                        var totalbudgetval = Convert.ToDecimal((from xml in doc.Element("Project").Descendants("Project_details")
                                                              select xml.Element("Budget").Value).First());
                        var tasksquery = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                         select result;

                        foreach (var task in tasksquery) 
                        {
                            tasksTotalCost.Value += Convert.ToDecimal(task.Element("Budget").Value);
                        }

                        projectTotalBudget.Value = totalbudgetval;
                        remainingBudget.Value = totalbudgetval;
                        var query = from result in doc.Element("Project").Element("Finances").Element("Costs").Elements("Entry")
                                    select result;
                        totalcost += tasksTotalCost.Value;

                        if (query.Count() != 0)
                        {

                            string Id;
                            string entryname;
                            string amount;
                            string adddate;
                            //string description;

                            foreach (var fv in query)
                            {
                                Id = fv.Element("Id").Value;
                                entryname = fv.Element("Name").Value;
                                amount = fv.Element("Amount").Value;
                                adddate = fv.Element("Add_date").Value;
                                //description = fv.Element("Description").Value;
                                totalcost += Convert.ToDecimal(amount);

                                List<string> row2 = new List<string>();
                                row2.Add(entryname); row2.Add(Id); row2.Add(adddate);  row2.Add(amount);
                                string[] r2 = { row2[1], row2[2], row2[3] };
                                financeList1.Items.Add(row2[0]).SubItems.AddRange(r2);
                            }
                            //totalcost+=tasksTotalCost.Value;
                            //remainingBudget.Value = projectTotalBudget.Value - totalcost;
                            //break;
                        }
                        remainingBudget.Value = projectTotalBudget.Value - totalcost;
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

        public void CreateNewMember()
        {
            CreateFinance createFform = new CreateFinance(this.projdir, this.projname);
            createFform.ShowDialog();
            createFform.Tag = this;
            Populate_list();
        }

        private void ColumnHeaderClick(object sender, ColumnClickEventArgs e)
        {
            this.financeList1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show("Column header clicked!");
        }

        public void EditModeSwitch(int val)
        {
            if (val == 1)
            {
                this.financeList1.Enabled = false;
                this.entryDetName.ReadOnly = false ;
                this.entryDetAmount.ReadOnly = false;
                this.entryDetDescription.ReadOnly = false;
            }
            else if (val == 0)
            {
                this.financeList1.Enabled = true;
                this.entryDetName.ReadOnly = true;
                this.entryDetAmount.ReadOnly = true;
                this.entryDetDescription.ReadOnly = true;
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
                        var query1 = from result in doc.Element("Project").Element("Finances").Element("Costs").Elements("Entry")
                                     select result;

                        foreach (var query in query1)
                        {
                            if (query.Element("Id").Value == this.currentID)
                            {
                                query.Element("Name").Value = this.entryDetName.Text;
                                query.Element("Amount").Value = this.entryDetAmount.Text;
                                query.Element("Description").Value = this.entryDetDescription.Text;
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

        public void DeleteFinanceEntry()
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
                            var query1 = from result in doc.Element("Project").Element("Finances").Element("Costs").Elements("Entry")
                                         select result;

                            foreach (var query in query1)
                            {
                                if (query.Element("Id").Value == this.currentID)
                                {  
                                    query.Remove();
                                    doc.Save(project);
                                    this.financeList1.SelectedItems.Clear();
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

        private void financeListSelectedIdChanged(object sender, EventArgs e)
        {
            if (this.financeList1.SelectedItems.Count != 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(0));
                this.currentID = null;

            }
            else if (this.financeList1.SelectedItems.Count == 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(1));

                //Sprawdzanie indeksu zaznaczonego zadania
                int i = 0;
                int max = this.financeList1.Items.Count;

                while (i < max)//this.memberList1.Size.Height)
                {
                    if (this.financeList1.Items[i].Selected == true)
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
                        var query = from result in doc.Element("Project").Element("Finances").Element("Costs").Elements("Entry")
                                    select result;

                        foreach (var fv in query)
                        {
                            if (fv.Element("Name").Value == this.financeList1.Items[i].Text)
                            {
                                this.currentID = fv.Element("Id").Value;
                                this.entryDetName.Text = fv.Element("Name").Value;
                                this.entryDetAmount.Value = Convert.ToDecimal(fv.Element("Amount").Value);
                                this.entryDetDescription.Text = fv.Element("Description").Value;
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
                MessageBox.Show("Failed to load finaces data - directory not found", "Warning!");
            }
            else if (val == 1)
            {
                MessageBox.Show("Failed to load finances data - XML error related", "Warning!");
            }
            else if (val == 2)
            {
                MessageBox.Show("Failed to load finances data - " + e.Message, "Warning!");
            }
        }

        public DialogResult ShowMessageWResult(int val)
        {
            if (val == 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this entry?", "Delete finance entry!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }


    }
}
