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
    public partial class CreateMember : Form
    {
        private string projdir;
        private string projname;
        private string filename;

        public CreateMember(string globalmemberlistfile)
        {
            InitializeComponent();
            this.CreateButton.Click -= CreateButton_Click;
            this.CreateButton.Click += CreateGlobalButton_Click;
            this.filename = globalmemberlistfile;
        }

        public CreateMember(string projectdir, string projectname)
        {
            InitializeComponent();
            this.projdir = projectdir;
            this.projname = projectname;
            this.CreateButton.Click -= CreateGlobalButton_Click;
            //this.CreateButton.Click += CreateButton_Click;
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
            birthDate.Text = mcalendar.SelectionStart.ToString("dd/MM/yyyy");
        }

        private void calendar1_Leave(object sender, EventArgs e)
        {
            var mcalendar = sender as MonthCalendar;
            mcalendar.Visible = false;
            //monthCalendar1.Visible = false;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            /*if (this.taskName.Text == "" || this.taskName.Text == " ")
            {
                //ShowMessage(0);
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

                    //Czy to ten projekt?
                    if (this.projname == tpn)
                    {

                        var query1 = from c in doc.Element("Project").Element("Members").Elements("Member")
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

                        XElement new_member = new XElement("Member",
                                                new XElement("Id", indeks),
                                                new XElement("Global_id", ""),
                                                new XElement("First_name", firstName.Text),
                                                new XElement("Last_name", lastName.Text),
                                                new XElement("Birth_date", birthDate.Text),
                                                new XElement("Add_date", DateTime.Now.ToString("dd/MM/yyyy")),
                                                new XElement("Additional_Information", additionalInformation.Text),
                                                new XElement("Specialisation", specialisation.Text)
                                                //new XElement("Progress", "0"),
                                                //new XElement("Budget", budgetValue.Value),
                                                //new XElement("Members", "")
                                            );

                        try
                        {
                            doc.Element("Project").Element("Members").Add(new_member);
                            doc.Save(project);
                            this.Close();
                            //ShowMessage(1);//MessageBox.Show("Member was saved successfully!", "Information");
                            break;
                        }
                        catch (Exception someexc)
                        {
                            ShowMessage(0, someexc);
                        }
                    }
                }
            //}
        }

        private void CreateGlobalButton_Click(object sender, EventArgs e)
        {
            /*foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
            {*/
                XDocument doc = XDocument.Load(this.filename);

                    var query1 = from c in doc.Element("Global_member_list").Elements("Member")
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

                    XElement new_member = new XElement("Member",
                                            new XElement("Id", indeks),
                                            new XElement("First_name", firstName.Text),
                                            new XElement("Last_name", lastName.Text),
                                            new XElement("Birth_date", birthDate.Text),
                                            new XElement("Add_date", DateTime.Now.ToString("dd/MM/yyyy")),
                                            new XElement("Additional_Information", additionalInformation.Text),
                                            new XElement("Specialisation", specialisation.Text)
                                        );

                    try
                    {
                        doc.Element("Global_member_list").Add(new_member);
                        doc.Save(this.filename);
                        this.Close();
                        //break;
                    }
                    catch (Exception someexc)
                    {
                        ShowMessage(0, someexc);
                        this.Close();
                    }

            //}
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowMessage(int val, Exception e) 
        {
            if (val == 0) 
            {
                MessageBox.Show("Failed to to create new member - "+e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
