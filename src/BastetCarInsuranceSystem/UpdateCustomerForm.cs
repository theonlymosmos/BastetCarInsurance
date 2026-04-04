using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class UpdateCustomerForm : Form
    {
        public UpdateCustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int customerId;

            if (!TryGetSelectedCustomerId(out customerId))
            {
                return;
            }

            List<string> updates = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(Database.Int("@CUSTOMERID", customerId));

            if (checkBox1.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Email cannot be empty.");
                    return;
                }

                updates.Add("EMAIL = @EMAIL");
                parameters.Add(Database.Text("@EMAIL", textBox6.Text));
            }

            if (checkBox2.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    MessageBox.Show("City cannot be empty.");
                    return;
                }

                updates.Add("CITY = @CITY");
                parameters.Add(Database.Text("@CITY", textBox8.Text));
            }

            if (checkBox3.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    MessageBox.Show("State cannot be empty.");
                    return;
                }

                updates.Add("STATE = @STATE");
                parameters.Add(Database.Text("@STATE", textBox9.Text));
            }

            if (checkBox4.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    MessageBox.Show("Street cannot be empty.");
                    return;
                }

                updates.Add("STREET = @STREET");
                parameters.Add(Database.Text("@STREET", textBox10.Text));
            }

            if (updates.Count == 0)
            {
                MessageBox.Show("Select at least one field to update.");
                return;
            }

            try
            {
                string updateQuery = "UPDATE CUSTOMER SET " + string.Join(", ", updates) + " WHERE CUSTOMERID = @CUSTOMERID";
                int rowsAffected = Database.Execute(updateQuery, parameters.ToArray());

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer updated successfully.");
                    LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCustomers()
        {
            DataTable customers = Database.Query(
                @"SELECT CUSTOMERID,
                         CAST(CUSTOMERID AS VARCHAR(10)) + ' - ' + FIRSTNAME + ' ' + LASTNAME AS DisplayName
                  FROM CUSTOMER
                  ORDER BY CUSTOMERID");

            comboBox1.DataSource = customers;
            comboBox1.DisplayMember = "DisplayName";
            comboBox1.ValueMember = "CUSTOMERID";
        }

        private bool TryGetSelectedCustomerId(out int customerId)
        {
            customerId = 0;

            if (comboBox1.SelectedValue == null || !int.TryParse(comboBox1.SelectedValue.ToString(), out customerId))
            {
                MessageBox.Show("Please select a valid customer.");
                return false;
            }

            return true;
        }
    }
}

