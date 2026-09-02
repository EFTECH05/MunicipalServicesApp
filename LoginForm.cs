using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Check that the user entered both fields
            if (username == "" || password == "")
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                // Check the credentials
                Account account = AccountStore.Login(
                    username,
                    password
                );

                if (account != null)
                {
                    MessageBox.Show(
                        "Login successful!\n\n" +
                        "Welcome, " + account.FullName + "!\n" +
                        "Account Type: " + account.AccountType,
                        "Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // ==============================
                    // CITIZEN
                    // ==============================
                    if (account.AccountType.Equals(
                        "Citizen",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        MainMenuForm mainMenu =
                            new MainMenuForm(account);

                        mainMenu.Show();

                        this.Hide();
                    }

                    // ==============================
                    // ADMIN
                    // ==============================
                    else if (account.AccountType.Equals(
                        "Admin",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        AdminDashboardForm adminDashboard =
                            new AdminDashboardForm();

                        adminDashboard.Show();

                        this.Hide();
                    }

                    // ==============================
                    // SUPER ADMIN
                    // ==============================
                    else if (account.AccountType.Equals(
                        "SuperAdmin",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        SuperAdminDashboardForm superAdminDashboard =
                            new SuperAdminDashboardForm();

                        superAdminDashboard.Show();

                        this.Hide();
                    }

                    // ==============================
                    // UNKNOWN ACCOUNT TYPE
                    // ==============================
                    else
                    {
                        MessageBox.Show(
                            "This account has an invalid account type.\n\n" +
                            "Please contact the system administrator.",
                            "Invalid Account Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    // Login failed
                    MessageBox.Show(
                        "Incorrect username or password.\n\n" +
                        "Please try again.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "A database error occurred.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // CITIZEN SIGN UP
        // ==========================================
        private void btnCitizenSignUp_Click(
            object sender,
            EventArgs e)
        {
            CitizenSignUpForm signUpForm =
                new CitizenSignUpForm();

            signUpForm.ShowDialog();
        }

        // ==========================================
        // EXIT APPLICATION
        // ==========================================
        private void btnExit_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to exit the application?",
                    "Exit Application",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ==========================================
        // SHOW / HIDE PASSWORD
        // ==========================================
        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        // ==========================================
        // BEAUTIFUL BACKGROUND DESIGN
        // ==========================================
        private void pnlScroll_Paint(
            object sender,
            PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int width = pnlScroll.ClientSize.Width;
            int height = pnlScroll.ClientSize.Height;

            // Make drawing smoother
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // ==========================================
            // DARK BLUE GRADIENT BACKGROUND
            // ==========================================
            using (LinearGradientBrush gradient =
                new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(width, height),
                    Color.FromArgb(8, 28, 62),
                    Color.FromArgb(35, 88, 150)))
            {
                g.FillRectangle(
                    gradient,
                    0,
                    0,
                    width,
                    height);
            }

            // ==========================================
            // LARGE CIRCLE - TOP LEFT
            // ==========================================
            using (SolidBrush brush =
                new SolidBrush(
                    Color.FromArgb(
                        25,
                        Color.White)))
            {
                g.FillEllipse(
                    brush,
                    -150,
                    -130,
                    380,
                    380);
            }

            // ==========================================
            // LARGE CIRCLE - BOTTOM RIGHT
            // ==========================================
            using (SolidBrush brush =
                new SolidBrush(
                    Color.FromArgb(
                        20,
                        Color.White)))
            {
                g.FillEllipse(
                    brush,
                    width - 230,
                    height - 160,
                    360,
                    360);
            }

            // ==========================================
            // SMALL DECORATIVE CIRCLES
            // ==========================================
            using (SolidBrush brush =
                new SolidBrush(
                    Color.FromArgb(
                        40,
                        Color.White)))
            {
                // Left side
                g.FillEllipse(
                    brush,
                    55,
                    410,
                    18,
                    18);

                g.FillEllipse(
                    brush,
                    95,
                    450,
                    10,
                    10);

                g.FillEllipse(
                    brush,
                    45,
                    520,
                    8,
                    8);

                // Right side
                g.FillEllipse(
                    brush,
                    width - 80,
                    100,
                    18,
                    18);

                g.FillEllipse(
                    brush,
                    width - 120,
                    140,
                    9,
                    9);
            }

            // ==========================================
            // DECORATIVE LINES
            // ==========================================
            using (Pen pen =
                new Pen(
                    Color.FromArgb(
                        45,
                        Color.White),
                    2))
            {
                g.DrawLine(
                    pen,
                    35,
                    105,
                    150,
                    105);

                g.DrawLine(
                    pen,
                    width - 150,
                    height - 70,
                    width - 35,
                    height - 70);
            }

            // ==========================================
            // LEFT SIDE DECORATIVE MUNICIPAL SYMBOL
            // ==========================================
            using (Pen pen =
                new Pen(
                    Color.FromArgb(
                        35,
                        Color.White),
                    2))
            {
                // Simple building-style lines
                int x = 75;
                int y = 200;

                g.DrawRectangle(
                    pen,
                    x,
                    y,
                    65,
                    80);

                g.DrawLine(
                    pen,
                    x - 10,
                    y,
                    x + 75,
                    y);

                g.DrawLine(
                    pen,
                    x + 8,
                    y - 18,
                    x + 57,
                    y - 18);

                g.DrawLine(
                    pen,
                    x + 8,
                    y - 18,
                    x + 32,
                    y - 35);

                g.DrawLine(
                    pen,
                    x + 57,
                    y - 18,
                    x + 32,
                    y - 35);

                // Windows
                g.DrawRectangle(
                    pen,
                    x + 12,
                    y + 15,
                    12,
                    15);

                g.DrawRectangle(
                    pen,
                    x + 32,
                    y + 15,
                    12,
                    15);

                g.DrawRectangle(
                    pen,
                    x + 52,
                    y + 15,
                    12,
                    15);

                // Door
                g.DrawRectangle(
                    pen,
                    x + 26,
                    y + 50,
                    18,
                    30);
            }

            // ==========================================
            // RIGHT SIDE DECORATIVE SHAPE
            // ==========================================
            using (Pen pen =
                new Pen(
                    Color.FromArgb(
                        35,
                        Color.White),
                    2))
            {
                int x = width - 145;
                int y = 250;

                g.DrawEllipse(
                    pen,
                    x,
                    y,
                    70,
                    70);

                g.DrawLine(
                    pen,
                    x + 35,
                    y - 20,
                    x + 35,
                    y + 90);

                g.DrawLine(
                    pen,
                    x - 20,
                    y + 35,
                    x + 90,
                    y + 35);
            }

            // ==========================================
            // FOOTER LINE
            // ==========================================
            using (Pen pen =
                new Pen(
                    Color.FromArgb(
                        50,
                        Color.White),
                    1))
            {
                g.DrawLine(
                    pen,
                    35,
                    height - 45,
                    width - 35,
                    height - 45);
            }

            // ==========================================
            // FOOTER TEXT
            // ==========================================
            using (SolidBrush brush =
                new SolidBrush(
                    Color.FromArgb(
                        180,
                        Color.White)))
            using (Font font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Regular))
            {
                string footer =
                    "Municipal Services  •  Serving the Community";

                SizeF textSize =
                    g.MeasureString(
                        footer,
                        font);

                g.DrawString(
                    footer,
                    font,
                    brush,
                    (width - textSize.Width) / 2,
                    height - 32);
            }
        }
    }
}