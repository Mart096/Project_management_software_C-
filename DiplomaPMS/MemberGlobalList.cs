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
    public partial class MemberGlobalList : Form
    {
        private string basedir;
        private string filename;
        private string currentID = null;
        private string projdir;
        private string projname;

        public MemberGlobalList()
        {
            InitializeComponent();
            memberDetails1.SwitchFieldsReadOnly(1);
        }

        public void Pass_data(string basedirectory)
        {
            this.basedir = basedirectory;
            this.filename = this.basedir + "GlobalMemberList.xml";

            if (!File.Exists(this.filename))//this.basedir + "GlobalMemberList.xml")) 
            {
                try
                {
                    XDeclaration dec = new XDeclaration("1.0", "UTF-8", "yes");
                    XDocument doc = new XDocument(dec,
                        new XElement("Global_member_list")
                        );
                    doc.Save(this.filename);//basedir + "GlobalMemberList.xml");
                }
                catch (Exception)
                {
                    ShowMessage(3, null);
                }
            }

            Populate_list();
        }

        public void Pass_data(string basedirectory, string projectname, string projectdir)
        {
            this.basedir = basedirectory;
            this.projdir = projectdir;
            this.projname = projectname;
            this.filename = this.basedir + "GlobalMemberList.xml";

            if (!File.Exists(this.filename))//this.basedir + "GlobalMemberList.xml")) 
            {
                try
                {
                    XDeclaration dec = new XDeclaration("1.0", "UTF-8", "yes");
                    XDocument doc = new XDocument(dec,
                        new XElement("Global_member_list")
                        );
                    doc.Save(this.filename);//basedir + "GlobalMemberList.xml");
                }
                catch (Exception)
                {
                    ShowMessage(3, null);
                }
            }
            EditModeSwitch(3);
            Populate_list();
        }

        public void Populate_list()
        {
            memberGlobalList1.Items.Clear();

            try
            {
                /*foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {*/
                XDocument doc = XDocument.Load(this.filename);//basedir+"GlobalMemberList.xml");

                var query = from result in doc.Element("Global_member_list").Elements("Member")
                            select result;

                if (query.Count() != 0)
                {

                    string Id;
                    string firstName;
                    string lastName;
                    string birthDate;
                    string addDate;
                    string specialisation;


                    foreach (var fv in query)
                    {
                        Id = fv.Element("Id").Value;
                        firstName = fv.Element("First_name").Value;
                        lastName = fv.Element("Last_name").Value;
                        birthDate = fv.Element("Birth_date").Value;
                        addDate = fv.Element("Add_date").Value;
                        specialisation = fv.Element("Specialisation").Value;

                        List<string> row2 = new List<string>();
                        row2.Add(lastName + " " + firstName); row2.Add(Id); row2.Add(addDate); row2.Add(specialisation);
                        string[] r2 = { row2[1], row2[2], row2[3] };
                        memberGlobalList1.Items.Add(row2[0]).SubItems.AddRange(r2);
                    }
                    //break;
                }
                //break;
                //}
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

        private void CreateNewMember(object sender, EventArgs e)
        {
            CreateMember createMform = new CreateMember(this.filename);
            createMform.ShowDialog();
            createMform.Tag = this;
            Populate_list();
        }

        private void editMemberButton_Click(object sender, EventArgs e)
        {
            this.EditModeSwitch(1);
        }

        private void memberDetSaveChangesButton_Click(object sender, EventArgs e)
        {
            this.SaveChanges();
        }

        private void memberDetCancelEditButton_Click(object sender, EventArgs e)
        {
            this.EditModeSwitch(0);
        }

        private void memberDeleteButton_Click(object sender, EventArgs e)
        {
            this.DeleteMember();
        }

        private void ColumnHeaderClick(object sender, ColumnClickEventArgs e)
        {
            this.memberGlobalList1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show("Column header clicked!");
        }

        void EditModeSwitch(int val)
        {
            if (val == 1)
            {
                this.memberGlobalList1.Enabled = false;
                this.CreateNewMemberButton.Enabled = false;
                this.editMemberButton.Enabled = false;
                this.editMemberButton.Visible = false;
                this.memberDeleteButton.Enabled = false;
                this.memberDetSaveChangesButton.Visible = true;
                this.memberDetSaveChangesButton.Enabled = true;
                this.memberDetCancelEditButton.Enabled = true;
                this.memberDetCancelEditButton.Visible = true;
                this.memberDetails1.SwitchFieldsReadOnly(0);
            }
            else if (val == 0)
            {
                this.memberGlobalList1.Enabled = true;
                this.CreateNewMemberButton.Enabled = true;
                this.editMemberButton.Enabled = true;
                this.editMemberButton.Visible = true;
                this.memberDeleteButton.Enabled = true;
                this.memberDetSaveChangesButton.Enabled = false;
                this.memberDetSaveChangesButton.Visible = false;
                this.memberDetCancelEditButton.Enabled = false;
                this.memberDetCancelEditButton.Visible = false;
                this.memberDetails1.SwitchFieldsReadOnly(1);
            }
            else if (val == 3)
            {
                this.CreateNewMemberButton.Enabled = false;
                this.CreateNewMemberButton.Visible = false;
                this.editMemberButton.Enabled = false;
                this.editMemberButton.Visible = false;
                this.memberDeleteButton.Enabled = false;
                this.memberDeleteButton.Visible = false;
                this.memberDetSaveChangesButton.Enabled = false;
                this.memberDetSaveChangesButton.Visible= false;
                this.memberDetCancelEditButton.Enabled = false;
                this.memberDetCancelEditButton.Visible = false;
                this.addToProjectButton.Enabled = true;
                this.addToProjectButton.Visible = true;
                this.memberDetails1.SwitchFieldsReadOnly(1);
            }
        }

        private void SaveChanges()
        {
            try
            {

                XDocument doc = XDocument.Load(this.filename);

                var query1 = from result in doc.Element("Global_member_list").Elements("Member")
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
                        doc.Save(this.filename);

                        EditModeSwitch(0);
                        Populate_list();
                        break;
                    }
                }
            }
            catch (XmlException e) { ShowMessage(0, e); }
            catch (Exception e) { ShowMessage(1, e); }
        }

        private void AddMemberToProject(object sender, EventArgs e)
        {
            foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
            {
                XDocument doc = XDocument.Load(project);
                XDocument globlist = XDocument.Load(this.filename);

                string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                              select qr.Element("Name").Value).First();

                //Czy to ten projekt?
                if (this.projname == tpn)
                {

                    var query1 = from c in doc.Element("Project").Element("Members").Elements("Member")
                                 select c;
                    var globallistquery = from c in globlist.Element("Global_member_list").Elements("Member")
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

                    foreach (var gmemb in globallistquery) 
                    {
                        if (gmemb.Element("Id").Value == this.currentID)
                        {
                            XElement new_member = new XElement("Member",
                                            new XElement("Id", indeks),
                                            new XElement("Global_id", gmemb.Element("Id")),
                                            new XElement("First_name", gmemb.Element("First_name")),
                                            new XElement("Last_name", gmemb.Element("Last_name")),
                                            new XElement("Birth_date", gmemb.Element("Birth_date")),
                                            new XElement("Add_date", DateTime.Now.ToString("dd/MM/yyyy")),
                                            new XElement("Additional_Information", gmemb.Element("Additional_information")),
                                            new XElement("Specialisation", gmemb.Element("Specialisation"))
                                        );

                            try
                            {
                                doc.Element("Project").Element("Members").Add(new_member);
                                doc.Save(project);
                                this.Close();
                                //ShowMessage(1);//MessageBox.Show("Project was saved successfully!", "Information");
                                break;
                            }
                            catch (Exception)
                            {
                                //ShowMessage(2);// MessageBox.Show("Error occured during project creation. Project was NOT saved!", "Warning!");
                                this.Close();
                            }
                        }
                    }

                    
                    break;
                }
 
            }

        }

        private void DeleteMember()
        {
            if (ShowMessageWResult(0) == DialogResult.Yes)
            {

                try
                {
                    //foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                    //{
                    XDocument doc = XDocument.Load(this.filename);

                    var query1 = from result in doc.Element("Global_member_list").Elements("Member")
                                 select result;
                    /*var taskmemberquery = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                          select result;*/

                    foreach (var query in query1)
                    {
                        if (query.Element("Id").Value == this.currentID)
                        {
                            query.Remove();
                            doc.Save(this.filename);
                            this.memberGlobalList1.SelectedItems.Clear();
                            this.currentID = null;
                        }
                    }
                    Populate_list();
                    //break;

                }
                catch (XmlException e) { ShowMessage(0, e); }
                catch (Exception e) { ShowMessage(1, e); }
            }
        }

        private void memberListSelectedIdChanged(object sender, EventArgs e)
        {
            if (this.memberGlobalList1.SelectedItems.Count != 1)
            {
                /*if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(0));*/
                this.editMemberButton.Enabled = false;
                this.memberDeleteButton.Enabled = false;
                this.currentID = null;

            }
            else if (this.memberGlobalList1.SelectedItems.Count == 1)
            {
                /*if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(1));*/
                this.editMemberButton.Enabled = true;
                this.memberDeleteButton.Enabled = true;

                //Sprawdzanie indeksu zaznaczonego zadania
                int i = 0;
                int max = this.memberGlobalList1.Items.Count;

                /*if (max > 0)
                {*/
                while (i < max)//this.memberGlobalList1.Size.Height)
                {
                    if (this.memberGlobalList1.Items[i].Selected == true)
                    {
                        break;
                    }
                    i += 1;
                }

                //foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                //{
                XDocument doc = XDocument.Load(this.filename);

                var query = from result in doc.Element("Global_member_list").Elements("Member")
                            select result;

                foreach (var fv in query)
                {
                    //if ((fv.Element("Last_name").Value + " " + fv.Element("First_name").Value) == this.memberGlobalList1.Items[i].Text)
                    if ((fv.Element("Id").Value) == this.memberGlobalList1.SelectedItems[0].SubItems[1].Text)
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
            //}
            //}
            //}
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
            else if (val == 3)
            {
                MessageBox.Show("Attempt of GlobalMemberList.xml file creation has failed.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
