namespace Task_Manager_G1_LINQ_Files_
{
    partial class Personal_Task_Manager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTaskInput = new TextBox();
            btnAddTask = new Button();
            btnShowAllTasks = new Button();
            btnShowPendingTasks = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnMarkCompleted = new Button();
            listBoxTasks = new ListBox();
            SuspendLayout();
            // 
            // txtTaskInput
            // 
            txtTaskInput.Location = new Point(38, 24);
            txtTaskInput.Name = "txtTaskInput";
            txtTaskInput.Size = new Size(377, 31);
            txtTaskInput.TabIndex = 0;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(455, 24);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(170, 34);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnShowAllTasks
            // 
            btnShowAllTasks.Location = new Point(38, 72);
            btnShowAllTasks.Name = "btnShowAllTasks";
            btnShowAllTasks.Size = new Size(172, 34);
            btnShowAllTasks.TabIndex = 2;
            btnShowAllTasks.Text = "Show All Tasks";
            btnShowAllTasks.UseVisualStyleBackColor = true;
            btnShowAllTasks.Click += btnShowAllTasks_Click;
            // 
            // btnShowPendingTasks
            // 
            btnShowPendingTasks.Location = new Point(248, 75);
            btnShowPendingTasks.Name = "btnShowPendingTasks";
            btnShowPendingTasks.Size = new Size(167, 34);
            btnShowPendingTasks.TabIndex = 3;
            btnShowPendingTasks.Text = "Show Pending";
            btnShowPendingTasks.UseVisualStyleBackColor = true;
            btnShowPendingTasks.Click += btnShowPendingTasks_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(455, 74);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(287, 31);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(760, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(153, 34);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnMarkCompleted
            // 
            btnMarkCompleted.Location = new Point(20, 392);
            btnMarkCompleted.Name = "btnMarkCompleted";
            btnMarkCompleted.Size = new Size(212, 34);
            btnMarkCompleted.TabIndex = 6;
            btnMarkCompleted.Text = "Mark as Complete";
            btnMarkCompleted.UseVisualStyleBackColor = true;
            btnMarkCompleted.Click += btnMarkCompleted_Click;
            // 
            // listBoxTasks
            // 
            listBoxTasks.FormattingEnabled = true;
            listBoxTasks.ItemHeight = 25;
            listBoxTasks.Location = new Point(38, 133);
            listBoxTasks.Name = "listBoxTasks";
            listBoxTasks.Size = new Size(875, 229);
            listBoxTasks.TabIndex = 7;
            // 
            // Personal_Task_Manager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 450);
            Controls.Add(listBoxTasks);
            Controls.Add(btnMarkCompleted);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnShowPendingTasks);
            Controls.Add(btnShowAllTasks);
            Controls.Add(btnAddTask);
            Controls.Add(txtTaskInput);
            Name = "Personal_Task_Manager";
            Text = "Personal_Task_Manager";
            Load += Personal_Task_Manager_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTaskInput;
        private Button btnAddTask;
        private Button btnShowAllTasks;
        private Button btnShowPendingTasks;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnMarkCompleted;
        private ListBox listBoxTasks;
    }
}
