using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Serial_DeSerial_Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Serialize button click
        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(AgeTextBox.Text))
            {
                MessageBox.Show("Please enter both Name and Age.");
                return;
            }

            // Validate age input
            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                MessageBox.Show("Please enter a valid age.");
                return;
            }

            // Create a Person object with input data
            Person person = new Person
            {
                Name = NameTextBox.Text,
                Age = age
            };

            // Get the selected serialization type from the ComboBox
            string serializationType = ((ComboBoxItem)SerializationTypeComboBox.SelectedItem).Content.ToString();

            try
            {
                // Perform serialization based on the selected type
                switch (serializationType)
                {
                    case "XML Serialization":
                        XmlSerialize(person);
                        break;
                    case "JSON Serialization":
                        JsonSerialize(person);
                        break;
                }
                MessageBox.Show($"{serializationType} completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during serialization: {ex.Message}");
            }
        }

        // Event handler for the Deserialize button click
        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected serialization type from the ComboBox
            string serializationType = ((ComboBoxItem)SerializationTypeComboBox.SelectedItem).Content.ToString();
            Person deserializedPerson = null;

            try
            {
                // Perform deserialization based on the selected type
                switch (serializationType)
                {
                    case "XML Serialization":
                        deserializedPerson = XmlDeserialize();
                        break;
                    case "JSON Serialization":
                        deserializedPerson = JsonDeserialize();
                        break;
                }

                // Display deserialized data if successful
                if (deserializedPerson != null)
                {
                    OutputTextBox.Text = $"{serializationType} Result:\nName: {deserializedPerson.Name}, Age: {deserializedPerson.Age}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during deserialization: {ex.Message}");
            }
        }

        // Method to serialize a Person object to XML
        private void XmlSerialize(Person person)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (TextWriter writer = new StreamWriter("person.xml"))
            {
                xmlSerializer.Serialize(writer, person);
            }
        }

        // Method to deserialize a Person object from XML
        private Person XmlDeserialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (TextReader reader = new StreamReader("person.xml"))
            {
                return (Person)xmlSerializer.Deserialize(reader);
            }
        }

        // Method to serialize a Person object to JSON
        private void JsonSerialize(Person person)
        {
            string jsonString = JsonSerializer.Serialize(person);
            File.WriteAllText("person.json", jsonString);
        }

        // Method to deserialize a Person object from JSON
        private Person JsonDeserialize()
        {
            string jsonString = File.ReadAllText("person.json");
            return JsonSerializer.Deserialize<Person>(jsonString);
        }
    }
}