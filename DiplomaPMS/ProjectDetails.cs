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
    public partial class ProjectDetails : UserControl
    {
        private string projdir;// { get { return projdir; } set { this.projdir = value; } }
        private string projname;// { get { return projname; } set { this.projname = value; } }

        public ProjectDetails()
        {
            InitializeComponent();
        }

        public void PassData(string projectname, string projectdir)
        {
            this.projdir = projectdir;
            this.projname = projectname;
        }

        public void CancelChanges() 
        {
            this.projectName.ReadOnly = true;
            this.startDate.ReadOnly = true;
            this.endDate.ReadOnly = true;
            this.description.ReadOnly = true;
            this.customerName.ReadOnly = true;
            this.customerAddress.ReadOnly = true;
            this.customersTelephone.ReadOnly = true;
            this.customerEmail.ReadOnly = true;
            this.budgetValue.ReadOnly = true;
           // this.projectStatus.Visible = true;
            this.statusBox.Visible = false;
            this.startDate.Enter -= StartDateInput_Enter;
            this.endDate.Enter -= EndDateInput_Enter;
            this.Populate_fields();
        }

        public void EnableEdit()
        {
            this.projectName.ReadOnly = false;
            this.startDate.ReadOnly = false;
            this.endDate.ReadOnly = false;
            this.description.ReadOnly = false;
            this.customerName.ReadOnly = false;
            this.customerAddress.ReadOnly = false;
            this.customersTelephone.ReadOnly = false;
            this.customerEmail.ReadOnly = false;
            this.budgetValue.ReadOnly = false;
            this.projectStatus.ReadOnly = true;
            this.statusBox.Visible = true;
            this.startDate.Enter += StartDateInput_Enter;
            this.endDate.Enter += EndDateInput_Enter;
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

        private void calendar_Leave(object sender, EventArgs e)
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

        public void Populate_fields() 
        {
            foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
            {
                XDocument doc = XDocument.Load(project);

                string tpn = (from qr in doc.Element("Project").Descendants("Project_details")
                              select qr.Element("Name").Value).First();

                if (this.projname == tpn)
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
                        //this.statusBox.
                        this.projectStatus.Text = fv.Element("Status").Value;
                        
                        int i=0;
                        while (i< this.statusBox.Items.Count) 
                        {
                            if(this.statusBox.Items[i].ToString()==this.projectStatus.Text)
                            {
                                this.statusBox.ClearSelected();
                                this.statusBox.SetSelected(i, true);
                                break;
                            }
                            i += 1;
                        }
                    }
                }
            }
        }


        public void Save_changes()
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
                        var query = from result in doc.Element("Project").Elements("Project_details")
                                    select result;

                        string projfilename = project.Remove((project.Length - 4), 4);                        

                        //doc.Element("Project").Element("Project_details").Element("Name").Value=this.projectName.Text;
                        query.Elements("Name").First().Value = this.projectName.Text;
                        query.Elements("Start_date").First().Value = this.startDate.Text;
                        query.Elements("End_date").First().Value = this.endDate.Text;

                        query.Elements("Description").First().Value = this.description.Text;
                        query.Elements("Customer_name").First().Value = this.customerName.Text;
                        query.Elements("Customer_address").First().Value = this.customerAddress.Text;
                        query.Elements("Customer_telephone").First().Value = this.customersTelephone.Text;
                        query.Elements("Customer_email").First().Value = this.customerEmail.Text;
                        query.Elements("Budget").First().Value = Convert.ToString(this.budgetValue.Value);
                        query.Elements("Status").First().Value = this.statusBox.Items[this.statusBox.SelectedIndex].ToString();
                        //query.Elements("Status").First().Value = this.projectStatus.Text;

                        doc.Save(project);
                        ShowMessage(0, null);
                        break;
                    }
                }
            }
            catch (XmlException e) { ShowMessage(0, e); }
            catch (Exception e) { ShowMessage(1, e); }
        }

        private void ShowMessage(int val, Exception e) 
        {
            if (val == 0) { MessageBox.Show("Changes in project details were saved successfully." + e, "Changes saved!", MessageBoxButtons.OK, MessageBoxIcon.None); }
            else if (val == 1) { MessageBox.Show("Failed to change project details - XML related error.\n" + e, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (val == 2) {MessageBox.Show("Failed to change project details.\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
