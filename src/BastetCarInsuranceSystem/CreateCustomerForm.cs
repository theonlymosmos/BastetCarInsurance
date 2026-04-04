using System;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class CreateCustomerForm : Form
    {
        public CreateCustomerForm()
        {
            InitializeComponent();
        }

        private void CreateCustomerForm_Load(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int customerId;
            int driverLicenseNumber;

            if (!int.TryParse(textBox9.Text.Trim(), out customerId))
            {
                MessageBox.Show("Customer ID must be numeric.");
                return;
            }

            if (!int.TryParse(textBox16.Text.Trim(), out driverLicenseNumber))
            {
                MessageBox.Show("Driver license number must be numeric.");
                return;
            }

            if (!HasRequiredCustomerFields())
            {
                MessageBox.Show("Please fill in all customer fields.");
                return;
            }

            try
            {
                int rowsAffected = Database.Execute(
                    @"INSERT INTO CUSTOMER
                      (CUSTOMERID, FIRSTNAME, LASTNAME, EMAIL, CITY, STATE, STREET, DRIVERLICENSENO)
                      VALUES
                      (@CustomerID, @FirstName, @LastName, @Email, @City, @State, @Street, @DriverLicenseNO)",
                    Database.Int("@CustomerID", customerId),
                    Database.Text("@FirstName", textBox15.Text),
                    Database.Text("@LastName", textBox14.Text),
                    Database.Text("@Email", textBox13.Text),
                    Database.Text("@City", textBox12.Text),
                    Database.Text("@State", textBox10.Text),
                    Database.Text("@Street", textBox11.Text),
                    Database.Int("@DriverLicenseNO", driverLicenseNumber));

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer inserted successfully.");
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Insert failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
        }

        private bool HasRequiredCustomerFields()
        {
            return
                !string.IsNullOrWhiteSpace(textBox15.Text) &&
                !string.IsNullOrWhiteSpace(textBox14.Text) &&
                !string.IsNullOrWhiteSpace(textBox13.Text) &&
                !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrWhiteSpace(textBox11.Text);
        }

        private void ClearInputs()
        {
            textBox9.Clear();
            textBox15.Clear();
            textBox14.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox16.Clear();
        }
    }
}

