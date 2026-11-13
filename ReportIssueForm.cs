
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        private string selectedAttachment = "";

        private Account currentUser;

        private static List<Issue> reportedIssues =
            new List<Issue>();

        // ==========================================
        // CONSTRUCTORS
        // ==========================================

        // Kept temporarily for compatibility with
        // the existing MainMenuForm.
        public ReportIssueForm()
        {
            InitializeComponent();
        }

        // Constructor for the logged-in account.
        public ReportIssueForm(Account account)
        {
            InitializeComponent();

            currentUser = account;
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
                            0, 130, 65);

                    UpdateProgress();
                }
            }
        }


        // ==========================================
        // SUBMIT SERVICE REQUEST
        // ==========================================

        private void btnSubmit_Click(
            object sender,
            EventArgs e)
        {
            // --------------------------------------
            // CHECK LOGGED-IN ACCOUNT
            // --------------------------------------

            if (currentUser == null)
            {
                MessageBox.Show(
                    "Your logged-in account could not be identified.\n\n" +
                    "Please return to the Main Menu and open this form again.",
                    "Account Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (currentUser.AccountType != "Citizen")
            {
                MessageBox.Show(
                    "Only citizen accounts can submit municipal issues.",
                    "Access Restricted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

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


            // ======================================
            // CREATE SERVICE REQUEST
            // ======================================

            Issue newIssue = new Issue
            {
                Location = location,

                Category = category,

                Description = description,

                Attachment = selectedAttachment,

                // Link request to logged-in citizen.
                AccountId = currentUser.Id,

                // Initial request status.
                Status = "Received",

                // Default priority: Medium.
                Priority = 3,

                // Department can be assigned later.
                Department = null,

                DateReported = DateTime.Now,

                LastUpdated = DateTime.Now
            };


            // ======================================
            // SAVE TO DATABASE
            // ======================================

            try
            {
                bool success =
                    IssueStore.AddIssue(newIssue);

                if (success)
                {
                    reportedIssues.Add(newIssue);

                    progressBar.Value = 100;

                    lblProgressMessage.Text =
                        "Service request submitted successfully!";

                    MessageBox.Show(
                        "Your municipal service request has been submitted successfully!\n\n" +
                        "Reference Number: " +
                        newIssue.RequestReference + "\n" +
                        "Issue ID: " + newIssue.Id + "\n" +
                        "Category: " + category + "\n" +
                        "Location: " + location + "\n" +
                        "Status: " + newIssue.Status + "\n" +
                        "Priority: " + newIssue.PriorityName + "\n\n" +
                        "Please keep your reference number to track your request.",
                        "Request Submitted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The service request could not be saved.\n\n" +
                    ex.Message,
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

        private void pnlScroll_Paint(
            object sender,
            PaintEventArgs e)
        {

        }
    }
}
