using System;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class CreateEmployeeForm : Form
    {
        public CreateEmployeeForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int employeeId;
            int salary;
            int? managerId;

            if (!int.TryParse(textBox7.Text.Trim(), out employeeId))
            {
                MessageBox.Show("Employee ID must be numeric.");
                return;
            }

            if (!int.TryParse(textBox12.Text.Trim(), out salary))
            {
                MessageBox.Show("Salary must be numeric.");
                return;
            }

            if (!TryGetManagerId(out managerId))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) ||
                string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("Please fill in first name, last name, and email.");
                return;
            }

            try
            {
                int rowsAffected = Database.Execute(
                    @"INSERT INTO EMPLOYEE
                      (EMPLOYEEID, EMP_EMPLOYEEID, FIRST_NAME, LAST_NAME, EMAIL, SALARY)
                      VALUES
                      (@EMPLOYEEID, @EMP_EMPLOYEEID, @FIRST_NAME, @LAST_NAME, @EMAIL, @SALARY)",
                    Database.Int("@EMPLOYEEID", employeeId),
                    Database.NullableInt("@EMP_EMPLOYEEID", managerId),
                    Database.Text("@FIRST_NAME", textBox9.Text),
                    Database.Text("@LAST_NAME", textBox10.Text),
                    Database.Text("@EMAIL", textBox11.Text),
                    Database.Int("@SALARY", salary));

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee inserted successfully.");
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
        }

        private void CreateEmployeeForm_Load(object sender, EventArgs e)
        {
        }

        private bool TryGetManagerId(out int? managerId)
        {
            managerId = null;

            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                return true;
            }

            int parsedManagerId;

            if (!int.TryParse(textBox8.Text.Trim(), out parsedManagerId))
            {
                MessageBox.Show("Manager ID must be numeric when provided.");
                return false;
            }

            managerId = parsedManagerId;
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

