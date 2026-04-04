using System;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    public partial class AccidentReportForm : Form
    {
        public AccidentReportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {
            try
            {
                dataGridView1.DataSource = Database.Query(
                    @"SELECT TOP 10
                             C.CUSTOMERID,
                             C.FIRSTNAME + ' ' + C.LASTNAME AS FULLNAME,
                             COUNT(*) AS ACCIDENT_COUNT
                      FROM COMMITS CM
                      INNER JOIN CUSTOMER C ON CM.CUSTOMERID = C.CUSTOMERID
                      GROUP BY C.CUSTOMERID, C.FIRSTNAME, C.LASTNAME
                      ORDER BY ACCIDENT_COUNT DESC;");
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

