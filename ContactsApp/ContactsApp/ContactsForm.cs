using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace ContactsApp
{
    public partial class ContactsForm : Form
    {
        ArrayList contacts = new ArrayList(); // An ArrayList to store contact objects.
        Contact selectedContact = new Contact(); // Holds the currently selected contact from the list.
        string username; // The username of the logged-in user.

        public ContactsForm(string username)
        {
            InitializeComponent(); // Initializes the components on the form.
            this.username = username; // Stores the username of the user.
        }

        private void ContactsForm_Load(object sender, EventArgs e)
        {
            // Initially disables edit and save buttons until a contact is selected.
            btnEdit.Enabled = false;
            btnSaveChanges.Enabled = false;

            try
            {
                // Establishes a connection to the database using a connection string.
                SqlConnection cnn = new SqlConnection(Properties.Settings.Default.ÇontactsConnection);
                cnn.Open(); // Opens the database connection.
                // SQL query to fetch all contacts for the logged-in user.
                string sqlQuery = "Select * from Contacts where Username='" + username + "'";
                SqlCommand command = new SqlCommand(sqlQuery, cnn);
                SqlDataReader dataReader = command.ExecuteReader(); //reads from the database

                // Reads through all the returned records and creates Contact objects.
                while (dataReader.Read())
                {
                    Contact temp = new Contact(
                        dataReader.GetInt32(0), // ID
                        dataReader.GetValue(1).ToString(), // Name
                        dataReader.GetValue(2).ToString(), // Surname
                        dataReader.GetValue(3).ToString(), // Email
                        dataReader.GetValue(4).ToString()); // Telephone
                    contacts.Add(temp); // Adds the contact to the ArrayList.
                }

                dataReader.Close(); // Closes the data reader.
                command.Dispose(); // Disposes of the command object.
                cnn.Close(); // Closes the database connection.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Displays any exception as a message box.
            }
            refreshUI(); // Updates the UI with the contacts loaded.
        }

        private void refreshUI()
        {
            // Clears the form fields and the list box.
            txtName.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtContactInfo.Clear();

            contacts.Sort(); // Sorts the contact list.
            lstContacts.Items.Clear(); // Clears existing items from the list box.

            // Populates the list box with contacts' names.
            foreach (Contact contact in contacts)
            {
                lstContacts.Items.Add(contact.Name + " " + contact.Surname);
            }
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true; // Enables the edit button when a contact is selected.

            if (lstContacts.SelectedItem != null)
            {
                string selectedName = lstContacts.SelectedItem.ToString(); // Gets the selected contact's name.
                // Finds the contact in the ArrayList based on the name.
                foreach (Contact contact in contacts)
                {
                    if ((contact.Name + " " + contact.Surname).Equals(selectedName))
                    {
                        selectedContact = contact; // Sets the selected contact.
                        break;
                    }
                }

                // Displays detailed information of the selected contact in the text box.
                List<string> contactInfo = new List<string>
                {
                    "Details:",
                    "-----------------",
                    $"ID: {selectedContact.ID}",
                    $"Name: {selectedContact.Name}",
                    $"Surname: {selectedContact.Surname}",
                    $"Telephone: {selectedContact.Telephone}",
                    $"Email: {selectedContact.Email}"
                };

                txtContactInfo.Lines = contactInfo.ToArray(); // Converts list to array and sets to text box.
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // Adds a new contact to the database.
            if (txtName.Text == "" || txtSurname.Text == "" || txtEmail.Text == "" || txtTelephone.Text == "")
            {
                MessageBox.Show("Error - values missing");
            }
            else
            {
                Contact newContact = new Contact(0, txtName.Text, txtSurname.Text, txtEmail.Text, txtTelephone.Text);
                try
                {
                    SqlConnection cnn = new SqlConnection(Properties.Settings.Default.ÇontactsConnection);
                    cnn.Open();
                    // SQL query to insert the new contact and return the new ID.
                    string sqlQuery = $"Insert into Contacts (Firstname, Surname, Email, Telephone, Username) VALUES ('{newContact.Name}', '{newContact.Surname}', '{newContact.Email}', '{newContact.Telephone}', '{username}'); SELECT SCOPE_IDENTITY();";

                    SqlCommand command = new SqlCommand(sqlQuery, cnn);
                    SqlDataAdapter adapter = new SqlDataAdapter(); //writes to the database
                    adapter.InsertCommand = command;

                    // Executes the command and retrieves the new contact ID.
                    int id = Convert.ToInt32(adapter.InsertCommand.ExecuteScalar());

                    newContact.ID = id; // Sets the new contact ID.
                    contacts.Add(newContact); // Adds the new contact to the ArrayList.

                    adapter.Dispose();
                    command.Dispose();
                    cnn.Close();
                    MessageBox.Show("Contact added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                refreshUI(); // Refreshes the UI to show the new contact.
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Allows editing of an existing contact.
            btnAddContact.Enabled = false; // Disables the add button.
            btnEdit.Enabled = false; // Disables the edit button.
            btnSaveChanges.Enabled = true; // Enables the save changes button.
            txtContactInfo.Clear(); // Clears the contact info text box.

            string selectedName = lstContacts.SelectedItem.ToString();
            foreach (Contact contact in contacts)
            {
                if ((contact.Name + " " + contact.Surname).Equals(selectedName))
                {
                    // Populates the form fields with the selected contact's information for editing.
                    txtName.Text = contact.Name;
                    txtSurname.Text = contact.Surname;
                    txtEmail.Text = contact.Email;
                    txtTelephone.Text = contact.Telephone;
                    break;
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Saves changes made to an existing contact.
            if (txtName.Text == "" || txtSurname.Text == "" || txtEmail.Text == "" || txtTelephone.Text == "")
            {
                MessageBox.Show("Error - Values missing!");
            }
            else
            {
                Contact newContact = new Contact(selectedContact.ID, txtName.Text, txtSurname.Text, txtEmail.Text, txtTelephone.Text);
                try
                {
                    SqlConnection cnn = new SqlConnection(Properties.Settings.Default.ÇontactsConnection);
                    cnn.Open();
                    // SQL query to update the existing contact's details.
                    string sqlQuery = $"UPDATE Contacts SET FirstName = '{newContact.Name}', Surname = '{newContact.Surname}', Email = '{newContact.Email}', Telephone = '{newContact.Telephone}' WHERE ID={newContact.ID}";

                    SqlCommand command = new SqlCommand(sqlQuery, cnn);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.UpdateCommand = command;
                    adapter.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Updated successfully");

                    contacts.Remove(selectedContact); // Removes the old contact details from the list.
                    contacts.Add(newContact); // Adds the updated contact details.

                    adapter.Dispose();
                    command.Dispose();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                refreshUI(); // Refreshes the UI to show the updated details.
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            refreshUI(); // Resets the form to its initial state.

            btnAddContact.Enabled = true; // Enables the add button.
            btnEdit.Enabled = false; // Keeps the edit button disabled.
            btnSaveChanges.Enabled = false; // Disables the save changes button.
        }
    }
}
