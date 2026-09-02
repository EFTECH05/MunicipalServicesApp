
using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class CreateAdminForm : Form
    {
        public CreateAdminForm()
        {
            InitializeComponent();
        }

        private void CreateAdminForm_Load(object sender, EventArgs e)
        {
            txtAdminFullName.Focus();
        }

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtAdminPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;

            txtAdminConfirmPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        private void btnCreateAdmin_Click(object sender, EventArgs e)
        {
            string fullName = txtAdminFullName.Text.Trim();
            string username = txtAdminUsername.Text.Trim();
            string password = txtAdminPassword.Text;
            string confirmPassword =
                txtAdminConfirmPassword.Text;

            // Check required fields
            if (fullName == "" ||
                username == "" ||
                password == "" ||
                confirmPassword == "")
            {
                MessageBox.Show(
                    "Please complete all required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Check password length
            if (password.Length < 5)
            {
                MessageBox.Show(
                    "The password must contain at least 5 characters.",
                    "Password Too Short",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtAdminPassword.Focus();
                return;
            }

            // Check password confirmation
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "The passwords do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtAdminConfirmPassword.Clear();
                txtAdminConfirmPassword.Focus();

                return;
            }

            // Check whether username already exists
            if (AccountStore.UsernameExists(username))
            {
                MessageBox.Show(
                    "That username is already registered.\n\n" +
                    "Please choose another username.",
                    "Username Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtAdminUsername.Focus();

                return;
            }

            // Create Admin account
            // Admin accounts do not require a Gmail address
            bool success = AccountStore.AddAccount(
                username,
                password,
                fullName,
                "Admin",
                ""
            );

            if (success)
            {
                MessageBox.Show(
                    "Administrator account created successfully!\n\n" +
                    "Administrator: " + fullName + "\n" +
                    "Username: " + username + "\n\n" +
                    "The administrator can now log in using these credentials.",
                    "Administrator Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Clear fields
                txtAdminFullName.Clear();
                txtAdminUsername.Clear();
                txtAdminPassword.Clear();
                txtAdminConfirmPassword.Clear();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "The administrator account could not be created.\n\n" +
                    "Please check the database connection and try again.",
                    "Creation Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to cancel?",
                    "Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

