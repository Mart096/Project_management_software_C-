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
    public partial class MemberList : UserControl
    {
        private string projdir = null;
        private string projname = null;
        private string currentID = null;
        public event EventHandler<CustomEventArgs> ListItemSelected;
        

        public MemberList()
        {
            InitializeComponent();
            memberDetails1.SwitchFieldsReadOnly(1);
        }

        public void Pass_data(string projectname, string projectdir) 
        {
            this.projdir = projectdir; 
            this.projname = projectname;
        }

        public void Populate_list() 
        {
            memberList1.Items.Clear();

            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    var currPName = (from xml in doc.Element("Project").Descendants("Project_details")
                                     select xml.Element("Name").Value).First();

                    if (currPName == projname)
                    {

                        var query = from result in doc.Element("Project").Element("Members").Elements("Member")
                                    select result;

                        if (query.Count() != 0)
                        {

                            string Id;
                            string globalId;
                            string firstName;
                            string lastName;
                            string birthDate;
                            string addDate;
                            string specialisation;


                            foreach (var fv in query)
                            {
                                Id = fv.Element("Id").Value;
                                globalId = fv.Element("Global_id").Value;
                                firstName = fv.Element("First_name").Value;
                                lastName = fv.Element("Last_name").Value;
                                birthDate = fv.Element("Birth_date").Value;
                                addDate = fv.Element("Add_date").Value;
                                specialisation = fv.Element("Specialisation").Value;

                                List<string> row2 = new List<string>();
                                row2.Add(lastName + " " + firstName); row2.Add(Id); row2.Add(globalId); row2.Add(addDate); row2.Add(specialisation);
                                string[] r2 = { row2[1], row2[2], row2[3], row2[4] };
                                memberList1.Items.Add(row2[0]).SubItems.AddRange(r2);
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

        public void CreateNewMember()
        {
            CreateMember createMform = new CreateMember(this.projdir, this.projname);
            createMform.ShowDialog();
            createMform.Tag = this;
            Populate_list();
        }

        private void ColumnHeaderClick(object sender, ColumnClickEventArgs e)
        {
            this.memberList1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show("Column header clicked!");
        }

        public void EditModeSwitch(int val)
        {
            if(val == 1)
            { 
                this.memberList1.Enabled = false;
                this.memberDetails1.SwitchFieldsReadOnly(0);
            }
            else if (val == 0) 
            {
                this.memberList1.Enabled = true;
                this.memberDetails1.SwitchFieldsReadOnly(1);
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
                        var query1 = from result in doc.Element("Project").Element("Members").Elements("Member")
                                     select result;

                        foreach (var query in query1)
                        {
                            if (query.Element("Id").Value == this.currentID)
                            {
                                query.Element("First_name").Value = this.memberDetails1.firstName.Text;
                                query.Element("Last_name").Value = this.memberDetails1.lastName.Text;
                                query.Element("Specialisation").Value = this.memberDetails1.specialisation.Text;
                                query.Element("Birth_date").Value = this.memberDetails1.birthDate.Text;
                                query.Element("Additional_Information").Value = this.memberDetails1.additionalInformation.Text;
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

        public void DeleteMember()
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
                            var query1 = from result in doc.Element("Project").Element("Members").Elements("Member")
                                         select result;
                            var taskmemberquery = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                                  select result;

                            foreach (var query in query1)
                            {
                                if (query.Element("Id").Value == this.currentID)
                                {

                                    foreach (var task in taskmemberquery)
                                    {
                                        foreach (var match in task.Element("Members").Elements("Id")) 
                                        {
                                            if(match.Value == query.Element("Id").Value)
                                            {
                                                match.Remove();
                                            }
                                        }
                                    }

                                    query.Remove();
                                    doc.Save(project);
                                    this.memberList1.SelectedItems.Clear();
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

        private void memberListSelectedIdChanged(object sender, EventArgs e)
        {
            if (this.memberList1.SelectedItems.Count != 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(0));
                this.currentID = null;

            }
            else if (this.memberList1.SelectedItems.Count == 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(1));
                
                //Sprawdzanie indeksu zaznaczonego zadania
                int i = 0;
                int max = this.memberList1.Items.Count;

                /*if (max > 0)
                {*/
                while (i < max)//this.memberList1.Size.Height)
                {
                    if (this.memberList1.Items[i].Selected == true)
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
                        var query = from result in doc.Element("Project").Element("Members").Elements("Member")
                                    select result;

                        foreach (var fv in query)
                        {
                            if ((fv.Element("Last_name").Value + " " + fv.Element("First_name").Value) == this.memberList1.Items[i].Text)
                            {
                                this.currentID = fv.Element("Id").Value;
                                this.memberDetails1.firstName.Text = fv.Element("First_name").Value;
                                this.memberDetails1.lastName.Text = fv.Element("Last_name").Value;
                                this.memberDetails1.specialisation.Text = fv.Element("Specialisation").Value;
                                this.memberDetails1.birthDate.Text = fv.Element("Birth_date").Value;
                                this.memberDetails1.additionalInformation.Text = fv.Element("Additional_Information").Value;
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
                MessageBox.Show("Failed to load members - directory not found", "Warning!");
            }
            else if (val == 1)
            {
                MessageBox.Show("Failed to load members - XML error related", "Warning!");
            }
            else if (val == 2)
            {
                MessageBox.Show("Failed to load members - " + e.Message, "Warning!");
            }
        }

        public DialogResult ShowMessageWResult(int val)
        {
            if (val == 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this member?", "Delete member!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }

    }
}
