using System;
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
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                lblWelcome.Text =
                    "Welcome, " + currentUser.FullName;
            }
        }

        // ==========================================
        // REPORT AN ISSUE
        // ==========================================
        private void btnReportIssues_Click(
            object sender,
            EventArgs e)
        {
            ReportIssueForm reportIssueForm =
                new ReportIssueForm();

            reportIssueForm.ShowDialog();
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
        // HEADER PANEL PAINT
        // ==========================================
        private void pnlHeader_Paint(
            object sender,
            PaintEventArgs e)
        {

        }
    }
}