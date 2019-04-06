namespace DiplomaPMS
{
    partial class TaskList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskList1 = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ganttChart1 = new Braincase.GanttChart.Chart();
            this.taskDetails1 = new DiplomaPMS.TaskDetails();
            this.SuspendLayout();
            // 
            // taskList1
            // 
            this.taskList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.idColumn,
            this.startDateColumn,
            this.endDateColumn,
            this.progressColumn});
            this.taskList1.Location = new System.Drawing.Point(0, 0);
            this.taskList1.Name = "taskList1";
            this.taskList1.Size = new System.Drawing.Size(603, 357);
            this.taskList1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.taskList1.TabIndex = 3;
            this.taskList1.UseCompatibleStateImageBehavior = false;
            this.taskList1.View = System.Windows.Forms.View.Details;
            this.taskList1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnHeaderClick);
            this.taskList1.SelectedIndexChanged += new System.EventHandler(this.TaskListIndexChanged);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Task";
            this.nameColumn.Width = 118;
            // 
            // idColumn
            // 
            this.idColumn.Text = "ID";
            // 
            // startDateColumn
            // 
            this.startDateColumn.Text = "Start date";
            this.startDateColumn.Width = 67;
            // 
            // endDateColumn
            // 
            this.endDateColumn.Text = "End date";
            this.endDateColumn.Width = 59;
            // 
            // progressColumn
            // 
            this.progressColumn.Text = "Progress";
            this.progressColumn.Width = 58;
            // 
            // ganttChart1
            // 
            this.ganttChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttChart1.FullDateStringFormat = null;
            this.ganttChart1.Location = new System.Drawing.Point(0, 0);
            this.ganttChart1.Margin = new System.Windows.Forms.Padding(0);
            this.ganttChart1.Name = "ganttChart1";
            this.ganttChart1.Size = new System.Drawing.Size(1045, 357);
            this.ganttChart1.TabIndex = 40;
            this.ganttChart1.Visible = false;
            // 
            // taskDetails1
            // 
            this.taskDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskDetails1.AutoScroll = true;
            this.taskDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.taskDetails1.Location = new System.Drawing.Point(609, 0);
            this.taskDetails1.MaximumSize = new System.Drawing.Size(433, 1080);
            this.taskDetails1.Name = "taskDetails1";
            this.taskDetails1.Size = new System.Drawing.Size(433, 357);
            this.taskDetails1.TabIndex = 39;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.taskDetails1);
            this.Controls.Add(this.taskList1);
            this.Controls.Add(this.ganttChart1);
            this.Name = "TaskList";
            this.Size = new System.Drawing.Size(1045, 357);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView taskList1;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader startDateColumn;
        private System.Windows.Forms.ColumnHeader endDateColumn;
        private System.Windows.Forms.ColumnHeader progressColumn;
        private TaskDetails taskDetails1;
        private System.Windows.Forms.ColumnHeader idColumn;
        private Braincase.GanttChart.Chart ganttChart1;

    }
}
