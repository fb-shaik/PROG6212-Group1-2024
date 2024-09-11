using System.Data.SqlClient;

namespace ContactsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); // Initializes the components on the LoginForm as defined in the designer file.
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                // Creates a connection using a predefined connection string from application settings.
                SqlConnection cnn = new SqlConnection(Properties.Settings.Default.ÇontactsConnection);
                cnn.Open(); // Opens the connection to the database.

                // Constructs a SQL query to check if a user exists with the given username and password.
                // WARNING: This method is prone to SQL injection attacks.
                string sqlQuery = "Select * From Users where Username='" + txt_Username.Text + "' AND Password='" + txt_Password.Text + "'";
                SqlCommand command = new SqlCommand(sqlQuery, cnn);
                SqlDataReader dataReader = command.ExecuteReader(); // Executes the query and returns data.

                if (dataReader.HasRows)
                {
                    MessageBox.Show("Success"); // Displays a message box if user is found.

                    // Creates and shows a new ContactsForm using the username provided.
                    ContactsForm c = new ContactsForm(txt_Username.Text);
                    txt_Username.Text = ""; // Clears the username textbox.
                    txt_Password.Text = ""; // Clears the password textbox.
                    c.ShowDialog(); // Shows the ContactsForm as a modal dialog.
                    this.Show(); // Shows the LoginForm again after ContactsForm is closed.
                }
                else
                {
                    MessageBox.Show("Invalid Credentials"); // Shows a message if login fails.
                }

                dataReader.Close(); // Closes the data reader object.
                command.Dispose(); // Disposes of the command object.
                cnn.Close(); // Closes the connection to the database.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Displays any exception as a message box.
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // This method is triggered when the LoginForm loads.
            // Currently empty but can be used to perform any initialization tasks.
        }
    }
}
