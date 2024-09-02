using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using Employee_Management_LINQ_FileHandling_G1;
using static System.Net.WebRequestMethods;

namespace EmployeeManager
{
    public partial class MainWindow : Window
    {
        private List<Employee> employeeList;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void UploadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //create and configure OpenFileDialog
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog()
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
                };
                //Show dialog & process selected file
                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;
                    ProcessFile(filePath);
                }
            }
            catch (Exception ex) 
            {//Message to the user that file upload fails
                MessageBox.Show($"An error occured while uploading the file:{ex.Message}", "Upload Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
         

        }

        private void ProcessFile(string filePath)
        {
            try 
            { //check if the file path exists
                if (!System.IO.File.Exists(filePath)) 
                { 
                    throw new FileNotFoundException("The specified file does not exist", filePath);
                }
            //Read all the lines from the file
            var lines = System.IO.File.ReadAllLines(filePath);
                if (lines.Length < 2) 
                {
                    throw new InvalidDataException($"Invalid data or file is empty");
                }
                employeeList = new List<Employee>();

                //Process the data in each line of the CSV file (skip the header line)
                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    if (parts.Length != 5)
                    {
                        throw new InvalidDataException($"Invalid data format in line {i + 1}). Expected 5" +
                            $"columns , found {parts.Length}");
                    }
                    //Parse EmployeeID
                    if (!int.TryParse(parts[0], out int employeeId))
                    {
                        throw new InvalidDataException($"Invalid EmployeeID in line {i + 1}: {parts[0]}");
                     }

                    //Parse Salary
                    if (!decimal.TryParse(parts[4], NumberStyles.Any, CultureInfo.InvariantCulture,
                        out decimal salary))
                    {
                        throw new InvalidDataException($"Invalid Salary in line {i + 1}: {parts[4]}");
                    }

                    //Create and add a new Employee object to the list
                    employeeList.Add(new Employee
                    {
                        EmployeeID = employeeId,
                        Name = parts[1],
                        Department = parts[2],
                        JobTitle = parts[3],
                        Salary = salary
                    });
                }

                //Update the DataGrid with the new data
                ResultsDataGrid.ItemsSource = employeeList;
                MessageBox.Show($"Successfully loaded {employeeList.Count} employees.","File processed",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {//Message to the user that file process has failed
                MessageBox.Show($"An error occured while processing the file:{ex.Message}", "Processing Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                //check if data is available to filter
                if (employeeList == null || !employeeList.Any()) 
                {
                    throw new InvalidOperationException("No data available to filter, Plase upload a file");
                }

                //Get Filter criteria from the UI
                string departmentFilter = FilterTextBox.Text.Trim();
                string jobFilter = FilterTextBox.Text.Trim();
                decimal minSalary = 0;
                decimal maxSalary = decimal.MaxValue;

                //Parse & validate min salary; max salary
                if (!string.IsNullOrEmpty(MinSalaryTextBox.Text) && !decimal.TryParse(MinSalaryTextBox.Text, out minSalary)) 
                {
                    throw new FormatException("Invalid minimum salary. Please enter a valid number");
                }
                if (!string.IsNullOrEmpty(MaxSalaryTextBox.Text) && !decimal.TryParse(MaxSalaryTextBox.Text, out minSalary))
                {
                    throw new FormatException("Invalid maximum salary. Please enter a valid number");
                }

                //Ensure min is not greater than max 
                if (minSalary > maxSalary) 
                {
                    throw new ArgumentException("Minimum salary canot be greater than maximum salary!");
                }

                //Apply filter to the employeeList
                var filterData = employeeList.Where(emp =>
                (string.IsNullOrEmpty(departmentFilter) || emp.Department.Contains(departmentFilter,
                StringComparison.OrdinalIgnoreCase))
                &&
                (string.IsNullOrEmpty(jobFilter) || emp.JobTitle.Contains(jobFilter,
                StringComparison.OrdinalIgnoreCase))
                &&
                emp.Salary >= minSalary
                &&
                emp.Salary <= maxSalary
                ).ToList();
            
                //Update DataGrid with filtered results
                ResultsDataGrid.ItemsSource = filterData;
                MessageBox.Show($"Filter applied Showing {filterData.Count} results.", "Filter Applied",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) 
            {
                //Display error message
                MessageBox.Show($"An error occured while applying the filter: {ex.Message}" ,"Filter Errror",
                     MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SortBySalary_Click(object sender, RoutedEventArgs e)
        {
            try {

                //check if data is available to filter
                if (employeeList == null || !employeeList.Any())
                {
                    throw new InvalidOperationException("No data available to filter, Plase upload a file");
                }

                //Sort employees by salary in descending order
                var sortData = employeeList.OrderByDescending(emp => emp.Salary).ToList();
                ResultsDataGrid.ItemsSource= sortData;
                MessageBox.Show($"Data sorted by salary in descending order.", "Sort Applied",
                 MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"An error occured while sorting the data: {ex.Message}", "Sort Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void GroupByDepartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (employeeList == null || !employeeList.Any())
                {
                    throw new InvalidOperationException("No data available to group. Please upload a file first.");
                }

                var groupedData = employeeList.GroupBy(emp => emp.Department)
                                              .Select(g => new
                                              {
                                                  Department = g.Key,
                                                  Employees = g.ToList(),
                                                  TotalSalary = g.Sum(emp => emp.Salary)
                                              }).ToList();

                ResultsDataGrid.ItemsSource = groupedData;
                MessageBox.Show($"Data grouped by department. Showing {groupedData.Count} " +
                    $"groups.", "Grouping Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while grouping the data: {ex.Message}", "Grouping Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportResults_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ResultsDataGrid.ItemsSource == null)
                {
                    throw new InvalidOperationException("No data available to export. Please load or filter data first.");
                }

                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var filteredData = (IEnumerable<Employee>)ResultsDataGrid.ItemsSource;
                    var csvLines = new List<string>
                    {
                        "EmployeeID,Name,Department,JobTitle,Salary" // Header
                    };

                    csvLines.AddRange(filteredData.Select(emp =>
                        $"{emp.EmployeeID},{emp.Name},{emp.Department},{emp.JobTitle},{emp.Salary}"));

                    System.IO.File.WriteAllLines(saveFileDialog.FileName, csvLines);
                    MessageBox.Show($"Export successful! File saved to: {saveFileDialog.FileName}", "Export Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting the data: {ex.Message}", "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (employeeList == null || !employeeList.Any())
                {
                    throw new InvalidOperationException("No data available. Please upload a file first.");
                }

                ResultsDataGrid.ItemsSource = employeeList;
                FilterTextBox.Clear();
                JobTitleFilterTextBox.Clear();
                MinSalaryTextBox.Clear();
                MaxSalaryTextBox.Clear();
                MessageBox.Show("Filters reset. Showing all data.", "Reset Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting filters: {ex.Message}", "Reset Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}