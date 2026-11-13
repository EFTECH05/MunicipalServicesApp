
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class CitizenSignUpForm : Form
    {
        private const int OtpLength = 6;
        private const int MaxOtpAttempts = 5;
        private static readonly TimeSpan OtpValidity =
            TimeSpan.FromMinutes(5);

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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate required fields.
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please complete all required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validate Gmail address.
            if (!email.EndsWith(
                "@gmail.com",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Please enter a Gmail address.\n\n" +
                    "Example: example@gmail.com",
                    "Invalid Gmail Address",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            // Validate password length.
            if (password.Length < 5)
            {
                MessageBox.Show(
                    "Password must contain at least 5 characters.",
                    "Password Too Short",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            // Validate password confirmation.
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "The passwords do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            // Check whether username already exists.
            if (AccountStore.UsernameExists(username))
            {
                MessageBox.Show(
                    "That username is already registered.\n\n" +
                    "Please choose another username.",
                    "Username Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }

            // Check whether email already exists.
            if (AccountStore.EmailExists(email))
            {
                MessageBox.Show(
                    "That Gmail address is already registered.\n\n" +
                    "Please use another Gmail address.",
                    "Gmail Already Registered",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            // Disable registration while OTP verification runs.
            btnRegister.Enabled = false;

            try
            {
                // Generate a secure six-digit OTP.
                string otp = GenerateOtp();

                // Send the OTP to the citizen's Gmail address.
                try
                {
                    EmailService.SendRegistrationOtp(email, otp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "We could not send the verification email.\n\n" +
                        "Your account has NOT been created.\n\n" +
                        "Please check your Gmail SMTP configuration " +
                        "and internet connection.\n\n" +
                        "Details: " + ex.Message,
                        "Email Sending Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // OTP expires five minutes after it is sent.
                DateTime expiryTime = DateTime.UtcNow.Add(OtpValidity);

                bool verified = false;

                for (int attempt = 1;
                     attempt <= MaxOtpAttempts;
                     attempt++)
                {
                    if (DateTime.UtcNow >= expiryTime)
                    {
                        MessageBox.Show(
                            "Your verification code has expired.\n\n" +
                            "Please register again to request a new code.",
                            "OTP Expired",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    string enteredOtp = PromptForOtp(
                        email,
                        attempt,
                        MaxOtpAttempts);

                    // Citizen cancelled OTP verification.
                    if (enteredOtp == null)
                    {
                        MessageBox.Show(
                            "Registration cancelled. Your account " +
                            "has not been created.",
                            "Registration Cancelled",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        return;
                    }

                    // Check expiry again after the dialog closes.
                    if (DateTime.UtcNow >= expiryTime)
                    {
                        MessageBox.Show(
                            "Your verification code has expired.\n\n" +
                            "Please register again to request a new code.",
                            "OTP Expired",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    if (string.Equals(
                        enteredOtp.Trim(),
                        otp,
                        StringComparison.Ordinal))
                    {
                        verified = true;
                        break;
                    }

                    if (attempt < MaxOtpAttempts)
                    {
                        MessageBox.Show(
                            "The verification code is incorrect.\n\n" +
                            "Attempts remaining: " +
                            (MaxOtpAttempts - attempt),
                            "Incorrect OTP",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }

                if (!verified)
                {
                    MessageBox.Show(
                        "You have used all your verification attempts.\n\n" +
                        "Please register again to request a new code.",
                        "Verification Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // Recheck duplicates before creating the account.
                // This helps avoid conflicts if another registration
                // occurred while the citizen was verifying the OTP.
                if (AccountStore.UsernameExists(username))
                {
                    MessageBox.Show(
                        "This username has already been registered. " +
                        "Please choose another username.",
                        "Username Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (AccountStore.EmailExists(email))
                {
                    MessageBox.Show(
                        "This email address has already been registered.",
                        "Email Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Create the account only after OTP verification.
                bool success = AccountStore.AddAccount(
                    username,
                    password,
                    fullName,
                    "Citizen",
                    email);

                if (!success)
                {
                    MessageBox.Show(
                        "Your email was verified, but the account " +
                        "could not be created.\n\n" +
                        "Please check the database and try again.",
                        "Registration Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "Your email has been verified and your account " +
                    "has been created successfully!\n\n" +
                    "Welcome, " + fullName + "!",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Account newCitizen = new Account
                {
                    FullName = fullName,
                    Email = email,
                    Username = username,
                    Password = password,
                    AccountType = "Citizen"
                };

                MainMenuForm mainMenu = new MainMenuForm(newCitizen);
                mainMenu.Show();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred during registration.\n\n" +
                    ex.Message,
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnRegister.Enabled = true;
                }
            }
        }

        private string GenerateOtp()
        {
            byte[] randomBytes = new byte[4];

            using (RandomNumberGenerator generator =
                RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
            }

            uint randomNumber = BitConverter.ToUInt32(
                randomBytes, 0);

            int otpNumber = (int)(randomNumber % 900000) + 100000;

            return otpNumber.ToString("D6");
        }

        private string PromptForOtp(
            string email,
            int attempt,
            int maxAttempts)
        {
            using (Form dialog = new Form())
            {
                dialog.Text = "Verify Your Email";
                dialog.StartPosition =
                    FormStartPosition.CenterParent;
                dialog.FormBorderStyle =
                    FormBorderStyle.FixedDialog;
                dialog.ClientSize = new Size(430, 220);
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.ShowInTaskbar = false;
                dialog.Font = new Font("Segoe UI", 9F);

                Label lblMessage = new Label
                {
                    Text =
                        "A six-digit verification code was sent to:\n" +
                        email + "\n\n" +
                        "Enter the code below. It expires in five minutes.",
                    Location = new Point(20, 15),
                    Size = new Size(390, 75)
                };

                TextBox txtOtp = new TextBox
                {
                    Location = new Point(20, 98),
                    Size = new Size(390, 30),
                    MaxLength = OtpLength,
                    Font = new Font("Segoe UI", 14F),
                    TextAlign = HorizontalAlignment.Center
                };

                Label lblAttempts = new Label
                {
                    Text = "Attempt " + attempt + " of " + maxAttempts,
                    Location = new Point(20, 135),
                    Size = new Size(180, 22)
                };

                Button btnVerify = new Button
                {
                    Text = "VERIFY",
                    Location = new Point(220, 168),
                    Size = new Size(90, 32),
                    DialogResult = DialogResult.OK
                };

                Button btnCancel = new Button
                {
                    Text = "CANCEL",
                    Location = new Point(320, 168),
                    Size = new Size(90, 32),
                    DialogResult = DialogResult.Cancel
                };

                dialog.Controls.Add(lblMessage);
                dialog.Controls.Add(txtOtp);
                dialog.Controls.Add(lblAttempts);
                dialog.Controls.Add(btnVerify);
                dialog.Controls.Add(btnCancel);

                dialog.AcceptButton = btnVerify;
                dialog.CancelButton = btnCancel;

                txtOtp.KeyPress += (sender, e) =>
                {
                    if (!char.IsControl(e.KeyChar) &&
                        !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                };

                dialog.Shown += (sender, e) => txtOtp.Focus();

                DialogResult result = dialog.ShowDialog(this);

                if (result != DialogResult.OK)
                {
                    return null;
                }

                return txtOtp.Text.Trim();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel registration?",
                "Cancel Registration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            // Existing header paint event.
        }
    }
}
