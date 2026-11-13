

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class SuperAdminDashboardForm : Form
    {
        private Account currentUser;

        // Service Request Management controls
        private Panel pnlServiceRequests;
        private Label lblServiceTitle;
        private Label lblServiceDescription;
        private Button btnManageServiceRequests;

        // ==========================================
        // DEFAULT CONSTRUCTOR
        // ==========================================

        public SuperAdminDashboardForm()
        {
            InitializeComponent();

            // Configure the existing Manage Events button.
            btnCreateEvent.Text = "MANAGE EVENTS";
            btnCreateEvent.Enabled = true;

            // Prevent duplicate event registration.
            btnCreateEvent.Click -= btnCreateEvent_Click;
            btnCreateEvent.Click += btnCreateEvent_Click;

            // Add the new Service Request Management card.
            AddServiceRequestManagementCard();
        }

        // ==========================================
        // CONSTRUCTOR WITH SUPER ADMIN ACCOUNT
        // ==========================================

        public SuperAdminDashboardForm(Account account)
            : this()
        {
            currentUser = account;
        }

        // ==========================================
        // SERVICE REQUEST MANAGEMENT CARD
        // ==========================================

        private void AddServiceRequestManagementCard()
        {
            // Enable scrolling if the dashboard becomes longer.
            pnlScroll.AutoScroll = true;

            // Main card panel.
            pnlServiceRequests = new Panel();

            pnlServiceRequests.Name = "pnlServiceRequests";

            pnlServiceRequests.Size =
                new Size(600, 155);

            pnlServiceRequests.BackColor =
                Color.FromArgb(25, 39, 62);

            pnlServiceRequests.BorderStyle =
                BorderStyle.None;

            // Heading.
            lblServiceTitle = new Label();

            lblServiceTitle.Text =
                "SERVICE REQUEST MANAGEMENT";

            lblServiceTitle.Font =
                new Font("Segoe UI", 13F, FontStyle.Bold);

            lblServiceTitle.ForeColor =
                Color.White;

            lblServiceTitle.AutoSize = true;

            lblServiceTitle.Location =
                new Point(22, 18);

            // Description.
            lblServiceDescription = new Label();

            lblServiceDescription.Text =
                "Monitor municipal service requests, review progress, " +
                "update request statuses and manage priorities.";

            lblServiceDescription.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);

            lblServiceDescription.ForeColor =
                Color.FromArgb(205, 215, 230);

            lblServiceDescription.AutoSize = false;

            lblServiceDescription.Location =
                new Point(22, 48);

            lblServiceDescription.Size =
                new Size(530, 40);

            // Manage requests button.
            btnManageServiceRequests = new Button();

            btnManageServiceRequests.Name =
                "btnManageServiceRequests";

            btnManageServiceRequests.Text =
                "MANAGE SERVICE REQUESTS  →";

            btnManageServiceRequests.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            btnManageServiceRequests.ForeColor =
                Color.White;

            btnManageServiceRequests.BackColor =
                Color.FromArgb(37, 117, 225);

            btnManageServiceRequests.FlatStyle =
                FlatStyle.Flat;

            btnManageServiceRequests.FlatAppearance.BorderSize = 0;

            btnManageServiceRequests.Cursor =
                Cursors.Hand;

            btnManageServiceRequests.Size =
                new Size(250, 38);

            btnManageServiceRequests.Location =
                new Point(22, 100);

            btnManageServiceRequests.Click +=
                btnManageServiceRequests_Click;

            // Add controls to the card.
            pnlServiceRequests.Controls.Add(lblServiceTitle);
            pnlServiceRequests.Controls.Add(lblServiceDescription);
            pnlServiceRequests.Controls.Add(btnManageServiceRequests);

            // Place the card underneath the existing dashboard controls.
            PositionServiceRequestCard();

            pnlScroll.Controls.Add(pnlServiceRequests);

            // Keep the card width responsive when the panel is resized.
            pnlScroll.Resize += pnlScroll_Resize;
        }

        // ==========================================
        // POSITION SERVICE REQUEST CARD
        // ==========================================

        private void PositionServiceRequestCard()
        {
            if (pnlServiceRequests == null)
            {
                return;
            }

            int bottomPosition = 15;

            // Find the bottom of all existing dashboard controls.
            foreach (Control control in pnlScroll.Controls)
            {
                if (control == pnlServiceRequests)
                {
                    continue;
                }

                bottomPosition = Math.Max(
                    bottomPosition,
                    control.Bottom + 15);
            }

            pnlServiceRequests.Location = new Point(
                20,
                bottomPosition);

            int availableWidth =
                pnlScroll.ClientSize.Width -
                pnlScroll.Padding.Horizontal -
                45;

            pnlServiceRequests.Width =
                Math.Max(300, availableWidth);

            lblServiceDescription.Width =
                Math.Max(200, pnlServiceRequests.Width - 44);
        }

        // ==========================================
        // RESIZE SERVICE REQUEST CARD
        // ==========================================

        private void pnlScroll_Resize(
            object sender,
            EventArgs e)
        {
            PositionServiceRequestCard();
        }

        // ==========================================
        // OPEN SERVICE REQUEST MANAGEMENT
        // ==========================================

        private void btnManageServiceRequests_Click(
            object sender,
            EventArgs e)
        {
            if (!IsSuperAdmin())
            {
                return;
            }

            using (ServiceRequestStatusForm statusForm =
                new ServiceRequestStatusForm(currentUser))
            {
                statusForm.ShowDialog(this);
            }
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
            if (!IsSuperAdmin())
            {
                return;
            }

            using (CreateAdminForm createAdminForm =
                new CreateAdminForm())
            {
                createAdminForm.ShowDialog(this);
            }

            try
            {
                AccountStore.LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to refresh accounts.\n\n" +
                    ex.Message,
                    "Account Refresh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // MANAGE EVENTS AND ANNOUNCEMENTS
        // ==========================================

        private void btnCreateEvent_Click(
            object sender,
            EventArgs e)
        {
            if (!IsSuperAdmin())
            {
                return;
            }

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
            if (!IsSuperAdmin())
            {
                return;
            }

            try
            {
                using (ManageAdminsForm manageAdminsForm =
                    new ManageAdminsForm())
                {
                    manageAdminsForm.ShowDialog(this);
                }

                AccountStore.LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open or refresh Manage Administrators.\n\n"
                    + ex.Message,
                    "Manage Administrators",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // VIEW CITIZENS
        // ==========================================

        private void btnViewCitizens_Click(
            object sender,
            EventArgs e)
        {
            if (!IsSuperAdmin())
            {
                return;
            }

            using (ViewCitizensForm viewCitizensForm =
                new ViewCitizensForm())
            {
                viewCitizensForm.ShowDialog(this);
            }

            try
            {
                AccountStore.LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to refresh accounts.\n\n" +
                    ex.Message,
                    "Account Refresh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // VIEW ALL ACCOUNTS
        // ==========================================

        private void btnViewAccounts_Click(
            object sender,
            EventArgs e)
        {
            if (!IsSuperAdmin())
            {
                return;
            }

            using (ViewAccountsForm viewAccountsForm =
                new ViewAccountsForm())
            {
                viewAccountsForm.ShowDialog(this);
            }

            try
            {
                AccountStore.LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to refresh accounts.\n\n" +
                    ex.Message,
                    "Account Refresh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // VERIFY SUPER ADMIN ACCESS
        // ==========================================

        private bool IsSuperAdmin()
        {
            if (currentUser == null)
            {
                MessageBox.Show(
                    "Super Administrator account information could not be loaded.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!string.Equals(
                currentUser.AccountType,
                "SuperAdmin",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Only Super Administrators can access this section.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
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
                Close();
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

        // ==========================================
        // HEADER PANEL PAINT
        // ==========================================

        private void pnlHeader_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}
