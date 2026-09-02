using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewCitizensForm : Form
    {
        public ViewCitizensForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void ViewCitizensForm_Load(
            object sender,
            EventArgs e)
        {
            LoadCitizens();
        }

        // ==========================================
        // LOAD CITIZENS FROM DATABASE
        // ==========================================
        private void LoadCitizens()
        {
            try
            {
                // Load the latest accounts from SQL Server
                AccountStore.LoadAccounts();

                // Clear existing rows
                dgvCitizens.Rows.Clear();

                int citizenCount = 0;

                // Display only Citizen accounts
                foreach (Account account in AccountStore.Accounts)
                {
                    if (account.AccountType.Equals(
                        "Citizen",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        dgvCitizens.Rows.Add(
                            account.Id,
                            account.FullName,
                            account.Email,
                            account.Username
                        );

                        citizenCount++;
                    }
                }

                // Update total citizen count
                lblCitizenCount.Text =
                    "Total Citizens: " + citizenCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The citizens could not be loaded.\n\n" +
                    "Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // REFRESH CITIZENS
        // ==========================================
        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadCitizens();

            MessageBox.Show(
                "The citizen list has been refreshed.",
                "Refresh Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // VIEW CITIZEN DETAILS
        // ==========================================
        private void btnViewDetails_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCitizens.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a citizen first.",
                    "No Citizen Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvCitizens.SelectedRows[0];

            string citizenId =
                row.Cells[0].Value == null
                    ? ""
                    : row.Cells[0].Value.ToString();

            string fullName =
                row.Cells[1].Value == null
                    ? ""
                    : row.Cells[1].Value.ToString();

            string email =
                row.Cells[2].Value == null
                    ? ""
                    : row.Cells[2].Value.ToString();

            string username =
                row.Cells[3].Value == null
                    ? ""
                    : row.Cells[3].Value.ToString();

            string details =
                "Citizen ID: " + citizenId +
                "\n\n" +

                "Full Name: " + fullName +
                "\n\n" +

                "Email: " + email +
                "\n\n" +

                "Username: " + username +
                "\n\n" +

                "Account Type: Citizen";

            MessageBox.Show(
                details,
                "Citizen Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // BACK TO SUPER ADMIN DASHBOARD
        // ==========================================
        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}