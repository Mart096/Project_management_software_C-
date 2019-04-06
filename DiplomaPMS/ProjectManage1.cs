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
    public partial class ProjectManage1 : UserControl
    {
        public mainWindow mainW=null;
        private string projname = null;
        private string projdir=null;

        public ProjectManage1()
        {
            InitializeComponent();
            //taskList1.ListItemSelected += new EventHandler(TaskListItemSelected);
        }

        public ProjectManage1(mainWindow mainWind,string projname, string projectsdir)
        {
            
            InitializeComponent();
            this.mainW = mainWind;
            this.projname = projname;
            this.projectName.Text = this.projname;
            this.projdir = projectsdir;

            this.panel2.AutoScroll = true;
            taskList1.Pass_data(this.projname, this.projdir);
            taskList1.Populate_list();
            memberList1.Pass_data(this.projname, this.projdir);
            memberList1.Populate_list();
            financesList1.Pass_data(this.projname, this.projdir);
            financesList1.Populate_list();
            resourceList1.Pass_data(this.projname, this.projdir);
            resourceList1.Populate_list();
            filesList1.Pass_data(this.projname, this.projdir);
            filesList1.Populate_list();
            riskList1.Pass_data(this.projname, this.projdir);
            riskList1.Populate_list();
            projectDetailsPanel1.PassData(this.projname, this.projdir);
            projectDetailsPanel1.Populate_fields();
            
            taskList1.ListItemSelected += new EventHandler<CustomEventArgs>(TaskButtonsSwitch);
            memberList1.ListItemSelected += new EventHandler<CustomEventArgs>(editMemberButtonSwitch);
            financesList1.ListItemSelected += new EventHandler<CustomEventArgs>(editFinancesButtonSwitch);
            resourceList1.ListItemSelected += new EventHandler<CustomEventArgs>(editResourcesButtonSwitch); 
            riskList1.ListItemSelected += new EventHandler<CustomEventArgs>(editRisksButtonSwitch);
            filesList1.ListItemSelected += new EventHandler<CustomEventArgs>(editFilesButtonSwitch); 
            this.Refresh();
        }

        //
        //Main Menu buttons
        //
        private void TasksButton_Click(object sender, EventArgs e)
        {
            this.taskList1.Visible = true;
            this.taskManagementButtonsPanel.Visible = true;
            this.projectDetailsPanel1.Visible = false;
            this.projectDetailsManagementPanel.Visible = false;
            this.memberList1.Visible = false;
            this.memberManagementPanel.Visible = false;
            this.financesList1.Visible = false;
            this.financesManagementPanel.Visible = false;
            this.resourceList1.Visible = false;
            this.resourceManagementPanel.Visible = false;
            this.riskList1.Visible = false;
            this.riskManagementPanel.Visible = false;
            this.filesList1.Visible = false;
            this.attachmentsManagementPanel.Visible = false;
        }

        private void MembersButton_Click(object sender, EventArgs e)
        {
            this.taskList1.Visible = false;
            this.taskManagementButtonsPanel.Visible = false;
            this.projectDetailsPanel1.Visible = false;
            this.projectDetailsManagementPanel.Visible = false;
            this.memberList1.Visible = true;
            this.memberManagementPanel.Visible = true;
            this.financesList1.Visible = false;
            this.financesManagementPanel.Visible = false;
            this.resourceList1.Visible = false;
            this.resourceManagementPanel.Visible = false;
            this.riskList1.Visible = false;
            this.riskManagementPanel.Visible = false;
            this.filesList1.Visible = false;
            this.attachmentsManagementPanel.Visible = false;
        }

        private void FinancesButton_Click(object sender, EventArgs e)
        {
            this.taskList1.Visible = false;
            this.taskManagementButtonsPanel.Visible = false;
            this.projectDetailsPanel1.Visible = false;
            this.projectDetailsManagementPanel.Visible = false;
            this.memberList1.Visible = false;
            this.memberManagementPanel.Visible = false;
            this.financesList1.Visible = true;
            this.financesManagementPanel.Visible = true;
            this.resourceList1.Visible = false;
            this.resourceManagementPanel.Visible = false;
            this.riskList1.Visible = false;
            this.riskManagementPanel.Visible = false;
            this.filesList1.Visible = false;
            this.attachmentsManagementPanel.Visible = false;
            this.financesList1.Populate_list();
        }

        private void ResourcesManageButton_Click(object sender, EventArgs e)
        {
            this.taskList1.Visible = false;
            this.taskManagementButtonsPanel.Visible = false;
            this.projectDetailsPanel1.Visible = false;
            this.projectDetailsManagementPanel.Visible = false;
            this.memberList1.Visible = false;
            this.memberManagementPanel.Visible = false;
            this.financesList1.Visible = false;
            this.financesManagementPanel.Visible = false;
            this.resourceList1.Visible = true;
            this.resourceManagementPanel.Visible = true;
            this.riskList1.Visible = false;
            this.riskManagementPanel.Visible = false;
            this.filesList1.Visible = false;
            this.attachmentsManagementPanel.Visible = false;
        }

        private void attachmentsButton_Click(object sender, EventArgs e)
        {
            this.taskList1.Visible = false;
            this.taskManagementButtonsPanel.Visible = false;
            this.projectDetailsPanel1.Visible = false;
            this.projectDetailsManagementPanel.Visible = false;
            this.memberList1.Visible = false;
            this.memberManagementPanel.Visible = false;
            this.financesList1.Visible = false;
            this.financesManagementPanel.Visible = false;
            this.resourceList1.Visible = false;
            this.resourceManagementPanel.Visible = false;
            this.riskList1.Visible = false;
            this.riskManagementPanel.Visible = false;
            this.filesList1.Visible = true;
            this.attachmentsManagementPanel.Visible = true;
        }

        private void RisksManagementButton_Click(object sender, EventArgs e)
        {
            this.taskList1.Visible = false;
            this.taskManagementButtonsPanel.Visible = false;
            this.projectDetailsPanel1.Visible = false;
            this.projectDetailsManagementPanel.Visible = false;
            this.memberList1.Visible = false;
            this.memberManagementPanel.Visible = false;
            this.financesList1.Visible = false;
            this.financesManagementPanel.Visible = false;
            this.resourceList1.Visible = false;
            this.resourceManagementPanel.Visible = false;
            this.riskList1.Visible = true;
            this.riskManagementPanel.Visible = true;
            this.filesList1.Visible = false;
            this.attachmentsManagementPanel.Visible = false;
        }

        private void ProjectDetailsButton_Click(object sender, EventArgs e)
        {
            this.taskList1.Visible = false;
            this.taskManagementButtonsPanel.Visible = false;
            this.projectDetailsPanel1.Visible = true;
            this.projectDetailsManagementPanel.Visible = true;
            this.memberList1.Visible = false;
            this.memberManagementPanel.Visible = false;
            this.financesList1.Visible = false;
            this.financesManagementPanel.Visible = false;
            this.resourceList1.Visible = false;
            this.resourceManagementPanel.Visible = false;
            this.riskList1.Visible = false;
            this.riskManagementPanel.Visible = false;
            this.filesList1.Visible = false;
            this.attachmentsManagementPanel.Visible = false;
        }

        private void ProjectListButton_Click(object sender, EventArgs e)
        {
            mainW.openProjectList1(mainW);
            this.Visible = false;
        }
        //
        //
        //

        //
        //Metody dla przycisków działających z listą zadań (task list)
        //
        /*void TaskListItemSelected(object sender, EventArgs e) 
        {
            
            
        }*/

        public void TaskButtonsSwitch(object sender, CustomEventArgs e) 
        {

            if (e.Buttonval == 0)
            {
                //if(taskList1.){}
                this.TaskEditButton.Enabled = false;
                this.TaskDeleteButton.Enabled = false;
            }
            else if (e.Buttonval == 1)
            {
                this.TaskEditButton.Enabled = true;
                this.TaskDeleteButton.Enabled = true;
            }
        }
        
        private void TaskCreateButton_Click(object sender, EventArgs e)
        {
            /*TaskList tsklst = new TaskList(this.projname, this.projdir);
            tsklst.create_new_button_Click(sender, e);*/ //działa ale nie mam pewności czy to dobre rozwiązanie
            this.taskList1.create_new_button_Click(sender, e);

        }

        private void TaskEditButton_Click(object sender, EventArgs e)
        {
            this.TaskEditButton.Visible = false;
            this.TaskEditButton.Enabled = false;
            this.saveTaskDetChangesButton.Enabled = true;
            this.cancelTaskDetChangesButton.Enabled = true;
            this.saveTaskDetChangesButton.Visible = true;
            this.cancelTaskDetChangesButton.Visible = true;
            
            this.TaskCreateButton.Enabled = false;
            this.TaskDeleteButton.Enabled = false;
            this.TaskListViewButton.Enabled = false;
            this.TaskGanttChartButton.Enabled = false;

            this.TaskListViewButton.Enabled = false;
            this.TaskListAndDetailsButton.Enabled = false;
            this.TaskGanttChartButton.Enabled = false;

            taskList1.EditButton_Click();
        }
        private void saveTaskDetChangesButton_Click(object sender, EventArgs e)
        {
            this.TaskEditButton.Visible = true;
            this.TaskEditButton.Enabled = true;
            this.saveTaskDetChangesButton.Enabled = false;
            this.cancelTaskDetChangesButton.Enabled = false;
            this.saveTaskDetChangesButton.Visible = false;
            this.cancelTaskDetChangesButton.Visible = false;
            
            this.TaskCreateButton.Enabled = true;
            this.TaskDeleteButton.Enabled = true;
            this.TaskListViewButton.Enabled = true;
            this.TaskGanttChartButton.Enabled = true;

            this.TaskListViewButton.Enabled = true;
            this.TaskListAndDetailsButton.Enabled = true;
            this.TaskGanttChartButton.Enabled = true;

            taskList1.SaveChanges();
            taskList1.Populate_list();
        }
        private void cancelTaskDetChangesButton_Click(object sender, EventArgs e)
        {
            this.TaskEditButton.Visible = true;
            this.TaskEditButton.Enabled = true;
            this.saveTaskDetChangesButton.Enabled = false;
            this.cancelTaskDetChangesButton.Enabled = false;
            this.saveTaskDetChangesButton.Visible = false;
            this.cancelTaskDetChangesButton.Visible = false;

            this.TaskCreateButton.Enabled = true;
            this.TaskDeleteButton.Enabled = true;
            this.TaskListViewButton.Enabled = true;
            this.TaskGanttChartButton.Enabled = true;

            this.TaskListViewButton.Enabled = true;
            this.TaskListAndDetailsButton.Enabled = true;
            this.TaskGanttChartButton.Enabled = true;

            taskList1.CancelEdit();
        }

        private void TaskDeleteButton_Click(object sender, EventArgs e)
        {
            this.taskList1.DeleteTask();
        }

        private void TaskListViewButton_Click(object sender, EventArgs e)
        {
            this.taskList1.ViewVariant(0);
        }

        private void TaskListAndDetailsButton_Click(object sender, EventArgs e)
        {
            this.taskList1.ViewVariant(1);
        }

        private void TaskGanttChartButton_Click(object sender, EventArgs e)
        {
            this.taskList1.ViewVariant(2);
        }
        //
        //
        //
        //
        //Project details buttons
        //
        private void editProjectDetailsButton_Click(object sender, EventArgs e)
        {
            projectDetailsPanel1.EnableEdit();
            this.editProjectDetailsButton.Enabled = false;
            this.editProjectDetailsButton.Visible = false;
            this.saveChangesProjDetButton.Enabled = true;
            this.saveChangesProjDetButton.Visible = true;
            this.cancelProjDetChangesButton.Enabled = true;
            this.cancelProjDetChangesButton.Visible = true;
        }

        private void saveChangesProjDetButton_Click(object sender, EventArgs e)
        {
            projectDetailsPanel1.Save_changes();
            this.ProjectListButton_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)//cancelProjDetailsChangeButton
        {
            projectDetailsPanel1.CancelChanges();
            this.editProjectDetailsButton.Enabled = true;
            this.editProjectDetailsButton.Visible = true;
            this.saveChangesProjDetButton.Enabled = false;
            this.saveChangesProjDetButton.Visible = false;
            this.cancelProjDetChangesButton.Enabled = false;
            this.cancelProjDetChangesButton.Visible = false;
        }
        //
        //
        //
        //
        //Przyciski do zarządzania listą pracowników/członków zespołu roboczego (members list)
        //
        private void CreateNewMemberButton_Click(object sender, EventArgs e)
        {
            this.memberList1.CreateNewMember();
        }

        private void addMemberFromGListButton_Click(object sender, EventArgs e)
        {
            MemberGlobalList mgloblist = new MemberGlobalList();
            mgloblist.Pass_data(AppDomain.CurrentDomain.BaseDirectory, this.projname, this.projdir);
            mgloblist.ShowDialog();
            mgloblist.Tag = this;
            this.memberList1.Populate_list();
        }

        private void editMemberButtonSwitch(object sender, CustomEventArgs e) 
        {
            if (e.Buttonval == 0)
            {
                this.editMemberButton.Enabled = false;
                this.memberDeleteButton.Enabled = false;
            }
            else if (e.Buttonval == 1)
            { 
                this.editMemberButton.Enabled = true;
                this.memberDeleteButton.Enabled = true;
            }
        }

        private void editMemberButton_Click(object sender, EventArgs e)
        {
            this.CreateNewMemberButton.Enabled = false;
            this.addMemberFromGListButton.Enabled = false;
            this.editMemberButton.Enabled = false;
            this.editMemberButton.Visible = false;
            this.memberDeleteButton.Enabled = false;
            this.memberDetSaveChangesButton.Enabled = true;
            this.memberDetSaveChangesButton.Visible = true;
            this.memberDetCancelEditButton.Enabled = true;
            this.memberDetCancelEditButton.Visible = true;
            this.memberList1.EditModeSwitch(1);
        }

        private void memberDetSaveChangesButton_Click(object sender, EventArgs e)
        {
            this.CreateNewMemberButton.Enabled = true;
            this.addMemberFromGListButton.Enabled = true;
            this.editMemberButton.Enabled = true;
            this.editMemberButton.Visible = true;
            this.memberDeleteButton.Enabled = true;
            this.memberDetSaveChangesButton.Enabled = false;
            this.memberDetSaveChangesButton.Visible = false;
            this.memberDetCancelEditButton.Enabled = false;
            this.memberDetCancelEditButton.Visible = false;
            this.memberList1.SaveChanges();
            this.memberList1.EditModeSwitch(0);
        }

        private void memberDetCancelEditButton_Click(object sender, EventArgs e)
        {
            this.CreateNewMemberButton.Enabled = true;
            this.addMemberFromGListButton.Enabled = true;
            this.editMemberButton.Enabled = true;
            this.editMemberButton.Visible = true;
            this.memberDeleteButton.Enabled = true;
            this.memberDetSaveChangesButton.Enabled = false;
            this.memberDetSaveChangesButton.Visible = false ;
            this.memberDetCancelEditButton.Enabled = false;
            this.memberDetCancelEditButton.Visible = false;
            this.memberList1.EditModeSwitch(0);
        }

        private void memberDeleteButton_Click(object sender, EventArgs e)
        {
            this.memberList1.DeleteMember();
        }
        //
        //
        //
        //
        //Finanse (Finances)
        //
        private void financesCreateButton_Click(object sender, EventArgs e)
        {
            this.financesList1.CreateNewMember();
        }

        private void editFinancesButton_Click(object sender, EventArgs e)
        {
            this.financesCreateButton.Enabled = false;
            this.financesEditButton.Enabled = false;
            this.financesEditButton.Visible = false;
            this.financesEntryDeleteButton.Enabled = false;
            this.financesSaveChangesButton.Enabled = true;
            this.financesSaveChangesButton.Visible = true;
            this.financesCancelButton.Enabled = true;
            this.financesCancelButton.Visible = true;
            this.financesList1.EditModeSwitch(1);
        }

        private void editFinancesButtonSwitch(object sender, CustomEventArgs e)
        {
            if (e.Buttonval == 0)
            {
                this.financesEditButton.Enabled = false;
                this.financesEntryDeleteButton.Enabled = false;
            }
            else if (e.Buttonval == 1)
            { 
                this.financesEditButton.Enabled = true;
                this.financesEntryDeleteButton.Enabled = true;
            }
        }

        private void financesSaveChangesButton_Click(object sender, EventArgs e)
        {
            this.financesCreateButton.Enabled = true;
            this.financesEditButton.Enabled = true;
            this.financesEditButton.Visible = true;
            this.financesEntryDeleteButton.Enabled = true;
            this.financesSaveChangesButton.Enabled = false;
            this.financesSaveChangesButton.Visible = false;
            this.financesCancelButton.Enabled = false;
            this.financesCancelButton.Visible = false;
            this.financesList1.SaveChanges();
            this.financesList1.EditModeSwitch(0);
        }

        private void financesCancelButton_Click(object sender, EventArgs e)
        {
            this.financesCreateButton.Enabled = true;
            this.financesEditButton.Enabled = true;
            this.financesEditButton.Visible = true;
            this.financesEntryDeleteButton.Enabled = true;
            this.financesSaveChangesButton.Enabled = false;
            this.financesSaveChangesButton.Visible = false;
            this.financesCancelButton.Enabled = false;
            this.financesCancelButton.Visible = false;
            this.financesList1.EditModeSwitch(0);
        }

        private void financesEntryDeleteButton_Click(object sender, EventArgs e)
        {
            this.financesList1.DeleteFinanceEntry();
        }
        //
        //
        //
        //
        //Zasoby (resources)
        //
        private void createResourceButton_Click(object sender, EventArgs e)
        {
            this.resourceList1.CreateNewResource();
        }

        private void editResourceButton_Click(object sender, EventArgs e)
        {
            this.createResourceButton.Enabled = false;
            this.editResourceButton.Enabled = false;
            this.editResourceButton.Visible = false;
            this.deleteResourceButton.Enabled = false;
            this.saveResourceChangesButton.Enabled = true;
            this.saveResourceChangesButton.Visible = true;
            this.cancelResourceChangesButton.Enabled = true;
            this.cancelResourceChangesButton.Visible = true;
            this.resourceList1.EditModeSwitch(1);
        }

        private void deleteResourceButton_Click(object sender, EventArgs e)
        {
            this.resourceList1.DeleteResource();
        }

        private void saveResourceChangesButton_Click(object sender, EventArgs e)
        {
            this.createResourceButton.Enabled = true;
            this.editResourceButton.Enabled = true;
            this.editResourceButton.Visible = true;
            this.deleteResourceButton.Enabled = true;
            this.saveResourceChangesButton.Enabled = false;
            this.saveResourceChangesButton.Visible = false;
            this.cancelResourceChangesButton.Enabled = false;
            this.cancelResourceChangesButton.Visible = false;
            this.resourceList1.SaveChanges();
            this.resourceList1.EditModeSwitch(0);
        }

        private void cancelResourceChangesButton_Click(object sender, EventArgs e)
        {
            this.createResourceButton.Enabled = true;
            this.editResourceButton.Enabled = true;
            this.editResourceButton.Visible = true;
            this.deleteResourceButton.Enabled = true;
            this.saveResourceChangesButton.Enabled = false;
            this.saveResourceChangesButton.Visible = false;
            this.cancelResourceChangesButton.Enabled = false;
            this.cancelResourceChangesButton.Visible = false;
            this.resourceList1.EditModeSwitch(0);
        }

        private void editResourcesButtonSwitch(object sender, CustomEventArgs e)
        {
            if (e.Buttonval == 0)
            {
                this.editResourceButton.Enabled = false;
                this.deleteResourceButton.Enabled = false;
            }
            else if (e.Buttonval == 1)
            {
                this.editResourceButton.Enabled = true;
                this.deleteResourceButton.Enabled = true;
            }
        }
        //
        //
        //
   
        //
        //Ryzyko (risk)
        //
        private void riskCreateButton_Click(object sender, EventArgs e)
        {
            this.riskList1.CreateNewRisk();
        }

        private void riskEditButton_Click(object sender, EventArgs e)
        {
            this.riskCreateButton.Enabled = false;
            this.riskEditButton.Enabled = false;
            this.riskEditButton.Visible = false;
            this.riskDeleteButton.Enabled = false;
            this.riskSaveChangesButton.Enabled = true;
            this.riskSaveChangesButton.Visible = true;
            this.riskCancelChangesButton.Enabled = true;
            this.riskCancelChangesButton.Visible = true;
            this.riskList1.EditModeSwitch(0);
        }

        private void riskDeleteButton_Click(object sender, EventArgs e)
        {
            this.riskList1.DeleteRisk();
        }

        private void riskSaveChangesButton_Click(object sender, EventArgs e)
        {
            this.riskCreateButton.Enabled = true;
            this.riskEditButton.Enabled = true;
            this.riskEditButton.Visible = true;
            this.riskDeleteButton.Enabled = true;
            this.riskSaveChangesButton.Enabled = false;
            this.riskSaveChangesButton.Visible = false;
            this.riskCancelChangesButton.Enabled = false;
            this.riskCancelChangesButton.Visible = false;
            this.riskList1.SaveChanges();
            this.riskList1.EditModeSwitch(0);
        }

        private void riskCancelChangesButton_Click(object sender, EventArgs e)
        {
            this.riskCreateButton.Enabled = true;
            this.riskEditButton.Enabled = true;
            this.riskEditButton.Visible = true;
            this.riskDeleteButton.Enabled = true;
            this.riskSaveChangesButton.Enabled = false;
            this.riskSaveChangesButton.Visible = false;
            this.riskCancelChangesButton.Enabled = false;
            this.riskCancelChangesButton.Visible = false;
            this.riskList1.EditModeSwitch(0);
        }

        private void editRisksButtonSwitch(object sender, CustomEventArgs e)
        {
            if (e.Buttonval == 0)
            {
                this.riskEditButton.Enabled = false;
                this.riskDeleteButton.Enabled = false;
            }
            else if (e.Buttonval == 1)
            {
                this.riskEditButton.Enabled = true;
                this.riskDeleteButton.Enabled = true;
            }
        }
        //
        //
        //
        //
        //Pliki (Files)
        //
        private void readFileButton_Click(object sender, EventArgs e)
        {
            this.filesList1.OpenFileUsingDefaultApp(filesList1.current_path, filesList1.current_filename);
        }

        private void openExplorerButton_Click(object sender, EventArgs e)
        {
            this.filesList1.OpenDirectoryinExplorer(filesList1.current_path);
        }

        private void editFilesButtonSwitch(object sender, CustomEventArgs e)
        {
            if (e.Buttonval == 0) 
            { 
                this.readFileButton.Enabled = false;
                this.openExplorerButton.Enabled = false;
            }
            else if (e.Buttonval == 1) 
            {
                this.readFileButton.Enabled = true;
                this.openExplorerButton.Enabled = true;
            }
            //throw new NotImplementedException();
        }
        //
        //
        //
    }
}
