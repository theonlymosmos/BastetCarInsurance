using System;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class SignInForm : Form
    {
        private const string FixedPassword = "team2025";

        public SignInForm()
        {
            InitializeComponent();
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeIdText = textBox4.Text.Trim();
            string password = textBox5.Text;
            int employeeId;

            if (string.IsNullOrEmpty(employeeIdText) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Employee ID and Password.");
                return;
            }

            if (!int.TryParse(employeeIdText, out employeeId))
            {
                MessageBox.Show("Employee ID must be a number.");
                return;
            }

            if (!Database.EmployeeExists(employeeId))
            {
                MessageBox.Show("Employee ID was not found.");
                return;
            }

            if (!string.Equals(password, FixedPassword, StringComparison.Ordinal))
            {
                MessageBox.Show("Incorrect password. Please try again.");
                return;
            }

            MessageBox.Show("Login successful. Welcome!");

            Hide();

            MainDashboardForm mainForm = new MainDashboardForm();
            mainForm.FormClosed += delegate { Close(); };
            mainForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }
    }
}

