using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class SuperAdminDashboardForm : Form
    {
        public SuperAdminDashboardForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void SuperAdminDashboardForm_Load(
            object sender,
            EventArgs e)
        {
            lblWelcome.Text =
                "Welcome, Super Administrator";
        }

        // ==========================================
        // CREATE ADMINISTRATOR
        // ==========================================
        private void btnCreateAdmin_Click(
            object sender,
            EventArgs e)
        {
            CreateAdminForm createAdminForm =
                new CreateAdminForm();

            createAdminForm.ShowDialog();

            // Reload accounts after creating
            // an administrator.
            try
            {
                AccountStore.LoadAccounts();
            }
            catch
            {
                // CreateAdminForm already handles
                // database errors.
            }
        }

        // ==========================================
        // MANAGE ADMINISTRATORS
        // ==========================================
        private void btnManageAdmins_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "The Manage Administrators section will allow the Super Administrator to view, edit and manage administrator accounts.",
                "Manage Administrators",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // VIEW CITIZENS
        // ==========================================
        private void btnViewCitizens_Click(
            object sender,
            EventArgs e)
        {
            ViewCitizensForm viewCitizensForm =
                new ViewCitizensForm();

            viewCitizensForm.ShowDialog();

            // Reload accounts when returning
            // from the citizens screen.
            try
            {
                AccountStore.LoadAccounts();
            }
            catch
            {
                // ViewCitizensForm already handles
                // database errors.
            }
        }

        // ==========================================
        // VIEW ALL ACCOUNTS
        // ==========================================
        private void btnViewAccounts_Click(
            object sender,
            EventArgs e)
        {
            ViewAccountsForm viewAccountsForm =
                new ViewAccountsForm();

            viewAccountsForm.ShowDialog();

            // Reload accounts when returning
            // from the accounts screen.
            try
            {
                AccountStore.LoadAccounts();
            }
            catch
            {
                // ViewAccountsForm already handles
                // database errors.
            }
        }

        // ==========================================
        // LOGOUT
        // ==========================================
        private void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to log out?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm =
                    new LoginForm();

                loginForm.Show();

                this.Close();
            }
        }

        // ==========================================
        // SECTION DESCRIPTION CLICK
        // ==========================================
        private void lblSectionDescription_Click(
            object sender,
            EventArgs e)
        {

        }

        // ==========================================
        // MAIN PANEL PAINT
        // ==========================================
        private void pnlMain_Paint(
            object sender,
            PaintEventArgs e)
        {

        }
    }
}