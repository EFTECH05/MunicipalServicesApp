using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewAccountsForm : Form
    {
        public ViewAccountsForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void ViewAccountsForm_Load(
            object sender,
            EventArgs e)
        {
            LoadAccounts();
        }

        // ==========================================
        // LOAD ALL ACCOUNTS
        // ==========================================
        private void LoadAccounts()
        {
            try
            {
                AccountStore.LoadAccounts();

                dgvAccounts.Rows.Clear();

                foreach (Account account in AccountStore.Accounts)
                {
                    dgvAccounts.Rows.Add(
                        account.Id,
                        account.FullName,
                        account.Email,
                        account.Username,
                        account.AccountType
                    );
                }

                lblAccountCount.Text =
                    "Total Accounts: " +
                    AccountStore.Accounts.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The accounts could not be loaded.\n\n" +
                    "Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // REFRESH
        // ==========================================
        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadAccounts();

            MessageBox.Show(
                "The account list has been refreshed.",
                "Refresh Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // VIEW ACCOUNT DETAILS
        // ==========================================
        private void btnViewDetails_Click(
            object sender,
            EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an account first.",
                    "No Account Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvAccounts.SelectedRows[0];

            string accountId =
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

            string accountType =
                row.Cells[4].Value == null
                    ? ""
                    : row.Cells[4].Value.ToString();

            string details =
                "Account ID: " + accountId +
                "\n\n" +
                "Full Name: " + fullName +
                "\n\n" +
                "Email: " + email +
                "\n\n" +
                "Username: " + username +
                "\n\n" +
                "Account Type: " + accountType;

            MessageBox.Show(
                details,
                "Account Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // BACK
        // ==========================================
        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        // ==========================================
        // HEADER PAINT
        // ==========================================
        private void pnlHeader_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}