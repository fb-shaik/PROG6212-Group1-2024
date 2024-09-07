using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SpaceExplorerAcademy
{
    public partial class MainWindow : Window
    {
        // Collection to hold all cadets
        private ObservableCollection<Cadet> cadets = new ObservableCollection<Cadet>();
        // List to hold all available missions
        private List<SpaceMission> availableMissions = new List<SpaceMission>();
        // File names for storing cadet and mission data
        private const string cadetsFileName = "cadets.json";
        private const string missionsFileName = "missions.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadDataAsync(); // Load data when the application starts
        }

        // Asynchronously load both cadets and missions data
        private async void LoadDataAsync()
        {
            try
            {
                await Task.WhenAll(LoadCadetsAsync(), LoadMissionsAsync());
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        // Load cadets from the JSON file
        private async Task LoadCadetsAsync()
        {
            if (File.Exists(cadetsFileName))
            {
                string json = await File.ReadAllTextAsync(cadetsFileName);
                var loadedCadets = JsonSerializer.Deserialize<List<Cadet>>(json);
                cadets = new ObservableCollection<Cadet>(loadedCadets);

                // Ensure each cadet has an ObservableCollection for Missions
                foreach (var cadet in cadets)
                {
                    cadet.Missions = new ObservableCollection<SpaceMission>(cadet.Missions);
                }
            }
        }

        // Load missions from the JSON file, or create default missions if the file doesn't exist
        private async Task LoadMissionsAsync()
        {
            if (File.Exists(missionsFileName))
            {
                string json = await File.ReadAllTextAsync(missionsFileName);
                availableMissions = JsonSerializer.Deserialize<List<SpaceMission>>(json);
            }
            else
            {
                // Create some default missions if the file doesn't exist
                availableMissions = new List<SpaceMission>
                {
                    new SpaceMission { Name = "Moon Landing", Difficulty = 3 },
                    new SpaceMission { Name = "Mars Exploration", Difficulty = 5 },
                    new SpaceMission { Name = "Asteroid Mining", Difficulty = 4 },
                    new SpaceMission { Name = "Jupiter's Moons Survey", Difficulty = 6 }
                };
                await SaveMissionsAsync();
            }
        }

        // Save cadets to the JSON file
        private async Task SaveCadetsAsync()
        {
            string json = JsonSerializer.Serialize(cadets);
            await File.WriteAllTextAsync(cadetsFileName, json);
        }

        // Save missions to the JSON file
        private async Task SaveMissionsAsync()
        {
            string json = JsonSerializer.Serialize(availableMissions);
            await File.WriteAllTextAsync(missionsFileName, json);
        }

        // Update the UI with the latest data
        private void UpdateUI()
        {
            cadetListBox.ItemsSource = cadets;
            missionComboBox.ItemsSource = availableMissions;
        }

        // Event handler for enrolling a new cadet
        private async void EnrollCadet_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a cadet name.");
                return;
            }

            Cadet newCadet = new Cadet { Name = name };
            cadets.Add(newCadet);
            await SaveCadetsAsync();
            nameTextBox.Clear();
            UpdateUI();
        }

        // Event handler for assigning a mission to a cadet
        private async void AssignMission_Click(object sender, RoutedEventArgs e)
        {
            if (cadetListBox.SelectedItem is Cadet selectedCadet && missionComboBox.SelectedItem is SpaceMission selectedMission)
            {
                selectedCadet.Missions.Add(selectedMission);
                cadetListBox.Items.Refresh(); // Force the ListBox to refresh its view
                await SaveCadetsAsync();
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Please select a cadet and a mission.");
            }
        }

        // Event handler for when a cadet is selected in the list
        private void Cadet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cadetListBox.SelectedItem is Cadet selectedCadet)
            {
                missionListBox.ItemsSource = selectedCadet.Missions;
            }
        }
    }
}
