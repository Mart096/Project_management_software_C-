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
    public partial class mainWindow : Form
    {
        private string projdir;
        private string diplomaPMversion = "0.1";
        private string basedirectory;

        public mainWindow()
        {
            InitializeComponent();

            string basedir = AppDomain.CurrentDomain.BaseDirectory;
            this.basedirectory = basedir;
            this.projdir = Initstuff(basedir);

            openProjectList1(this);
            /*this.workspaceDir_textbox.Text = this.projdir;
            Populate_list();*/
        }

        public void openProjectList1(mainWindow mainW) 
        {
            ProjectList ucProjectList = new ProjectList(this);
            ucProjectList.Location = new System.Drawing.Point(0, 25);
            ucProjectList.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
            ucProjectList.Height = Convert.ToInt32(this.Size.Height)-70;
            ucProjectList.Width = Convert.ToInt32(this.Size.Width)-20;
            this.Controls.Add(ucProjectList);
        }

        public void openProjectManager(mainWindow mainW, string projname)
        {
            ProjectManage1 ucProjectManage = new ProjectManage1(this, projname, projdir);
            ucProjectManage.Location = new System.Drawing.Point(0, 25);
            ucProjectManage.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
            ucProjectManage.Height = Convert.ToInt32(this.Size.Height)-70;
            ucProjectManage.Width = Convert.ToInt32(this.Size.Width)-20;
            this.Controls.Add(ucProjectManage);
        }

        private string Initstuff(string basedir) 
        {
            string projectsdir = basedir + "Projects\\";

            if(!File.Exists(basedir+"config.xml"))
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
                    MessageBox.Show("Attempt of config.xml file creation has failed.", "Warning!");
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
                    MessageBox.Show("Loading workspace directory from config.xml file was unsuccessful.", "Warning!");
                }
            }

            if (!Directory.Exists(projectsdir))
            {
                Directory.CreateDirectory(projectsdir);
                return projectsdir;
            }

            if (!File.Exists(basedir + "LICENSE.txt")) 
            {
                string[] liclines = { "The MIT License (MIT)", 
                                        "", 
                                        "Copyright (c) 2012 Jake See", 
                                        "", 
                                        "Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:", 
                                        "",
                                        "The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.",
                                        "",
                                        "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE."
                                    };
                File.WriteAllLines(basedir + "LICENSE.txt", liclines);
            }

            return projectsdir;
            //XDocument document;
        }

        /*private void Populate_list() {
            //Dodawanie elementów do listy
            //projectList1.Items.Add("Column")
            /*List<string> row1 = new List<string>();// ( "s1", "s2", "s3" );
            row1.Add("s1"); row1.Add("s2"); row1.Add("s3"); row1.Add("s4");
            string[] r2 = { row1[0], row1[1], row1[2], row1[3] };
            projectList1.Items.Add("Column1Text").SubItems.AddRange(r2);
            projectList1.Items.Add("Column2Text").SubItems.AddRange(r2);*/

           /******* projectList1.Items.Clear();

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
                    List<string> row1 = new List<string>();

                    foreach (var fv in query)
                    {
                        pname = fv.Element("Name").Value;
                        startdate = fv.Element("Start_date").Value;
                        enddate = fv.Element("End_date").Value;
                        customername = fv.Element("Customer_name").Value;
                        row1.Add(pname); row1.Add(startdate); row1.Add(enddate); row1.Add(customername);
                    }

                    string[] r2 = { row1[1], row1[2], "", row1[3] };
                    projectList1.Items.Add(row1[0]).SubItems.AddRange(r2);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Failed to load projects - directory not found", "Warning!");
            }
            catch (Exception) 
            {
                MessageBox.Show("Failed to load projects - general error", "Warning!");
            }

        }*/

        //Przyciski
        /*private void create_new_button_Click(object sender, EventArgs e)
        {
            CreateProject createPform = new CreateProject(projdir);
            createPform.ShowDialog();
            createPform.Tag = this;
        }*/

       /* private void loadButton_Click(object sender, EventArgs e)
        {
           int i=0;
           int max=Directory.GetFiles(this.projdir, "*.xml").Length;
          // MessageBox.Show(Convert.ToString(this.projectList1.Size.Width));
           try
           {
               while (i < max)//this.projectList1.Size.Height)
               {
                   if (this.projectList1.Items[i].Selected == true)
                   {
                       MessageBox.Show(this.projectList1.Items[i].Text + " was selected and loaded successfully.", "Test load result");
                       ProjectManage prmanager1 = new ProjectManage();
                       prmanager1.Show();
                       break;
                   }
                   i += 1;
               }
           }
           catch (Exception) { MessageBox.Show("Critical error detected. Program will shut down.", "Warning!"); Application.Exit(); }
        }*/

        private void renameButton_Click(object sender, EventArgs e)
        {

        }

       /* private void deleteButton_Click(object sender, EventArgs e)
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
                        var mresult = MessageBox.Show("Do you want to delete " + this.projectList1.Items[i].Text + "?\nAll data associated with this project will be lost forever.", "Delete" + this.projectList1.Items[i].Text , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mresult == DialogResult.No)
                        { 
                            break;
                        }
                        else if (mresult == DialogResult.Yes) 
                        { 
                            var dpname=this.projectList1.Items[i].Text;
                            //string pname;
                            try
                            {
                                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                                {

                                    XDocument doc = XDocument.Load(project);

                                    string pname = (from xml in doc.Element("Project").Descendants("Project_details")
                                                 select xml.Element("Name").Value).First();

                                    if(dpname==pname)
                                    {
                                        File.Delete(project);
                                        break;
                                    }
                                    
                                }
                                Populate_list();
                                MessageBox.Show(dpname + " was deleted successfully.", "Delete completed");
                                break;
                            }
                            catch (FileNotFoundException) 
                            {
                                MessageBox.Show("Error occured during file deleting. " + dpname + " was not found.", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error occured during file deleting. ", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        }
                    }
                    i += 1;
                }
            }
            catch (Exception) { MessageBox.Show("Critical error detected. Program will shut down.", "Warning!"); Application.Exit(); }
        }*/

       /* private void changedir_button_Click(object sender, EventArgs e)
        {
            /*if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.label3.Text = folderBrowserDialog1.SelectedPath;
            }*/
           /***** if (Directory.Exists(workspaceDir_textbox.Text))
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
                catch (Exception) { MessageBox.Show("Failed to change workspace directory.", "Warning!"); }
            }
            else 
            {
                MessageBox.Show("Failed to change workspace directory - new directory is invalid.", "Warning!");
                workspaceDir_textbox.Text = this.projdir;
            }
        }*/

        /*private void workspaceTextBox_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.workspaceDir_textbox.Text = folderBrowserDialog1.SelectedPath;
            }
        }*/

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
            //Populate_list();
        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberGlobalList GlobalMemberWindow = new MemberGlobalList();
            GlobalMemberWindow.Pass_data(basedirectory);
            GlobalMemberWindow.ShowDialog();
            GlobalMemberWindow.Tag = this;
        }

        /*private void ProjectListIndexChanged(object sender, EventArgs e)
        {
            if (this.projectList1.SelectedItems.Count <= 0)
            {
                this.loadButton.Enabled = false;
                this.deleteButton.Enabled = false;
                //this.renameButton.Enabled = false;
            }
            else if (this.projectList1.SelectedItems.Count == 1)
            {
                this.loadButton.Enabled = true;
                this.deleteButton.Enabled = true;

                //Sprawdzanie indeksu zaznaczonego projektu
                int i = 0;
                int max = Directory.GetFiles(this.projdir, "*.xml").Length;


                    while (i < max)//this.projectList1.Size.Height)
                    {
                        if (this.projectList1.Items[i].Selected == true)
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
                        }
                    }
                }
            }
            else 
            {
                this.loadButton.Enabled = false;
                this.deleteButton.Enabled = false;
                //this.renameButton.Enabled = false;
            }
        }*/
        
    }
}
