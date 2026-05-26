using System;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Simple login — change credentials as needed
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // simple hard-coded check for now
            if (user == "admin" && pass == "123")
            {
                MainForm main = new MainForm();
                main.Show();
                this.Hide(); // hide login; app continues with main form
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelUser_Click(object sender, EventArgs e)
        {

        }
    }
}
