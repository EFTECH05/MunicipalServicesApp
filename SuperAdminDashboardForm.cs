
using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class SuperAdminDashboardForm : Form
    {
        public SuperAdminDashboardForm()
        {
            InitializeComponent();

            // Configure the existing Create Event button.
            // The button must already exist in the Designer.
            btnCreateEvent.Text = "MANAGE EVENTS";
            btnCreateEvent.Enabled = true;

            // Prevent the same click handler from being registered twice.
            btnCreateEvent.Click -= btnCreateEvent_Click;
            btnCreateEvent.Click += btnCreateEvent_Click;
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void SuperAdminDashboardForm_Load(
            object sender,
            EventArgs e)
        {
            lblWelcome.Text = "Welcome, Super Administrator";
        }

        // ==========================================
        // CREATE ADMINISTRATOR
        // ==========================================
        private void btnCreateAdmin_Click(
            object sender,
            EventArgs e)
        {
            using (CreateAdminForm createAdminForm =
                new CreateAdminForm())
            {
                createAdminForm.ShowDialog(this);
            }

            try
            {
                AccountStore.LoadAccounts();
            }
            catch
            {
                // Preserve existing error handling.
            }
        }

        // ==========================================
        // MANAGE EVENTS AND ANNOUNCEMENTS
        // ==========================================
        private void btnCreateEvent_Click(
            object sender,
            EventArgs e)
        {
            using (LocalEventsForm eventsForm =
                new LocalEventsForm(true))
            {
                eventsForm.ShowDialog(this);
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
                "The Manage Administrators section will allow " +
                "the Super Administrator to view, edit and manage " +
                "administrator accounts.",
                "Manage Administrators",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ==========================================
        // VIEW CITIZENS
        // ==========================================
        private void btnViewCitizens_Click(
            object sender,
            EventArgs e)
        {
            using (ViewCitizensForm viewCitizensForm =
                new ViewCitizensForm())
            {
                viewCitizensForm.ShowDialog(this);
            }

            try
            {
                AccountStore.LoadAccounts();
            }
            catch
            {
                // Preserve existing error handling.
            }
        }

        // ==========================================
        // VIEW ALL ACCOUNTS
        // ==========================================
        private void btnViewAccounts_Click(
            object sender,
            EventArgs e)
        {
            using (ViewAccountsForm viewAccountsForm =
                new ViewAccountsForm())
            {
                viewAccountsForm.ShowDialog(this);
            }

            try
            {
                AccountStore.LoadAccounts();
            }
            catch
            {
                // Preserve existing error handling.
            }
        }

        // ==========================================
        // LOGOUT
        // ==========================================
        private void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
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

        // ==========================================
        // SCROLL PANEL PAINT
        // ==========================================
        private void pnlScroll_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}
