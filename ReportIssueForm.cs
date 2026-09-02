using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        private string selectedAttachment = "";

        private static List<Issue> reportedIssues =
            new List<Issue>();

        public ReportIssueForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void ReportIssueForm_Load(
            object sender,
            EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            UpdateProgress();
        }

        // ==========================================
        // LOCATION CHANGED
        // ==========================================
        private void txtLocation_TextChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        // ==========================================
        // CATEGORY CHANGED
        // ==========================================
        private void cmbCategory_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        // ==========================================
        // DESCRIPTION CHANGED
        // ==========================================
        private void txtDescription_TextChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }

        // ==========================================
        // ATTACHMENT
        // ==========================================
        private void btnAttachment_Click(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog openFileDialog =
                new OpenFileDialog())
            {
                openFileDialog.Title =
                    "Select an Attachment";

                openFileDialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.gif|" +
                    "Documents|*.pdf;*.doc;*.docx|" +
                    "All Files|*.*";

                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() ==
                    DialogResult.OK)
                {
                    selectedAttachment =
                        openFileDialog.FileName;

                    lblAttachmentName.Text =
                        "Selected: " +
                        System.IO.Path.GetFileName(
                            selectedAttachment);

                    lblAttachmentName.ForeColor =
                        System.Drawing.Color.FromArgb(
                            0,
                            130,
                            65);

                    UpdateProgress();
                }
            }
        }

        // ==========================================
        // SUBMIT ISSUE
        // ==========================================
        private void btnSubmit_Click(
            object sender,
            EventArgs e)
        {
            string location =
                txtLocation.Text.Trim();

            string category =
                cmbCategory.SelectedItem == null
                    ? ""
                    : cmbCategory.SelectedItem.ToString();

            string description =
                txtDescription.Text.Trim();

            // --------------------------------------
            // VALIDATE LOCATION
            // --------------------------------------
            if (location == "")
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Location Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtLocation.Focus();

                return;
            }

            // --------------------------------------
            // VALIDATE CATEGORY
            // --------------------------------------
            if (category == "")
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Category Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategory.Focus();

                return;
            }

            // --------------------------------------
            // VALIDATE DESCRIPTION
            // --------------------------------------
            if (description == "")
            {
                MessageBox.Show(
                    "Please provide a detailed description of the issue.",
                    "Description Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDescription.Focus();

                return;
            }

            // --------------------------------------
            // DESCRIPTION LENGTH
            // --------------------------------------
            if (description.Length < 10)
            {
                MessageBox.Show(
                    "Please provide a more detailed description.\n\n" +
                    "The description should contain at least 10 characters.",
                    "Description Too Short",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDescription.Focus();

                return;
            }

            // --------------------------------------
            // CREATE ISSUE OBJECT
            // --------------------------------------
            Issue newIssue = new Issue
            {
                Location = location,
                Category = category,
                Description = description,
                Attachment = selectedAttachment
            };

            // ======================================
            // SAVE TO DATABASE
            // ======================================
            bool success =
                IssueStore.AddIssue(newIssue);

            // ======================================
            // DATABASE SAVE SUCCESSFUL
            // ======================================
            if (success)
            {
                // Also keep it in the local list.
                reportedIssues.Add(newIssue);

                progressBar.Value = 100;

                lblProgressMessage.Text =
                    "Issue submitted successfully! " +
                    "Thank you for helping your community.";

                MessageBox.Show(
                    "Your issue has been submitted successfully!\n\n" +
                    "Issue ID: " + newIssue.Id + "\n" +
                    "Category: " + category + "\n" +
                    "Location: " + location + "\n\n" +
                    "Thank you for helping improve your community.",
                    "Issue Submitted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearForm();
            }
            else
            {
                // ==================================
                // DATABASE SAVE FAILED
                // ==================================
                MessageBox.Show(
                    "The issue could not be saved to the database.\n\n" +
                    "Please check your database connection and try again.",
                    "Submission Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // CLEAR BUTTON
        // ==========================================
        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to clear all the information you entered?",
                    "Clear Form",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        // ==========================================
        // BACK BUTTON
        // ==========================================
        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to return to the Main Menu?\n\n" +
                    "Any information you entered will be lost.",
                    "Return to Main Menu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ==========================================
        // CLEAR FORM
        // ==========================================
        private void ClearForm()
        {
            txtLocation.Clear();

            cmbCategory.SelectedIndex = -1;

            txtDescription.Clear();

            selectedAttachment = "";

            lblAttachmentName.Text =
                "No file selected.";

            lblAttachmentName.ForeColor =
                System.Drawing.Color.DimGray;

            progressBar.Value = 0;

            UpdateProgress();

            txtLocation.Focus();
        }

        // ==========================================
        // UPDATE PROGRESS
        // ==========================================
        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(
                txtLocation.Text))
            {
                progress += 25;
            }

            if (cmbCategory.SelectedIndex >= 0)
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(
                txtDescription.Text))
            {
                progress += 35;
            }

            if (!string.IsNullOrEmpty(
                selectedAttachment))
            {
                progress += 15;
            }

            if (progress > 100)
            {
                progress = 100;
            }

            progressBar.Value = progress;

            if (progress == 0)
            {
                lblProgressMessage.Text =
                    "Let's get started! Complete the fields above.";
            }
            else if (progress < 50)
            {
                lblProgressMessage.Text =
                    "Good start! Keep going.";
            }
            else if (progress < 80)
            {
                lblProgressMessage.Text =
                    "You're making great progress!";
            }
            else if (progress < 100)
            {
                lblProgressMessage.Text =
                    "Almost there! Just a little more.";
            }
            else
            {
                lblProgressMessage.Text =
                    "Everything is ready. You can submit your issue!";
            }
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