using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherDashboardWPF
{
    public partial class MainWindow : Window
    {
        private List<string> cities = new List<string> { "New York", "London", "Tokyo", "Sydney", "Rio de Janeiro" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshButton.IsEnabled = false;

            var weatherTasks = cities.Select(FetchWeatherDataAsync).ToList();

            try
            {
                var weatherData = await Task.WhenAll(weatherTasks);
                await Task.Run(() => ProcessWeatherData(weatherData));

                WeatherItemsControl.ItemsSource = weatherData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                RefreshButton.IsEnabled = true;
            }
        }

        private async Task<WeatherData> FetchWeatherDataAsync(string city)
        {
            await Task.Delay(1000); // Simulate API call delay
            var random = new Random();
            return new WeatherData
            {
                City = city,
                Temperature = random.Next(-10, 40), // Already in Celsius
                Condition = GetRandomWeatherCondition()
            };
        }

        private void ProcessWeatherData(IEnumerable<WeatherData> weatherData)
        {
            foreach (var data in weatherData)
            {
                System.Threading.Thread.Sleep(500); // Simulate processing time
                // No temperature conversion needed as we're keeping it in Celsius
            }
        }

        private string GetRandomWeatherCondition()
        {
            var conditions = new[] { "Sunny", "Cloudy", "Rainy", "Snowy", "Windy" };
            return conditions[new Random().Next(conditions.Length)];
        }
    }

    public class WeatherData
    {
        public string City { get; set; }
        public int Temperature { get; set; }
        public string Condition { get; set; }
    }
}