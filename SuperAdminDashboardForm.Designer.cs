namespace MunicipalServicesApp
{
    partial class SuperAdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;

        private System.Windows.Forms.PictureBox picLogo;

        private System.Windows.Forms.Label lblMunicipalName;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblSectionDescription;

        private System.Windows.Forms.Panel pnlCreateAdmin;
        private System.Windows.Forms.Panel pnlManageAdmins;
        private System.Windows.Forms.Panel pnlViewCitizens;
        private System.Windows.Forms.Panel pnlViewAccounts;

        private System.Windows.Forms.Label lblCreateIcon;
        private System.Windows.Forms.Label lblManageIcon;
        private System.Windows.Forms.Label lblCitizensIcon;
        private System.Windows.Forms.Label lblAccountsIcon;

        private System.Windows.Forms.Label lblCreateTitle;
        private System.Windows.Forms.Label lblManageTitle;
        private System.Windows.Forms.Label lblCitizensTitle;
        private System.Windows.Forms.Label lblAccountsTitle;

        private System.Windows.Forms.Label lblCreateDescription;
        private System.Windows.Forms.Label lblManageDescription;
        private System.Windows.Forms.Label lblCitizensDescription;
        private System.Windows.Forms.Label lblAccountsDescription;

        private System.Windows.Forms.Button btnCreateAdmin;
        private System.Windows.Forms.Button btnManageAdmins;
        private System.Windows.Forms.Button btnViewCitizens;
        private System.Windows.Forms.Button btnViewAccounts;

        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Label lblFooter;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminDashboardForm));
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlViewAccounts = new System.Windows.Forms.Panel();
            this.btnViewAccounts = new System.Windows.Forms.Button();
            this.lblAccountsDescription = new System.Windows.Forms.Label();
            this.lblAccountsTitle = new System.Windows.Forms.Label();
            this.lblAccountsIcon = new System.Windows.Forms.Label();
            this.pnlViewCitizens = new System.Windows.Forms.Panel();
            this.btnViewCitizens = new System.Windows.Forms.Button();
            this.lblCitizensDescription = new System.Windows.Forms.Label();
            this.lblCitizensTitle = new System.Windows.Forms.Label();
            this.lblCitizensIcon = new System.Windows.Forms.Label();
            this.pnlManageAdmins = new System.Windows.Forms.Panel();
            this.btnManageAdmins = new System.Windows.Forms.Button();
            this.lblManageDescription = new System.Windows.Forms.Label();
            this.lblManageTitle = new System.Windows.Forms.Label();
            this.lblManageIcon = new System.Windows.Forms.Label();
            this.pnlCreateAdmin = new System.Windows.Forms.Panel();
            this.btnCreateAdmin = new System.Windows.Forms.Button();
            this.lblCreateDescription = new System.Windows.Forms.Label();
            this.lblCreateTitle = new System.Windows.Forms.Label();
            this.lblCreateIcon = new System.Windows.Forms.Label();
            this.lblSectionDescription = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblMunicipalName = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlScroll.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlViewAccounts.SuspendLayout();
            this.pnlViewCitizens.SuspendLayout();
            this.pnlManageAdmins.SuspendLayout();
            this.pnlCreateAdmin.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMinSize = new System.Drawing.Size(0, 900);
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlScroll.Controls.Add(this.pnlMain);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(771, 649);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblFooter);
            this.pnlMain.Controls.Add(this.btnLogout);
            this.pnlMain.Controls.Add(this.pnlViewAccounts);
            this.pnlMain.Controls.Add(this.pnlViewCitizens);
            this.pnlMain.Controls.Add(this.pnlManageAdmins);
            this.pnlMain.Controls.Add(this.pnlCreateAdmin);
            this.pnlMain.Controls.Add(this.lblSectionDescription);
            this.pnlMain.Controls.Add(this.lblSection);
            this.pnlMain.Controls.Add(this.lblRole);
            this.pnlMain.Controls.Add(this.lblWelcome);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Location = new System.Drawing.Point(34, 22);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(686, 780);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(150)))));
            this.lblFooter.Location = new System.Drawing.Point(30, 715);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(626, 39);
            this.lblFooter.TabIndex = 13;
            this.lblFooter.Text = "Municipal Services Management System\r\nSuper Administrator Control Panel";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(30, 659);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(626, 39);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlViewAccounts
            // 
            this.pnlViewAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlViewAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewAccounts.Controls.Add(this.btnViewAccounts);
            this.pnlViewAccounts.Controls.Add(this.lblAccountsDescription);
            this.pnlViewAccounts.Controls.Add(this.lblAccountsTitle);
            this.pnlViewAccounts.Controls.Add(this.lblAccountsIcon);
            this.pnlViewAccounts.Location = new System.Drawing.Point(356, 477);
            this.pnlViewAccounts.Name = "pnlViewAccounts";
            this.pnlViewAccounts.Size = new System.Drawing.Size(300, 152);
            this.pnlViewAccounts.TabIndex = 11;
            // 
            // btnViewAccounts
            // 
            this.btnViewAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.btnViewAccounts.FlatAppearance.BorderSize = 0;
            this.btnViewAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAccounts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewAccounts.ForeColor = System.Drawing.Color.White;
            this.btnViewAccounts.Location = new System.Drawing.Point(21, 104);
            this.btnViewAccounts.Name = "btnViewAccounts";
            this.btnViewAccounts.Size = new System.Drawing.Size(257, 33);
            this.btnViewAccounts.TabIndex = 3;
            this.btnViewAccounts.Text = "VIEW ALL ACCOUNTS";
            this.btnViewAccounts.UseVisualStyleBackColor = false;
            this.btnViewAccounts.Click += new System.EventHandler(this.btnViewAccounts_Click);
            // 
            // lblAccountsDescription
            // 
            this.lblAccountsDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAccountsDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.lblAccountsDescription.Location = new System.Drawing.Point(21, 54);
            this.lblAccountsDescription.Name = "lblAccountsDescription";
            this.lblAccountsDescription.Size = new System.Drawing.Size(257, 39);
            this.lblAccountsDescription.TabIndex = 2;
            this.lblAccountsDescription.Text = "View all citizen and administrator accounts in the system.";
            // 
            // lblAccountsTitle
            // 
            this.lblAccountsTitle.AutoSize = true;
            this.lblAccountsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccountsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.lblAccountsTitle.Location = new System.Drawing.Point(56, 22);
            this.lblAccountsTitle.Name = "lblAccountsTitle";
            this.lblAccountsTitle.Size = new System.Drawing.Size(105, 21);
            this.lblAccountsTitle.TabIndex = 1;
            this.lblAccountsTitle.Text = "All Accounts";
            // 
            // lblAccountsIcon
            // 
            this.lblAccountsIcon.AutoSize = true;
            this.lblAccountsIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.lblAccountsIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(75)))), ((int)(((byte)(130)))));
            this.lblAccountsIcon.Location = new System.Drawing.Point(19, 16);
            this.lblAccountsIcon.Name = "lblAccountsIcon";
            this.lblAccountsIcon.Size = new System.Drawing.Size(40, 37);
            this.lblAccountsIcon.TabIndex = 0;
            this.lblAccountsIcon.Text = "▣";
            // 
            // pnlViewCitizens
            // 
            this.pnlViewCitizens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlViewCitizens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewCitizens.Controls.Add(this.btnViewCitizens);
            this.pnlViewCitizens.Controls.Add(this.lblCitizensDescription);
            this.pnlViewCitizens.Controls.Add(this.lblCitizensTitle);
            this.pnlViewCitizens.Controls.Add(this.lblCitizensIcon);
            this.pnlViewCitizens.Location = new System.Drawing.Point(30, 477);
            this.pnlViewCitizens.Name = "pnlViewCitizens";
            this.pnlViewCitizens.Size = new System.Drawing.Size(300, 152);
            this.pnlViewCitizens.TabIndex = 10;
            // 
            // btnViewCitizens
            // 
            this.btnViewCitizens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(80)))));
            this.btnViewCitizens.FlatAppearance.BorderSize = 0;
            this.btnViewCitizens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCitizens.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewCitizens.ForeColor = System.Drawing.Color.White;
            this.btnViewCitizens.Location = new System.Drawing.Point(21, 104);
            this.btnViewCitizens.Name = "btnViewCitizens";
            this.btnViewCitizens.Size = new System.Drawing.Size(257, 33);
            this.btnViewCitizens.TabIndex = 3;
            this.btnViewCitizens.Text = "VIEW CITIZENS";
            this.btnViewCitizens.UseVisualStyleBackColor = false;
            this.btnViewCitizens.Click += new System.EventHandler(this.btnViewCitizens_Click);
            // 
            // lblCitizensDescription
            // 
            this.lblCitizensDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCitizensDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.lblCitizensDescription.Location = new System.Drawing.Point(21, 54);
            this.lblCitizensDescription.Name = "lblCitizensDescription";
            this.lblCitizensDescription.Size = new System.Drawing.Size(257, 39);
            this.lblCitizensDescription.TabIndex = 2;
            this.lblCitizensDescription.Text = "View registered citizens and monitor municipal system access.";
            // 
            // lblCitizensTitle
            // 
            this.lblCitizensTitle.AutoSize = true;
            this.lblCitizensTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCitizensTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.lblCitizensTitle.Location = new System.Drawing.Point(56, 22);
            this.lblCitizensTitle.Name = "lblCitizensTitle";
            this.lblCitizensTitle.Size = new System.Drawing.Size(112, 21);
            this.lblCitizensTitle.TabIndex = 1;
            this.lblCitizensTitle.Text = "View Citizens";
            // 
            // lblCitizensIcon
            // 
            this.lblCitizensIcon.AutoSize = true;
            this.lblCitizensIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.lblCitizensIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(105)))), ((int)(((byte)(80)))));
            this.lblCitizensIcon.Location = new System.Drawing.Point(19, 16);
            this.lblCitizensIcon.Name = "lblCitizensIcon";
            this.lblCitizensIcon.Size = new System.Drawing.Size(44, 37);
            this.lblCitizensIcon.TabIndex = 0;
            this.lblCitizensIcon.Text = "♙";
            // 
            // pnlManageAdmins
            // 
            this.pnlManageAdmins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlManageAdmins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlManageAdmins.Controls.Add(this.btnManageAdmins);
            this.pnlManageAdmins.Controls.Add(this.lblManageDescription);
            this.pnlManageAdmins.Controls.Add(this.lblManageTitle);
            this.pnlManageAdmins.Controls.Add(this.lblManageIcon);
            this.pnlManageAdmins.Location = new System.Drawing.Point(356, 308);
            this.pnlManageAdmins.Name = "pnlManageAdmins";
            this.pnlManageAdmins.Size = new System.Drawing.Size(300, 152);
            this.pnlManageAdmins.TabIndex = 9;
            // 
            // btnManageAdmins
            // 
            this.btnManageAdmins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(135)))));
            this.btnManageAdmins.FlatAppearance.BorderSize = 0;
            this.btnManageAdmins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageAdmins.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageAdmins.ForeColor = System.Drawing.Color.White;
            this.btnManageAdmins.Location = new System.Drawing.Point(21, 104);
            this.btnManageAdmins.Name = "btnManageAdmins";
            this.btnManageAdmins.Size = new System.Drawing.Size(257, 33);
            this.btnManageAdmins.TabIndex = 3;
            this.btnManageAdmins.Text = "MANAGE ADMINS";
            this.btnManageAdmins.UseVisualStyleBackColor = false;
            this.btnManageAdmins.Click += new System.EventHandler(this.btnManageAdmins_Click);
            // 
            // lblManageDescription
            // 
            this.lblManageDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblManageDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.lblManageDescription.Location = new System.Drawing.Point(21, 54);
            this.lblManageDescription.Name = "lblManageDescription";
            this.lblManageDescription.Size = new System.Drawing.Size(257, 39);
            this.lblManageDescription.TabIndex = 2;
            this.lblManageDescription.Text = "View, update and manage existing administrator accounts.";
            // 
            // lblManageTitle
            // 
            this.lblManageTitle.AutoSize = true;
            this.lblManageTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblManageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.lblManageTitle.Location = new System.Drawing.Point(56, 22);
            this.lblManageTitle.Name = "lblManageTitle";
            this.lblManageTitle.Size = new System.Drawing.Size(189, 21);
            this.lblManageTitle.TabIndex = 1;
            this.lblManageTitle.Text = "Manage Administrators";
            // 
            // lblManageIcon
            // 
            this.lblManageIcon.AutoSize = true;
            this.lblManageIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 21F);
            this.lblManageIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(135)))));
            this.lblManageIcon.Location = new System.Drawing.Point(19, 16);
            this.lblManageIcon.Name = "lblManageIcon";
            this.lblManageIcon.Size = new System.Drawing.Size(41, 38);
            this.lblManageIcon.TabIndex = 0;
            this.lblManageIcon.Text = "⚙";
            // 
            // pnlCreateAdmin
            // 
            this.pnlCreateAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlCreateAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCreateAdmin.Controls.Add(this.btnCreateAdmin);
            this.pnlCreateAdmin.Controls.Add(this.lblCreateDescription);
            this.pnlCreateAdmin.Controls.Add(this.lblCreateTitle);
            this.pnlCreateAdmin.Controls.Add(this.lblCreateIcon);
            this.pnlCreateAdmin.Location = new System.Drawing.Point(30, 308);
            this.pnlCreateAdmin.Name = "pnlCreateAdmin";
            this.pnlCreateAdmin.Size = new System.Drawing.Size(300, 152);
            this.pnlCreateAdmin.TabIndex = 8;
            // 
            // btnCreateAdmin
            // 
            this.btnCreateAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            this.btnCreateAdmin.FlatAppearance.BorderSize = 0;
            this.btnCreateAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreateAdmin.ForeColor = System.Drawing.Color.White;
            this.btnCreateAdmin.Location = new System.Drawing.Point(21, 104);
            this.btnCreateAdmin.Name = "btnCreateAdmin";
            this.btnCreateAdmin.Size = new System.Drawing.Size(257, 33);
            this.btnCreateAdmin.TabIndex = 3;
            this.btnCreateAdmin.Text = "CREATE ADMIN";
            this.btnCreateAdmin.UseVisualStyleBackColor = false;
            this.btnCreateAdmin.Click += new System.EventHandler(this.btnCreateAdmin_Click);
            // 
            // lblCreateDescription
            // 
            this.lblCreateDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCreateDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.lblCreateDescription.Location = new System.Drawing.Point(21, 54);
            this.lblCreateDescription.Name = "lblCreateDescription";
            this.lblCreateDescription.Size = new System.Drawing.Size(257, 39);
            this.lblCreateDescription.TabIndex = 2;
            this.lblCreateDescription.Text = "Create a new administrator account and grant system management access.";
            // 
            // lblCreateTitle
            // 
            this.lblCreateTitle.AutoSize = true;
            this.lblCreateTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCreateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.lblCreateTitle.Location = new System.Drawing.Point(56, 22);
            this.lblCreateTitle.Name = "lblCreateTitle";
            this.lblCreateTitle.Size = new System.Drawing.Size(169, 21);
            this.lblCreateTitle.TabIndex = 1;
            this.lblCreateTitle.Text = "Create Administrator";
            // 
            // lblCreateIcon
            // 
            this.lblCreateIcon.AutoSize = true;
            this.lblCreateIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 22F);
            this.lblCreateIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            this.lblCreateIcon.Location = new System.Drawing.Point(19, 15);
            this.lblCreateIcon.Name = "lblCreateIcon";
            this.lblCreateIcon.Size = new System.Drawing.Size(54, 41);
            this.lblCreateIcon.TabIndex = 0;
            this.lblCreateIcon.Text = "＋";
            // 
            // lblSectionDescription
            // 
            this.lblSectionDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSectionDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblSectionDescription.Location = new System.Drawing.Point(33, 264);
            this.lblSectionDescription.Name = "lblSectionDescription";
            this.lblSectionDescription.Size = new System.Drawing.Size(600, 30);
            this.lblSectionDescription.TabIndex = 7;
            this.lblSectionDescription.Text = "Choose an option below to manage users and administrator access.";
            this.lblSectionDescription.Click += new System.EventHandler(this.lblSectionDescription_Click);
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.lblSection.Location = new System.Drawing.Point(30, 234);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(238, 31);
            this.lblSection.TabIndex = 6;
            this.lblSection.Text = "System Management";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            this.lblRole.Location = new System.Drawing.Point(33, 191);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(184, 15);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "●  ACCESS LEVEL: SUPER ADMIN";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.lblWelcome.Location = new System.Drawing.Point(30, 165);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(302, 28);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome, Super Administrator";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblMunicipalName);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(686, 143);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(133, 88);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(506, 35);
            this.lblHeaderSubtitle.TabIndex = 3;
            this.lblHeaderSubtitle.Text = "Secure management of municipal system accounts and administrator access.";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(130, 48);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(363, 41);
            this.lblHeaderTitle.TabIndex = 2;
            this.lblHeaderTitle.Text = "Super Admin Dashboard";
            // 
            // lblMunicipalName
            // 
            this.lblMunicipalName.AutoSize = true;
            this.lblMunicipalName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMunicipalName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.lblMunicipalName.Location = new System.Drawing.Point(133, 22);
            this.lblMunicipalName.Name = "lblMunicipalName";
            this.lblMunicipalName.Size = new System.Drawing.Size(150, 19);
            this.lblMunicipalName.TabIndex = 1;
            this.lblMunicipalName.Text = "MUNICIPAL SERVICES";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(-8, -10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(132, 140);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // SuperAdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(771, 649);
            this.Controls.Add(this.pnlScroll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuperAdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services - Super Admin Dashboard";
            this.Load += new System.EventHandler(this.SuperAdminDashboardForm_Load);
            this.pnlScroll.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlViewAccounts.ResumeLayout(false);
            this.pnlViewAccounts.PerformLayout();
            this.pnlViewCitizens.ResumeLayout(false);
            this.pnlViewCitizens.PerformLayout();
            this.pnlManageAdmins.ResumeLayout(false);
            this.pnlManageAdmins.PerformLayout();
            this.pnlCreateAdmin.ResumeLayout(false);
            this.pnlCreateAdmin.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}