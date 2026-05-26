using System;
using System.IO;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ReturnForm : Form
    {
        string filePath = "C:\\Users\\Naeem zee\\Desktop\\car rental system\\Car Rental System\\Car Rental System\\Data\\return.txt";

        public ReturnForm()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string customer = txtCustomer.Text.Trim();
            string car = txtCar.Text.Trim();

            if (customer == "" || car == "")
            {
                MessageBox.Show("Please enter both Customer Name and Car Name.");
                return;
            }

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("Customer: " + customer);
                sw.WriteLine("Car Returned: " + car);
                sw.WriteLine("Date: " + DateTime.Now);
                sw.WriteLine("--------------------------");
            }

            MessageBox.Show("Car Returned Successfully!");
            this.Close();
        }

        private void txtCar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
