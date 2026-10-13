
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

        private void InitializeComponent()
        {
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.pnlReport = new System.Windows.Forms.Panel();
            this.lblReportIcon = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lblReportDescription = new System.Windows.Forms.Label();
            this.btnReportIssues = new System.Windows.Forms.Button();

            this.pnlEvents = new System.Windows.Forms.Panel();
            this.lblEventsIcon = new System.Windows.Forms.Label();
            this.lblEventsTitle = new System.Windows.Forms.Label();
            this.lblEventsDescription = new System.Windows.Forms.Label();
            this.btnEvents = new System.Windows.Forms.Button();

            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatusIcon = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblStatusDescription = new System.Windows.Forms.Label();
            this.btnServiceStatus = new System.Windows.Forms.Button();

            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();

            this.pnlScroll.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.pnlEvents.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            // Main scrolling panel
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.Controls.Add(this.pnlHeader);
            this.pnlScroll.Controls.Add(this.lblWelcome);
            this.pnlScroll.Controls.Add(this.lblDescription);
            this.pnlScroll.Controls.Add(this.pnlReport);
            this.pnlScroll.Controls.Add(this.pnlEvents);
            this.pnlScroll.Controls.Add(this.pnlStatus);
            this.pnlScroll.Controls.Add(this.lblInstruction);
            this.pnlScroll.Controls.Add(this.lblFooter);
            this.pnlScroll.Controls.Add(this.btnLogout);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1000, 620);
            this.pnlScroll.TabIndex = 0;

            // Header panel
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 125);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(
                this.pnlHeader_Paint);

            // Header title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(40, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Municipal Services";

            // Header subtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(44, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(350, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text =
                "Your community. Your voice. Our responsibility.";

            // Welcome label
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(40, 145);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(250, 35);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Citizen";

            // Description label
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(43, 188);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(600, 20);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text =
                "Access services, report problems and stay informed in your community.";

            // Report card
            this.pnlReport.Controls.Add(this.lblReportIcon);
            this.pnlReport.Controls.Add(this.lblReportTitle);
            this.pnlReport.Controls.Add(this.lblReportDescription);
            this.pnlReport.Controls.Add(this.btnReportIssues);
            this.pnlReport.Location = new System.Drawing.Point(40, 235);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(280, 220);
            this.pnlReport.TabIndex = 3;

            this.lblReportIcon.AutoSize = false;
            this.lblReportIcon.Location = new System.Drawing.Point(22, 20);
            this.lblReportIcon.Name = "lblReportIcon";
            this.lblReportIcon.Size = new System.Drawing.Size(50, 40);
            this.lblReportIcon.TabIndex = 0;
            this.lblReportIcon.Text = "!";

            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Location = new System.Drawing.Point(22, 68);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(150, 25);
            this.lblReportTitle.TabIndex = 1;
            this.lblReportTitle.Text = "Report an Issue";

            this.lblReportDescription.AutoSize = false;
            this.lblReportDescription.Location = new System.Drawing.Point(22, 102);
            this.lblReportDescription.Name = "lblReportDescription";
            this.lblReportDescription.Size = new System.Drawing.Size(235, 55);
            this.lblReportDescription.TabIndex = 2;
            this.lblReportDescription.Text =
                "Report municipal problems and community issues.";

            this.btnReportIssues.Location = new System.Drawing.Point(22, 165);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(235, 38);
            this.btnReportIssues.TabIndex = 3;
            this.btnReportIssues.Text = "Report an Issue";
            this.btnReportIssues.UseVisualStyleBackColor = false;
            this.btnReportIssues.Click += new System.EventHandler(
                this.btnReportIssues_Click);

            // Events card
            this.pnlEvents.Controls.Add(this.lblEventsIcon);
            this.pnlEvents.Controls.Add(this.lblEventsTitle);
            this.pnlEvents.Controls.Add(this.lblEventsDescription);
            this.pnlEvents.Controls.Add(this.btnEvents);
            this.pnlEvents.Location = new System.Drawing.Point(350, 235);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(280, 220);
            this.pnlEvents.TabIndex = 4;

            this.lblEventsIcon.AutoSize = false;
            this.lblEventsIcon.Location = new System.Drawing.Point(22, 20);
            this.lblEventsIcon.Name = "lblEventsIcon";
            this.lblEventsIcon.Size = new System.Drawing.Size(50, 40);
            this.lblEventsIcon.TabIndex = 0;
            this.lblEventsIcon.Text = "★";

            this.lblEventsTitle.AutoSize = true;
            this.lblEventsTitle.Location = new System.Drawing.Point(22, 68);
            this.lblEventsTitle.Name = "lblEventsTitle";
            this.lblEventsTitle.Size = new System.Drawing.Size(150, 25);
            this.lblEventsTitle.TabIndex = 1;
            this.lblEventsTitle.Text = "Local Events";

            this.lblEventsDescription.AutoSize = false;
            this.lblEventsDescription.Location = new System.Drawing.Point(22, 102);
            this.lblEventsDescription.Name = "lblEventsDescription";
            this.lblEventsDescription.Size = new System.Drawing.Size(235, 55);
            this.lblEventsDescription.TabIndex = 2;
            this.lblEventsDescription.Text =
                "Discover local events and municipal announcements.";

            this.btnEvents.Location = new System.Drawing.Point(22, 165);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(235, 38);
            this.btnEvents.TabIndex = 3;
            this.btnEvents.Text = "View Events";
            this.btnEvents.UseVisualStyleBackColor = false;

            // Service status card
            this.pnlStatus.Controls.Add(this.lblStatusIcon);
            this.pnlStatus.Controls.Add(this.lblStatusTitle);
            this.pnlStatus.Controls.Add(this.lblStatusDescription);
            this.pnlStatus.Controls.Add(this.btnServiceStatus);
            this.pnlStatus.Location = new System.Drawing.Point(660, 235);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(280, 220);
            this.pnlStatus.TabIndex = 5;

            this.lblStatusIcon.AutoSize = false;
            this.lblStatusIcon.Location = new System.Drawing.Point(22, 20);
            this.lblStatusIcon.Name = "lblStatusIcon";
            this.lblStatusIcon.Size = new System.Drawing.Size(50, 40);
            this.lblStatusIcon.TabIndex = 0;
            this.lblStatusIcon.Text = "i";

            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Location = new System.Drawing.Point(22, 68);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(150, 25);
            this.lblStatusTitle.TabIndex = 1;
            this.lblStatusTitle.Text = "Service Status";

            this.lblStatusDescription.AutoSize = false;
            this.lblStatusDescription.Location = new System.Drawing.Point(22, 102);
            this.lblStatusDescription.Name = "lblStatusDescription";
            this.lblStatusDescription.Size = new System.Drawing.Size(235, 55);
            this.lblStatusDescription.TabIndex = 2;
            this.lblStatusDescription.Text =
                "Check service request progress and updates.";

            this.btnServiceStatus.Location = new System.Drawing.Point(22, 165);
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.Size = new System.Drawing.Size(235, 38);
            this.btnServiceStatus.TabIndex = 3;
            this.btnServiceStatus.Text = "Coming Soon";
            this.btnServiceStatus.UseVisualStyleBackColor = false;
            this.btnServiceStatus.Enabled = false;

            // Instruction
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(40, 480);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(300, 20);
            this.lblInstruction.TabIndex = 6;
            this.lblInstruction.Text =
                "Choose a service above to get started.";

            // Footer
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(40, 565);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(350, 18);
            this.lblFooter.TabIndex = 7;
            this.lblFooter.Text =
                "Municipal Services Application | Citizen Portal";

            // Logout button
            this.btnLogout.Location = new System.Drawing.Point(810, 475);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 38);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(
                this.btnLogout_Click);

            // Main form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.pnlScroll);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services | Citizen Portal";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);

            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            this.pnlEvents.ResumeLayout(false);
            this.pnlEvents.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
