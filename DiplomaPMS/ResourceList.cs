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
    public partial class ResourceList : UserControl
    {
        private string projdir = null;
        private string projname = null;
        private string currentID = null;
        public event EventHandler<CustomEventArgs> ListItemSelected;

        public ResourceList()
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
            resourceList1.Items.Clear();

            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    var currPName = (from xml in doc.Element("Project").Descendants("Project_details")
                                     select xml.Element("Name").Value).First();

                    if (currPName == projname)
                    {
                        var query = from result in doc.Element("Project").Element("Resources").Elements("Resource")
                                    select result;

                        if (query.Count() != 0)
                        {

                            string Id;
                            string resourcename;
                            string quantity;
                            string adddate;
                            //string description;

                            foreach (var fv in query)
                            {
                                Id = fv.Element("Id").Value;
                                resourcename = fv.Element("Name").Value;
                                quantity = fv.Element("Quantity").Value;
                                adddate = fv.Element("Add_date").Value;

                                List<string> row2 = new List<string>();
                                row2.Add(resourcename); row2.Add(Id); row2.Add(adddate); row2.Add(quantity);
                                string[] r2 = { row2[1], row2[2], row2[3] };
                                resourceList1.Items.Add(row2[0]).SubItems.AddRange(r2);
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

        public void CreateNewResource()
        {
            CreateResource createRform = new CreateResource(this.projdir, this.projname);
            createRform.ShowDialog();
            createRform.Tag = this;
            Populate_list();
        }

        private void ColumnHeaderClick(object sender, ColumnClickEventArgs e)
        {
            this.resourceList1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show("Column header clicked!");
        }

        public void EditModeSwitch(int val)
        {
            if (val == 1)
            {
                this.resourceList1.Enabled = false;
                this.resourceDetName.ReadOnly = false;
                this.resourceDetQuantity.ReadOnly = false;
                this.resourceDetDescription.ReadOnly = false;
            }
            else if (val == 0)
            {
                this.resourceList1.Enabled = true;
                this.resourceDetName.ReadOnly = true;
                this.resourceDetQuantity.ReadOnly = true;
                this.resourceDetDescription.ReadOnly = true;
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
                        var query1 = from result in doc.Element("Project").Element("Resources").Elements("Resource")
                                     select result;

                        foreach (var query in query1)
                        {
                            if (query.Element("Id").Value == this.currentID)
                            {
                                query.Element("Name").Value = this.resourceDetName.Text;
                                query.Element("Quantity").Value = this.resourceDetQuantity.Value.ToString();
                                query.Element("Description").Value = this.resourceDetDescription.Text;
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

        public void DeleteResource()
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
                            var query1 = from result in doc.Element("Project").Element("Resources").Elements("Resource")
                                         select result;

                            foreach (var query in query1)
                            {
                                if (query.Element("Id").Value == this.currentID)
                                {
                                    query.Remove();
                                    doc.Save(project);
                                    this.resourceList1.SelectedItems.Clear();
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

        private void resourceListSelectedIdChanged(object sender, EventArgs e)
        {
            if (this.resourceList1.SelectedItems.Count != 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(0));
                this.currentID = null;

            }
            else if (this.resourceList1.SelectedItems.Count == 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(1));

                //Sprawdzanie indeksu zaznaczonego zadania
                int i = 0;
                int max = this.resourceList1.Items.Count;

                while (i < max)//this.memberList1.Size.Height)
                {
                    if (this.resourceList1.Items[i].Selected == true)
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
                        var query = from result in doc.Element("Project").Element("Resources").Elements("Resource")
                                    select result;

                        foreach (var fv in query)
                        {
                            if (fv.Element("Name").Value == this.resourceList1.Items[i].Text)
                            {
                                this.currentID = fv.Element("Id").Value;
                                this.resourceDetName.Text = fv.Element("Name").Value;
                                this.resourceDetQuantity.Value = Convert.ToDecimal(fv.Element("Quantity").Value);
                                this.resourceDetDescription.Text = fv.Element("Description").Value;
                                break;
                            }
                        }
                    }
                }
            }
        }


        public void ShowMessage(int val, Exception e)
        {
            if (val == 0)
            {
                MessageBox.Show("Failed to load resources - directory not found", "Warning!");
            }
            else if (val == 1)
            {
                MessageBox.Show("Failed to load resources - XML error related", "Warning!");
            }
            else if (val == 2)
            {
                MessageBox.Show("Failed to load resources - " + e.Message, "Warning!");
            }
        }

        public DialogResult ShowMessageWResult(int val)
        {
            if (val == 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this resource?", "Delete resource!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }
    }
}
