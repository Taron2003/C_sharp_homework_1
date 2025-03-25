using System;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        // Struct definition for Person
        public struct Person
        {
            public int id;
            public string name;
            public int age;
            public string address;

            public Person(int id, string name, int age, string address)
            {
                this.id = id;
                this.name = name;
                this.age = age;
                this.address = address;
            }
        }

        // Array to store the data
        private Person[] people = new Person[10];
        private int currentIndex = 0; // To track how many people have been added

        public MainWindow()
        {
            InitializeComponent();
        }

        // Add a new person
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < people.Length)
            {
                people[currentIndex] = new Person(currentIndex + 1, "Name" + (currentIndex + 1), 20 + (currentIndex % 30), "Address" + (currentIndex + 1));
                currentIndex++;
                MessageBox.Show("Person added successfully!");
            }
            else
            {
                MessageBox.Show("Array is full!");
            }
        }

        // Display all records
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string output = "ID | Name | Age | Address\n";
            foreach (var person in people)
            {
                if (person.id != 0) // Check if this is a valid entry
                {
                    output += $"{person.id} | {person.name} | {person.age} | {person.address}\n";
                }
            }
            txtOutput.Text = output;
        }

        // Sort by Name
        private void btnSortByName_Click(object sender, RoutedEventArgs e)
        {
            Array.Sort(people, (x, y) => x.name.CompareTo(y.name));
            MessageBox.Show("Sorted by Name.");
        }

        // Sort by Age
        private void btnSortByAge_Click(object sender, RoutedEventArgs e)
        {
            Array.Sort(people, (x, y) => x.age.CompareTo(y.age));
            MessageBox.Show("Sorted by Age.");
        }

        // Search by Age
        private void btnSearchByAge_Click(object sender, RoutedEventArgs e)
        {
            int ageToSearch = 25; // Example age to search
            var result = Array.Find(people, p => p.age == ageToSearch);
            if (result.id != 0)
            {
                MessageBox.Show($"Found: {result.name} - Age: {result.age}");
            }
            else
            {
                MessageBox.Show("No record found with that age.");
            }
        }

        // Search by Name
        private void btnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            string nameToSearch = "Name5"; // Example name to search
            var result = Array.Find(people, p => p.name == nameToSearch);
            if (result.id != 0)
            {
                MessageBox.Show($"Found: {result.name} - Age: {result.age}");
            }
            else
            {
                MessageBox.Show("No record found with that name.");
            }
        }

        // Remove record by Name
        private void btnRemoveByName_Click(object sender, RoutedEventArgs e)
        {
            string nameToRemove = "Name5"; // Example name to remove
            int index = Array.FindIndex(people, p => p.name == nameToRemove);
            if (index != -1)
            {
                people[index] = new Person(); // Remove by resetting the object
                MessageBox.Show("Person removed by name.");
            }
            else
            {
                MessageBox.Show("No person found with that name.");
            }
        }

        // Remove record by Age
        private void btnRemoveByAge_Click(object sender, RoutedEventArgs e)
        {
            int ageToRemove = 25; // Example age to remove
            int index = Array.FindIndex(people, p => p.age == ageToRemove);
            if (index != -1)
            {
                people[index] = new Person(); // Remove by resetting the object
                MessageBox.Show("Person removed by age.");
            }
            else
            {
                MessageBox.Show("No person found with that age.");
            }
        }
    }
}
