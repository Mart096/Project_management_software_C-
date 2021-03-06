﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DiplomaPMS
{    
    public partial class ProjectList : UserControl
    {
        private string projdir;
        private string diplomaPMversion = "0.1";
        private string basedirectory;
        private mainWindow mainWind=null;

        public ProjectList()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            InitializeComponent();

            string basedir = AppDomain.CurrentDomain.BaseDirectory;
            this.basedirectory = basedir;
            this.projdir = Initstuff(basedir);

            this.workspaceDir_textbox.Text = this.projdir;
            Populate_list();
        }

        public ProjectList(mainWindow mainWind)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");

            InitializeComponent();

            string basedir = AppDomain.CurrentDomain.BaseDirectory;
            this.basedirectory = basedir;
            this.projdir = Initstuff(basedir);
            this.mainWind = mainWind;

            this.workspaceDir_textbox.Text = this.projdir;
            Populate_list();
        }

        private string Initstuff(string basedir)
        {
            string projectsdir = basedir + "Projects\\";

            if (!File.Exists(basedir + "config.xml"))
            {
                try
                {
                    XDeclaration dec = new XDeclaration("1.0", "UTF-8", "yes");
                    XDocument doc = new XDocument(dec,
                        new XElement("Diploma_Project_Manager_Config",
                            new XElement("Workspace_dir", projectsdir),
                            new XElement("Version", this.diplomaPMversion))
                        );
                    doc.Save(basedir + "config.xml");
                }
                catch (Exception)
                {
                    ShowMessage(0); //MessageBox.Show("Attempt of config.xml file creation has failed.", "Warning!");
                }
            }
            else
            {
                try
                {
                    XDocument doc = XDocument.Load(basedir + "config.xml");
                    projectsdir = (from xml in doc.Descendants("Diploma_Project_Manager_Config")
                                   select xml.Element("Workspace_dir").Value).First();
                }
                catch (Exception)
                {
                    ShowMessage(1); //MessageBox.Show("Loading workspace directory from config.xml file was unsuccessful.", "Warning!");
                }
            }

            if (!Directory.Exists(projectsdir))
            {
                Directory.CreateDirectory(projectsdir);
                return projectsdir;
            }

            return projectsdir;
            //XDocument document;
        }

        private void Populate_list()
        {
            //Dodawanie elementów do listy
            //projectList1.Items.Add("Column")
            /*List<string> row1 = new List<string>();// ( "s1", "s2", "s3" );
            row1.Add("s1"); row1.Add("s2"); row1.Add("s3"); row1.Add("s4");
            string[] r2 = { row1[0], row1[1], row1[2], row1[3] };
            projectList1.Items.Add("Column1Text").SubItems.AddRange(r2);
            projectList1.Items.Add("Column2Text").SubItems.AddRange(r2);*/

            projectList1.Items.Clear();

            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    var query = from result in doc.Element("Project").Elements("Project_details")
                                select result;
                    string pname;
                    string startdate;
                    string enddate;
                    string customername;
                    string pstatus;
                    List<string> row1 = new List<string>();

                    foreach (var fv in query)
                    {
                        pname = fv.Element("Name").Value;
                        startdate = fv.Element("Start_date").Value;
                        enddate = fv.Element("End_date").Value;
                        customername = fv.Element("Customer_name").Value;
                        pstatus = fv.Element("Status").Value;
                        row1.Add(pname); row1.Add(startdate); row1.Add(enddate); row1.Add(pstatus); row1.Add(customername);
                    }

                    string[] r2 = { row1[1], row1[2], row1[3], row1[4] };
                    projectList1.Items.Add(row1[0]).SubItems.AddRange(r2);
                }
            }
            catch (DirectoryNotFoundException)
            {
                ShowMessage(2); //MessageBox.Show("Failed to load projects - directory not found", "Warning!");
            }
            catch (Exception)
            {
                ShowMessage(3); //MessageBox.Show("Failed to load projects - general error", "Warning!");
            }

        }

        //Przyciski
        private void create_new_button_Click(object sender, EventArgs e)
        {
            CreateProject createPform = new CreateProject(projdir);
            createPform.ShowDialog();
            createPform.Tag = this;
            Populate_list();
        }

        private void duplicateProjectButton_Click(object sender, EventArgs e)
        {
            if (projectList1.SelectedItems.Count == 1) { 
                string projname= projectList1.SelectedItems[0].Text;
                //MessageBox.Show("" + projname);
                CreateProject duplicateSelP = new CreateProject(this.projdir, projname);
                duplicateSelP.ShowDialog();
                duplicateSelP.Tag = this;
                Populate_list();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            int max = Directory.GetFiles(this.projdir, "*.xml").Length;
            // MessageBox.Show(Convert.ToString(this.projectList1.Size.Width));
            try
            {
                while (i < max)//this.projectList1.Size.Height)
                {
                    if (this.projectList1.Items[i].Selected == true)
                    {
                        //ShowMessage(0, this.projectList1.Items[i].Text); //MessageBox.Show(this.projectList1.Items[i].Text + " was selected and loaded successfully.", "Test load result");
                        mainWind.openProjectManager(mainWind, this.projectList1.Items[i].Text);
                        this.Dispose();
                        //this.DestroyHandle();
                        break;
                    }
                    i += 1;
                }
            }
            catch (Exception) { ShowMessage(4); /*MessageBox.Show("Critical error detected. Program will shut down.", "Warning!");*/ Application.Exit(); }
        }

        /*private void renameButton_Click(object sender, EventArgs e)
        {

        }*/

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            int max = Directory.GetFiles(this.projdir, "*.xml").Length;
            // MessageBox.Show(Convert.ToString(this.projectList1.Size.Width));
            try
            {
                while (i < max)//this.projectList1.Size.Height)
                {
                    if (this.projectList1.Items[i].Selected == true)
                    {
                        var mresult = ShowMessageWResult(0, this.projectList1.Items[i].Text); //MessageBox.Show("Do you want to delete " + this.projectList1.Items[i].Text + "?\nAll data associated with this project will be lost forever.", "Delete" + this.projectList1.Items[i].Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mresult == DialogResult.No)
                        {
                            break;
                        }
                        else if (mresult == DialogResult.Yes)
                        {
                            var dpname = this.projectList1.Items[i].Text;
                            //string pname;
                            try
                            {
                                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                                {

                                    XDocument doc = XDocument.Load(project);

                                    string pname = (from xml in doc.Element("Project").Descendants("Project_details")
                                                    select xml.Element("Name").Value).First();

                                    if (dpname == pname)
                                    {
                                        File.Delete(project);
                                        break;
                                    }

                                }
                                Populate_list();
                                ShowMessage(1, dpname); //MessageBox.Show(dpname + " was deleted successfully.", "Delete completed");
                                break;
                            }
                            catch (FileNotFoundException)
                            {
                                ShowMessage(2, dpname); //MessageBox.Show("Error occured during file deleting. " + dpname + " was not found.", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            catch (Exception)
                            {
                                ShowMessage(5); //MessageBox.Show("Error occured during file deleting. ", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        }
                    }
                    i += 1;
                }
            }
            catch (Exception) { ShowMessage(4);/*MessageBox.Show("Critical error detected. Program will shut down.", "Warning!");*/ Application.Exit(); }
        }

        private void changedir_button_Click(object sender, EventArgs e)
        {
            /*if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.label3.Text = folderBrowserDialog1.SelectedPath;
            }*/
            if (Directory.Exists(workspaceDir_textbox.Text))
            {

                try
                {
                    this.projdir = workspaceDir_textbox.Text;

                    XDocument doc = XDocument.Load(this.basedirectory + "config.xml");
                    var query1 = from c in doc.Elements("Diploma_Project_Manager_Config")
                                 select c;
                    foreach (var elem in query1)
                    {
                        elem.Element("Workspace_dir").SetValue(workspaceDir_textbox.Text);
                        break;
                    }
                    doc.Save(this.basedirectory + "config.xml");
                    //this.projdir = workspaceDir_textbox.Text;
                    Populate_list();
                }
                catch (Exception) { ShowMessage(6); /*MessageBox.Show("Failed to change workspace directory.", "Warning!");*/ }
            }
            else
            {
                ShowMessage(7); //MessageBox.Show("Failed to change workspace directory - new directory is invalid.", "Warning!");
                workspaceDir_textbox.Text = this.projdir;
            }
        }

        private void workspaceTextBox_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.workspaceDir_textbox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutScreen aboutform = new AboutScreen();
            aboutform.ShowDialog();
            aboutform.Tag = this;
        }

        private void MainWindowFocus(object sender, EventArgs e)
        {
            Populate_list();
        }

        private void ProjectListIndexChanged(object sender, EventArgs e)
        {
            if (this.projectList1.SelectedItems.Count <= 0)
            {
                this.duplicateProjectButton.Enabled = false;
                this.loadButton.Enabled = false;
                this.deleteButton.Enabled = false;
                //this.renameButton.Enabled = false;
            }
            else if (this.projectList1.SelectedItems.Count == 1)
            {
                this.duplicateProjectButton.Enabled = true;
                this.loadButton.Enabled = true;
                this.deleteButton.Enabled = true;

                //Sprawdzanie indeksu zaznaczonego projektu
                int i = 0;
                int max = Directory.GetFiles(this.projdir, "*.xml").Length;

                /*try
                {*/
                while (i < max)//this.projectList1.Size.Height)
                {
                    if (this.projectList1.Items[i].Selected == true)
                    {
                        break;
                    }
                    i += 1;
                }
                /*}
                catch (Exception) { MessageBox.Show("Critical error detected. Program will shut down.", "Warning!"); Application.Exit(); }*/
                /***************************************/
                //int i = 0;
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                                  select qr.Element("Name").Value).First();

                    if (this.projectList1.Items[i].Text == tpn)
                    {
                        var query = from result in doc.Element("Project").Elements("Project_details")
                                    select result;
                        

                        foreach (var fv in query)
                        {
                            this.projectName.Text = fv.Element("Name").Value;
                            this.startDate.Text = fv.Element("Start_date").Value;
                            this.endDate.Text = fv.Element("End_date").Value;
                            this.description.Text = fv.Element("Description").Value;
                            this.customerName.Text = fv.Element("Customer_name").Value;
                            this.customerAddress.Text = fv.Element("Customer_address").Value;
                            this.customersTelephone.Text = fv.Element("Customer_telephone").Value;
                            this.customerEmail.Text = fv.Element("Customer_email").Value;
                            this.budgetValue.Value = Convert.ToDecimal(fv.Element("Budget").Value);

                            var tempstartd = DateTime.ParseExact(this.startDate.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                            var tempendd = DateTime.ParseExact(this.endDate.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                            int prduration =(int) (tempendd.Date-tempstartd.Date).TotalDays;
                            this.projectDetDuration.Text = prduration.ToString();
                            break;
                        }
                    }
                }
            }
            else
            {
                this.duplicateProjectButton.Enabled = false;
                this.loadButton.Enabled = false;
                this.deleteButton.Enabled = false;
                //this.renameButton.Enabled = false;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void ColumnHeaderClick(object sender, ColumnClickEventArgs e)
        {
            this.projectList1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show("Column header clicked!");
        }

        private void ShowMessage(int mnumber) 
        {
            if (mnumber == 0)
            {
                MessageBox.Show("Attempt of config.xml file creation has failed.", "Warning!");
            }
            else if (mnumber == 1)
            {
                MessageBox.Show("Loading workspace directory from config.xml file was unsuccessful.", "Warning!");
            }
            else if (mnumber == 2) 
            {
                MessageBox.Show("Failed to load projects - directory not found", "Warning!");
            }
            else if (mnumber == 3)
            {
                MessageBox.Show("Failed to load projects - general error", "Warning!");
            }
            else if (mnumber == 4)
            {
                MessageBox.Show("Critical error detected. Program will shut down.", "Warning!");
            }
            else if (mnumber == 5)
            {
                MessageBox.Show("Error occured during file deleting. ", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (mnumber == 6) 
            {
                MessageBox.Show("Failed to change workspace directory.", "Warning!");
            }
            else if (mnumber == 7)
            {
                MessageBox.Show("Failed to change workspace directory - new directory is invalid.", "Warning!");
            }
        }

        private void ShowMessage(int mnumber, string name) 
        {
            if (mnumber == 0) 
            {
                MessageBox.Show(name + " was selected and loaded successfully.", "Test load result");
            }
            else if (mnumber == 1)
            {
                MessageBox.Show(name + " was deleted successfully.", "Delete completed");
            }
            else if (mnumber == 2) 
            {
                MessageBox.Show("Error occured during file deleting. " + name + " was not found.", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DialogResult ShowMessageWResult(int mnumber, string name)
        {
            if (mnumber == 0)
            {
                DialogResult mesres=MessageBox.Show("Do you want to delete " + name + "?\nAll data associated with this project will be lost forever.", "Delete" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return mesres;
            }
            return DialogResult.Cancel;
        }
    }
}
