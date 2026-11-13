
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class AdminDashboardForm : Form
    {
        private Account currentUser;

        // ==========================================
        // DEFAULT CONSTRUCTOR
        // ==========================================

        public AdminDashboardForm()
        {
            InitializeComponent();

            // Extend the existing dashboard to fit the new card.
            pnlMain.Height = 1060;

            // Move the footer and logout button down.
            lblFooter.Location = new Point(35, 990);
            btnLogout.Location = new Point(610, 985);

            // Add the Create Event card without changing
            // the existing four cards.
            AddCreateEventCard();
        }

        // ==========================================
        // CONSTRUCTOR WITH ADMIN ACCOUNT
        // ==========================================

        public AdminDashboardForm(Account account)
            : this()
        {
            currentUser = account;
        }

        // ==========================================
        // FORM LOAD
        // ==========================================

        private void AdminDashboardForm_Load(
            object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, Municipal Administrator";
        }

        // ==========================================
        // VIEW ISSUES
        // ==========================================

        private void btnViewIssues_Click(
            object sender, EventArgs e)
        {
            using (ViewIssuesForm viewIssuesForm =
                new ViewIssuesForm())
            {
                viewIssuesForm.ShowDialog(this);
            }
        }

        // ==========================================
        // MANAGE ISSUES
        // ==========================================

        private void btnManageIssues_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Manage Issues section allows administrators " +
                "to review reported municipal issues.\n\n" +
                "Editing and deleting issues are not available here.",
                "Manage Issues",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // UPDATE SERVICE REQUEST STATUS
        // ==========================================

        private void btnUpdateStatus_Click(
            object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show(
                    "Administrator account information could not be loaded.",
                    "Update Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!string.Equals(
                    currentUser.AccountType,
                    "Admin",
                    StringComparison.OrdinalIgnoreCase)
                &&
                !string.Equals(
                    currentUser.AccountType,
                    "SuperAdmin",
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Only administrators can update service requests.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using (ServiceRequestStatusForm statusForm =
                new ServiceRequestStatusForm(currentUser))
            {
                statusForm.ShowDialog(this);
            }
        }

        // ==========================================
        // VIEW CITIZENS
        // ==========================================

        private void btnViewCitizens_Click(
            object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Citizens section will display registered citizen accounts.",
                "View Citizens",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // CREATE EVENT CARD
        // ==========================================

        private void AddCreateEventCard()
        {
            Panel pnlCreateEvent = new Panel
            {
                Name = "pnlCreateEvent",
                BackColor = Color.FromArgb(249, 251, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(35, 780),
                Size = new Size(350, 190),
                TabIndex = 15
            };

            Panel accent = new Panel
            {
                Name = "pnlCreateEventAccent",
                BackColor = Color.FromArgb(255, 184, 0),
                Dock = DockStyle.Top,
                Height = 6
            };

            Label icon = new Label
            {
                Name = "lblCreateEventIcon",
                AutoSize = true,
                Font = new Font("Segoe UI Symbol", 28F),
                ForeColor = Color.FromArgb(0, 103, 71),
                Location = new Point(22, 22),
                Text = "＋"
            };

            Label title = new Label
            {
                Name = "lblCreateEventTitle",
                AutoSize = true,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(35, 45, 55),
                Location = new Point(85, 30),
                Text = "Events & Announcements"
            };

            Label description = new Label
            {
                Name = "lblCreateEventDescription",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(25, 78),
                Size = new Size(300, 38),
                Text = "Create and view local events or municipal announcements."
            };

            // Create Event button.
            Button btnCreateEvent = new Button
            {
                Name = "btnCreateEvent",
                BackColor = Color.FromArgb(0, 103, 71),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 130),
                Size = new Size(145, 38),
                Text = "CREATE EVENT",
                UseVisualStyleBackColor = false
            };

            btnCreateEvent.FlatAppearance.BorderSize = 0;
            btnCreateEvent.Click += btnCreateEvent_Click;

            // View Events button.
            Button btnViewEvents = new Button
            {
                Name = "btnViewEvents",
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 103, 71),
                Location = new Point(180, 130),
                Size = new Size(145, 38),
                Text = "VIEW EVENTS",
                UseVisualStyleBackColor = false
            };

            btnViewEvents.FlatAppearance.BorderColor =
                Color.FromArgb(0, 103, 71);

            btnViewEvents.Click += btnViewEvents_Click;

            // Add all controls to the new card.
            pnlCreateEvent.Controls.Add(btnCreateEvent);
            pnlCreateEvent.Controls.Add(btnViewEvents);
            pnlCreateEvent.Controls.Add(description);
            pnlCreateEvent.Controls.Add(title);
            pnlCreateEvent.Controls.Add(icon);
            pnlCreateEvent.Controls.Add(accent);

            // Add the new card to the existing dashboard.
            pnlMain.Controls.Add(pnlCreateEvent);
        }

        // ==========================================
        // CREATE EVENT
        // ==========================================

        private void btnCreateEvent_Click(
            object sender, EventArgs e)
        {
            using (CreateEventForm createEventForm =
                new CreateEventForm())
            {
                createEventForm.ShowDialog(this);
            }
        }

        // ==========================================
        // VIEW EVENTS
        // ==========================================

        private void btnViewEvents_Click(
            object sender, EventArgs e)
        {
            using (LocalEventsForm localEventsForm =
                new LocalEventsForm())
            {
                localEventsForm.ShowDialog(this);
            }
        }

        // ==========================================
        // LOGOUT
        // ==========================================

        private void btnLogout_Click(
            object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        // ==========================================
        // PANEL EVENTS
        // ==========================================

        private void pnlMain_Paint(
            object sender, PaintEventArgs e)
        {
        }

        private void pnlHeader_Paint(
            object sender, PaintEventArgs e)
        {
        }

        private void pnlScroll_Paint(
            object sender, PaintEventArgs e)
        {
        }
    }
}
