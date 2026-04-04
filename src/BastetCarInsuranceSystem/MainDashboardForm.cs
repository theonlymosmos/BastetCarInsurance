using System;
using System.Data;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class MainDashboardForm : Form
    {
        public MainDashboardForm()
        {
            InitializeComponent();
        }

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int customerId;

            if (!TryGetCustomerId(out customerId))
            {
                return;
            }

            try
            {
                ClearSearchResults();

                dataGridView1.DataSource = Database.Query(
                    "SELECT * FROM CUSTOMER WHERE CUSTOMERID = @CustomerID",
                    Database.Int("@CustomerID", customerId));

                DataTable customerTable = (DataTable)dataGridView1.DataSource;

                if (customerTable.Rows.Count == 0)
                {
                    MessageBox.Show("Customer not found.");
                    return;
                }

                dataGridView2.DataSource = Database.Query(
                    @"SELECT c.*
                      FROM CAR c
                      INNER JOIN OWNSS o ON c.CARID = o.CARID
                      WHERE o.CUSTOMERID = @CustomerID",
                    Database.Int("@CustomerID", customerId));

                dataGridView4.DataSource = Database.Query(
                    @"SELECT a.*
                      FROM CAR_ACCIDENT a
                      INNER JOIN OWNSS o ON a.CARID = o.CARID
                      WHERE o.CUSTOMERID = @CustomerID",
                    Database.Int("@CustomerID", customerId));

                dataGridView3.DataSource = Database.Query(
                    @"SELECT p.*, ip.PROVIDERNAME
                      FROM INSURANCE_POLICY p
                      INNER JOIN INSURANCEPROVIDER ip ON p.PROVIDERID = ip.PROVIDERID
                      WHERE p.CUSTOMERID = @CustomerID",
                    Database.Int("@CustomerID", customerId));

                MessageBox.Show("Search completed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form x = new CreateCustomerForm();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form x = new UpdateCustomerForm();
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form x = new DeleteCustomerForm();
            x.Show();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form x = new CreateEmployeeForm();
            x.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form x = new CreateCarForm();
            x.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form x = new UpdateCarForm();
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form x = new DeleteCarForm();
            x.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form x = new AccidentReportForm();
            x.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form x = new DataBrowserForm();
            x.Show();
        }

        private bool TryGetCustomerId(out int customerId)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a Customer ID.");
                customerId = 0;
                return false;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out customerId))
            {
                MessageBox.Show("Please enter a valid numeric Customer ID.");
                return false;
            }

            return true;
        }

        private void ClearSearchResults()
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
        }
    }
}

