using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ForexExchangeWPF
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<CurrencyRate> currencyRates;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCurrencyRates();
            UpdateUI();
        }

        private void InitializeCurrencyRates()
        {
            currencyRates = new ObservableCollection<CurrencyRate>
            {
                new CurrencyRate { Currency = "EUR", Rate = 0.85M },
                new CurrencyRate { Currency = "GBP", Rate = 0.73M },
                new CurrencyRate { Currency = "JPY", Rate = 110.33M },
                new CurrencyRate { Currency = "AUD", Rate = 1.34M },
                new CurrencyRate { Currency = "CAD", Rate = 1.25M }

            };
            DataContext = currencyRates;
        }

        private async void UpdateRatesButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateRatesButton.IsEnabled = false;
            ResultTextBlock.Text = "Updating rates...";

            try
            {
                await Task.Run(() => ProcessExchangeRates());
                UpdateUI();
                ResultTextBlock.Text = "Rates updated successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ResultTextBlock.Text = "Failed to update rates.";
            }
            finally
            {
                UpdateRatesButton.IsEnabled = true;
            }
        }

        private void ProcessExchangeRates()
        {
            // Simulate some processing time
            System.Threading.Thread.Sleep(2000);

            // Update rates with some random fluctuation
            Random rand = new Random();
            foreach (var rate in currencyRates)
            {
                rate.Rate = Math.Round(rate.Rate * (decimal)(1 + (rand.NextDouble() - 0.5) * 0.1), 4);
            }
        }

        private void UpdateUI()
        {
            // This method is no longer needed for updating the ListView, 
            // but we keep it for updating the ComboBox
            Application.Current.Dispatcher.Invoke(() =>
            {
                CurrencyComboBox.ItemsSource = currencyRates.Select(r => r.Currency);
                CurrencyComboBox.SelectedIndex = 0;
            });
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                var selectedCurrency = CurrencyComboBox.SelectedItem as string;
                var rate = currencyRates.FirstOrDefault(r => r.Currency == selectedCurrency)?.Rate ?? 1;
                var convertedAmount = amount * rate;
                ResultTextBlock.Text = $"{amount} USD = {convertedAmount:F2} {selectedCurrency}";
            }
            else
            {
                ResultTextBlock.Text = "Please enter a valid amount.";
            }
        }

        private void RatesListView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedItem = e.Row.Item as CurrencyRate;
                var editedTextBox = e.EditingElement as TextBox;

                if (editedItem != null && editedTextBox != null && decimal.TryParse(editedTextBox.Text, out decimal newRate))
                {
                    editedItem.Rate = newRate;
                }
            }
        }
    }

    public class CurrencyRate : INotifyPropertyChanged
    {
        private string _currency;
        private decimal _rate;

        public string Currency
        {
            get => _currency;
            set
            {
                if (_currency != value)
                {
                    _currency = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Rate
        {
            get => _rate;
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}