namespace ContactsApp
{
    partial class ContactsForm
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
            txtName = new TextBox();
            txtTelephone = new TextBox();
            txtEmail = new TextBox();
            txtSurname = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAddContact = new Button();
            lstContacts = new ListBox();
            btnEdit = new Button();
            btnReset = new Button();
            btnSaveChanges = new Button();
            txtContactInfo = new TextBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(188, 61);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 0;
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(188, 228);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(150, 31);
            txtTelephone.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(188, 175);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 2;
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(188, 120);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(150, 31);
            txtSurname.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 67);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 4;
            label1.Text = "Firstname:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 123);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 5;
            label2.Text = "Surname:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 181);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 6;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 234);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 7;
            label4.Text = "Telephone:";
            // 
            // btnAddContact
            // 
            btnAddContact.Location = new Point(73, 289);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(265, 34);
            btnAddContact.TabIndex = 8;
            btnAddContact.Text = "Add Contact";
            btnAddContact.UseVisualStyleBackColor = true;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // lstContacts
            // 
            lstContacts.FormattingEnabled = true;
            lstContacts.ItemHeight = 25;
            lstContacts.Location = new Point(388, 40);
            lstContacts.Name = "lstContacts";
            lstContacts.Size = new Size(200, 454);
            lstContacts.TabIndex = 9;
            lstContacts.SelectedIndexChanged += lstContacts_SelectedIndexChanged;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(73, 341);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(265, 34);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(73, 460);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(265, 34);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(73, 397);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(265, 34);
            btnSaveChanges.TabIndex = 13;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // txtContactInfo
            // 
            txtContactInfo.Location = new Point(616, 40);
            txtContactInfo.Multiline = true;
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.Size = new Size(337, 454);
            txtContactInfo.TabIndex = 14;
            // 
            // ContactsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 546);
            Controls.Add(txtContactInfo);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnReset);
            Controls.Add(btnEdit);
            Controls.Add(lstContacts);
            Controls.Add(btnAddContact);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSurname);
            Controls.Add(txtEmail);
            Controls.Add(txtTelephone);
            Controls.Add(txtName);
            Name = "ContactsForm";
            Text = "ContactsForm";
            Load += ContactsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtTelephone;
        private TextBox txtEmail;
        private TextBox txtSurname;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAddContact;
        private ListBox lstContacts;
        private Button btnEdit;
        private Button btnReset;
        private Button btnSaveChanges;
        private TextBox txtContactInfo;
    }
}