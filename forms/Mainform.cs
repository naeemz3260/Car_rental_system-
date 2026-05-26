using CarRentalApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainForm : Form
    {
        List<Car> cars = new List<Car>();
        List<BookingItem> cart = new List<BookingItem>();

        // FILE PATHS (CHANGE ONLY THESE IF NEEDED)
        string carsFile = " C:\\Users\\Naeem zee\\Desktop\\car rental system\\Car Rental System\\Car Rental System\\Data\\Cars.txt";
        string bookingsFile = " C:\\Users\\Naeem zee\\Desktop\\car rental system\\Car Rental System\\Car Rental System\\Data\\Bookings.txt";

        public MainForm()
        {
            InitializeComponent();

            // Make sure buttons work
            button1.Click += button1_Click; // Add
            button2.Click += button2_Click; // Edit
            button3.Click += button3_Click; // Remove
            button4.Click += button4_Click; // Checkout
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            EnsureCarsFile();       // Create Cars.txt if missing
            LoadCars();             // Load cars
            LoadCategories();       // Load categories
            FilterCarsByCategory(); // Populate listBox1 immediately
        }

        // Ensure Cars.txt exists
        private void EnsureCarsFile()
        {
            string folder = Path.GetDirectoryName(carsFile);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            if (!File.Exists(carsFile))
            {
                File.WriteAllLines(carsFile, new string[]
                {
                    "Honda Civic,Sedan,5000,7",
                    "Corolla Altis,Sedan,4800,5",
                    "Suzuki Cultus,Hatchback,3000,10",
                    "Swift,Hatchback,3500,6",
                    "Land Cruiser,SUV,15000,4",
                    "Prado,SUV,12000,3",
                    "Toyota Revo,Pickup,9000,5",
                    "Vigo,Pickup,8500,4",
                    "Hiace,Van,7000,12",
                    "APV,Van,6000,9"
                });
            }
        }

        // Load cars from Cars.txt
        private void LoadCars()
        {
            cars.Clear();

            if (!File.Exists(carsFile))
            {
                MessageBox.Show("Cars.txt not found at: " + carsFile);
                return;
            }

            foreach (string line in File.ReadAllLines(carsFile))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] p = line.Split(',');
                if (p.Length < 4) continue;

                string name = p[0].Trim();
                string category = p[1].Trim();
                if (!double.TryParse(p[2].Trim(), out double price)) continue;
                if (!int.TryParse(p[3].Trim(), out int available)) continue;

                cars.Add(new Car(name, category, price, available));
            }
        }

        // Load categories into comboBox1
        private void LoadCategories()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");

            var unique = cars.Select(c => c.Category.Trim())
                              .Distinct()
                              .OrderBy(c => c)
                              .ToList();

            foreach (string cat in unique)
                comboBox1.Items.Add(cat);

            comboBox1.SelectedIndex = 0;
        }

        // Filter cars based on selected category
        private void FilterCarsByCategory()
        {
            listBox1.Items.Clear();
            string selectedCat = comboBox1.SelectedItem.ToString().Trim();

            foreach (Car c in cars)
            {
                if (selectedCat.Equals("All", StringComparison.OrdinalIgnoreCase) ||
                    c.Category.Trim().Equals(selectedCat, StringComparison.OrdinalIgnoreCase))
                {
                    listBox1.Items.Add($"{c.Name} - Rs {c.PricePerDay}/day");
                }
            }
        }

        // ComboBox category changed
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCarsByCategory();
        }

        // Add selected car to cart
        private void button1_Click(object sender, EventArgs e) // ADD
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select a car.");
                return;
            }

            string selectedText = listBox1.SelectedItem.ToString();
            string carName = selectedText.Split('-')[0].Trim();

            Car selected = cars.FirstOrDefault(c => c.Name.Equals(carName, StringComparison.OrdinalIgnoreCase));
            if (selected == null)
            {
                MessageBox.Show("Car not found!");
                return;
            }

            int days = (int)numericUpDown1.Value;

            BookingItem item = new BookingItem(selected, days);
            cart.Add(item);

            listBox2.Items.Add(item.ToString());
            UpdateTotal();
        }

        // Edit selected cart item
        private void button2_Click(object sender, EventArgs e) // EDIT
        {
            int index = listBox2.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Select an item to edit.");
                return;
            }

            BookingItem item = cart[index];
            item.Days = (int)numericUpDown1.Value;
            listBox2.Items[index] = item.ToString();
            UpdateTotal();
        }

        // Remove selected cart item
        private void button3_Click(object sender, EventArgs e) // REMOVE
        {
            int index = listBox2.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Select an item to remove.");
                return;
            }

            cart.RemoveAt(index);
            listBox2.Items.RemoveAt(index);
            UpdateTotal();
        }

        // Update total price
        private void UpdateTotal()
        {
            double total = cart.Sum(i => i.TotalPrice());
            label4.Text = "Total: Rs " + total;
        }

        // Checkout → open PaymentForm and save booking record
        private void button4_Click(object sender, EventArgs e) // CHECKOUT
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add cars first.");
                return;
            }

            // Save booking record to Bookings.txt
            SaveBookingToFile();

            // Open PaymentForm
            PaymentForm pf = new PaymentForm(cart);
            pf.Show();
        }

        // Save booking details
        private void SaveBookingToFile()
        {
            // Ensure folder exists
            string folder = Path.GetDirectoryName(bookingsFile);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using (StreamWriter sw = new StreamWriter(bookingsFile, true))
            {
                sw.WriteLine("------ BOOKING RECORD ------");
                foreach (BookingItem item in cart)
                    sw.WriteLine(item.ToString());

                sw.WriteLine("Total Amount: Rs " + cart.Sum(i => i.TotalPrice()));
                sw.WriteLine("----------------------------");
                sw.WriteLine();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
            ReturnForm rf = new ReturnForm();
            rf.Show();   // show return form
        }

    }
}

