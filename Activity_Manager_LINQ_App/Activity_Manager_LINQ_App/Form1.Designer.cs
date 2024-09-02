namespace Activity_Manager_LINQ_App
{
    partial class Form1
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
            listBoxActivities = new ListBox();
            comboBoxCategory = new ComboBox();
            buttonDisplayAll = new Button();
            buttonFilter = new Button();
            buttonFindLongest = new Button();
            buttonCalculateTotal = new Button();
            labelLongestActivity = new Label();
            labelTotalDuration = new Label();
            SuspendLayout();
            // 
            // listBoxActivities
            // 
            listBoxActivities.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxActivities.FormattingEnabled = true;
            listBoxActivities.ItemHeight = 32;
            listBoxActivities.Location = new Point(317, 66);
            listBoxActivities.Name = "listBoxActivities";
            listBoxActivities.Size = new Size(565, 356);
            listBoxActivities.TabIndex = 0;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(45, 66);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(182, 40);
            comboBoxCategory.TabIndex = 1;
            // 
            // buttonDisplayAll
            // 
            buttonDisplayAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDisplayAll.Location = new Point(45, 156);
            buttonDisplayAll.Name = "buttonDisplayAll";
            buttonDisplayAll.Size = new Size(191, 49);
            buttonDisplayAll.TabIndex = 2;
            buttonDisplayAll.Text = "Display All";
            buttonDisplayAll.UseVisualStyleBackColor = true;
            buttonDisplayAll.Click += buttonDisplayAll_Click;
            // 
            // buttonFilter
            // 
            buttonFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonFilter.Location = new Point(45, 253);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(191, 47);
            buttonFilter.TabIndex = 3;
            buttonFilter.Text = "Filter";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // buttonFindLongest
            // 
            buttonFindLongest.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonFindLongest.Location = new Point(45, 342);
            buttonFindLongest.Name = "buttonFindLongest";
            buttonFindLongest.Size = new Size(191, 45);
            buttonFindLongest.TabIndex = 4;
            buttonFindLongest.Text = "Find Longest";
            buttonFindLongest.UseVisualStyleBackColor = true;
            buttonFindLongest.Click += buttonFindLongest_Click;
            // 
            // buttonCalculateTotal
            // 
            buttonCalculateTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCalculateTotal.Location = new Point(45, 445);
            buttonCalculateTotal.Name = "buttonCalculateTotal";
            buttonCalculateTotal.Size = new Size(191, 68);
            buttonCalculateTotal.TabIndex = 5;
            buttonCalculateTotal.Text = "Calculate Total";
            buttonCalculateTotal.UseVisualStyleBackColor = true;
            buttonCalculateTotal.Click += buttonCalculateTotal_Click;
            // 
            // labelLongestActivity
            // 
            labelLongestActivity.AutoSize = true;
            labelLongestActivity.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLongestActivity.Location = new Point(335, 465);
            labelLongestActivity.Name = "labelLongestActivity";
            labelLongestActivity.Size = new Size(222, 29);
            labelLongestActivity.TabIndex = 6;
            labelLongestActivity.Text = "Longest Activity: ";
            // 
            // labelTotalDuration
            // 
            labelTotalDuration.AutoSize = true;
            labelTotalDuration.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalDuration.Location = new Point(335, 545);
            labelTotalDuration.Name = "labelTotalDuration";
            labelTotalDuration.Size = new Size(194, 29);
            labelTotalDuration.TabIndex = 7;
            labelTotalDuration.Text = "Total Duration:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 635);
            Controls.Add(labelTotalDuration);
            Controls.Add(labelLongestActivity);
            Controls.Add(buttonCalculateTotal);
            Controls.Add(buttonFindLongest);
            Controls.Add(buttonFilter);
            Controls.Add(buttonDisplayAll);
            Controls.Add(comboBoxCategory);
            Controls.Add(listBoxActivities);
            Name = "Form1";
            Text = "Activity Manager";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxActivities;
        private ComboBox comboBoxCategory;
        private Button buttonDisplayAll;
        private Button buttonFilter;
        private Button buttonFindLongest;
        private Button buttonCalculateTotal;
        private Label labelLongestActivity;
        private Label labelTotalDuration;
    }
}
