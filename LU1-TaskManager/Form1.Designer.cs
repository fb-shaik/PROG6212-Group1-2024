namespace LU1_TaskManager
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnThreads = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnLoadedModules = new System.Windows.Forms.Button();
            this.btnAssemblies = new System.Windows.Forms.Button();
            this.btnStartChrome = new System.Windows.Forms.Button();
            this.btnKillChrome = new System.Windows.Forms.Button();
            this.btnEndTaskMng = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(510, 364);
            this.listBox1.TabIndex = 0;
            // 
            // btnThreads
            // 
            this.btnThreads.Location = new System.Drawing.Point(50, 413);
            this.btnThreads.Name = "btnThreads";
            this.btnThreads.Size = new System.Drawing.Size(155, 61);
            this.btnThreads.TabIndex = 1;
            this.btnThreads.Text = "Threads of Selected Process";
            this.btnThreads.UseVisualStyleBackColor = true;
            this.btnThreads.Click += new System.EventHandler(this.btnThreads_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(50, 501);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(155, 59);
            this.btnDetails.TabIndex = 2;
            this.btnDetails.Text = "Details of Current AppDomain";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnLoadedModules
            // 
            this.btnLoadedModules.Location = new System.Drawing.Point(308, 413);
            this.btnLoadedModules.Name = "btnLoadedModules";
            this.btnLoadedModules.Size = new System.Drawing.Size(174, 61);
            this.btnLoadedModules.TabIndex = 3;
            this.btnLoadedModules.Text = "Loaded Modules of Selected Process";
            this.btnLoadedModules.UseVisualStyleBackColor = true;
            this.btnLoadedModules.Click += new System.EventHandler(this.btnLoadedModules_Click);
            // 
            // btnAssemblies
            // 
            this.btnAssemblies.Location = new System.Drawing.Point(308, 497);
            this.btnAssemblies.Name = "btnAssemblies";
            this.btnAssemblies.Size = new System.Drawing.Size(174, 67);
            this.btnAssemblies.TabIndex = 4;
            this.btnAssemblies.Text = "Assemblies in the AppDomain";
            this.btnAssemblies.UseVisualStyleBackColor = true;
            this.btnAssemblies.Click += new System.EventHandler(this.btnAssemblies_Click);
            // 
            // btnStartChrome
            // 
            this.btnStartChrome.Location = new System.Drawing.Point(24, 600);
            this.btnStartChrome.Name = "btnStartChrome";
            this.btnStartChrome.Size = new System.Drawing.Size(120, 40);
            this.btnStartChrome.TabIndex = 5;
            this.btnStartChrome.Text = "Start Chrome";
            this.btnStartChrome.UseVisualStyleBackColor = true;
            this.btnStartChrome.Click += new System.EventHandler(this.btnStartChrome_Click);
            // 
            // btnKillChrome
            // 
            this.btnKillChrome.Location = new System.Drawing.Point(183, 600);
            this.btnKillChrome.Name = "btnKillChrome";
            this.btnKillChrome.Size = new System.Drawing.Size(119, 40);
            this.btnKillChrome.TabIndex = 6;
            this.btnKillChrome.Text = "Kill Chrome";
            this.btnKillChrome.UseVisualStyleBackColor = true;
            this.btnKillChrome.Click += new System.EventHandler(this.btnKillChrome_Click);
            // 
            // btnEndTaskMng
            // 
            this.btnEndTaskMng.Location = new System.Drawing.Point(336, 600);
            this.btnEndTaskMng.Name = "btnEndTaskMng";
            this.btnEndTaskMng.Size = new System.Drawing.Size(167, 40);
            this.btnEndTaskMng.TabIndex = 7;
            this.btnEndTaskMng.Text = "End Task Manager";
            this.btnEndTaskMng.UseVisualStyleBackColor = true;
            this.btnEndTaskMng.Click += new System.EventHandler(this.btnEndTaskMng_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 662);
            this.Controls.Add(this.btnEndTaskMng);
            this.Controls.Add(this.btnKillChrome);
            this.Controls.Add(this.btnStartChrome);
            this.Controls.Add(this.btnAssemblies);
            this.Controls.Add(this.btnLoadedModules);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnThreads);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnThreads;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnLoadedModules;
        private System.Windows.Forms.Button btnAssemblies;
        private System.Windows.Forms.Button btnStartChrome;
        private System.Windows.Forms.Button btnKillChrome;
        private System.Windows.Forms.Button btnEndTaskMng;
    }
}

