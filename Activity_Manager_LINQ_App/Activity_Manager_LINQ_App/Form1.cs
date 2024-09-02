using System.Diagnostics;
namespace Activity_Manager_LINQ_App
{
    public partial class Form1 : Form
    {
        private List<Activity> activities;
        public Form1()
        {
            InitializeComponent();
            InitializeActivities();
            PopulateCategoryComboBox();
        }

        private void InitializeActivities()
        {
            activities = new List<Activity>
            {
                new Activity { Name = "Morning Run", Category = "Exercise", Duration = 30 },
                new Activity { Name = "Office Work", Category = "Work", Duration = 480 },
                new Activity { Name = "Lunch Break", Category = "Break", Duration = 60 },
                new Activity { Name = "Reading", Category = "Leisure", Duration = 90 },
                new Activity { Name = "Gym", Category = "Exercise", Duration = 45 },
                new Activity { Name = "Project Meeting", Category = "Work", Duration = 120 },
                new Activity { Name = "Dinner with Family", Category = "Leisure", Duration = 90 },
            };
        }

        private void PopulateCategoryComboBox()
        {
            var categories = (from a in activities
                              select a.Category).Distinct().ToList();
            comboBoxCategory.Items.AddRange(categories.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDisplayAll_Click(object sender, EventArgs e)
        {
            DisplayAllActivities();
        }

        private void DisplayAllActivities()
        {
            listBoxActivities.Items.Clear();
            foreach (var activity in activities)
            {
                listBoxActivities.Items.Add($"{activity.Name} ({activity.Category}) - {activity.Duration} mins");
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            FilterActivitiesByCategory();
        }

        private void FilterActivitiesByCategory()
        {
            string category = comboBoxCategory.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category to filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filteredActivities = (from a in activities
                                      where a.Category.Equals(category, StringComparison.OrdinalIgnoreCase)
                                      select a).ToList();

            listBoxActivities.Items.Clear();
            foreach (var activity in filteredActivities)
            {
                listBoxActivities.Items.Add($"{activity.Name} ({activity.Duration} mins)");
            }
        }

        private void buttonFindLongest_Click(object sender, EventArgs e)
        {
            FindLongestActivity();
        }

        private void FindLongestActivity()
        {// Get the selected category from the combo box.
            string category = comboBoxCategory.SelectedItem?.ToString();

            // Check if a category is selected.
            if (!string.IsNullOrEmpty(category))
            {
                // If a category is selected, find the longest activity within that category.
                var longestActivity = (from a in activities
                                       where a.Category.Equals(category, StringComparison.OrdinalIgnoreCase)
                                       orderby a.Duration descending
                                       select a).FirstOrDefault();

                if (longestActivity != null)
                {
                    labelLongestActivity.Text = $"Longest {category} Activity: {longestActivity.Name} ({longestActivity.Duration} mins)";
                }
                else
                {
                    labelLongestActivity.Text = $"No activities available in {category} category.";
                }
            }
            else
            {
                // If no category is selected, find the longest activity across all activities.
                var longestActivity = (from a in activities
                                       orderby a.Duration descending
                                       select a).FirstOrDefault();

                if (longestActivity != null)
                {
                    labelLongestActivity.Text = $"Longest Activity: {longestActivity.Name} ({longestActivity.Duration} mins)";
                }
                else
                {
                    labelLongestActivity.Text = "No activities available.";
                }
            }
        }

        private void buttonCalculateTotal_Click(object sender, EventArgs e)
        {
            CalculateTotalDuration();
        }

        private void CalculateTotalDuration()
        {
            // Get the selected category from the combo box.
            string category = comboBoxCategory.SelectedItem?.ToString();

            // If a category is selected, calculate the total duration for that category.
            if (!string.IsNullOrEmpty(category))
            {
                // LINQ query to sum the durations of activities that match the selected category.
                int totalDuration = (from a in activities
                                     where a.Category.Equals(category, StringComparison.OrdinalIgnoreCase)
                                     select a.Duration).Sum();

                // Display the total duration for the filtered category in the label.
                labelTotalDuration.Text = $"Total Duration for {category}: {totalDuration} mins";
            }
            else
            {
                // If no category is selected, calculate the total duration for all activities.
                int totalDuration = (from a in activities
                                     select a.Duration).Sum();

                // Display the total duration for all activities in the label.
                labelTotalDuration.Text = $"Total Duration: {totalDuration} mins";
            }
        }
    }

    public class Activity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; }
    }
}