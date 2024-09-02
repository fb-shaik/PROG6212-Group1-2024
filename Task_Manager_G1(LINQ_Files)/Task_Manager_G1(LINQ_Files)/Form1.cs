namespace Task_Manager_G1_LINQ_Files_
{
    public partial class Personal_Task_Manager : Form
    {
        private List<Task> taskList = new List<Task>();
        private string filePath = "tasks.txt";
        public Personal_Task_Manager()
        {
            InitializeComponent();
            LoadTasksFromFile();
        }


        private void btnAddTask_Click(object sender, EventArgs e)
        {
            // Get the task description from the input textbox
            string taskDescription = txtTaskInput.Text.Trim();
            // Ensure the task description is not empty
            if (!string.IsNullOrEmpty(taskDescription))
            {
                // Create a new Task object with the description and mark it as not completed
                Task newTask = new Task { Description = taskDescription, IsCompleted = false };
                // Add the new task to the task list
                taskList.Add(newTask);
                // Write the new task to the file
                WriteTaskToFile(newTask);
                // Clear the input textbox for new entries
                txtTaskInput.Clear();
                // Update the ListBox display with the latest list of tasks
                DisplayTasks(taskList);
            }
        }


        //Key methods needed:
        // Load tasks from the file into the task list
        private void LoadTasksFromFile()
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath);
                // Parse each line to create Task objects
                foreach (var line in lines)
                { // Split the line into task description and status
                    var parts = line.Split('|');
                    // Ensure the line is correctly formatted with two parts
                    if (parts.Length == 2)
                    { // Create a new Task object and add it to the task list
                        taskList.Add(new Task
                        {
                            Description = parts[0],
                            IsCompleted = bool.Parse(parts[1]),
                        });
                    }
                }
            }
        }

        // Write a new task to the file
        private void WriteTaskToFile(Task task)
        {
            // Open the file in append mode to add the new task
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Write the task's description and completion status to the file
                writer.WriteLine($"{task.Description} | {task.IsCompleted}");
            }
        }

        // Update the file with the current state of all tasks
        private void UpdateTasksFile()
        {
            // Write all tasks to the file, overwriting the existing content
            File.WriteAllLines(filePath, taskList.Select(t => $"{t.Description} | {t.IsCompleted}"));
        }


        // Display the tasks in the ListBox
        private void DisplayTasks(List<Task> tasks)
        {
            // Clear the current contents of the ListBox
            listBoxTasks.Items.Clear();

            // Add each task to the ListBox with its status
            foreach (var task in tasks)
            {
                // Determine the task status (Pending or Completed)
                string status = task.IsCompleted ? "[Completed] " : "[Pending]";
                // Add the task with its status to the ListBox
                listBoxTasks.Items.Add(status + task.Description);
            }






        }

        private void Personal_Task_Manager_Load(object sender, EventArgs e)
        {

        }

        private void btnShowAllTasks_Click(object sender, EventArgs e)
        {
            // Display all tasks in the ListBox
            DisplayTasks(taskList);

        }

        private void btnShowPendingTasks_Click(object sender, EventArgs e)
        {
            // Filter tasks to get only those that are not complete
            var pendingTasks = taskList.Where(t => !t.IsCompleted).ToList();
            // Display the pending tasks in the ListBox
            DisplayTasks(pendingTasks);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search term from the input textbox and convert it to lowercase for case-insensitive search
            string searchTerm = txtSearch.Text.Trim().ToLower();
            // Filter tasks that contain the search term in their description
            var filteredTasks = taskList.Where(t => t.Description.ToLower().Contains(searchTerm)).ToList();
            // Display the filtered tasks in the ListBox
            DisplayTasks(filteredTasks);
        }

        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            // Check if a task is selected in the ListBox
            if (listBoxTasks.SelectedIndex != -1) {
                // Get the index of the selected task
                int index = listBoxTasks.SelectedIndex;

                // Mark the selected task as completed
                taskList[index].IsCompleted = true;
                // Update the tasks file to reflect the changes
                UpdateTasksFile();
                // Refresh the ListBox to show the updated task statuses
                DisplayTasks(taskList);
        }
        }
    }
}
