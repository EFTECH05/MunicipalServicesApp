
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainMenuForm : Form
    {
        private Account currentUser;

        public MainMenuForm(Account account)
        {
            InitializeComponent();

            currentUser = account;

            ApplyModernDesign();

            // Connect the Events button without changing the Designer.
            btnEvents.Enabled = true;
            btnEvents.Text = "View Events";
            btnEvents.Click += btnEvents_Click;
        }

        // ==========================================
        // MODERN MAIN MENU DESIGN
        // ==========================================
        private void ApplyModernDesign()
        {
            this.Text = "Municipal Services | Citizen Portal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1000, 620);
            this.MinimumSize = new Size(850, 580);
            this.BackColor = Color.FromArgb(244, 247, 251);
            this.Font = new Font("Segoe UI", 9F);
            this.AutoScaleMode = AutoScaleMode.Font;

            // Main scrolling area
            pnlScroll.Dock = DockStyle.Fill;
            pnlScroll.BackColor = Color.FromArgb(244, 247, 251);
            pnlScroll.AutoScroll = true;
            pnlScroll.AutoScrollMinSize = new Size(0, 620);

            // Header
            pnlHeader.BackColor = Color.FromArgb(21, 43, 72);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Size = new Size(980, 125);
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left
                               | AnchorStyles.Right;

            lblTitle.Text = "Municipal Services";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font(
                "Segoe UI", 25F, FontStyle.Bold);
            lblTitle.Location = new Point(40, 20);
            lblTitle.AutoSize = true;

            lblSubtitle.Text =
                "Your community. Your voice. Our responsibility.";
            lblSubtitle.ForeColor = Color.FromArgb(210, 224, 239);
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.Location = new Point(44, 75);
            lblSubtitle.AutoSize = true;

            // Welcome section
            lblWelcome.ForeColor = Color.FromArgb(21, 43, 72);
            lblWelcome.Font = new Font(
                "Segoe UI", 19F, FontStyle.Bold);
            lblWelcome.Location = new Point(40, 145);
            lblWelcome.AutoSize = true;

            lblDescription.Text =
                "Access services, report problems and stay informed in your community.";
            lblDescription.ForeColor = Color.FromArgb(95, 108, 125);
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.Location = new Point(43, 188);
            lblDescription.AutoSize = true;

            // Service cards
            StyleCard(pnlReport);
            StyleCard(pnlEvents);
            StyleCard(pnlStatus);

            pnlReport.Location = new Point(40, 235);
            pnlEvents.Location = new Point(350, 235);
            pnlStatus.Location = new Point(660, 235);

            pnlReport.Size = new Size(280, 220);
            pnlEvents.Size = new Size(280, 220);
            pnlStatus.Size = new Size(280, 220);

            // Report Issues card
            StyleIcon(lblReportIcon);
            lblReportIcon.Text = "!";
            lblReportIcon.ForeColor = Color.FromArgb(0, 125, 140);
            lblReportIcon.Location = new Point(22, 20);

            StyleCardTitle(lblReportTitle);
            lblReportTitle.Text = "Report an Issue";
            lblReportTitle.Location = new Point(22, 68);

            StyleCardDescription(lblReportDescription);
            lblReportDescription.Text =
                "Report municipal problems such as damaged roads, " +
                "water leaks and other community issues.";
            lblReportDescription.Location = new Point(22, 102);
            lblReportDescription.Size = new Size(235, 55);

            StylePrimaryButton(btnReportIssues);
            btnReportIssues.Text = "Report an Issue";
            btnReportIssues.Location = new Point(22, 165);
            btnReportIssues.Size = new Size(235, 38);
            btnReportIssues.Enabled = true;

            // Events card
            StyleIcon(lblEventsIcon);
            lblEventsIcon.Text = "★";
            lblEventsIcon.ForeColor = Color.FromArgb(0, 125, 140);
            lblEventsIcon.Location = new Point(22, 20);

            StyleCardTitle(lblEventsTitle);
            lblEventsTitle.Text = "Local Events";
            lblEventsTitle.Location = new Point(22, 68);

            StyleCardDescription(lblEventsDescription);
            lblEventsDescription.Text =
                "Discover local events, community activities " +
                "and important municipal announcements.";
            lblEventsDescription.Location = new Point(22, 102);
            lblEventsDescription.Size = new Size(235, 55);

            StylePrimaryButton(btnEvents);
            btnEvents.Text = "View Events";
            btnEvents.Location = new Point(22, 165);
            btnEvents.Size = new Size(235, 38);
            btnEvents.Enabled = true;

            // Service Status card
            StyleIcon(lblStatusIcon);
            lblStatusIcon.Text = "i";
            lblStatusIcon.ForeColor = Color.FromArgb(0, 125, 140);
            lblStatusIcon.Location = new Point(22, 20);

            StyleCardTitle(lblStatusTitle);
            lblStatusTitle.Text = "Service Status";
            lblStatusTitle.Location = new Point(22, 68);

            StyleCardDescription(lblStatusDescription);
            lblStatusDescription.Text =
                "Check the progress of municipal services " +
                "and stay updated on service requests.";
            lblStatusDescription.Location = new Point(22, 102);
            lblStatusDescription.Size = new Size(235, 55);

            btnServiceStatus.Text = "Coming Soon";
            btnServiceStatus.Location = new Point(22, 165);
            btnServiceStatus.Size = new Size(235, 38);
            btnServiceStatus.BackColor = Color.FromArgb(225, 230, 236);
            btnServiceStatus.ForeColor = Color.FromArgb(110, 120, 132);
            btnServiceStatus.FlatStyle = FlatStyle.Flat;
            btnServiceStatus.FlatAppearance.BorderSize = 0;
            btnServiceStatus.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            btnServiceStatus.Cursor = Cursors.Default;
            btnServiceStatus.Enabled = false;

            // Instruction
            lblInstruction.Text =
                "Choose a service above to get started.";
            lblInstruction.ForeColor = Color.FromArgb(95, 108, 125);
            lblInstruction.Font = new Font("Segoe UI", 9F);
            lblInstruction.Location = new Point(40, 480);
            lblInstruction.AutoSize = true;

            // Logout button
            btnLogout.Text = "Log Out";
            btnLogout.Location = new Point(810, 475);
            btnLogout.Size = new Size(130, 38);
            btnLogout.BackColor = Color.FromArgb(190, 55, 65);
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Footer
            lblFooter.Text =
                "Municipal Services Application | Citizen Portal";
            lblFooter.ForeColor = Color.FromArgb(125, 135, 148);
            lblFooter.Font = new Font("Segoe UI", 8F);
            lblFooter.Location = new Point(40, 565);
            lblFooter.AutoSize = true;
        }

        // ==========================================
        // CARD STYLING HELPERS
        // ==========================================
        private void StyleCard(Panel panel)
        {
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void StyleIcon(Label label)
        {
            label.Font = new Font(
                "Segoe UI", 25F, FontStyle.Bold);
            label.Size = new Size(50, 40);
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void StyleCardTitle(Label label)
        {
            label.ForeColor = Color.FromArgb(21, 43, 72);
            label.Font = new Font(
                "Segoe UI", 13F, FontStyle.Bold);
            label.AutoSize = true;
        }

        private void StyleCardDescription(Label label)
        {
            label.ForeColor = Color.FromArgb(95, 108, 125);
            label.Font = new Font("Segoe UI", 9F);
            label.AutoSize = false;
        }

        private void StylePrimaryButton(Button button)
        {
            button.BackColor = Color.FromArgb(0, 125, 140);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void MainMenuForm_Load(
            object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                lblWelcome.Text =
                    "Welcome, " + currentUser.FullName;
            }
            else
            {
                lblWelcome.Text = "Welcome, Citizen";
            }
        }

        // ==========================================
        // REPORT AN ISSUE
        // ==========================================
        private void btnReportIssues_Click(
            object sender, EventArgs e)
        {
            using (ReportIssueForm reportIssueForm =
                new ReportIssueForm())
            {
                reportIssueForm.ShowDialog(this);
            }
        }

        // ==========================================
        // LOCAL EVENTS AND ANNOUNCEMENTS
        // ==========================================
        private void btnEvents_Click(
            object sender, EventArgs e)
        {
            using (LocalEventsForm eventsForm =
                new LocalEventsForm())
            {
                eventsForm.ShowDialog(this);
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
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                this.Close();
            }
        }

        // ==========================================
        // HEADER PANEL PAINT
        // ==========================================
        private void pnlHeader_Paint(
            object sender, PaintEventArgs e)
        {
            // The header design is configured in ApplyModernDesign().
        }
    }
}
