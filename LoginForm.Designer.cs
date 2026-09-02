
namespace MunicipalServicesApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.PictureBox picCapeTown;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblMunicipality;

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.CheckBox chkShowPassword;

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCitizenSignUp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));

            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCitizenSignUp = new System.Windows.Forms.Button();
            this.lblRegister = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMunicipality = new System.Windows.Forms.Label();
            this.picCapeTown = new System.Windows.Forms.PictureBox();

            this.pnlScroll.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapeTown)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMinSize = new System.Drawing.Size(0, 750);
            this.pnlScroll.BackColor =
                System.Drawing.Color.FromArgb(18, 42, 82);
            this.pnlScroll.Controls.Add(this.pnlLogin);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(900, 600);
            this.pnlScroll.TabIndex = 0;
            this.pnlScroll.Paint +=
                new System.Windows.Forms.PaintEventHandler(this.pnlScroll_Paint);

            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlLogin.Controls.Add(this.lblInfo);
            this.pnlLogin.Controls.Add(this.btnCitizenSignUp);
            this.pnlLogin.Controls.Add(this.lblRegister);
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.chkShowPassword);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.lblWelcome);
            this.pnlLogin.Controls.Add(this.lblSubtitle);
            this.pnlLogin.Controls.Add(this.lblTitle);
            this.pnlLogin.Controls.Add(this.lblMunicipality);
            this.pnlLogin.Controls.Add(this.picCapeTown);
            this.pnlLogin.Location = new System.Drawing.Point(250, 30);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(400, 680);
            this.pnlLogin.TabIndex = 0;

            // 
            // picCapeTown
            // 
            this.picCapeTown.BackColor = System.Drawing.Color.Transparent;
            this.picCapeTown.Image =
                ((System.Drawing.Image)(resources.GetObject("picCapeTown.Image")));
            this.picCapeTown.Location = new System.Drawing.Point(122, 18);
            this.picCapeTown.Name = "picCapeTown";
            this.picCapeTown.Size = new System.Drawing.Size(155, 73);
            this.picCapeTown.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCapeTown.TabIndex = 0;
            this.picCapeTown.TabStop = false;

            // 
            // lblMunicipality
            // 
            this.lblMunicipality.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold);
            this.lblMunicipality.ForeColor =
                System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblMunicipality.Location =
                new System.Drawing.Point(55, 92);
            this.lblMunicipality.Name = "lblMunicipality";
            this.lblMunicipality.Size =
                new System.Drawing.Size(290, 20);
            this.lblMunicipality.TabIndex = 14;
            this.lblMunicipality.Text =
                "CITY OF CAPE TOWN • CITIZEN PORTAL";
            this.lblMunicipality.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblTitle
            // 
            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(25, 55, 109);
            this.lblTitle.Location =
                new System.Drawing.Point(55, 118);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size =
                new System.Drawing.Size(290, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Municipal Services";
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);
            this.lblSubtitle.ForeColor =
                System.Drawing.Color.Gray;
            this.lblSubtitle.Location =
                new System.Drawing.Point(55, 160);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size =
                new System.Drawing.Size(290, 25);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text =
                "Citizen Services Portal";
            this.lblSubtitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblWelcome
            // 
            this.lblWelcome.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor =
                System.Drawing.Color.FromArgb(45, 45, 45);
            this.lblWelcome.Location =
                new System.Drawing.Point(55, 198);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size =
                new System.Drawing.Size(290, 30);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor =
                System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblUsername.Location =
                new System.Drawing.Point(55, 240);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size =
                new System.Drawing.Size(64, 15);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";

            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);
            this.txtUsername.Location =
                new System.Drawing.Point(55, 263);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size =
                new System.Drawing.Size(290, 25);
            this.txtUsername.TabIndex = 5;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor =
                System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblPassword.Location =
                new System.Drawing.Point(55, 305);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size =
                new System.Drawing.Size(59, 15);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";

            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);
            this.txtPassword.Location =
                new System.Drawing.Point(55, 328);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size =
                new System.Drawing.Size(290, 25);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);
            this.chkShowPassword.ForeColor =
                System.Drawing.Color.FromArgb(80, 80, 80);
            this.chkShowPassword.Location =
                new System.Drawing.Point(55, 365);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size =
                new System.Drawing.Size(108, 19);
            this.chkShowPassword.TabIndex = 8;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged +=
                new System.EventHandler(
                    this.chkShowPassword_CheckedChanged);

            // 
            // btnLogin
            // 
            this.btnLogin.BackColor =
                System.Drawing.Color.FromArgb(25, 55, 109);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor =
                System.Drawing.Color.White;
            this.btnLogin.Location =
                new System.Drawing.Point(55, 402);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size =
                new System.Drawing.Size(290, 45);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click +=
                new System.EventHandler(this.btnLogin_Click);

            // 
            // lblRegister
            // 
            this.lblRegister.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.lblRegister.ForeColor =
                System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblRegister.Location =
                new System.Drawing.Point(55, 465);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size =
                new System.Drawing.Size(290, 20);
            this.lblRegister.TabIndex = 10;
            this.lblRegister.Text =
                "New citizen? Create an account below";
            this.lblRegister.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnCitizenSignUp
            // 
            this.btnCitizenSignUp.BackColor =
                System.Drawing.Color.White;
            this.btnCitizenSignUp.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(25, 55, 109);
            this.btnCitizenSignUp.FlatAppearance.BorderSize = 1;
            this.btnCitizenSignUp.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCitizenSignUp.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.btnCitizenSignUp.ForeColor =
                System.Drawing.Color.FromArgb(25, 55, 109);
            this.btnCitizenSignUp.Location =
                new System.Drawing.Point(55, 495);
            this.btnCitizenSignUp.Name =
                "btnCitizenSignUp";
            this.btnCitizenSignUp.Size =
                new System.Drawing.Size(290, 45);
            this.btnCitizenSignUp.TabIndex = 11;
            this.btnCitizenSignUp.Text =
                "CITIZEN SIGN UP";
            this.btnCitizenSignUp.UseVisualStyleBackColor = false;
            this.btnCitizenSignUp.Click +=
                new System.EventHandler(
                    this.btnCitizenSignUp_Click);

            // 
            // btnExit
            // 
            this.btnExit.BackColor =
                System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(190, 190, 190);
            this.btnExit.FlatAppearance.BorderSize = 1;
            this.btnExit.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor =
                System.Drawing.Color.FromArgb(70, 70, 70);
            this.btnExit.Location =
                new System.Drawing.Point(55, 550);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size =
                new System.Drawing.Size(290, 38);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click +=
                new System.EventHandler(this.btnExit_Click);

            // 
            // lblInfo
            // 
            this.lblInfo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Italic);
            this.lblInfo.ForeColor =
                System.Drawing.Color.Gray;
            this.lblInfo.Location =
                new System.Drawing.Point(55, 600);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size =
                new System.Drawing.Size(290, 55);
            this.lblInfo.TabIndex = 13;
            this.lblInfo.Text =
                "Demo accounts:\r\nCitizen: citizen / 12345\r\nAdmin: admin / admin123";
            this.lblInfo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize =
                new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlScroll);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text =
                "Municipal Services - Login";
            this.Load +=
                new System.EventHandler(this.LoginForm_Load);

            this.pnlScroll.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.picCapeTown)).EndInit();

            this.ResumeLayout(false);
        }
    }
}
