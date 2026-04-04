using System;
using System.Data;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class CreateCarForm : Form
    {
        public CreateCarForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int customerId;
            int carId;
            int policyId;
            int year;

            if (!TryGetSelectedCustomerId(out customerId))
            {
                return;
            }

            if (!int.TryParse(textBox7.Text.Trim(), out carId))
            {
                MessageBox.Show("Car ID must be numeric.");
                return;
            }

            if (!int.TryParse(textBox8.Text.Trim(), out policyId))
            {
                MessageBox.Show("Policy ID must be numeric.");
                return;
            }

            if (!int.TryParse(textBox11.Text.Trim(), out year))
            {
                MessageBox.Show("Year must be numeric.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) ||
                string.IsNullOrWhiteSpace(textBox12.Text))
            {
                MessageBox.Show("Please fill in model, manufacturer, and license plate.");
                return;
            }

            try
            {
                Database.ExecuteTransaction((connection, transaction) =>
                {
                    bool policyBelongsToCustomer = Convert.ToInt32(
                        Database.Scalar(
                            connection,
                            transaction,
                            @"SELECT COUNT(1)
                              FROM INSURANCE_POLICY
                              WHERE POLICYID = @POLICYID AND CUSTOMERID = @CUSTOMERID",
                            Database.Int("@POLICYID", policyId),
                            Database.Int("@CUSTOMERID", customerId))) > 0;

                    if (!policyBelongsToCustomer)
                    {
                        throw new InvalidOperationException("The selected customer does not own that policy ID.");
                    }

                    Database.Execute(
                        connection,
                        transaction,
                        @"INSERT INTO CAR (CARID, POLICYID, MODEL, MANIFACTURER, LICENSE_PLATE, YEAR)
                          VALUES (@CARID, @POLICYID, @MODEL, @MANIFACTURER, @LICENSE_PLATE, @YEAR)",
                        Database.Int("@CARID", carId),
                        Database.Int("@POLICYID", policyId),
                        Database.Text("@MODEL", textBox9.Text),
                        Database.Text("@MANIFACTURER", textBox10.Text),
                        Database.Text("@LICENSE_PLATE", textBox12.Text),
                        Database.Int("@YEAR", year));

                    Database.Execute(
                        connection,
                        transaction,
                        "INSERT INTO OWNSS (CARID, CUSTOMERID) VALUES (@CARID, @CUSTOMERID)",
                        Database.Int("@CARID", carId),
                        Database.Int("@CUSTOMERID", customerId));
                });

                MessageBox.Show("Car added successfully.");
                ClearInputs();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CreateCarForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
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

        private void ClearInputs()
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }
    }
}

