
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class AdminDashboardForm : Form
    {
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

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, Municipal Administrator";
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            using (ViewIssuesForm viewIssuesForm = new ViewIssuesForm())
            {
                viewIssuesForm.ShowDialog(this);
            }
        }

        private void btnManageIssues_Click(object sender, EventArgs e)
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

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Issue status updates are not available yet.",
                "Update Issue Status",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnViewCitizens_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Citizens section will display registered citizen accounts.",
                "View Citizens",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

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

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            using (CreateEventForm createEventForm = new CreateEventForm())
            {
                createEventForm.ShowDialog(this);
            }
        }

        private void btnViewEvents_Click(object sender, EventArgs e)
        {
            using (LocalEventsForm localEventsForm = new LocalEventsForm())
            {
                localEventsForm.ShowDialog(this);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
