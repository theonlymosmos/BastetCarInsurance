using System;
using System.Windows.Forms;
using BastetCarInsuranceSystem.Data;

namespace BastetCarInsuranceSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (var connection = Database.OpenConnection())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the SS database.\r\n\r\n" + ex.Message,
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            Application.Run(new SignInForm());
        }
    }
}

