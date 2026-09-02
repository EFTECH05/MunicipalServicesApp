using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewIssuesForm : Form
    {
        public ViewIssuesForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void ViewIssuesForm_Load(
            object sender,
            EventArgs e)
        {
            LoadIssues();
        }

        // ==========================================
        // LOAD ISSUES FROM DATABASE
        // ==========================================
        private void LoadIssues()
        {
            try
            {
                IssueStore.LoadIssues();

                dgvIssues.Rows.Clear();

                foreach (Issue issue in IssueStore.Issues)
                {
                    dgvIssues.Rows.Add(
                        issue.Id,
                        issue.Location,
                        issue.Category,
                        issue.Description,
                        string.IsNullOrEmpty(issue.Attachment)
                            ? "No attachment"
                            : "Attachment available",
                        issue.DateReported.ToString(
                            "dd/MM/yyyy HH:mm")
                    );
                }

                lblIssueCount.Text =
                    "Total Issues: " +
                    IssueStore.Issues.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The issues could not be loaded.\n\n" +
                    ex.Message,
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
            LoadIssues();

            MessageBox.Show(
                "The issue list has been refreshed.",
                "Refresh Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // VIEW ISSUE DETAILS
        // ==========================================
        private void btnViewDetails_Click(
            object sender,
            EventArgs e)
        {
            if (dgvIssues.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an issue first.",
                    "No Issue Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvIssues.SelectedRows[0];

            string details =
                "Issue ID: " +
                row.Cells[0].Value +
                "\n\n" +

                "Location: " +
                row.Cells[1].Value +
                "\n\n" +

                "Category: " +
                row.Cells[2].Value +
                "\n\n" +

                "Description:\n" +
                row.Cells[3].Value +
                "\n\n" +

                "Attachment: " +
                row.Cells[4].Value +
                "\n\n" +

                "Date Reported: " +
                row.Cells[5].Value;

            MessageBox.Show(
                details,
                "Issue Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // VIEW ATTACHMENT
        // ==========================================
        private void btnViewAttachment_Click(
            object sender,
            EventArgs e)
        {
            if (dgvIssues.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an issue first.",
                    "No Issue Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvIssues.SelectedRows[0];

            int selectedIssueId =
                Convert.ToInt32(
                    row.Cells[0].Value);

            Issue selectedIssue = null;

            foreach (Issue issue in IssueStore.Issues)
            {
                if (issue.Id == selectedIssueId)
                {
                    selectedIssue = issue;
                    break;
                }
            }

            if (selectedIssue == null)
            {
                MessageBox.Show(
                    "The selected issue could not be found.",
                    "Issue Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // --------------------------------------
            // CHECK FOR ATTACHMENT
            // --------------------------------------
            if (string.IsNullOrEmpty(
                selectedIssue.Attachment))
            {
                MessageBox.Show(
                    "This issue does not have an attachment.",
                    "No Attachment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            string filePath =
                selectedIssue.Attachment;

            // --------------------------------------
            // CHECK WHETHER FILE EXISTS
            // --------------------------------------
            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    "The attachment could not be found.\n\n" +
                    "File path:\n" +
                    filePath +
                    "\n\n" +
                    "The file may have been moved or deleted.",
                    "Attachment Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // --------------------------------------
            // OPEN ATTACHMENT
            // --------------------------------------
            try
            {
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The attachment could not be opened.\n\n" +
                    ex.Message,
                    "Attachment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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