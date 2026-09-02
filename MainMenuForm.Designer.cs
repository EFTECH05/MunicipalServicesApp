namespace MunicipalServicesApp
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlScroll;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Label lblReportIcon;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label lblReportDescription;
        private System.Windows.Forms.Button btnReportIssues;

        private System.Windows.Forms.Panel pnlEvents;
        private System.Windows.Forms.Label lblEventsIcon;
        private System.Windows.Forms.Label lblEventsTitle;
        private System.Windows.Forms.Label lblEventsDescription;
        private System.Windows.Forms.Button btnEvents;

        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatusIcon;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatusDescription;
        private System.Windows.Forms.Button btnServiceStatus;

        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblFooter;

        private System.Windows.Forms.Button btnLogout;

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
            this.pnlScroll = new System.Windows.Forms.Panel();

            this.lblFooter = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();

            this.btnLogout = new System.Windows.Forms.Button();

            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatusIcon = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblStatusDescription = new System.Windows.Forms.Label();
            this.btnServiceStatus = new System.Windows.Forms.Button();

            this.pnlEvents = new System.Windows.Forms.Panel();
            this.lblEventsIcon = new System.Windows.Forms.Label();
            this.lblEventsTitle = new System.Windows.Forms.Label();
            this.lblEventsDescription = new System.Windows.Forms.Label();
            this.btnEvents = new System.Windows.Forms.Button();

            this.pnlReport = new System.Windows.Forms.Panel();
            this.lblReportIcon = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lblReportDescription = new System.Windows.Forms.Label();
            this.btnReportIssues = new System.Windows.Forms.Button();

            this.lblDescription = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlScroll.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlEvents.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.pnlHeader.SuspendLayout();

            this.SuspendLayout();

            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMinSize =
                new System.Drawing.Size(0, 620);

            this.pnlScroll.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(245)))),
                    ((int)(((byte)(247)))),
                    ((int)(((byte)(250))))
                );

            this.pnlScroll.Controls.Add(this.lblFooter);
            this.pnlScroll.Controls.Add(this.lblInstruction);
            this.pnlScroll.Controls.Add(this.btnLogout);
            this.pnlScroll.Controls.Add(this.pnlStatus);
            this.pnlScroll.Controls.Add(this.pnlEvents);
            this.pnlScroll.Controls.Add(this.pnlReport);
            this.pnlScroll.Controls.Add(this.lblDescription);
            this.pnlScroll.Controls.Add(this.lblWelcome);
            this.pnlScroll.Controls.Add(this.pnlHeader);

            this.pnlScroll.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlScroll.Location =
                new System.Drawing.Point(0, 0);

            this.pnlScroll.Name =
                "pnlScroll";

            this.pnlScroll.Size =
                new System.Drawing.Size(1000, 570);

            this.pnlScroll.TabIndex = 0;

            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;

            this.lblFooter.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8F);

            this.lblFooter.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(150)))),
                    ((int)(((byte)(150)))),
                    ((int)(((byte)(150))))
                );

            this.lblFooter.Location =
                new System.Drawing.Point(45, 590);

            this.lblFooter.Name =
                "lblFooter";

            this.lblFooter.Size =
                new System.Drawing.Size(202, 13);

            this.lblFooter.TabIndex = 0;

            this.lblFooter.Text =
                "Municipal Services Application • Part 1";

            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;

            this.lblInstruction.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblInstruction.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(110)))),
                    ((int)(((byte)(120)))),
                    ((int)(((byte)(130))))
                );

            this.lblInstruction.Location =
                new System.Drawing.Point(45, 495);

            this.lblInstruction.Name =
                "lblInstruction";

            this.lblInstruction.Size =
                new System.Drawing.Size(359, 15);

            this.lblInstruction.TabIndex = 1;

            this.lblInstruction.Text =
                "Tip: Select 'Report an Issue' to submit a municipal service problem.";

            // 
            // btnLogout
            // 
            this.btnLogout.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(180)))),
                    ((int)(((byte)(45)))),
                    ((int)(((byte)(45))))
                );

            this.btnLogout.FlatAppearance.BorderSize = 0;

            this.btnLogout.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnLogout.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnLogout.ForeColor =
                System.Drawing.Color.White;

            this.btnLogout.Location =
                new System.Drawing.Point(810, 485);

            this.btnLogout.Name =
                "btnLogout";

            this.btnLogout.Size =
                new System.Drawing.Size(145, 40);

            this.btnLogout.TabIndex = 9;

            this.btnLogout.Text =
                "Logout";

            this.btnLogout.UseVisualStyleBackColor =
                false;

            this.btnLogout.Click +=
                new System.EventHandler(
                    this.btnLogout_Click);

            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor =
                System.Drawing.Color.White;

            this.pnlStatus.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlStatus.Controls.Add(
                this.lblStatusIcon);

            this.pnlStatus.Controls.Add(
                this.lblStatusTitle);

            this.pnlStatus.Controls.Add(
                this.lblStatusDescription);

            this.pnlStatus.Controls.Add(
                this.btnServiceStatus);

            this.pnlStatus.Location =
                new System.Drawing.Point(675, 240);

            this.pnlStatus.Name =
                "pnlStatus";

            this.pnlStatus.Size =
                new System.Drawing.Size(280, 220);

            this.pnlStatus.TabIndex = 2;

            // 
            // lblStatusIcon
            // 
            this.lblStatusIcon.Font =
                new System.Drawing.Font(
                    "Segoe UI Symbol",
                    28F);

            this.lblStatusIcon.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(65)))),
                    ((int)(((byte)(155)))),
                    ((int)(((byte)(105))))
                );

            this.lblStatusIcon.Location =
                new System.Drawing.Point(20, 15);

            this.lblStatusIcon.Name =
                "lblStatusIcon";

            this.lblStatusIcon.Size =
                new System.Drawing.Size(55, 50);

            this.lblStatusIcon.TabIndex = 0;

            this.lblStatusIcon.Text =
                "✓";

            this.lblStatusIcon.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;

            this.lblStatusTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            this.lblStatusTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(24)))),
                    ((int)(((byte)(55)))),
                    ((int)(((byte)(89))))
                );

            this.lblStatusTitle.Location =
                new System.Drawing.Point(20, 70);

            this.lblStatusTitle.Name =
                "lblStatusTitle";

            this.lblStatusTitle.Size =
                new System.Drawing.Size(143, 25);

            this.lblStatusTitle.TabIndex = 1;

            this.lblStatusTitle.Text =
                "Request Status";

            // 
            // lblStatusDescription
            // 
            this.lblStatusDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblStatusDescription.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(105)))),
                    ((int)(((byte)(105)))),
                    ((int)(((byte)(105))))
                );

            this.lblStatusDescription.Location =
                new System.Drawing.Point(20, 102);

            this.lblStatusDescription.Name =
                "lblStatusDescription";

            this.lblStatusDescription.Size =
                new System.Drawing.Size(240, 45);

            this.lblStatusDescription.TabIndex = 2;

            this.lblStatusDescription.Text =
                "Track the progress and current status of your submitted service requests.";

            // 
            // btnServiceStatus
            // 
            this.btnServiceStatus.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(225)))),
                    ((int)(((byte)(228)))),
                    ((int)(((byte)(232))))
                );

            this.btnServiceStatus.Enabled = false;

            this.btnServiceStatus.FlatAppearance.BorderSize = 0;

            this.btnServiceStatus.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnServiceStatus.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnServiceStatus.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(125)))),
                    ((int)(((byte)(125)))),
                    ((int)(((byte)(125))))
                );

            this.btnServiceStatus.Location =
                new System.Drawing.Point(20, 165);

            this.btnServiceStatus.Name =
                "btnServiceStatus";

            this.btnServiceStatus.Size =
                new System.Drawing.Size(240, 38);

            this.btnServiceStatus.TabIndex = 3;

            this.btnServiceStatus.Text =
                "Coming Soon";

            this.btnServiceStatus.UseVisualStyleBackColor =
                false;

            // 
            // pnlEvents
            // 
            this.pnlEvents.BackColor =
                System.Drawing.Color.White;

            this.pnlEvents.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlEvents.Controls.Add(
                this.lblEventsIcon);

            this.pnlEvents.Controls.Add(
                this.lblEventsTitle);

            this.pnlEvents.Controls.Add(
                this.lblEventsDescription);

            this.pnlEvents.Controls.Add(
                this.btnEvents);

            this.pnlEvents.Location =
                new System.Drawing.Point(360, 240);

            this.pnlEvents.Name =
                "pnlEvents";

            this.pnlEvents.Size =
                new System.Drawing.Size(280, 220);

            this.pnlEvents.TabIndex = 3;

            // 
            // lblEventsIcon
            // 
            this.lblEventsIcon.Font =
                new System.Drawing.Font(
                    "Segoe UI Emoji",
                    27F);

            this.lblEventsIcon.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(70)))),
                    ((int)(((byte)(120)))),
                    ((int)(((byte)(190))))
                );

            this.lblEventsIcon.Location =
                new System.Drawing.Point(20, 15);

            this.lblEventsIcon.Name =
                "lblEventsIcon";

            this.lblEventsIcon.Size =
                new System.Drawing.Size(55, 50);

            this.lblEventsIcon.TabIndex = 0;

            this.lblEventsIcon.Text =
                "📅";

            this.lblEventsIcon.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblEventsTitle
            // 
            this.lblEventsTitle.AutoSize = true;

            this.lblEventsTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            this.lblEventsTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(24)))),
                    ((int)(((byte)(55)))),
                    ((int)(((byte)(89))))
                );

            this.lblEventsTitle.Location =
                new System.Drawing.Point(20, 70);

            this.lblEventsTitle.Name =
                "lblEventsTitle";

            this.lblEventsTitle.Size =
                new System.Drawing.Size(178, 25);

            this.lblEventsTitle.TabIndex = 1;

            this.lblEventsTitle.Text =
                "Local Events & News";

            // 
            // lblEventsDescription
            // 
            this.lblEventsDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblEventsDescription.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(105)))),
                    ((int)(((byte)(105)))),
                    ((int)(((byte)(105))))
                );

            this.lblEventsDescription.Location =
                new System.Drawing.Point(20, 102);

            this.lblEventsDescription.Name =
                "lblEventsDescription";

            this.lblEventsDescription.Size =
                new System.Drawing.Size(240, 45);

            this.lblEventsDescription.TabIndex = 2;

            this.lblEventsDescription.Text =
                "View upcoming community events and important municipal announcements.";

            // 
            // btnEvents
            // 
            this.btnEvents.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(225)))),
                    ((int)(((byte)(228)))),
                    ((int)(((byte)(232))))
                );

            this.btnEvents.Enabled = false;

            this.btnEvents.FlatAppearance.BorderSize = 0;

            this.btnEvents.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnEvents.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnEvents.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(125)))),
                    ((int)(((byte)(125)))),
                    ((int)(((byte)(125))))
                );

            this.btnEvents.Location =
                new System.Drawing.Point(20, 165);

            this.btnEvents.Name =
                "btnEvents";

            this.btnEvents.Size =
                new System.Drawing.Size(240, 38);

            this.btnEvents.TabIndex = 3;

            this.btnEvents.Text =
                "Coming Soon";

            this.btnEvents.UseVisualStyleBackColor =
                false;

            // 
            // pnlReport
            // 
            this.pnlReport.BackColor =
                System.Drawing.Color.White;

            this.pnlReport.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlReport.Controls.Add(
                this.lblReportIcon);

            this.pnlReport.Controls.Add(
                this.lblReportTitle);

            this.pnlReport.Controls.Add(
                this.lblReportDescription);

            this.pnlReport.Controls.Add(
                this.btnReportIssues);

            this.pnlReport.Location =
                new System.Drawing.Point(45, 240);

            this.pnlReport.Name =
                "pnlReport";

            this.pnlReport.Size =
                new System.Drawing.Size(280, 220);

            this.pnlReport.TabIndex = 4;

            // 
            // lblReportIcon
            // 
            this.lblReportIcon.Font =
                new System.Drawing.Font(
                    "Segoe UI Emoji",
                    27F);

            this.lblReportIcon.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(220)))),
                    ((int)(((byte)(70)))),
                    ((int)(((byte)(70))))
                );

            this.lblReportIcon.Location =
                new System.Drawing.Point(20, 15);

            this.lblReportIcon.Name =
                "lblReportIcon";

            this.lblReportIcon.Size =
                new System.Drawing.Size(55, 50);

            this.lblReportIcon.TabIndex = 0;

            this.lblReportIcon.Text =
                "⚠";

            this.lblReportIcon.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;

            this.lblReportTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            this.lblReportTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(24)))),
                    ((int)(((byte)(55)))),
                    ((int)(((byte)(89))))
                );

            this.lblReportTitle.Location =
                new System.Drawing.Point(20, 70);

            this.lblReportTitle.Name =
                "lblReportTitle";

            this.lblReportTitle.Size =
                new System.Drawing.Size(150, 25);

            this.lblReportTitle.TabIndex = 1;

            this.lblReportTitle.Text =
                "Report an Issue";

            // 
            // lblReportDescription
            // 
            this.lblReportDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblReportDescription.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(105)))),
                    ((int)(((byte)(105)))),
                    ((int)(((byte)(105))))
                );

            this.lblReportDescription.Location =
                new System.Drawing.Point(20, 102);

            this.lblReportDescription.Name =
                "lblReportDescription";

            this.lblReportDescription.Size =
                new System.Drawing.Size(240, 45);

            this.lblReportDescription.TabIndex = 2;

            this.lblReportDescription.Text =
                "Report problems such as roads, water, electricity, waste and other municipal issues.";

            // 
            // btnReportIssues
            // 
            this.btnReportIssues.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(24)))),
                    ((int)(((byte)(55)))),
                    ((int)(((byte)(89))))
                );

            this.btnReportIssues.FlatAppearance.BorderSize = 0;

            this.btnReportIssues.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnReportIssues.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnReportIssues.ForeColor =
                System.Drawing.Color.White;

            this.btnReportIssues.Location =
                new System.Drawing.Point(20, 165);

            this.btnReportIssues.Name =
                "btnReportIssues";

            this.btnReportIssues.Size =
                new System.Drawing.Size(240, 38);

            this.btnReportIssues.TabIndex = 3;

            this.btnReportIssues.Text =
                "Report an Issue";

            this.btnReportIssues.UseVisualStyleBackColor =
                false;

            this.btnReportIssues.Click +=
                new System.EventHandler(
                    this.btnReportIssues_Click);

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;

            this.lblDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblDescription.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(110)))),
                    ((int)(((byte)(120)))),
                    ((int)(((byte)(130))))
                );

            this.lblDescription.Location =
                new System.Drawing.Point(48, 190);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(462, 19);

            this.lblDescription.TabIndex = 5;

            this.lblDescription.Text =
                "Choose a service below to report an issue or access municipal information.";

            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;

            this.lblWelcome.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.lblWelcome.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(35)))),
                    ((int)(((byte)(45)))),
                    ((int)(((byte)(55))))
                );

            this.lblWelcome.Location =
                new System.Drawing.Point(45, 155);

            this.lblWelcome.Name =
                "lblWelcome";

            this.lblWelcome.Size =
                new System.Drawing.Size(211, 32);

            this.lblWelcome.TabIndex = 6;

            this.lblWelcome.Text =
                "Welcome, Citizen";

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(24)))),
                    ((int)(((byte)(55)))),
                    ((int)(((byte)(89))))
                );

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Location =
                new System.Drawing.Point(0, 0);

            this.pnlHeader.Name =
                "pnlHeader";

            this.pnlHeader.Size =
                new System.Drawing.Size(980, 125);

            this.pnlHeader.TabIndex = 7;

            this.pnlHeader.Paint +=
                new System.Windows.Forms.PaintEventHandler(
                    this.pnlHeader_Paint);

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(210)))),
                    ((int)(((byte)(220)))),
                    ((int)(((byte)(230))))
                );

            this.lblSubtitle.Location =
                new System.Drawing.Point(49, 78);

            this.lblSubtitle.Name =
                "lblSubtitle";

            this.lblSubtitle.Size =
                new System.Drawing.Size(326, 19);

            this.lblSubtitle.TabIndex = 0;

            this.lblSubtitle.Text =
                "Connecting citizens with essential municipal services";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    26F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(45, 25);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(328, 47);

            this.lblTitle.TabIndex = 1;

            this.lblTitle.Text =
                "Municipal Services";

            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    6F,
                    13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(245)))),
                    ((int)(((byte)(247)))),
                    ((int)(((byte)(250))))
                );

            this.ClientSize =
                new System.Drawing.Size(
                    1000,
                    570);

            this.Controls.Add(
                this.pnlScroll);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name =
                "MainMenuForm";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Municipal Services Application";

            this.Load +=
                new System.EventHandler(
                    this.MainMenuForm_Load);

            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();

            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();

            this.pnlEvents.ResumeLayout(false);
            this.pnlEvents.PerformLayout();

            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion
    }
}