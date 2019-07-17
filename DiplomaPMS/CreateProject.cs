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
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace DiplomaPMS
{
    public partial class CreateProject : Form
    {

        //private MonthCalendar mcalender = new MonthCalendar();
        private string projdir;
        private double duplicateProjTimeLength;
        private string projname;
        private string ppath;

        public CreateProject(string projdir)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            InitializeComponent();
            this.projdir = projdir;
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar2.MaxSelectionCount = 1;

            monthCalendar1.DateSelected -= calendar1DuplicateProject_DateSelected;
            monthCalendar1.DateSelected += calendar1_DateSelected;
            CreateButton.Click -= CreateDuplicate_Click;
            //CreateButton.Click += CreateButton_Click;
        }

        public CreateProject(string projdir, string projectname)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            InitializeComponent();
            this.projdir = projdir;
            this.projname = projectname;

            /*foreach(var project in Directory.EnumerateFiles(this.projdir, ".xml"))
            {
                XDocument doc = XDocument.Load(project);

                string tpname = (from result in doc.Element("Project").Element("Project_details").Elements("Name")
                                select result).First().ToString();
                MessageBox.Show("" + project);
                if (this.projname == tpname) {  }
            }*/
            //MessageBox.Show("" + this.projdir);

            monthCalendar1.MaxSelectionCount = 1;

            monthCalendar1.DateSelected -= calendar1_DateSelected;
            monthCalendar1.DateSelected += calendar1DuplicateProject_DateSelected;
            CreateButton.Click -= CreateButton_Click;
            CreateButton.Click += CreateDuplicate_Click;
            endDate.Enabled = false;
            this.DuplicateProjectFillData();
        }

        //Start date input
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
            startDate.Text = mcalendar.SelectionStart.ToString("dd/MM/yyyy");
            //DateTime tempdate = new DateTime(mcalendar.SelectionStart.Year, mcalendar.SelectionStart.Month, mcalendar.SelectionStart.Day);
            //startDate.Text = //tempdate.ToString("dd/MM/yyyy");

        }

        private void calendar1DuplicateProject_DateSelected(object sender, DateRangeEventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            startDate.Text = mcalendar.SelectionStart.ToString("dd/MM/yyyy");
            DateTime tempdate = mcalendar.SelectionStart.Date;
            endDate.Text = tempdate.AddDays(duplicateProjTimeLength).ToString("dd/MM/yyyy");
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
            endDate.Text = mcalendar.SelectionStart.ToString("dd/MM/yyyy");
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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (this.projectName.Text == "")
            {
                ShowMessage(0);
            }
            else if (this.startDate.MaskCompleted == false || this.endDate.MaskCompleted == false)
            {
                ShowMessage(4);
            }
            else
            {

                DateTime tempsd = DateTime.Today;// = DateTime.ParseExact(this.startDate.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pl-PL")); //CultureInfo.CurrentCulture
                DateTime temped = DateTime.Today;// = DateTime.ParseExact(this.endDate.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pl-PL"));

                try
                {
                    tempsd = DateTime.ParseExact(this.startDate.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture); //CultureInfo.CurrentCulture
                    temped = DateTime.ParseExact(this.endDate.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                }
                catch (FormatException)
                {
                    ShowMessage(6);
                    tempsd = DateTime.Today;
                    temped = DateTime.Today.AddDays(1);
                }

                if (tempsd.Date < temped.Date)
                {

                    if (!File.Exists(projdir + "\\" + projectName.Text + ".xml"))
                    {
                        XDeclaration ddeclaration = new XDeclaration("1.0", "UTF-8", "yes");
                        XDocument doc = new XDocument(ddeclaration,
                                    new XElement("Project",
                                        new XElement("Project_details",
                                            new XElement("Name", projectName.Text),
                                            new XElement("Start_date", startDate.Text),
                                            new XElement("End_date", endDate.Text),
                                            new XElement("Description", description.Text),
                                            new XElement("Customer_name", customerName.Text),
                                            new XElement("Customer_address", customerAddress.Text),
                                            new XElement("Customer_telephone", customersTelephone.Text),
                                            new XElement("Customer_email", customerEmail.Text),
                                            new XElement("Budget", budgetValue.Value),
                                            new XElement("Status", "New")),
                                        new XElement("Tasks"),
                                        new XElement("Members"),
                                        new XElement("Finances",
                                            new XElement("Costs")),
                                        new XElement("Resources"),
                                        new XElement("Risks")
                                    )

                            );

                        try
                        {
                            doc.Save(projdir + "\\" + projectName.Text + ".xml");
                            this.Close();
                            ShowMessage(1);//MessageBox.Show("Project was saved successfully!", "Information");
                        }
                        catch (Exception)
                        {
                            ShowMessage(2);// MessageBox.Show("Error occured during project creation. Project was NOT saved!", "Warning!");
                        }
                    }
                    else
                    {
                        ShowMessage(3);//MessageBox.Show("Project with this name already exists! Change project\'s name to something else.", "Warning!");
                    }
                }
                else { ShowMessage(5); }
            }
        }

        private void CreateDuplicate_Click(object sender, EventArgs e)
        {
            if (this.projectName.Text == "")
            {
                ShowMessage(0);
            }
            else
            {
                if (!File.Exists(projdir + "\\" + projectName.Text + ".xml"))
                {
                    XDocument doc = XDocument.Load(this.ppath);

                    var query = from result in doc.Element("Project").Elements("Project_details")
                                select result;
                    var query1 = from result in doc.Element("Project").Element("Tasks").Elements("Task")
                                 select result;
                    /*var query2 = from result in doc.Element("Project").Element("Members").Elements("Member")
                                 select result;
                    var query3 = from result in doc.Element("Project").Element("Finances").Elements("Finance")
                                 select result;
                    var query4 = from result in doc.Element("Project").Element("Resources").Elements("Resource")
                                 select result;
                    var query5 = from result in doc.Element("Project").Element("Risks").Elements("Risk")
                                 select result;*/

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
                    query.Elements("Status").First().Value = "New";

                    foreach (var task in query1)
                    {
                        DateTime tempstartd = Convert.ToDateTime(task.Element("Start_date").Value);
                        DateTime tempendd = Convert.ToDateTime(task.Element("End_date").Value);
                        double start_end = (tempendd.Date - tempstartd.Date).TotalDays;
                        //MessageBox.Show("" + tempstartd + " (" + start_end + ") " + tempendd);
                        tempstartd = tempstartd.AddDays(this.duplicateProjTimeLength);
                        tempendd = tempstartd.AddDays(start_end);
                        task.Element("Start_date").Value = tempstartd.ToString("dd/MM/yyyy");
                        task.Element("End_date").Value = tempendd.ToString("dd/MM/yyyy");
                        task.Element("Progress").Value = "0";
                        //MessageBox.Show("" + tempstartd + " (" + start_end + ") " + tempendd);
                    }

                    try
                    {
                        doc.Save(projdir + "\\" + projectName.Text + ".xml");
                        this.Close();
                        ShowMessage(1);//MessageBox.Show("Project was saved successfully!", "Information");
                    }
                    catch (Exception)
                    {
                        ShowMessage(2);// MessageBox.Show("Error occured during project creation. Project was NOT saved!", "Warning!");
                    }
                }
                else
                {
                    ShowMessage(3);//MessageBox.Show("Project with this name already exists! Change project\'s name to something else.", "Warning!");
                }
            }
        }

        /*protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Focus();
        }*/

        private void DuplicateProjectFillData()
        {
            foreach (var project in Directory.EnumerateFiles(this.projdir, "*.xml"))
            {
                XDocument doc = XDocument.Load(project);

                string tpname = (from qr in doc.Element("Project").Descendants("Project_details")
                                 select qr.Element("Name").Value).First();

                //MessageBox.Show(""+ this.projname +" "+ tpname);
                if (this.projname == tpname)
                {
                    this.ppath = project;
                    var query = (from result in doc.Element("Project").Elements("Project_details")
                                 select result).First();
                    this.duplicateProjTimeLength = ((Convert.ToDateTime(query.Element("End_date").Value)).Date - (Convert.ToDateTime(query.Element("Start_date").Value)).Date).TotalDays;

                    this.projectName.Text = query.Element("Name").Value;
                    this.startDate.Text = query.Element("Start_date").Value;
                    this.endDate.Text = query.Element("End_date").Value;
                    this.description.Text = query.Element("Description").Value;
                    this.customerName.Text = query.Element("Customer_name").Value;
                    this.customerAddress.Text = query.Element("Customer_address").Value;
                    this.customersTelephone.Text = query.Element("Customer_telephone").Value;
                    this.customerEmail.Text = query.Element("Customer_email").Value;
                    this.budgetValue.Value = Convert.ToDecimal(query.Element("Budget").Value);
                    break;
                }
            }



        }

        private void ShowMessage(int messagenumb)
        {
            if (messagenumb == 0)
            {
                MessageBox.Show("You have to enter project name!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (messagenumb == 1)
            {
                MessageBox.Show("Project was saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (messagenumb == 2)
            {
                MessageBox.Show("Error occured during project creation. Project was NOT saved!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (messagenumb == 3)
            {
                MessageBox.Show("Project with this name already exists! Change project\'s name to something else.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (messagenumb == 4)
            {
                MessageBox.Show("You have to enter start date and end date.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (messagenumb == 5)
            {
                MessageBox.Show("Project's end date has been set before the start date. End date must be set after start date.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (messagenumb == 6)
            {
                MessageBox.Show("Project's start date or end date has wrong format! Change start/end date to value compatible with gregorian calendar. Temporary values were filled instead.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
