using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace OfficeEquipmentInventory
{
    public partial class MainWindow : Window
    {
        // Stores the ID of the currently selected item in the DataGrid
        private int? selectedItemId = null;

        // Constructor: Initializes the window and loads initial data
        public MainWindow()
        {
            InitializeComponent();
            LoadEquipment();
        }

        /// <summary>
        /// Loads equipment data from the database and populates the DataGrid
        /// </summary>
        /// <param name="filter">Optional search filter</param>
        /// <param name="sortColumn">Optional column name for sorting</param>
        private void LoadEquipment(string filter = "", string sortColumn = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();
                    // Construct the SQL query with optional filtering and sorting
                    string query = "SELECT * FROM OfficeEquipment WHERE Name LIKE @filter OR Category LIKE @filter OR Status LIKE @filter";

                    if (!string.IsNullOrWhiteSpace(sortColumn))
                    {
                        query += $" ORDER BY {sortColumn}";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@filter", $"%{filter}%");

                    // Use a SqlDataAdapter to fill a DataTable with the query results
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGrid's ItemsSource to the filled DataTable
                    dgEquipment.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Event handler for the Add button click
        /// Adds a new equipment item to the database
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Validate that the quantity is a valid integer
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid number for Quantity.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();
                    // Construct and execute the INSERT query
                    string query = "INSERT INTO OfficeEquipment (Name, Category, Quantity, Status, DateAdded) VALUES (@Name, @Category, @Quantity, @Status, @DateAdded)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Category", txtCategory.Text);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Status", cmbStatus.Text);
                    command.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                    command.ExecuteNonQuery();
                }
                // Refresh the DataGrid and clear the input fields
                LoadEquipment();
                ClearInputs();
                MessageBox.Show("Equipment added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding equipment: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Event handler for the Update button click
        /// Updates an existing equipment item in the database
        /// </summary>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected
            if (selectedItemId == null)
            {
                MessageBox.Show("Please select an item to update.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate that the quantity is a valid integer
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid number for Quantity.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();
                    // Construct and execute the UPDATE query
                    string query = "UPDATE OfficeEquipment SET Name = @Name, Category = @Category, Quantity = @Quantity, Status = @Status WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", selectedItemId);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Category", txtCategory.Text);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Status", cmbStatus.Text);
                    command.ExecuteNonQuery();
                }
                // Refresh the DataGrid and clear the input fields
                LoadEquipment();
                ClearInputs();
                MessageBox.Show("Equipment updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating equipment: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Event handler for the Delete button click
        /// Deletes an existing equipment item from the database
        /// </summary>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected
            if (selectedItemId == null)
            {
                MessageBox.Show("Please select an item to delete.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();
                    // Construct and execute the DELETE query
                    string query = "DELETE FROM OfficeEquipment WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", selectedItemId);
                    command.ExecuteNonQuery();
                }
                // Refresh the DataGrid and clear the input fields
                LoadEquipment();
                ClearInputs();
                MessageBox.Show("Equipment deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting equipment: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Event handler for the Search button click
        /// Filters the equipment list based on the search text
        /// </summary>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            LoadEquipment(filter);
        }

        /// <summary>
        /// Event handler for the Sort ComboBox selection change
        /// Sorts the equipment list based on the selected column
        /// </summary>
        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sortColumn = "";
            switch (cmbSort.SelectedIndex)
            {
                case 0: sortColumn = "Name"; break;
                case 1: sortColumn = "Category"; break;
                case 2: sortColumn = "Quantity"; break;
                case 3: sortColumn = "DateAdded"; break;
            }

            LoadEquipment(sortColumn: sortColumn);
        }

        /// <summary>
        /// Clears all input fields and resets the selection state
        /// </summary>
        private void ClearInputs()
        {
            txtName.Clear();
            txtCategory.Clear();
            txtQuantity.Clear();
            cmbStatus.SelectedIndex = -1;
            selectedItemId = null;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

        /// <summary>
        /// Event handler for the Clear button click
        /// Clears all input fields and resets the selection state
        /// </summary>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        /// <summary>
        /// Event handler for the DataGrid selection change
        /// Populates the input fields with the selected item's data
        /// </summary>
        private void dgEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEquipment.SelectedItem != null)
            {
                // Cast the selected item to DataRowView and populate the input fields
                DataRowView row = (DataRowView)dgEquipment.SelectedItem;
                selectedItemId = Convert.ToInt32(row["Id"]);
                txtName.Text = row["Name"].ToString();
                txtCategory.Text = row["Category"].ToString();
                txtQuantity.Text = row["Quantity"].ToString();
                cmbStatus.Text = row["Status"].ToString();

                // Enable the Update and Delete buttons
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
            else
            {
                // If no item is selected, clear the inputs and disable Update and Delete buttons
                ClearInputs();
            }
        }
    }
}