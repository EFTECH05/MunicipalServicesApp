namespace MunicipalServicesApp
{
    partial class ViewIssuesForm
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(
                    typeof(ViewIssuesForm));

            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();

            this.lblMunicipalName =
                new System.Windows.Forms.Label();

            this.lblHeaderTitle =
                new System.Windows.Forms.Label();

            this.lblHeaderSubtitle =
                new System.Windows.Forms.Label();

            this.lblSection =
                new System.Windows.Forms.Label();

            this.lblDescription =
                new System.Windows.Forms.Label();

            this.lblIssueCount =
                new System.Windows.Forms.Label();

            this.dgvIssues =
                new System.Windows.Forms.DataGridView();

            this.colId =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colLocation =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colCategory =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colDescription =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colAttachment =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colDateReported =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.btnRefresh =
                new System.Windows.Forms.Button();

            this.btnViewDetails =
                new System.Windows.Forms.Button();

            this.btnViewAttachment =
                new System.Windows.Forms.Button();

            this.btnBack =
                new System.Windows.Forms.Button();

            this.lblFooter =
                new System.Windows.Forms.Label();

            this.pnlScroll.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.picLogo)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvIssues)).BeginInit();

            this.SuspendLayout();

            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;

            this.pnlScroll.AutoScrollMinSize =
                new System.Drawing.Size(0, 850);

            this.pnlScroll.BackColor =
                System.Drawing.Color.FromArgb(
                    245,
                    247,
                    250);

            this.pnlScroll.Controls.Add(
                this.pnlMain);

            this.pnlScroll.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlScroll.Location =
                new System.Drawing.Point(0, 0);

            this.pnlScroll.Name =
                "pnlScroll";

            this.pnlScroll.Size =
                new System.Drawing.Size(1000, 700);

            this.pnlScroll.TabIndex = 0;

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor =
                System.Drawing.Color.White;

            this.pnlMain.Controls.Add(
                this.pnlHeader);

            this.pnlMain.Controls.Add(
                this.lblSection);

            this.pnlMain.Controls.Add(
                this.lblDescription);

            this.pnlMain.Controls.Add(
                this.lblIssueCount);

            this.pnlMain.Controls.Add(
                this.dgvIssues);

            this.pnlMain.Controls.Add(
                this.btnRefresh);

            this.pnlMain.Controls.Add(
                this.btnViewDetails);

            this.pnlMain.Controls.Add(
                this.btnViewAttachment);

            this.pnlMain.Controls.Add(
                this.btnBack);

            this.pnlMain.Controls.Add(
                this.lblFooter);

            this.pnlMain.Location =
                new System.Drawing.Point(20, 20);

            this.pnlMain.Name =
                "pnlMain";

            this.pnlMain.Size =
                new System.Drawing.Size(940, 800);

            this.pnlMain.TabIndex = 0;

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(
                    24,
                    55,
                    95);

            this.pnlHeader.Controls.Add(
                this.pnlAccent);

            this.pnlHeader.Controls.Add(
                this.picLogo);

            this.pnlHeader.Controls.Add(
                this.lblMunicipalName);

            this.pnlHeader.Controls.Add(
                this.lblHeaderTitle);

            this.pnlHeader.Controls.Add(
                this.lblHeaderSubtitle);

            this.pnlHeader.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.pnlHeader.Location =
                new System.Drawing.Point(0, 0);

            this.pnlHeader.Name =
                "pnlHeader";

            this.pnlHeader.Size =
                new System.Drawing.Size(940, 150);

            this.pnlHeader.TabIndex = 0;

            this.pnlHeader.Paint +=
                new System.Windows.Forms.PaintEventHandler(
                    this.pnlHeader_Paint);

            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor =
                System.Drawing.Color.FromArgb(
                    0,
                    166,
                    81);

            this.pnlAccent.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            this.pnlAccent.Location =
                new System.Drawing.Point(0, 145);

            this.pnlAccent.Name =
                "pnlAccent";

            this.pnlAccent.Size =
                new System.Drawing.Size(940, 5);

            this.pnlAccent.TabIndex = 0;

            // 
            // picLogo
            // 
            this.picLogo.BackColor =
                System.Drawing.Color.Transparent;

            this.picLogo.Image =
                ((System.Drawing.Image)
                    (resources.GetObject(
                        "picLogo.Image")));

            this.picLogo.Location =
                new System.Drawing.Point(0, 3);

            this.picLogo.Name =
                "picLogo";

            this.picLogo.Size =
                new System.Drawing.Size(128, 90);

            this.picLogo.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.picLogo.TabIndex = 1;

            this.picLogo.TabStop = false;

            // 
            // lblMunicipalName
            // 
            this.lblMunicipalName.AutoSize = true;

            this.lblMunicipalName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblMunicipalName.ForeColor =
                System.Drawing.Color.White;

            this.lblMunicipalName.Location =
                new System.Drawing.Point(140, 25);

            this.lblMunicipalName.Name =
                "lblMunicipalName";

            this.lblMunicipalName.Size =
                new System.Drawing.Size(150, 19);

            this.lblMunicipalName.TabIndex = 2;

            this.lblMunicipalName.Text =
                "MUNICIPAL SERVICES";

            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;

            this.lblHeaderTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    23F,
                    System.Drawing.FontStyle.Bold);

            this.lblHeaderTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblHeaderTitle.Location =
                new System.Drawing.Point(137, 50);

            this.lblHeaderTitle.Name =
                "lblHeaderTitle";

            this.lblHeaderTitle.Size =
                new System.Drawing.Size(250, 42);

            this.lblHeaderTitle.TabIndex = 3;

            this.lblHeaderTitle.Text =
                "Reported Issues";

            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;

            this.lblHeaderSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.lblHeaderSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    220,
                    230,
                    240);

            this.lblHeaderSubtitle.Location =
                new System.Drawing.Point(141, 98);

            this.lblHeaderSubtitle.Name =
                "lblHeaderSubtitle";

            this.lblHeaderSubtitle.Size =
                new System.Drawing.Size(207, 17);

            this.lblHeaderSubtitle.TabIndex = 4;

            this.lblHeaderSubtitle.Text =
                "Review issues reported by citizens";

            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;

            this.lblSection.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    16F,
                    System.Drawing.FontStyle.Bold);

            this.lblSection.ForeColor =
                System.Drawing.Color.FromArgb(
                    24,
                    55,
                    95);

            this.lblSection.Location =
                new System.Drawing.Point(35, 175);

            this.lblSection.Name =
                "lblSection";

            this.lblSection.Size =
                new System.Drawing.Size(209, 30);

            this.lblSection.TabIndex = 1;

            this.lblSection.Text =
                "Issue Management";

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;

            this.lblDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblDescription.ForeColor =
                System.Drawing.Color.DimGray;

            this.lblDescription.Location =
                new System.Drawing.Point(38, 212);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(307, 19);

            this.lblDescription.TabIndex = 2;

            this.lblDescription.Text =
                "Review and monitor issues submitted by citizens.";

            // 
            // lblIssueCount
            // 
            this.lblIssueCount.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblIssueCount.ForeColor =
                System.Drawing.Color.FromArgb(
                    0,
                    130,
                    65);

            this.lblIssueCount.Location =
                new System.Drawing.Point(680, 175);

            this.lblIssueCount.Name =
                "lblIssueCount";

            this.lblIssueCount.Size =
                new System.Drawing.Size(220, 30);

            this.lblIssueCount.TabIndex = 3;

            this.lblIssueCount.Text =
                "Total Issues: 0";

            this.lblIssueCount.TextAlign =
                System.Drawing.ContentAlignment.MiddleRight;

            // 
            // dgvIssues
            // 
            this.dgvIssues.AllowUserToAddRows = false;

            this.dgvIssues.AllowUserToDeleteRows = false;

            this.dgvIssues.AllowUserToResizeRows = false;

            this.dgvIssues.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvIssues.ColumnHeadersHeight = 40;

            this.dgvIssues.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvIssues.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colId,
                    this.colLocation,
                    this.colCategory,
                    this.colDescription,
                    this.colAttachment,
                    this.colDateReported
                });

            this.dgvIssues.EnableHeadersVisualStyles = false;

            this.dgvIssues.GridColor =
                System.Drawing.Color.LightGray;

            this.dgvIssues.Location =
                new System.Drawing.Point(35, 250);

            this.dgvIssues.MultiSelect = false;

            this.dgvIssues.Name =
                "dgvIssues";

            this.dgvIssues.ReadOnly = true;

            this.dgvIssues.RowHeadersVisible = false;

            this.dgvIssues.RowTemplate.Height = 45;

            this.dgvIssues.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvIssues.Size =
                new System.Drawing.Size(865, 350);

            this.dgvIssues.TabIndex = 4;

            // 
            // colId
            // 
            this.colId.HeaderText =
                "ID";

            this.colId.Name =
                "colId";

            this.colId.ReadOnly = true;

            this.colId.Width = 50;

            // 
            // colLocation
            // 
            this.colLocation.HeaderText =
                "Location";

            this.colLocation.Name =
                "colLocation";

            this.colLocation.ReadOnly = true;

            this.colLocation.Width = 145;

            // 
            // colCategory
            // 
            this.colCategory.HeaderText =
                "Category";

            this.colCategory.Name =
                "colCategory";

            this.colCategory.ReadOnly = true;

            this.colCategory.Width = 145;

            // 
            // colDescription
            // 
            this.colDescription.HeaderText =
                "Description";

            this.colDescription.Name =
                "colDescription";

            this.colDescription.ReadOnly = true;

            this.colDescription.Width = 235;

            // 
            // colAttachment
            // 
            this.colAttachment.HeaderText =
                "Attachment";

            this.colAttachment.Name =
                "colAttachment";

            this.colAttachment.ReadOnly = true;

            this.colAttachment.Width = 120;

            // 
            // colDateReported
            // 
            this.colDateReported.HeaderText =
                "Date Reported";

            this.colDateReported.Name =
                "colDateReported";

            this.colDateReported.ReadOnly = true;

            this.colDateReported.Width = 150;

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor =
                System.Drawing.Color.FromArgb(
                    0,
                    166,
                    81);

            this.btnRefresh.FlatAppearance.BorderSize = 0;

            this.btnRefresh.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRefresh.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnRefresh.ForeColor =
                System.Drawing.Color.White;

            this.btnRefresh.Location =
                new System.Drawing.Point(35, 625);

            this.btnRefresh.Name =
                "btnRefresh";

            this.btnRefresh.Size =
                new System.Drawing.Size(135, 45);

            this.btnRefresh.TabIndex = 5;

            this.btnRefresh.Text =
                "Refresh";

            this.btnRefresh.UseVisualStyleBackColor = false;

            this.btnRefresh.Click +=
                new System.EventHandler(
                    this.btnRefresh_Click);

            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor =
                System.Drawing.Color.FromArgb(
                    24,
                    55,
                    95);

            this.btnViewDetails.FlatAppearance.BorderSize = 0;

            this.btnViewDetails.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnViewDetails.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnViewDetails.ForeColor =
                System.Drawing.Color.White;

            this.btnViewDetails.Location =
                new System.Drawing.Point(185, 625);

            this.btnViewDetails.Name =
                "btnViewDetails";

            this.btnViewDetails.Size =
                new System.Drawing.Size(155, 45);

            this.btnViewDetails.TabIndex = 6;

            this.btnViewDetails.Text =
                "View Details";

            this.btnViewDetails.UseVisualStyleBackColor = false;

            this.btnViewDetails.Click +=
                new System.EventHandler(
                    this.btnViewDetails_Click);

            // 
            // btnViewAttachment
            // 
            this.btnViewAttachment.BackColor =
                System.Drawing.Color.FromArgb(
                    70,
                    100,
                    130);

            this.btnViewAttachment.FlatAppearance.BorderSize = 0;

            this.btnViewAttachment.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnViewAttachment.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnViewAttachment.ForeColor =
                System.Drawing.Color.White;

            this.btnViewAttachment.Location =
                new System.Drawing.Point(355, 625);

            this.btnViewAttachment.Name =
                "btnViewAttachment";

            this.btnViewAttachment.Size =
                new System.Drawing.Size(165, 45);

            this.btnViewAttachment.TabIndex = 7;

            this.btnViewAttachment.Text =
                "View Attachment";

            this.btnViewAttachment.UseVisualStyleBackColor = false;

            this.btnViewAttachment.Click +=
                new System.EventHandler(
                    this.btnViewAttachment_Click);

            // 
            // btnBack
            // 
            this.btnBack.BackColor =
                System.Drawing.Color.FromArgb(
                    120,
                    120,
                    120);

            this.btnBack.FlatAppearance.BorderSize = 0;

            this.btnBack.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBack.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnBack.ForeColor =
                System.Drawing.Color.White;

            this.btnBack.Location =
                new System.Drawing.Point(755, 625);

            this.btnBack.Name =
                "btnBack";

            this.btnBack.Size =
                new System.Drawing.Size(145, 45);

            this.btnBack.TabIndex = 8;

            this.btnBack.Text =
                "Back";

            this.btnBack.UseVisualStyleBackColor = false;

            this.btnBack.Click +=
                new System.EventHandler(
                    this.btnBack_Click);

            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;

            this.lblFooter.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F);

            this.lblFooter.ForeColor =
                System.Drawing.Color.Gray;

            this.lblFooter.Location =
                new System.Drawing.Point(35, 745);

            this.lblFooter.Name =
                "lblFooter";

            this.lblFooter.Size =
                new System.Drawing.Size(264, 15);

            this.lblFooter.TabIndex = 9;

            this.lblFooter.Text =
                "Municipal Services System • Administrator Portal";

            // 
            // ViewIssuesForm
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    6F,
                    13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(
                    1000,
                    700);

            this.Controls.Add(
                this.pnlScroll);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name =
                "ViewIssuesForm";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Reported Issues - Municipal Services";

            this.Load +=
                new System.EventHandler(
                    this.ViewIssuesForm_Load);

            this.pnlScroll.ResumeLayout(false);

            this.pnlMain.ResumeLayout(false);

            this.pnlMain.PerformLayout();

            this.pnlHeader.ResumeLayout(false);

            this.pnlHeader.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.picLogo)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvIssues)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlMain;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlAccent;

        private System.Windows.Forms.PictureBox picLogo;

        private System.Windows.Forms.Label lblMunicipalName;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblIssueCount;

        private System.Windows.Forms.DataGridView dgvIssues;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttachment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateReported;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnViewAttachment;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.Label lblFooter;
    }
}