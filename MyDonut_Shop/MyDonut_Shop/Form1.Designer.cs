namespace MyDonut_Shop
{
    partial class Donut_Shop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donut_Shop));
            btnOrder = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtbDonuts = new TextBox();
            txtbCoffee = new TextBox();
            SuspendLayout();
            // 
            // btnOrder
            // 
            resources.ApplyResources(btnOrder, "btnOrder");
            btnOrder.Name = "btnOrder";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // txtbDonuts
            // 
            resources.ApplyResources(txtbDonuts, "txtbDonuts");
            txtbDonuts.Name = "txtbDonuts";
            // 
            // txtbCoffee
            // 
            resources.ApplyResources(txtbCoffee, "txtbCoffee");
            txtbCoffee.Name = "txtbCoffee";
            // 
            // Donut_Shop
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtbCoffee);
            Controls.Add(txtbDonuts);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOrder);
            Name = "Donut_Shop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOrder;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtbDonuts;
        private TextBox txtbCoffee;
    }
}
