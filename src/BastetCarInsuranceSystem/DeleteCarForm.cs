using System;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class DeleteCarForm : Form
    {
        public DeleteCarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carId;

            if (!int.TryParse(textBox2.Text.Trim(), out carId))
            {
                MessageBox.Show("Car ID must be numeric.");
                return;
            }

            try
            {
                Database.ExecuteTransaction((connection, transaction) =>
                {
                    bool carExists = Convert.ToInt32(
                        Database.Scalar(
                            connection,
                            transaction,
                            "SELECT COUNT(1) FROM CAR WHERE CARID = @CarID",
                            Database.Int("@CarID", carId))) > 0;

                    if (!carExists)
                    {
                        throw new InvalidOperationException("Car not found.");
                    }

                    Database.Execute(
                        connection,
                        transaction,
                        @"
                        DELETE FROM COMMITS
                        WHERE ACCIDENT_ID IN (
                            SELECT ACCIDENT_ID
                            FROM CAR_ACCIDENT
                            WHERE CARID = @CarID
                        );

                        DELETE FROM CAR_ACCIDENT
                        WHERE CARID = @CarID;

                        DELETE FROM COLOR
                        WHERE CARID = @CarID;

                        DELETE FROM OWNSS
                        WHERE CARID = @CarID;

                        DELETE FROM CAR
                        WHERE CARID = @CarID;",
                        Database.Int("@CarID", carId));
                });

                MessageBox.Show("Car deleted successfully.");
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DeleteCarForm_Load(object sender, EventArgs e)
        {
        }
    }
}

