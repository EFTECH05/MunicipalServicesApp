namespace MunicipalServicesApp
{
    partial class ViewCitizensForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlAccent;

        private System.Windows.Forms.Label lblMunicipalName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCitizenCount;

        private System.Windows.Forms.DataGridView dgvCitizens;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.Label lblFooter;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;

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
            this.pnlMain = new System.Windows.Forms.Panel();

            this.lblFooter = new System.Windows.Forms.Label();

            this.btnBack = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.dgvCitizens = new System.Windows.Forms.DataGridView();

            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblCitizenCount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlAccent = new System.Windows.Forms.Panel();

            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMunicipalName = new System.Windows.Forms.Label();

            this.pnlScroll.SuspendLayout();
            this.pnlMain.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCitizens)).BeginInit();

            this.pnlHeader.SuspendLayout();

            this.SuspendLayout();

            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;

            this.pnlScroll.AutoScrollMinSize =
                new System.Drawing.Size(0, 800);

            this.pnlScroll.BackColor =
                System.Drawing.Color.FromArgb(
                    245,
                    247,
                    250
                );

            this.pnlScroll.Controls.Add(
                this.pnlMain
            );

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
                this.lblFooter
            );

            this.pnlMain.Controls.Add(
                this.btnBack
            );

            this.pnlMain.Controls.Add(
                this.btnViewDetails
            );

            this.pnlMain.Controls.Add(
                this.btnRefresh
            );

            this.pnlMain.Controls.Add(
                this.dgvCitizens
            );

            this.pnlMain.Controls.Add(
                this.lblCitizenCount
            );

            this.pnlMain.Controls.Add(
                this.lblDescription
            );

            this.pnlMain.Controls.Add(
                this.lblSection
            );

            this.pnlMain.Controls.Add(
                this.pnlHeader
            );

            this.pnlMain.Location =
                new System.Drawing.Point(20, 20);

            this.pnlMain.Name =
                "pnlMain";

            this.pnlMain.Size =
                new System.Drawing.Size(940, 780);

            this.pnlMain.TabIndex = 0;

            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;

            this.lblFooter.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8F
                );

            this.lblFooter.ForeColor =
                System.Drawing.Color.FromArgb(
                    150,
                    150,
                    150
                );

            this.lblFooter.Location =
                new System.Drawing.Point(37, 720);

            this.lblFooter.Name =
                "lblFooter";

            this.lblFooter.Size =
                new System.Drawing.Size(249, 13);

            this.lblFooter.TabIndex = 8;

            this.lblFooter.Text =
                "Municipal Services Application • Administration";

            // 
            // btnBack
            // 
            this.btnBack.BackColor =
                System.Drawing.Color.FromArgb(
                    90,
                    90,
                    90
                );

            this.btnBack.FlatAppearance.BorderSize = 0;

            this.btnBack.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBack.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnBack.ForeColor =
                System.Drawing.Color.White;

            this.btnBack.Location =
                new System.Drawing.Point(760, 635);

            this.btnBack.Name =
                "btnBack";

            this.btnBack.Size =
                new System.Drawing.Size(143, 42);

            this.btnBack.TabIndex = 7;

            this.btnBack.Text =
                "Back";

            this.btnBack.UseVisualStyleBackColor =
                false;

            this.btnBack.Click +=
                new System.EventHandler(
                    this.btnBack_Click
                );

            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor =
                System.Drawing.Color.FromArgb(
                    24,
                    55,
                    89
                );

            this.btnViewDetails.FlatAppearance.BorderSize = 0;

            this.btnViewDetails.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnViewDetails.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnViewDetails.ForeColor =
                System.Drawing.Color.White;

            this.btnViewDetails.Location =
                new System.Drawing.Point(200, 635);

            this.btnViewDetails.Name =
                "btnViewDetails";

            this.btnViewDetails.Size =
                new System.Drawing.Size(165, 42);

            this.btnViewDetails.TabIndex = 6;

            this.btnViewDetails.Text =
                "View Details";

            this.btnViewDetails.UseVisualStyleBackColor =
                false;

            this.btnViewDetails.Click +=
                new System.EventHandler(
                    this.btnViewDetails_Click
                );

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor =
                System.Drawing.Color.FromArgb(
                    0,
                    130,
                    65
                );

            this.btnRefresh.FlatAppearance.BorderSize = 0;

            this.btnRefresh.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRefresh.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnRefresh.ForeColor =
                System.Drawing.Color.White;

            this.btnRefresh.Location =
                new System.Drawing.Point(37, 635);

            this.btnRefresh.Name =
                "btnRefresh";

            this.btnRefresh.Size =
                new System.Drawing.Size(145, 42);

            this.btnRefresh.TabIndex = 5;

            this.btnRefresh.Text =
                "Refresh";

            this.btnRefresh.UseVisualStyleBackColor =
                false;

            this.btnRefresh.Click +=
                new System.EventHandler(
                    this.btnRefresh_Click
                );

            // 
            // dgvCitizens
            // 
            this.dgvCitizens.AllowUserToAddRows = false;
            this.dgvCitizens.AllowUserToDeleteRows = false;
            this.dgvCitizens.AllowUserToResizeRows = false;

            this.dgvCitizens.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvCitizens.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvCitizens.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.dgvCitizens.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvCitizens.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            this.dgvCitizens.ColumnHeadersHeight = 40;

            this.dgvCitizens.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvCitizens.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colId,
                    this.colFullName,
                    this.colEmail,
                    this.colUsername
                }
            );

            this.dgvCitizens.EnableHeadersVisualStyles = false;

            this.dgvCitizens.Location =
                new System.Drawing.Point(37, 280);

            this.dgvCitizens.MultiSelect = false;

            this.dgvCitizens.Name =
                "dgvCitizens";

            this.dgvCitizens.ReadOnly = true;

            this.dgvCitizens.RowHeadersVisible = false;

            this.dgvCitizens.RowTemplate.Height = 35;

            this.dgvCitizens.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvCitizens.Size =
                new System.Drawing.Size(866, 330);

            this.dgvCitizens.TabIndex = 4;

            // 
            // colId
            // 
            this.colId.FillWeight = 15F;

            this.colId.HeaderText =
                "ID";

            this.colId.Name =
                "colId";

            this.colId.ReadOnly = true;

            // 
            // colFullName
            // 
            this.colFullName.FillWeight = 30F;

            this.colFullName.HeaderText =
                "Full Name";

            this.colFullName.Name =
                "colFullName";

            this.colFullName.ReadOnly = true;

            // 
            // colEmail
            // 
            this.colEmail.FillWeight = 35F;

            this.colEmail.HeaderText =
                "Email";

            this.colEmail.Name =
                "colEmail";

            this.colEmail.ReadOnly = true;

            // 
            // colUsername
            // 
            this.colUsername.FillWeight = 25F;

            this.colUsername.HeaderText =
                "Username";

            this.colUsername.Name =
                "colUsername";

            this.colUsername.ReadOnly = true;

            // 
            // lblCitizenCount
            // 
            this.lblCitizenCount.AutoSize = true;

            this.lblCitizenCount.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblCitizenCount.ForeColor =
                System.Drawing.Color.FromArgb(
                    0,
                    130,
                    65
                );

            this.lblCitizenCount.Location =
                new System.Drawing.Point(37, 248);

            this.lblCitizenCount.Name =
                "lblCitizenCount";

            this.lblCitizenCount.Size =
                new System.Drawing.Size(113, 19);

            this.lblCitizenCount.TabIndex = 3;

            this.lblCitizenCount.Text =
                "Total Citizens: 0";

            // 
            // lblDescription
            // 
            this.lblDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F
                );

            this.lblDescription.ForeColor =
                System.Drawing.Color.FromArgb(
                    105,
                    105,
                    105
                );

            this.lblDescription.Location =
                new System.Drawing.Point(37, 212);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(650, 35);

            this.lblDescription.TabIndex = 2;

            this.lblDescription.Text =
                "The table below displays citizens who have registered for the municipal services application.";

            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;

            this.lblSection.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    16F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblSection.ForeColor =
                System.Drawing.Color.FromArgb(
                    35,
                    45,
                    55
                );

            this.lblSection.Location =
                new System.Drawing.Point(35, 175);

            this.lblSection.Name =
                "lblSection";

            this.lblSection.Size =
                new System.Drawing.Size(211, 30);

            this.lblSection.TabIndex = 1;

            this.lblSection.Text =
                "Registered Citizens";

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(
                    24,
                    55,
                    89
                );

            this.pnlHeader.Controls.Add(
                this.pnlAccent
            );

            this.pnlHeader.Controls.Add(
                this.lblSubtitle
            );

            this.pnlHeader.Controls.Add(
                this.lblTitle
            );

            this.pnlHeader.Controls.Add(
                this.lblMunicipalName
            );

            this.pnlHeader.Location =
                new System.Drawing.Point(0, 0);

            this.pnlHeader.Name =
                "pnlHeader";

            this.pnlHeader.Size =
                new System.Drawing.Size(940, 150);

            this.pnlHeader.TabIndex = 0;

            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor =
                System.Drawing.Color.FromArgb(
                    0,
                    130,
                    65
                );

            this.pnlAccent.Location =
                new System.Drawing.Point(0, 145);

            this.pnlAccent.Name =
                "pnlAccent";

            this.pnlAccent.Size =
                new System.Drawing.Size(940, 5);

            this.pnlAccent.TabIndex = 0;

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    205,
                    215,
                    225
                );

            this.lblSubtitle.Location =
                new System.Drawing.Point(36, 102);

            this.lblSubtitle.Name =
                "lblSubtitle";

            this.lblSubtitle.Size =
                new System.Drawing.Size(353, 19);

            this.lblSubtitle.TabIndex = 3;

            this.lblSubtitle.Text =
                "View registered citizens in the municipal services system.";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    25F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(32, 45);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(231, 46);

            this.lblTitle.TabIndex = 2;

            this.lblTitle.Text =
                "View Citizens";

            // 
            // lblMunicipalName
            // 
            this.lblMunicipalName.AutoSize = true;

            this.lblMunicipalName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblMunicipalName.ForeColor =
                System.Drawing.Color.FromArgb(
                    220,
                    225,
                    230
                );

            this.lblMunicipalName.Location =
                new System.Drawing.Point(35, 20);

            this.lblMunicipalName.Name =
                "lblMunicipalName";

            this.lblMunicipalName.Size =
                new System.Drawing.Size(206, 15);

            this.lblMunicipalName.TabIndex = 1;

            this.lblMunicipalName.Text =
                "CITY OF CAPE TOWN MUNICIPALITY";

            // 
            // ViewCitizensForm
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    6F,
                    13F
                );

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    245,
                    247,
                    250
                );

            this.ClientSize =
                new System.Drawing.Size(
                    1000,
                    700
                );

            this.Controls.Add(
                this.pnlScroll
            );

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.MinimizeBox = false;

            this.Name =
                "ViewCitizensForm";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "View Citizens - Municipal Services";

            this.Load +=
                new System.EventHandler(
                    this.ViewCitizensForm_Load
                );

            this.pnlScroll.ResumeLayout(false);

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvCitizens)).EndInit();

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion
    }
}