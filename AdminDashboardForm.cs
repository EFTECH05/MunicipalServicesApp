using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, Municipal Administrator";
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            ViewIssuesForm viewIssuesForm =
                new ViewIssuesForm();

            viewIssuesForm.ShowDialog();
        }

        private void btnManageIssues_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Manage Issues section will allow administrators to review, assign and manage reported issues.",
                "Manage Issues",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Update Status section will allow administrators to update the progress of reported issues.",
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

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}