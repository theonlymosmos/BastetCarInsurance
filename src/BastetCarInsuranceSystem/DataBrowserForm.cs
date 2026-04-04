using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class DataBrowserForm : Form
    {
        private static readonly Dictionary<string, string> AllowedTables =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "ADDRESS", "ADDRESS" },
                { "CAR", "CAR" },
                { "CAR_ACCIDENT", "CAR_ACCIDENT" },
                { "COLOR", "COLOR" },
                { "COMMITS", "COMMITS" },
                { "CUSTOMER", "CUSTOMER" },
                { "EMPLOYEE", "EMPLOYEE" },
                { "INSURANCE_POLICY", "INSURANCE_POLICY" },
                { "INSURANCEPROVIDER", "INSURANCEPROVIDER" },
                { "MONTHLY_REPORT", "MONTHLY_REPORT" },
                { "OWNSS", "OWNSS" },
                { "PHONE_NUMBER", "PHONE_NUMBER" },
                { "PHONE_NUMBER2", "PHONE_NUMBER2" },
                { "PHONE_NUMBER3", "PHONE_NUMBER3" },
                { "POLICYCOVERAGEITEM", "POLICYCOVERAGEITEM" }
            };

        public DataBrowserForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tableName;

            if (!AllowedTables.TryGetValue(comboBox1.Text.Trim(), out tableName))
            {
                MessageBox.Show("Please select a valid table.");
                return;
            }

            try
            {
                dataGridView1.DataSource = Database.Query("SELECT * FROM " + tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

