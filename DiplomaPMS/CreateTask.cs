using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class CreateTask : Form
    {
        private string projdir;
        private string projname;

        public CreateTask(string projectdir, string projectname)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            InitializeComponent();

            this.projdir = projectdir;
            this.projname = projectname;
            this.startDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.endDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            this.GetMembersList();
        }

        /*private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/

        private void StartDateInput_Enter(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void StartDateInput_Leave(object sender, EventArgs e)
        {
            if (!monthCalendar1.Focused)
            {
                monthCalendar1.Visible = false;
            }

        }

        private void calendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            startDate.Text = mcalendar.SelectionStart.ToString();
        }

        private void calendar1_Leave(object sender, EventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            mcalendar.Visible = false;
        }

        //End Date Input
        private void EndDateInput_Enter(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void EndDateInput_Leave(object sender, EventArgs e)
        {
            if (!monthCalendar2.Focused)
            {
                monthCalendar2.Visible = false;
            }

        }

        private void calendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            endDate.Text = mcalendar.SelectionStart.ToString();
        }

        private void calendar2_Leave(object sender, EventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            mcalendar.Visible = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetMembersList() 
        {
            foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
            {
                XDocument doc = XDocument.Load(project);

                string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                              select qr.Element("Name").Value).First();

                //Czy to ten projekt?
                if (this.projname == tpn)
                {

                    var query1 = from c in doc.Element("Project").Element("Members").Elements("Member")
                                 select c;

                    foreach (var fv in query1) 
                    {
                        listView1.Items.Add(fv.Element("Last_name").Value + " " + fv.Element("First_name").Value).SubItems.Add(fv.Element("Id").Value);
                        //listBox1.Items.Add(fv.Element("Last_name").Value + " " + fv.Element("First_name").Value+"(" + fv.Element("Id").Value+")");
                        listBox1.Items.Add(listView1.Items[listView1.Items.Count-1].Text);
                    }
                }
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (this.startDate.MaskCompleted == false || this.endDate.MaskCompleted == false)//(this.taskName.Text == "" || this.taskName.Text == " ")
            {
                ShowMessage(0);
            }
            else
            {
                /*if (File.Exists(this.projdir + "\\" + this.projname + ".xml"))
                {*/

                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                                  select qr.Element("Name").Value).First();
                    string tpsd = (from qr in doc.Element("Project").Descendants("Project_details")
                                  select qr.Element("Start_date").Value).First();
                    string tped = (from qr in doc.Element("Project").Descendants("Project_details")
                                  select qr.Element("End_date").Value).First();

                    //Czy to ten projekt?
                    if (this.projname == tpn)
                    {
                        //MessageBox.Show("" + System.Globalization.CultureInfo.CurrentCulture.ToString());
                        DateTime temppstartd = DateTime.ParseExact(tpsd, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture).Date;
                        DateTime temppendd = DateTime.ParseExact(tped, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture).Date;
                        DateTime temptstartd = DateTime.ParseExact(this.startDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture).Date;
                        DateTime temptendd = DateTime.ParseExact(this.endDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture).Date;

                        if (temppstartd > temptstartd) 
                        {
                            DialogResult userresponse = ShowMessageWResult(0);
                            if (userresponse == DialogResult.No || userresponse == DialogResult.Cancel) { break; }
                        }
                        if (temptendd > temppendd)
                        {
                            DialogResult userresponse = ShowMessageWResult(1);
                            if (userresponse == DialogResult.No || userresponse == DialogResult.Cancel) { break; }
                        }

                        var query1 = from c in doc.Element("Project").Element("Tasks").Elements("Task")
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

                        XElement new_task = new XElement("Task",
                                                new XElement("Id", indeks),
                                                new XElement("Name", taskName.Text),
                                                new XElement("Start_date", startDate.Text),
                                                new XElement("End_date", endDate.Text),
                                                new XElement("Description", description.Text),
                                                new XElement("Progress", "0"),
                                                new XElement("Budget", budgetValue.Value),
                                                new XElement("Members", "")
                                            );

                        foreach (var ff in listBox1.SelectedItems) 
                        {
                            //MessageBox.Show("selected: " + ff.ToString());//.ToString());
                            foreach (ListViewItem fs in listView1.Items)
                            {
                                //MessageBox.Show("in list: " + fs.Text + "\n id: " + fs.SubItems[1].Text);//.ToString());
                                if(ff.ToString()==fs.Text)
                                {
                                    new_task.Element("Members").Add(new XElement("Id", fs.SubItems[1].Text));
                                    break;
                                }
                            }
                        }

                        try
                        {
                            doc.Element("Project").Element("Tasks").Add(new_task);
                            doc.Save(project);
                            this.Close();
                            ShowMessage(1);
                            break;
                        }
                        catch (Exception)
                        {
                            ShowMessage(2);
                        }
                    }
                }
            }
        }

        private void ShowMessage(int messagenumb)
        {
            if (messagenumb == 0)
            {
                MessageBox.Show("You have to enter task start date and end date!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (messagenumb == 1)
            {
                MessageBox.Show("Task was created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (messagenumb == 2)
            {
                MessageBox.Show("Error occured during task creation. Task was NOT saved!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (messagenumb == 3)
            {
                MessageBox.Show("Task with this name already exists! Change task name to something else.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DialogResult ShowMessageWResult(int messagenumb) 
        {
            if (messagenumb == 0) 
            {
                DialogResult userresponse = MessageBox.Show("Start date of this task has been set before project's start date.\n Are you absolutely sure you want to continue?", "Start date conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return userresponse;
            }
            else if (messagenumb == 1)
            {
                DialogResult userresponse = MessageBox.Show("End date of this task has been set after project's end date.\n Are you absolutely sure you want to continue?", "End date conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return userresponse;
            }
            return DialogResult.Cancel;
        }
    }
}
