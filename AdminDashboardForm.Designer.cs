namespace MunicipalServicesApp
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;


    protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlViewCitizens = new System.Windows.Forms.Panel();
            this.btnViewCitizens = new System.Windows.Forms.Button();
            this.lblViewCitizensDescription = new System.Windows.Forms.Label();
            this.lblViewCitizensTitle = new System.Windows.Forms.Label();
            this.lblViewCitizensIcon = new System.Windows.Forms.Label();
            this.pnlViewCitizensAccent = new System.Windows.Forms.Panel();
            this.pnlUpdateStatus = new System.Windows.Forms.Panel();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.lblUpdateStatusDescription = new System.Windows.Forms.Label();
            this.lblUpdateStatusTitle = new System.Windows.Forms.Label();
            this.lblUpdateStatusIcon = new System.Windows.Forms.Label();
            this.pnlUpdateStatusAccent = new System.Windows.Forms.Panel();
            this.pnlManageIssues = new System.Windows.Forms.Panel();
            this.btnManageIssues = new System.Windows.Forms.Button();
            this.lblManageIssuesDescription = new System.Windows.Forms.Label();
            this.lblManageIssuesTitle = new System.Windows.Forms.Label();
            this.lblManageIssuesIcon = new System.Windows.Forms.Label();
            this.pnlManageIssuesAccent = new System.Windows.Forms.Panel();
            this.pnlViewIssues = new System.Windows.Forms.Panel();
            this.btnViewIssues = new System.Windows.Forms.Button();
            this.lblViewIssuesDescription = new System.Windows.Forms.Label();
            this.lblViewIssuesTitle = new System.Windows.Forms.Label();
            this.lblViewIssuesIcon = new System.Windows.Forms.Label();
            this.pnlViewIssuesAccent = new System.Windows.Forms.Panel();
            this.lblSectionDescription = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlSouthAfricanAccent = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblMunicipalName = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.pnlScroll.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlViewCitizens.SuspendLayout();
            this.pnlUpdateStatus.SuspendLayout();
            this.pnlManageIssues.SuspendLayout();
            this.pnlViewIssues.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Controls.Add(this.pnlMain);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(920, 749);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblFooter);
            this.pnlMain.Controls.Add(this.btnLogout);
            this.pnlMain.Controls.Add(this.pnlViewCitizens);
            this.pnlMain.Controls.Add(this.pnlUpdateStatus);
            this.pnlMain.Controls.Add(this.pnlManageIssues);
            this.pnlMain.Controls.Add(this.pnlViewIssues);
            this.pnlMain.Controls.Add(this.lblSectionDescription);
            this.pnlMain.Controls.Add(this.lblSection);
            this.pnlMain.Controls.Add(this.lblRole);
            this.pnlMain.Controls.Add(this.lblWelcome);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Location = new System.Drawing.Point(50, 20);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 920);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(35, 810);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(500, 35);
            this.lblFooter.TabIndex = 14;
            this.lblFooter.Text = "Municipal Services System  •  Administrator Access";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(610, 805);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(155, 42);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlViewCitizens
            // 
            this.pnlViewCitizens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.pnlViewCitizens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewCitizens.Controls.Add(this.btnViewCitizens);
            this.pnlViewCitizens.Controls.Add(this.lblViewCitizensDescription);
            this.pnlViewCitizens.Controls.Add(this.lblViewCitizensTitle);
            this.pnlViewCitizens.Controls.Add(this.lblViewCitizensIcon);
            this.pnlViewCitizens.Controls.Add(this.pnlViewCitizensAccent);
            this.pnlViewCitizens.Location = new System.Drawing.Point(415, 570);
            this.pnlViewCitizens.Name = "pnlViewCitizens";
            this.pnlViewCitizens.Size = new System.Drawing.Size(350, 190);
            this.pnlViewCitizens.TabIndex = 12;
            // 
            // btnViewCitizens
            // 
            this.btnViewCitizens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnViewCitizens.FlatAppearance.BorderSize = 0;
            this.btnViewCitizens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCitizens.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewCitizens.ForeColor = System.Drawing.Color.White;
            this.btnViewCitizens.Location = new System.Drawing.Point(25, 130);
            this.btnViewCitizens.Name = "btnViewCitizens";
            this.btnViewCitizens.Size = new System.Drawing.Size(145, 38);
            this.btnViewCitizens.TabIndex = 4;
            this.btnViewCitizens.Text = "VIEW CITIZENS";
            this.btnViewCitizens.UseVisualStyleBackColor = false;
            this.btnViewCitizens.Click += new System.EventHandler(this.btnViewCitizens_Click);
            // 
            // lblViewCitizensDescription
            // 
            this.lblViewCitizensDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViewCitizensDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblViewCitizensDescription.Location = new System.Drawing.Point(25, 78);
            this.lblViewCitizensDescription.Name = "lblViewCitizensDescription";
            this.lblViewCitizensDescription.Size = new System.Drawing.Size(300, 38);
            this.lblViewCitizensDescription.TabIndex = 3;
            this.lblViewCitizensDescription.Text = "View registered citizens in the system.";
            // 
            // lblViewCitizensTitle
            // 
            this.lblViewCitizensTitle.AutoSize = true;
            this.lblViewCitizensTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblViewCitizensTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblViewCitizensTitle.Location = new System.Drawing.Point(85, 30);
            this.lblViewCitizensTitle.Name = "lblViewCitizensTitle";
            this.lblViewCitizensTitle.Size = new System.Drawing.Size(124, 25);
            this.lblViewCitizensTitle.TabIndex = 2;
            this.lblViewCitizensTitle.Text = "View Citizens";
            // 
            // lblViewCitizensIcon
            // 
            this.lblViewCitizensIcon.AutoSize = true;
            this.lblViewCitizensIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 28F);
            this.lblViewCitizensIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblViewCitizensIcon.Location = new System.Drawing.Point(22, 22);
            this.lblViewCitizensIcon.Name = "lblViewCitizensIcon";
            this.lblViewCitizensIcon.Size = new System.Drawing.Size(60, 51);
            this.lblViewCitizensIcon.TabIndex = 1;
            this.lblViewCitizensIcon.Text = "♙";
            // 
            // pnlViewCitizensAccent
            // 
            this.pnlViewCitizensAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlViewCitizensAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlViewCitizensAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlViewCitizensAccent.Name = "pnlViewCitizensAccent";
            this.pnlViewCitizensAccent.Size = new System.Drawing.Size(348, 6);
            this.pnlViewCitizensAccent.TabIndex = 0;
            // 
            // pnlUpdateStatus
            // 
            this.pnlUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.pnlUpdateStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateStatus.Controls.Add(this.btnUpdateStatus);
            this.pnlUpdateStatus.Controls.Add(this.lblUpdateStatusDescription);
            this.pnlUpdateStatus.Controls.Add(this.lblUpdateStatusTitle);
            this.pnlUpdateStatus.Controls.Add(this.lblUpdateStatusIcon);
            this.pnlUpdateStatus.Controls.Add(this.pnlUpdateStatusAccent);
            this.pnlUpdateStatus.Location = new System.Drawing.Point(35, 570);
            this.pnlUpdateStatus.Name = "pnlUpdateStatus";
            this.pnlUpdateStatus.Size = new System.Drawing.Size(350, 190);
            this.pnlUpdateStatus.TabIndex = 11;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(25, 130);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(145, 38);
            this.btnUpdateStatus.TabIndex = 4;
            this.btnUpdateStatus.Text = "UPDATE STATUS";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // lblUpdateStatusDescription
            // 
            this.lblUpdateStatusDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUpdateStatusDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblUpdateStatusDescription.Location = new System.Drawing.Point(25, 78);
            this.lblUpdateStatusDescription.Name = "lblUpdateStatusDescription";
            this.lblUpdateStatusDescription.Size = new System.Drawing.Size(300, 38);
            this.lblUpdateStatusDescription.TabIndex = 3;
            this.lblUpdateStatusDescription.Text = "Update the progress of reported issues.";
            // 
            // lblUpdateStatusTitle
            // 
            this.lblUpdateStatusTitle.AutoSize = true;
            this.lblUpdateStatusTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblUpdateStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblUpdateStatusTitle.Location = new System.Drawing.Point(85, 30);
            this.lblUpdateStatusTitle.Name = "lblUpdateStatusTitle";
            this.lblUpdateStatusTitle.Size = new System.Drawing.Size(132, 25);
            this.lblUpdateStatusTitle.TabIndex = 2;
            this.lblUpdateStatusTitle.Text = "Update Status";
            // 
            // lblUpdateStatusIcon
            // 
            this.lblUpdateStatusIcon.AutoSize = true;
            this.lblUpdateStatusIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 28F);
            this.lblUpdateStatusIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.lblUpdateStatusIcon.Location = new System.Drawing.Point(22, 22);
            this.lblUpdateStatusIcon.Name = "lblUpdateStatusIcon";
            this.lblUpdateStatusIcon.Size = new System.Drawing.Size(54, 51);
            this.lblUpdateStatusIcon.TabIndex = 1;
            this.lblUpdateStatusIcon.Text = "↻";
            // 
            // pnlUpdateStatusAccent
            // 
            this.pnlUpdateStatusAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.pnlUpdateStatusAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateStatusAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateStatusAccent.Name = "pnlUpdateStatusAccent";
            this.pnlUpdateStatusAccent.Size = new System.Drawing.Size(348, 6);
            this.pnlUpdateStatusAccent.TabIndex = 0;
            // 
            // pnlManageIssues
            // 
            this.pnlManageIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.pnlManageIssues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlManageIssues.Controls.Add(this.btnManageIssues);
            this.pnlManageIssues.Controls.Add(this.lblManageIssuesDescription);
            this.pnlManageIssues.Controls.Add(this.lblManageIssuesTitle);
            this.pnlManageIssues.Controls.Add(this.lblManageIssuesIcon);
            this.pnlManageIssues.Controls.Add(this.pnlManageIssuesAccent);
            this.pnlManageIssues.Location = new System.Drawing.Point(415, 360);
            this.pnlManageIssues.Name = "pnlManageIssues";
            this.pnlManageIssues.Size = new System.Drawing.Size(350, 190);
            this.pnlManageIssues.TabIndex = 10;
            // 
            // btnManageIssues
            // 
            this.btnManageIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(71)))));
            this.btnManageIssues.FlatAppearance.BorderSize = 0;
            this.btnManageIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageIssues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageIssues.ForeColor = System.Drawing.Color.White;
            this.btnManageIssues.Location = new System.Drawing.Point(25, 130);
            this.btnManageIssues.Name = "btnManageIssues";
            this.btnManageIssues.Size = new System.Drawing.Size(145, 38);
            this.btnManageIssues.TabIndex = 4;
            this.btnManageIssues.Text = "MANAGE ISSUES";
            this.btnManageIssues.UseVisualStyleBackColor = false;
            this.btnManageIssues.Click += new System.EventHandler(this.btnManageIssues_Click);
            // 
            // lblManageIssuesDescription
            // 
            this.lblManageIssuesDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblManageIssuesDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblManageIssuesDescription.Location = new System.Drawing.Point(25, 78);
            this.lblManageIssuesDescription.Name = "lblManageIssuesDescription";
            this.lblManageIssuesDescription.Size = new System.Drawing.Size(300, 38);
            this.lblManageIssuesDescription.TabIndex = 3;
            this.lblManageIssuesDescription.Text = "Review and manage citizen reports.";
            // 
            // lblManageIssuesTitle
            // 
            this.lblManageIssuesTitle.AutoSize = true;
            this.lblManageIssuesTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblManageIssuesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblManageIssuesTitle.Location = new System.Drawing.Point(85, 30);
            this.lblManageIssuesTitle.Name = "lblManageIssuesTitle";
            this.lblManageIssuesTitle.Size = new System.Drawing.Size(137, 25);
            this.lblManageIssuesTitle.TabIndex = 2;
            this.lblManageIssuesTitle.Text = "Manage Issues";
            // 
            // lblManageIssuesIcon
            // 
            this.lblManageIssuesIcon.AutoSize = true;
            this.lblManageIssuesIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 28F);
            this.lblManageIssuesIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(71)))));
            this.lblManageIssuesIcon.Location = new System.Drawing.Point(22, 22);
            this.lblManageIssuesIcon.Name = "lblManageIssuesIcon";
            this.lblManageIssuesIcon.Size = new System.Drawing.Size(54, 51);
            this.lblManageIssuesIcon.TabIndex = 1;
            this.lblManageIssuesIcon.Text = "⚙";
            // 
            // pnlManageIssuesAccent
            // 
            this.pnlManageIssuesAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.pnlManageIssuesAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlManageIssuesAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlManageIssuesAccent.Name = "pnlManageIssuesAccent";
            this.pnlManageIssuesAccent.Size = new System.Drawing.Size(348, 6);
            this.pnlManageIssuesAccent.TabIndex = 0;
            // 
            // pnlViewIssues
            // 
            this.pnlViewIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.pnlViewIssues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewIssues.Controls.Add(this.btnViewIssues);
            this.pnlViewIssues.Controls.Add(this.lblViewIssuesDescription);
            this.pnlViewIssues.Controls.Add(this.lblViewIssuesTitle);
            this.pnlViewIssues.Controls.Add(this.lblViewIssuesIcon);
            this.pnlViewIssues.Controls.Add(this.pnlViewIssuesAccent);
            this.pnlViewIssues.Location = new System.Drawing.Point(35, 360);
            this.pnlViewIssues.Name = "pnlViewIssues";
            this.pnlViewIssues.Size = new System.Drawing.Size(350, 190);
            this.pnlViewIssues.TabIndex = 9;
            // 
            // btnViewIssues
            // 
            this.btnViewIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(71)))));
            this.btnViewIssues.FlatAppearance.BorderSize = 0;
            this.btnViewIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewIssues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewIssues.ForeColor = System.Drawing.Color.White;
            this.btnViewIssues.Location = new System.Drawing.Point(25, 130);
            this.btnViewIssues.Name = "btnViewIssues";
            this.btnViewIssues.Size = new System.Drawing.Size(145, 38);
            this.btnViewIssues.TabIndex = 4;
            this.btnViewIssues.Text = "VIEW ISSUES";
            this.btnViewIssues.UseVisualStyleBackColor = false;
            this.btnViewIssues.Click += new System.EventHandler(this.btnViewIssues_Click);
            // 
            // lblViewIssuesDescription
            // 
            this.lblViewIssuesDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViewIssuesDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblViewIssuesDescription.Location = new System.Drawing.Point(25, 78);
            this.lblViewIssuesDescription.Name = "lblViewIssuesDescription";
            this.lblViewIssuesDescription.Size = new System.Drawing.Size(300, 38);
            this.lblViewIssuesDescription.TabIndex = 3;
            this.lblViewIssuesDescription.Text = "View reports submitted by citizens.";
            // 
            // lblViewIssuesTitle
            // 
            this.lblViewIssuesTitle.AutoSize = true;
            this.lblViewIssuesTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblViewIssuesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblViewIssuesTitle.Location = new System.Drawing.Point(85, 30);
            this.lblViewIssuesTitle.Name = "lblViewIssuesTitle";
            this.lblViewIssuesTitle.Size = new System.Drawing.Size(109, 25);
            this.lblViewIssuesTitle.TabIndex = 2;
            this.lblViewIssuesTitle.Text = "View Issues";
            // 
            // lblViewIssuesIcon
            // 
            this.lblViewIssuesIcon.AutoSize = true;
            this.lblViewIssuesIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 28F);
            this.lblViewIssuesIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(71)))));
            this.lblViewIssuesIcon.Location = new System.Drawing.Point(22, 22);
            this.lblViewIssuesIcon.Name = "lblViewIssuesIcon";
            this.lblViewIssuesIcon.Size = new System.Drawing.Size(56, 51);
            this.lblViewIssuesIcon.TabIndex = 1;
            this.lblViewIssuesIcon.Text = "☷";
            // 
            // pnlViewIssuesAccent
            // 
            this.pnlViewIssuesAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(71)))));
            this.pnlViewIssuesAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlViewIssuesAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlViewIssuesAccent.Name = "pnlViewIssuesAccent";
            this.pnlViewIssuesAccent.Size = new System.Drawing.Size(348, 6);
            this.pnlViewIssuesAccent.TabIndex = 0;
            // 
            // lblSectionDescription
            // 
            this.lblSectionDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSectionDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblSectionDescription.Location = new System.Drawing.Point(38, 312);
            this.lblSectionDescription.Name = "lblSectionDescription";
            this.lblSectionDescription.Size = new System.Drawing.Size(700, 30);
            this.lblSectionDescription.TabIndex = 8;
            this.lblSectionDescription.Text = "Review citizen reports and manage municipal service requests.";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblSection.Location = new System.Drawing.Point(35, 280);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(199, 25);
            this.lblSection.TabIndex = 7;
            this.lblSection.Text = "Service Management";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(71)))));
            this.lblRole.Location = new System.Drawing.Point(38, 240);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(201, 15);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "●  ACCESS LEVEL: ADMINISTRATOR";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.lblWelcome.Location = new System.Drawing.Point(35, 205);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(390, 31);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Welcome, Municipal Administrator";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(71)))));
            this.pnlHeader.Controls.Add(this.pnlSouthAfricanAccent);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblMunicipalName);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 170);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlSouthAfricanAccent
            // 
            this.pnlSouthAfricanAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.pnlSouthAfricanAccent.Location = new System.Drawing.Point(0, 165);
            this.pnlSouthAfricanAccent.Name = "pnlSouthAfricanAccent";
            this.pnlSouthAfricanAccent.Size = new System.Drawing.Size(800, 5);
            this.pnlSouthAfricanAccent.TabIndex = 1;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 13);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(134, 134);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblMunicipalName
            // 
            this.lblMunicipalName.AutoSize = true;
            this.lblMunicipalName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMunicipalName.ForeColor = System.Drawing.Color.White;
            this.lblMunicipalName.Location = new System.Drawing.Point(155, 25);
            this.lblMunicipalName.Name = "lblMunicipalName";
            this.lblMunicipalName.Size = new System.Drawing.Size(200, 19);
            this.lblMunicipalName.TabIndex = 2;
            this.lblMunicipalName.Text = "REPUBLIC OF SOUTH AFRICA";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(152, 52);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(377, 42);
            this.lblHeaderTitle.TabIndex = 3;
            this.lblHeaderTitle.Text = "Municipal Administrator";
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(155, 102);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(590, 45);
            this.lblHeaderSubtitle.TabIndex = 4;
            this.lblHeaderSubtitle.Text = "Municipal Services Administration Portal\r\nManage citizen reports and municipal se" +
    "rvice requests.";
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 749);
            this.Controls.Add(this.pnlScroll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services - Administrator Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.pnlScroll.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlViewCitizens.ResumeLayout(false);
            this.pnlViewCitizens.PerformLayout();
            this.pnlUpdateStatus.ResumeLayout(false);
            this.pnlUpdateStatus.PerformLayout();
            this.pnlManageIssues.ResumeLayout(false);
            this.pnlManageIssues.PerformLayout();
            this.pnlViewIssues.ResumeLayout(false);
            this.pnlViewIssues.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlMain;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;

        private System.Windows.Forms.Label lblMunicipalName;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        private System.Windows.Forms.Panel pnlSouthAfricanAccent;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;

        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblSectionDescription;

        private System.Windows.Forms.Panel pnlViewIssues;
        private System.Windows.Forms.Panel pnlViewIssuesAccent;
        private System.Windows.Forms.Label lblViewIssuesIcon;
        private System.Windows.Forms.Label lblViewIssuesTitle;
        private System.Windows.Forms.Label lblViewIssuesDescription;
        private System.Windows.Forms.Button btnViewIssues;

        private System.Windows.Forms.Panel pnlManageIssues;
        private System.Windows.Forms.Panel pnlManageIssuesAccent;
        private System.Windows.Forms.Label lblManageIssuesIcon;
        private System.Windows.Forms.Label lblManageIssuesTitle;
        private System.Windows.Forms.Label lblManageIssuesDescription;
        private System.Windows.Forms.Button btnManageIssues;

        private System.Windows.Forms.Panel pnlUpdateStatus;
        private System.Windows.Forms.Panel pnlUpdateStatusAccent;
        private System.Windows.Forms.Label lblUpdateStatusIcon;
        private System.Windows.Forms.Label lblUpdateStatusTitle;
        private System.Windows.Forms.Label lblUpdateStatusDescription;
        private System.Windows.Forms.Button btnUpdateStatus;

        private System.Windows.Forms.Panel pnlViewCitizens;
        private System.Windows.Forms.Panel pnlViewCitizensAccent;
        private System.Windows.Forms.Label lblViewCitizensIcon;
        private System.Windows.Forms.Label lblViewCitizensTitle;
        private System.Windows.Forms.Label lblViewCitizensDescription;
        private System.Windows.Forms.Button btnViewCitizens;

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblFooter;
    }


}

