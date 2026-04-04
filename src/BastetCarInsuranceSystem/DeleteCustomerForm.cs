using System;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class DeleteCustomerForm : Form
    {
        public DeleteCustomerForm()
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

            if (!int.TryParse(textBox2.Text.Trim(), out customerId))
            {
                MessageBox.Show("Customer ID must be numeric.");
                return;
            }

            try
            {
                Database.ExecuteTransaction((connection, transaction) =>
                {
                    bool customerExists = Convert.ToInt32(
                        Database.Scalar(
                            connection,
                            transaction,
                            "SELECT COUNT(1) FROM CUSTOMER WHERE CUSTOMERID = @CustomerID",
                            Database.Int("@CustomerID", customerId))) > 0;

                    if (!customerExists)
                    {
                        throw new InvalidOperationException("Customer not found.");
                    }

                    Database.Execute(
                        connection,
                        transaction,
                        @"
                        DECLARE @CustomerCars TABLE (CARID INT PRIMARY KEY);
                        DECLARE @CustomerPolicies TABLE (POLICYID INT PRIMARY KEY);

                        INSERT INTO @CustomerCars (CARID)
                        SELECT CARID
                        FROM OWNSS
                        WHERE CUSTOMERID = @CustomerID;

                        INSERT INTO @CustomerPolicies (POLICYID)
                        SELECT POLICYID
                        FROM INSURANCE_POLICY
                        WHERE CUSTOMERID = @CustomerID;

                        DELETE FROM COMMITS
                        WHERE CUSTOMERID = @CustomerID
                           OR ACCIDENT_ID IN (
                                SELECT ACCIDENT_ID
                                FROM CAR_ACCIDENT
                                WHERE CARID IN (SELECT CARID FROM @CustomerCars)
                           );

                        DELETE FROM CAR_ACCIDENT
                        WHERE CARID IN (SELECT CARID FROM @CustomerCars);

                        DELETE FROM COLOR
                        WHERE CARID IN (SELECT CARID FROM @CustomerCars);

                        DELETE FROM PHONE_NUMBER2
                        WHERE CUSTOMERID = @CustomerID;

                        DELETE FROM POLICYCOVERAGEITEM
                        WHERE POLICYID IN (SELECT POLICYID FROM @CustomerPolicies);

                        DELETE FROM OWNSS
                        WHERE CARID IN (SELECT CARID FROM @CustomerCars);

                        DELETE FROM CAR
                        WHERE CARID IN (SELECT CARID FROM @CustomerCars);

                        DELETE FROM INSURANCE_POLICY
                        WHERE CUSTOMERID = @CustomerID;

                        DELETE FROM CUSTOMER
                        WHERE CUSTOMERID = @CustomerID;",
                        Database.Int("@CustomerID", customerId));
                });

                MessageBox.Show("Customer deleted successfully.");
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DeleteCustomerForm_Load(object sender, EventArgs e)
        {
        }
    }
}

