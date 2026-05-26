using CarRentalApp;
using CarRentalApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class PaymentForm : Form
    {
        List<BookingItem> cart;

        // FILE PATHS (CHANGE ONLY THESE IF NEEDED)
        string paymentFile = "C:\\Users\\Naeem zee\\Desktop\\car rental system\\Car Rental System\\Car Rental System\\Data\\Payments.txt";

        public PaymentForm(List<BookingItem> cartList)
        {
            InitializeComponent();
            cart = cartList;

            // Wire up event handlers
            button1.Click += button1_Click; // Confirm Payment
            button2.Click += button2_Click; // Save Payment
            button3.Click += button3_Click; // Back

            LoadSummary();
        }

        private void LoadSummary()
        {
            listBox1.Items.Clear();
            foreach (BookingItem item in cart)
                listBox1.Items.Add(item.ToString());
        }

        private string GetPaymentMethod()
        {
            if (radioButton1.Checked) return "Cash";
            if (radioButton2.Checked) return "Card";
            if (radioButton3.Checked) return "Online Payment";
            return "Unknown";
        }

        // Helper method to save payment to file
        private void SavePaymentToFile()
        {
            // Ensure folder exists
            string folder = Path.GetDirectoryName(paymentFile);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using (StreamWriter sw = new StreamWriter(paymentFile, true))
            {
                sw.WriteLine("------ PAYMENT RECORD ------");
                sw.WriteLine("Customer: " + textBox1.Text);
                sw.WriteLine("Payment Method: " + GetPaymentMethod());
                sw.WriteLine("Items:");

                foreach (BookingItem item in cart)
                    sw.WriteLine(item.ToString());

                sw.WriteLine("Total Amount: Rs " + cart.Sum(i => i.TotalPrice()));
                sw.WriteLine("----------------------------");
                sw.WriteLine();
            }
        }

        // Confirm Payment → saves payment and exits
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter customer name.");
                return;
            }

            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add cars first.");
                return;
            }

            SavePaymentToFile();

            double total = cart.Sum(i => i.TotalPrice());
            MessageBox.Show($"Payment Successful!\nTotal Amount: Rs {total}");

            // Exit application
            Application.Exit();
        }

        // Save Payment → writes all details to Payments.txt
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter customer name.");
                return;
            }

            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is empty. Nothing to save.");
                return;
            }

            SavePaymentToFile();
            MessageBox.Show("Payment saved successfully to Payments.txt!");
        }

        // Back → closes form
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Successful!");

            // Move to Return Form
            ReturnForm rf = new ReturnForm();
            rf.Show();

            this.Close(); // close payment form

        
        }
    }

}
