using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class FilesList : UserControl
    {
        private string projdir = null;
        private string projname = null;
        //private string currentID = null;
        public string current_filename;
        public string current_path;
        public event EventHandler<CustomEventArgs> ListItemSelected;

        public FilesList()
        {
            InitializeComponent();
            //taskDetails1.SwitchFieldsReadOnly(1);
        }

        public void Pass_data(string projectname, string projectdir)
        {
            this.projname = projectname;
            this.projdir = projectdir;
        }

        public void Populate_list()
        {
            fileList1.Items.Clear();

            try
            {
                foreach (string project in Directory.EnumerateFiles(this.projdir, "*.xml"))
                {
                    XDocument doc = XDocument.Load(project);

                    var currPName = (from xml in doc.Element("Project").Descendants("Project_details")
                                     select xml.Element("Name").Value).First();

                    if (currPName == projname)
                    {
                        string projfilename = project.Remove((project.Length - 4), 4);

                        if (!Directory.Exists(projfilename)) 
                        {
                            Directory.CreateDirectory(projfilename);
                        }
                        //currentDirectory.Text = projfilename;


                        string[] files = Directory.GetFiles(projfilename, "*", SearchOption.AllDirectories);
                            foreach (string file in files)
                            {

                                string fileName = Path.GetFileName(file);
                                ListViewItem item = new ListViewItem(fileName);
                                string dircoord = file.Remove((file.Length - item.Text.Length), item.Text.Length);

                                fileList1.Items.Add(item).SubItems.Add(dircoord);

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

        public void OpenFileUsingDefaultApp(string path, string filename) 
        {
            string filecont;// = File.ReadAllText(path + filename);
            using (StreamReader streamReader = new StreamReader(path+filename, Encoding.UTF8))
            {
                filecont = streamReader.ReadToEnd();
            }
            try
            {
                Process.Start(path + filename);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to open selected file - " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void OpenDirectoryinExplorer(string path) 
        {
            Process.Start(path);
        }

        private void ListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.fileList1.SelectedItems.Count != 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(0));
                this.current_filename = null;
                this.current_path = null;

            }
            else if (this.fileList1.SelectedItems.Count == 1)
            {
                if (this.ListItemSelected != null)
                    ListItemSelected(sender, new CustomEventArgs(1));

                //Sprawdzanie indeksu zaznaczonego zadania

                this.current_path = this.fileList1.SelectedItems[0].SubItems[1].Text;
                this.current_filename = this.fileList1.SelectedItems[0].Text;
            }
        }

        public void ShowMessage(int val, Exception e)
        {
            if (val == 0)
            {
                MessageBox.Show("Failed to load files - directory not found", "Warning!");
            }
            else if (val == 1)
            {
                MessageBox.Show("Failed to load files - XML error related", "Warning!");
            }
            else if (val == 2)
            {
                MessageBox.Show("Failed to load files - " + e.Message, "Warning!");
            }
        }

        public DialogResult ShowMessageWResult(int val)
        {
            if (val == 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this file?", "Delete file!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }

        
    }
}