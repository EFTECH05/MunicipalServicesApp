
using System;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
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
                AccountStore.LoadAccounts();

                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                string errorDetails =
                    "Application startup failed.\n\n" +
                    ex.ToString();

                try
                {
                    File.WriteAllText(
                        "startup-error.txt",
                        errorDetails
                    );
                }
                catch
                {
                    // Keep the error message available even if logging fails.
                }

                MessageBox.Show(
                    errorDetails,
                    "Application Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
