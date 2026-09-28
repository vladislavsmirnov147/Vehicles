using System.Windows;
using System.Windows.Controls;
using Vehicles.Core;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        // Общая коллекция Vehicle, требуемая заданием.
        private readonly List<Vehicle> vehicles = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                LogListBox.Items.Add("Error: vehicle name cannot be empty.");
                return;
            }

            string? type = (TypeComboBox.SelectedItem as ComboBoxItem)
                ?.Content?.ToString();

            Vehicle? vehicle = type switch
            {
                "Car" => new Car(name),
                "Boat" => new Boat(name),
                "AmphibiousCar" => new AmphibiousCar(name),
                _ => null
            };

            if (vehicle == null)
            {
                LogListBox.Items.Add("Error: invalid vehicle type.");
                return;
            }

            vehicles.Add(vehicle);

            RefreshVehicles();

            LogListBox.Items.Add(
                $"Added {vehicle.GetType().Name}: {vehicle.Name}");

            NameTextBox.Clear();
        }

        private void MoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            int index = VehiclesListBox.SelectedIndex;

            if (index < 0 || index >= vehicles.Count)
            {
                LogListBox.Items.Add("Error: select a vehicle first.");
                return;
            }

            Vehicle vehicle = vehicles[index];

            // Полиморфизм: вызываем Move через базовый тип Vehicle.
            string message = vehicle.Move(10);

            LogListBox.Items.Add(message);

            RefreshVehicles();

            VehiclesListBox.SelectedIndex = index;
        }

        private void RefreshVehicles()
        {
            VehiclesListBox.Items.Clear();

            foreach (Vehicle vehicle in vehicles)
            {
                VehiclesListBox.Items.Add(vehicle.ToString());
            }
        }
    }
}