using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class CitizenSignUpForm : Form
    {
        public CitizenSignUpForm()
        {
            InitializeComponent();
        }

        private void CitizenSignUpForm_Load(object sender, EventArgs e)
        {
            txtFullName.Focus();
        }

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;

            txtConfirmPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        private void btnRegister_Click(
            object sender,
            EventArgs e)
        {
            string fullName =
                txtFullName.Text.Trim();

            string email =
                txtEmail.Text.Trim();

            string username =
                txtUsername.Text.Trim();

            string password =
                txtPassword.Text;

            string confirmPassword =
                txtConfirmPassword.Text;


            // ==========================================
            // CHECK REQUIRED FIELDS
            // ==========================================
            if (fullName == "" ||
                email == "" ||
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


            // ==========================================
            // CHECK GMAIL ADDRESS
            // ==========================================
            if (!email.EndsWith(
                "@gmail.com",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Please enter a valid Gmail address.\n\n" +
                    "Example: example@gmail.com",
                    "Invalid Gmail Address",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();

                return;
            }


            // ==========================================
            // CHECK PASSWORD LENGTH
            // ==========================================
            if (password.Length < 5)
            {
                MessageBox.Show(
                    "Password must contain at least 5 characters.",
                    "Password Too Short",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();

                return;
            }


            // ==========================================
            // CHECK PASSWORD CONFIRMATION
            // ==========================================
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "The passwords do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtConfirmPassword.Clear();

                txtConfirmPassword.Focus();

                return;
            }


            // ==========================================
            // CHECK USERNAME
            // ==========================================
            if (AccountStore.UsernameExists(username))
            {
                MessageBox.Show(
                    "That username is already registered.\n\n" +
                    "Please choose another username.",
                    "Username Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsername.Focus();

                return;
            }


            // ==========================================
            // CHECK EMAIL
            // ==========================================
            if (AccountStore.EmailExists(email))
            {
                MessageBox.Show(
                    "That Gmail address is already registered.\n\n" +
                    "Please use another Gmail address.",
                    "Gmail Already Registered",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();

                return;
            }


            // ==========================================
            // CREATE CITIZEN ACCOUNT
            // ==========================================
            bool success =
                AccountStore.AddAccount(
                    username,
                    password,
                    fullName,
                    "Citizen",
                    email
                );


            // ==========================================
            // REGISTRATION SUCCESSFUL
            // ==========================================
            if (success)
            {
                MessageBox.Show(
                    "Citizen account created successfully!\n\n" +
                    "Welcome, " + fullName + "!\n\n" +
                    "You are now being taken to the Municipal Services Main Menu.",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                // ==========================================
                // CREATE ACCOUNT OBJECT FOR LOGGED-IN CITIZEN
                // ==========================================
                Account newCitizen =
                    new Account
                    {
                        FullName = fullName,
                        Email = email,
                        Username = username,
                        Password = password,
                        AccountType = "Citizen"
                    };


                // ==========================================
                // OPEN MAIN MENU
                // ==========================================
                MainMenuForm mainMenu =
                    new MainMenuForm(newCitizen);

                mainMenu.Show();


                // Close the registration form
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "The account could not be created.\n\n" +
                    "Please check your database connection and try again.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ==========================================
        // CANCEL REGISTRATION
        // ==========================================
        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to cancel registration?",
                    "Cancel Registration",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
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