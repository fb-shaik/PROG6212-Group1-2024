namespace ContactsApp
{
    partial class LoginForm
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
            txt_Username = new TextBox();
            txt_Password = new TextBox();
            btn_Login = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txt_Username
            // 
            txt_Username.Location = new Point(163, 119);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(185, 31);
            txt_Username.TabIndex = 0;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(163, 189);
            txt_Password.Name = "txt_Password";
            txt_Password.PasswordChar = '*';
            txt_Password.Size = new Size(185, 31);
            txt_Password.TabIndex = 1;
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(114, 277);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(177, 34);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 119);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 3;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 189);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 360);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Login);
            Controls.Add(txt_Password);
            Controls.Add(txt_Username);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Username;
        private TextBox txt_Password;
        private Button btn_Login;
        private Label label1;
        private Label label2;
    }
}
