using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class UpdateCarForm : Form
    {
        public UpdateCarForm()
        {
            InitializeComponent();
            LoadCars();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carId;

            if (!TryGetSelectedCarId(out carId))
            {
                return;
            }

            List<string> updates = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(Database.Int("@CARID", carId));

            if (checkBox1.Checked)
            {
                int policyId;

                if (!int.TryParse(textBox7.Text.Trim(), out policyId))
                {
                    MessageBox.Show("Policy ID must be numeric.");
                    return;
                }

                bool policyExists = Convert.ToInt32(
                    Database.Scalar(
                        "SELECT COUNT(1) FROM INSURANCE_POLICY WHERE POLICYID = @POLICYID",
                        Database.Int("@POLICYID", policyId))) > 0;

                if (!policyExists)
                {
                    MessageBox.Show("Policy ID was not found.");
                    return;
                }

                updates.Add("POLICYID = @POLICYID");
                parameters.Add(Database.Int("@POLICYID", policyId));
            }

            if (checkBox2.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    MessageBox.Show("Model cannot be empty.");
                    return;
                }

                updates.Add("MODEL = @MODEL");
                parameters.Add(Database.Text("@MODEL", textBox8.Text));
            }

            if (checkBox3.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    MessageBox.Show("Manufacturer cannot be empty.");
                    return;
                }

                updates.Add("MANIFACTURER = @MANIFACTURER");
                parameters.Add(Database.Text("@MANIFACTURER", textBox9.Text));
            }

            if (checkBox4.Checked)
            {
                int year;

                if (!int.TryParse(textBox10.Text.Trim(), out year))
                {
                    MessageBox.Show("Year must be numeric.");
                    return;
                }

                updates.Add("YEAR = @YEAR");
                parameters.Add(Database.Int("@YEAR", year));
            }

            if (checkBox5.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox11.Text))
                {
                    MessageBox.Show("License plate cannot be empty.");
                    return;
                }

                updates.Add("LICENSE_PLATE = @LICENSE_PLATE");
                parameters.Add(Database.Text("@LICENSE_PLATE", textBox11.Text));
            }

            if (updates.Count == 0)
            {
                MessageBox.Show("Select at least one field to update.");
                return;
            }

            try
            {
                string updateQuery = "UPDATE CAR SET " + string.Join(", ", updates) + " WHERE CARID = @CARID";
                int rowsAffected = Database.Execute(updateQuery, parameters.ToArray());

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Car updated successfully.");
                    LoadCars();
                }
                else
                {
                    MessageBox.Show("Car not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCars()
        {
            DataTable cars = Database.Query(
                @"SELECT CARID,
                         CAST(CARID AS VARCHAR(10)) + ' - ' + ISNULL(MODEL, 'No Model') AS DisplayName
                  FROM CAR
                  ORDER BY CARID");

            comboBox1.DataSource = cars;
            comboBox1.DisplayMember = "DisplayName";
            comboBox1.ValueMember = "CARID";
        }

        private bool TryGetSelectedCarId(out int carId)
        {
            carId = 0;

            if (comboBox1.SelectedValue == null || !int.TryParse(comboBox1.SelectedValue.ToString(), out carId))
            {
                MessageBox.Show("Please select a valid car.");
                return false;
            }

            return true;
        }
    }
}

