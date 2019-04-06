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
    public partial class TaskDetails : UserControl
    {
        public TaskDetails()
        {
            InitializeComponent();
        }

        public ListBox tempListBox1=new ListBox();

        public void SwitchFieldsReadOnly(int val) 
        {
            if (val == 0)
            {
                this.taskName.ReadOnly = false;
                this.startDate.ReadOnly = false;
                this.endDate.ReadOnly = false;
                this.description.ReadOnly = false;
                this.budgetValue.ReadOnly = false;
                this.progressBar.Enabled = true;

                this.tempListBox1.Items.Clear();
                //MessageBox.Show("" + this.listBox1.Items.Count);
                for (int i = 0; i < this.listBox1.Items.Count; i++ )
                { this.tempListBox1.Items.Add(listBox1.Items[i]); }
                this.listBox1.Items.Clear();
                this.listBox1.Enabled = true;

                this.startDate.Enter +=StartDateInput_Enter;
                this.endDate.Enter += EndDateInput_Enter;
            }
            else if (val == 1)
            {
                this.taskName.ReadOnly = true;
                this.startDate.ReadOnly = true;
                this.endDate.ReadOnly = true;
                this.description.ReadOnly = true;
                this.budgetValue.ReadOnly = true;
                this.progressBar.Enabled = false;

                this.listBox1.Items.Clear();
                //MessageBox.Show("" + this.listBox1.Items.Count);
                for (int i = 0; i < this.tempListBox1.Items.Count; i++)
                { this.listBox1.Items.Add(tempListBox1.Items[i]); }
                this.tempListBox1.Items.Clear();
                this.listBox1.Enabled = true;
                this.listView1.Items.Clear();

                this.startDate.Enter -= StartDateInput_Enter;
                this.endDate.Enter -= EndDateInput_Enter;
            }
        }

        /*private void trackBar1_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar1, trackBar1.Value.ToString());

        }*/

        public void GetMembersList(string projdir, string projname)
        {
            foreach (string project in Directory.EnumerateFiles(projdir, "*.xml"))
            {
                XDocument doc = XDocument.Load(project);

                string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                              select qr.Element("Name").Value).First();

                //Czy to ten projekt?
                if (projname == tpn)
                {

                    var query1 = from c in doc.Element("Project").Element("Members").Elements("Member")
                                 select c;

                    foreach (var fv in query1)
                    {
                        listView1.Items.Add(fv.Element("Last_name").Value + " " + fv.Element("First_name").Value).SubItems.Add(fv.Element("Id").Value);
                        listBox1.Items.Add(listView1.Items[listView1.Items.Count - 1].Text);
                    }
                }
            }
        }

        public void SelectMembersFromTask()
        {
            for (int i = 0; i < this.listBox1.Items.Count; i++ )
            {
                for (int j = 0; j < this.tempListBox1.Items.Count; j++) 
                {
                    //MessageBox.Show("" + this.listBox1.Items[i] + " " + this.tempListBox1.Items[j]);
                    if (this.listBox1.Items[i] == this.tempListBox1.Items[j]) { this.listBox1.SelectedItem = i; break; }
                }
            }
            
        }

        private void progressBar_Scroll(object sender, EventArgs e)
        {
            this.progressToolTip1.SetToolTip(this.progressBar, this.progressBar.Value.ToString());
        }

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

        /*public void EnableFields()
        {
            this.taskName.Enabled = true;
            this.startDate.Enabled = true;
            this.endDate.Enabled = true;
            this.description.Enabled = true;
            this.budgetValue.Enabled = true;
        }*/
       /* public ProjectName 
        {
            get { return projectName; }
        }*/
    }
}
