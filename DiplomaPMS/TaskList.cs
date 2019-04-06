using System;
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
using Braincase.GanttChart;

namespace DiplomaPMS
{
    public partial class TaskList : UserControl
    {
        //public ProjectManage1 tasklistcontrols = null;
        private string projdir = null;
        private string projname = null;
        public event EventHandler<CustomEventArgs> ListItemSelected;
        private string currentID=null;
        private int currentView = 1;
        ProjectManager pManager;


        public delegate void create_new_button_click(object sender, EventArgs e);
        
        public TaskList()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            InitializeComponent();
            taskDetails1.SwitchFieldsReadOnly(1);

            pManager= new ProjectManager();
            ganttChart1.Init(pManager);
        }

        public TaskList(string projectname, string projectdir)
        {
            InitializeComponent();

            this.projdir = projectdir;
            this.projname = projectname;
            //Populate_list();
        }

        public void Pass_data(string projectname, string projectdir) 
        {
            this.projname = projectname;
            this.projdir = projectdir;
        }

        public void Populate_list() 
        {

            //var pmanager = new ProjectManager();
            pManager = new ProjectManager();
            ganttChart1.Init(pManager);

            taskList1.Items.Clear();
            //ColumnClickEventArgs args = new ColumnClickEventArgs(0);
            ColumnHeaderClick(this, new ColumnClickEventArgs(0));

            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    var currPName = (from xml in doc.Element("Project").Descendants("Project_details")
                                                    select xml.Element("Name").Value).First();

                    if (currPName == projname)
                    {
                        
                        var query = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                    select result;
                        var membersquery = from result in doc.Element("Project").Element("Members").Elements("Member")
                                           select result;

                        if (query.Count() != 0)
                        {

                            string id;
                            string taskname;
                            string startdate;
                            string enddate;
                            string progress;

                            foreach (var fv in query)
                            {
                                id = fv.Element("Id").Value;
                                taskname = fv.Element("Name").Value;
                                startdate = fv.Element("Start_date").Value;
                                enddate = fv.Element("End_date").Value;
                                progress = fv.Element("Progress").Value;

                                //pManager.Add(new Braincase.GanttChart.Task() { Name = taskname });

                                List<string> row2 = new List<string>();
                                row2.Add(taskname); row2.Add(id); row2.Add(startdate); row2.Add(enddate); row2.Add(progress); //row2.Add(members);
                                string[] r2 = { row2[1], row2[2], row2[3], row2[4] };
                                taskList1.Items.Add(row2[0]).SubItems.AddRange(r2);
                            }

                            //Teraz należy posegregować zadania po datach i narysować je w wykresie Gantta
                            List<DateTime> tempstartdList = new List<DateTime>();
                            List<DateTime> tempenddList = new List<DateTime>();
                            List<string> tasknamesList = new List<string>();
                            foreach (ListViewItem itm in taskList1.Items)
                            {
                                tempstartdList.Add(DateTime.ParseExact(itm.SubItems[2].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture));
                                tempenddList.Add(DateTime.ParseExact(itm.SubItems[3].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture));
                                tasknamesList.Add(itm.Text);
                            }
                            //Sortowanie dat od najwcześniejszych do najpóźniejszych
                            for (int j = 0; j < tempstartdList.Count; j++)
                                for (int i = 1; i < tempstartdList.Count; i++)
                                {
                                    if (tempstartdList[i - 1] > tempstartdList[i])
                                    {
                                        DateTime tempstartdate = tempstartdList[i];
                                        DateTime tempenddate = tempenddList[i];
                                        string tempname = tasknamesList[i];

                                        tempstartdList[i] = tempstartdList[i - 1];
                                        tempenddList[i] = tempenddList[i - 1];
                                        tasknamesList[i] = tasknamesList[i - 1];

                                        tempstartdList[i - 1] = tempstartdate;
                                        tempenddList[i - 1] = tempenddate;
                                        tasknamesList[i - 1] = tempname;
                                    }
                                }
                            ////foreach (var itm in tempstartdList) MessageBox.Show("" + itm.Date.ToString("dd/MM/yyyy"));
                            var span = tempenddList.Max(t => t.Date) - tempstartdList.Min(g => g.Date);
                            pManager.Start = tempstartdList[0];
                            //pManager.Now = (int)Math.Round(span.TotalDays);
                            for (int i = 0; i < tempstartdList.Count; i++)
                            {
                                Braincase.GanttChart.Task generatedtask = new Braincase.GanttChart.Task() { Name = tasknamesList[i] };
                                var taskduration = tempenddList[i] - tempstartdList[i];
                                int taskstart = (int)(tempstartdList[i].Date - tempstartdList[0].Date).TotalDays;
                                pManager.Add(generatedtask);
                                pManager.SetStart(generatedtask, taskstart);//Convert.ToInt32(tempstartdList[i]));
                                pManager.SetDuration(generatedtask, (int)taskduration.TotalDays);
                                //pManager.Add(new Braincase.GanttChart.Task() { Name = taskname });
                                //ganttChart1.Invalidate();
                            }
                            ColumnHeaderClick(this, new ColumnClickEventArgs(1));

                            //ganttChart1.Invalidate();
                            break;
                        }
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

        public void create_new_button_Click(object sender, EventArgs e)
        {
            CreateTask createTform = new CreateTask(this.projdir, this.projname);
            createTform.ShowDialog();
            createTform.Tag = this;
            Populate_list();
        }   

        public void EditButton_Click()
        {
            this.taskList1.Enabled = false;
            this.taskDetails1.SwitchFieldsReadOnly(0);
            this.taskDetails1.GetMembersList(this.projdir, this.projname);
            this.ViewVariant(1);
            //this.taskDetails1.SelectMembersFromTask();

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
                        var query1 = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                    select result;
                        var membersquery = from result in doc.Element("Project").Element("Members").Elements("Member")
                                           select result;

                        foreach (var query in query1)
                        {
                            if(query.Element("Id").Value == this.currentID)
                            {
                                query.Element("Name").Value = this.taskDetails1.taskName.Text;
                                query.Element("Start_date").Value = this.taskDetails1.startDate.Text;
                                query.Element("End_date").Value = this.taskDetails1.endDate.Text;
                                query.Element("Description").Value = this.taskDetails1.description.Text;
                                query.Element("Budget").Value = Convert.ToString(this.taskDetails1.budgetValue.Value);
                                query.Element("Progress").Value = this.taskDetails1.progressBar.Value.ToString();
                                query.Element("Members").Elements("Id").Remove();
                                

                                foreach (var ff in this.taskDetails1.listBox1.SelectedItems)
                                {
                                    //MessageBox.Show("selected: " + ff.ToString());//.ToString());
                                    foreach (ListViewItem fs in this.taskDetails1.listView1.Items)
                                    {
                                        //MessageBox.Show("in list: " + fs.Text + "\n id: " + fs.SubItems[1].Text);//.ToString());
                                        if (ff.ToString() == fs.Text)
                                        {
                                            query.Element("Members").Add(new XElement("Id", fs.SubItems[1].Text));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        doc.Save(project);
                        //ShowMessage(0, null);
                        CancelEdit();
                        break;
                    }
                }
            }
            catch (XmlException e) { ShowMessage(0, e); }
            catch (Exception e) { ShowMessage(1, e); }
        }

        public void CancelEdit() 
        {
            this.taskList1.Enabled = true;
            this.taskDetails1.SwitchFieldsReadOnly(1);
        }

        public void DeleteTask()
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
                            var query1 = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                         select result;

                            foreach (var query in query1)
                            {
                                if (query.Element("Id").Value == this.currentID)
                                {
                                    /*query.Element("Name").Value = this.taskDetails1.taskName.Text;
                                    query.Element("Start_date").Value = this.taskDetails1.startDate.Text;
                                    query.Element("End_date").Value = this.taskDetails1.endDate.Text;
                                    query.Element("Description").Value = this.taskDetails1.description.Text;
                                    query.Element("Budget").Value = Convert.ToString(this.taskDetails1.budgetValue.Value);
                                    query.Element("Progress").Value = this.taskDetails1.progressBar.Value.ToString();*/
                                    query.Remove();
                                    doc.Save(project);
                                    this.taskList1.SelectedItems.Clear();
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

        private void TaskListIndexChanged(object sender, EventArgs e) //funkcja służy do blokowania i odblokowywania niektórych przycisków w menu i wyświetlania danych wybranego zadania
        {
            if (this.taskList1.SelectedItems.Count != 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(0));
                this.currentID = null;
                
            }
            else if (this.taskList1.SelectedItems.Count == 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(1));
                 
                //Sprawdzanie indeksu zaznaczonego zadania
                int i = 0;
                int max = this.taskList1.Items.Count;

                /*if (max > 0)
                {*/
                    while (i < max)//this.taskList1.Size.Height)
                    {
                        if (this.taskList1.Items[i].Selected == true)
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
                            var query = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                        select result;
                            var membersquery = from result in doc.Element("Project").Element("Members").Elements("Member")
                                               select result;

                            foreach (var fv in query)
                            {
                                if(fv.Element("Name").Value == this.taskList1.Items[i].Text)
                                {
                                    this.currentID = fv.Element("Id").Value;
                                    this.taskDetails1.taskName.Text = fv.Element("Name").Value;
                                    this.taskDetails1.startDate.Text = fv.Element("Start_date").Value;
                                    this.taskDetails1.endDate.Text = fv.Element("End_date").Value;
                                    this.taskDetails1.description.Text = fv.Element("Description").Value;
                                    this.taskDetails1.budgetValue.Value = Convert.ToDecimal(fv.Element("Budget").Value);
                                    this.taskDetails1.progressBar.Value =  Convert.ToInt32(fv.Element("Progress").Value);
                                    //this.listBox1.;
                                    this.taskDetails1.listBox1.Items.Clear();
                                    this.taskDetails1.listView1.Items.Clear();
                                    foreach (var ff in fv.Elements("Members").Elements("Id")) 
                                    {
                                        foreach (var fss in membersquery) 
                                        {
                                            if(ff.Value== fss.Element("Id").Value)
                                            {
                                                this.taskDetails1.listBox1.Items.Add(fss.Element("Last_name").Value +" "+ fss.Element("First_name").Value);// + "(" + ff.Value+")");
                                                break;
                                            }
                                        }
                                    }

                                    /*foreach (var fss in membersquery)
                                    {
                                        this.taskDetails1.listView1.Items.Add(fss.Element("Last_name").Value + " " + fss.Element("First_name").Value).SubItems.Add(fss.Element("Id").Value);
                                    }*/
                                    break;
                                }
                            }
                        }
                    }
                //}
            }
        }

        public void ViewVariant(int val)
        {
            if (val == 0 && currentView != 0) 
            {   
                //this.taskList1.Width = this.taskList1.Size.Width + this.taskDetails1.Size.Width; 
                this.taskList1.Width = this.Size.Width;
                this.taskList1.Visible = true;
                this.ganttChart1.Visible = false; 
                this.taskDetails1.Visible = false; 
                this.currentView = 0; 
            }
            else if (val == 1 && currentView != 1) 
            {
                //this.taskList1.Width = this.taskList1.Size.Width - this.taskDetails1.Size.Width; 
                this.taskList1.Width = this.Size.Width - this.taskDetails1.Size.Width;
                this.taskList1.Visible = true; 
                this.taskDetails1.Visible = true; 
                this.ganttChart1.Visible = false; 
                this.currentView = 1; 
            }
            else if (val == 2 && currentView != 2) 
            { this.taskList1.Visible = false; 
                this.taskDetails1.Visible = false; 
                this.ganttChart1.Visible = true; 
                this.currentView = 2; 
            }
        }

        public void ShowMessage(int val, Exception e)
        {
            if (val == 0) 
            {
                MessageBox.Show("Failed to load tasks - directory not found", "Warning!");
            }
            else if (val == 1) 
            {
                MessageBox.Show("Failed to load tasks - XML error related", "Warning!");
            }
            else if (val == 2)
            {
                MessageBox.Show("Failed to load tasks - " + e.Message, "Warning!");
            }
        }

        public DialogResult ShowMessageWResult(int val) 
        {
            if (val == 0) 
            {
                var result = MessageBox.Show("Are you sure you want to delete this task?", "Delete task!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }

        private void ColumnHeaderClick(object sender, ColumnClickEventArgs e)
        {
            this.taskList1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show("Column header clicked!");
        }
    }

}
