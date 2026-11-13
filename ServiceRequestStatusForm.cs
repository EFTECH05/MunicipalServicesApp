
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        private Account currentUser;

        private DataGridView requestGrid;
        private Button btnViewHistory;
        private Button btnUpdateRequest;

        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblPageTitle;
        private Label lblSubtitle;
        private Label lblRequestCount;

        private readonly Color navy =
            Color.FromArgb(25, 39, 62);

        private readonly Color blue =
            Color.FromArgb(37, 117, 225);

        private readonly Color green =
            Color.FromArgb(30, 130, 85);

        private readonly Color background =
            Color.FromArgb(243, 246, 250);

        // ==========================================
        // CONSTRUCTORS
        // ==========================================

        public ServiceRequestStatusForm(Account account)
        {
            InitializeComponent();
            currentUser = account;
        }

        // Keep this constructor for the Windows Forms Designer.
        public ServiceRequestStatusForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================

        private void ServiceRequestStatusForm_Load(
            object sender,
            EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show(
                    "User information could not be loaded.",
                    "Service Request Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            this.Text = "Municipal Services | Request Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1150, 650);
            this.MinimumSize = new Size(850, 500);
            this.BackColor = background;
            this.Font = new Font("Segoe UI", 9F);

            CreateDashboardLayout();
            LoadServiceRequests();
        }

        // ==========================================
        // CREATE MAIN DASHBOARD LAYOUT
        // ==========================================

        private void CreateDashboardLayout()
        {
            TableLayoutPanel mainLayout =
                new TableLayoutPanel();

            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 3;
            mainLayout.Margin = new Padding(0);
            mainLayout.Padding = new Padding(0);

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 115));

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 75));

            CreateHeader();

            pnlContent = new Panel();

            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.White;
            pnlContent.Padding = new Padding(20);

            CreateRequestGrid();

            Panel footer = CreateFooter();

            mainLayout.Controls.Add(pnlHeader, 0, 0);
            mainLayout.Controls.Add(pnlContent, 0, 1);
            mainLayout.Controls.Add(footer, 0, 2);

            this.Controls.Add(mainLayout);
        }

        // ==========================================
        // CREATE HEADER
        // ==========================================

        private void CreateHeader()
        {
            pnlHeader = new Panel();

            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.BackColor = navy;
            pnlHeader.Padding = new Padding(25, 15, 25, 10);

            lblPageTitle = new Label();

            lblPageTitle.Text =
                "SERVICE REQUEST MANAGEMENT";

            lblPageTitle.Font =
                new Font("Segoe UI", 19F, FontStyle.Bold);

            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.AutoSize = true;

            lblPageTitle.Location =
                new Point(25, 20);

            lblSubtitle = new Label();

            string accountType =
                currentUser.AccountType ?? "";

            bool isCitizen = string.Equals(
                accountType,
                "Citizen",
                StringComparison.OrdinalIgnoreCase);

            lblSubtitle.Text = isCitizen
                ? "Track your reported municipal service requests and their progress."
                : "Monitor, review and update municipal service requests.";

            lblSubtitle.Font =
                new Font("Segoe UI", 9.5F);

            lblSubtitle.ForeColor =
                Color.FromArgb(205, 215, 230);

            lblSubtitle.AutoSize = true;

            lblSubtitle.Location =
                new Point(27, 63);

            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Controls.Add(lblSubtitle);
        }

        // ==========================================
        // CREATE REQUEST TABLE
        // ==========================================

        private void CreateRequestGrid()
        {
            TableLayoutPanel contentLayout =
                new TableLayoutPanel();

            contentLayout.Dock = DockStyle.Fill;
            contentLayout.ColumnCount = 1;
            contentLayout.RowCount = 2;

            contentLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 45));

            contentLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Panel headingPanel = new Panel();

            headingPanel.Dock = DockStyle.Fill;
            headingPanel.BackColor = Color.White;

            Label heading = new Label();

            heading.Text = "Reported Service Requests";

            heading.Font =
                new Font("Segoe UI", 12F, FontStyle.Bold);

            heading.ForeColor = navy;
            heading.AutoSize = true;

            heading.Location = new Point(0, 5);

            lblRequestCount = new Label();

            lblRequestCount.Text = "0 requests";

            lblRequestCount.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);

            lblRequestCount.ForeColor =
                Color.FromArgb(110, 120, 135);

            lblRequestCount.AutoSize = true;

            lblRequestCount.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;

            headingPanel.Controls.Add(heading);
            headingPanel.Controls.Add(lblRequestCount);

            headingPanel.Resize += (sender, e) =>
            {
                lblRequestCount.Location = new Point(
                    Math.Max(
                        heading.Right + 15,
                        headingPanel.ClientSize.Width -
                        lblRequestCount.Width - 10),
                    10);
            };

            // Request table.
            requestGrid = new DataGridView();

            requestGrid.Dock = DockStyle.Fill;
            requestGrid.ReadOnly = true;

            requestGrid.AllowUserToAddRows = false;
            requestGrid.AllowUserToDeleteRows = false;
            requestGrid.AllowUserToResizeRows = false;

            requestGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            requestGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            requestGrid.MultiSelect = false;
            requestGrid.RowHeadersVisible = false;

            requestGrid.BackgroundColor =
                Color.FromArgb(248, 250, 253);

            requestGrid.BorderStyle =
                BorderStyle.None;

            requestGrid.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            requestGrid.GridColor =
                Color.FromArgb(230, 235, 242);

            requestGrid.EnableHeadersVisualStyles = false;

            requestGrid.ColumnHeadersDefaultCellStyle.BackColor =
                navy;

            requestGrid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            requestGrid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            requestGrid.ColumnHeadersDefaultCellStyle.Padding =
                new Padding(8);

            requestGrid.ColumnHeadersHeight = 45;

            requestGrid.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            requestGrid.DefaultCellStyle.ForeColor =
                Color.FromArgb(45, 55, 70);

            requestGrid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(218, 233, 252);

            requestGrid.DefaultCellStyle.SelectionForeColor =
                navy;

            requestGrid.DefaultCellStyle.Padding =
                new Padding(7);

            requestGrid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 248, 252);

            requestGrid.RowsDefaultCellStyle.BackColor =
                Color.White;

            requestGrid.RowTemplate.Height = 42;

            requestGrid.Columns.Add(
                "Reference", "REQUEST REFERENCE");

            requestGrid.Columns.Add(
                "Location", "LOCATION");

            requestGrid.Columns.Add(
                "Category", "CATEGORY");

            requestGrid.Columns.Add(
                "Status", "CURRENT STATUS");

            requestGrid.Columns.Add(
                "Priority", "PRIORITY");

            requestGrid.Columns.Add(
                "DateReported", "DATE REPORTED");

            requestGrid.Columns.Add(
                "Department", "DEPARTMENT");

            requestGrid.Columns["Reference"].FillWeight = 115;
            requestGrid.Columns["Location"].FillWeight = 110;
            requestGrid.Columns["Category"].FillWeight = 100;
            requestGrid.Columns["Status"].FillWeight = 100;
            requestGrid.Columns["Priority"].FillWeight = 75;
            requestGrid.Columns["DateReported"].FillWeight = 120;
            requestGrid.Columns["Department"].FillWeight = 110;

            requestGrid.CellFormatting +=
                requestGrid_CellFormatting;

            contentLayout.Controls.Add(headingPanel, 0, 0);
            contentLayout.Controls.Add(requestGrid, 0, 1);

            pnlContent.Controls.Add(contentLayout);
        }

        // ==========================================
        // STATUS AND PRIORITY COLOURS
        // ==========================================

        private void requestGrid_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName =
                requestGrid.Columns[e.ColumnIndex].Name;

            string value =
                Convert.ToString(e.Value);

            if (columnName == "Status")
            {
                e.CellStyle.Font =
                    new Font("Segoe UI", 9F, FontStyle.Bold);

                if (string.Equals(value, "Received",
                    StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(35, 105, 180);
                }
                else if (string.Equals(value, "In Progress",
                    StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(190, 115, 20);
                }
                else if (string.Equals(value, "Resolved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(25, 130, 80);
                }
                else if (string.Equals(value, "Rejected",
                    StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(190, 55, 55);
                }
            }

            if (columnName == "Priority")
            {
                e.CellStyle.Font =
                    new Font("Segoe UI", 9F, FontStyle.Bold);

                if (value == "Critical")
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(190, 35, 35);
                }
                else if (value == "High")
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(205, 105, 25);
                }
                else if (value == "Medium")
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(40, 105, 180);
                }
                else if (value == "Low")
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(35, 130, 85);
                }
            }
        }

        // ==========================================
        // CREATE FOOTER AND ACTION BUTTONS
        // ==========================================

        private Panel CreateFooter()
        {
            Panel footer = new Panel();

            footer.Dock = DockStyle.Fill;
            footer.BackColor =
                Color.FromArgb(235, 240, 247);

            footer.Padding = new Padding(15);

            FlowLayoutPanel buttonPanel =
                new FlowLayoutPanel();

            buttonPanel.Dock = DockStyle.Right;
            buttonPanel.FlowDirection =
                FlowDirection.RightToLeft;

            buttonPanel.WrapContents = false;
            buttonPanel.AutoSize = true;

            btnViewHistory = new Button();

            btnViewHistory.Text = "VIEW STATUS HISTORY";

            StyleButton(btnViewHistory, blue, 190);

            btnViewHistory.Click +=
                btnViewHistory_Click;

            btnUpdateRequest = new Button();

            btnUpdateRequest.Text = "UPDATE REQUEST";

            StyleButton(btnUpdateRequest, green, 190);

            btnUpdateRequest.Click +=
                btnUpdateRequest_Click;

            string accountType =
                currentUser.AccountType ?? "";

            bool isAdministrator =
                string.Equals(accountType, "Admin",
                    StringComparison.OrdinalIgnoreCase)
                ||
                string.Equals(accountType, "SuperAdmin",
                    StringComparison.OrdinalIgnoreCase);

            btnUpdateRequest.Visible = isAdministrator;

            buttonPanel.Controls.Add(btnViewHistory);

            if (isAdministrator)
            {
                buttonPanel.Controls.Add(btnUpdateRequest);
            }

            footer.Controls.Add(buttonPanel);

            return footer;
        }

        // ==========================================
        // REUSABLE BUTTON DESIGN
        // ==========================================

        private void StyleButton(
            Button button,
            Color buttonColor,
            int width)
        {
            button.Size = new Size(width, 42);

            button.BackColor = buttonColor;
            button.ForeColor = Color.White;

            button.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            button.FlatStyle = FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 0;

            button.Cursor = Cursors.Hand;
            button.Margin = new Padding(8, 0, 0, 0);

            button.UseVisualStyleBackColor = false;
        }

        // ==========================================
        // LOAD SERVICE REQUESTS USING MIN HEAP
        // ==========================================

        private void LoadServiceRequests()
        {
            try
            {
                IssueStore.LoadIssues();

                requestGrid.Rows.Clear();

                List<Issue> visibleIssues =
                    new List<Issue>();

                string accountType =
                    currentUser.AccountType ?? "";

                bool isCitizen = string.Equals(
                    accountType,
                    "Citizen",
                    StringComparison.OrdinalIgnoreCase);

                bool isAdministrator =
                    string.Equals(accountType, "Admin",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    string.Equals(accountType, "SuperAdmin",
                        StringComparison.OrdinalIgnoreCase);

                if (!isCitizen && !isAdministrator)
                {
                    MessageBox.Show(
                        "You do not have permission to view service requests.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Filter requests according to account role.
                foreach (Issue issue in IssueStore.Issues)
                {
                    if (isCitizen &&
                        issue.AccountId != currentUser.Id)
                    {
                        continue;
                    }

                    visibleIssues.Add(issue);
                }

                // ==================================
                // MIN HEAP INTEGRATION
                // ==================================

                List<Issue> displayIssues =
                    new List<Issue>();

                if (isAdministrator)
                {
                    MinHeap priorityHeap =
                        new MinHeap();

                    // Insert requests into the heap.
                    foreach (Issue issue in visibleIssues)
                    {
                        priorityHeap.Insert(issue);
                    }

                    // Extract requests in priority order.
                    while (!priorityHeap.IsEmpty)
                    {
                        Issue urgentIssue =
                            priorityHeap.ExtractMin();

                        if (urgentIssue != null)
                        {
                            displayIssues.Add(urgentIssue);
                        }
                    }
                }
                else
                {
                    // Citizens only see their own requests.
                    displayIssues.AddRange(visibleIssues);
                }

                // ==================================
                // DISPLAY REQUESTS
                // ==================================

                foreach (Issue issue in displayIssues)
                {
                    requestGrid.Rows.Add(
                        issue.RequestReference,
                        issue.Location,
                        issue.Category,
                        issue.Status,
                        issue.PriorityName,
                        issue.DateReported.ToString(
                            "dd MMM yyyy HH:mm"),
                        string.IsNullOrWhiteSpace(issue.Department)
                            ? "Not assigned"
                            : issue.Department);
                }

                lblRequestCount.Text =
                    displayIssues.Count +
                    (displayIssues.Count == 1
                        ? " request"
                        : " requests");

                if (displayIssues.Count == 0)
                {
                    MessageBox.Show(
                        "No service requests were found.",
                        "Service Request Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load service requests.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // GET SELECTED REQUEST
        // ==========================================

        private Issue GetSelectedRequest()
        {
            if (requestGrid.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a service request first.",
                    "Select Request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return null;
            }

            string reference = Convert.ToString(
                requestGrid.CurrentRow.Cells["Reference"].Value);

            if (string.IsNullOrWhiteSpace(reference))
            {
                MessageBox.Show(
                    "The selected request reference is invalid.",
                    "Request Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return null;
            }

            Issue selectedIssue =
                IssueStore.FindIssueByReference(reference);

            if (selectedIssue == null)
            {
                MessageBox.Show(
                    "The selected service request could not be found.",
                    "Request Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return selectedIssue;
        }

        // ==========================================
        // VIEW STATUS HISTORY
        // ==========================================

        private void btnViewHistory_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Issue selectedIssue = GetSelectedRequest();

                if (selectedIssue == null)
                    return;

                string accountType =
                    currentUser.AccountType ?? "";

                bool isCitizen = string.Equals(
                    accountType,
                    "Citizen",
                    StringComparison.OrdinalIgnoreCase);

                bool isAdministrator =
                    string.Equals(accountType, "Admin",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    string.Equals(accountType, "SuperAdmin",
                        StringComparison.OrdinalIgnoreCase);

                if (!isCitizen && !isAdministrator)
                {
                    MessageBox.Show(
                        "You do not have permission to view this history.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (isCitizen &&
                    selectedIssue.AccountId != currentUser.Id)
                {
                    MessageBox.Show(
                        "You can only view the history of your own requests.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DataTable history =
                    IssueStore.GetStatusHistory(selectedIssue.Id);

                DisplayStatusHistory(selectedIssue, history);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to retrieve status history.\n\n" +
                    ex.Message,
                    "History Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // DISPLAY STATUS HISTORY
        // ==========================================

        private void DisplayStatusHistory(
            Issue issue,
            DataTable history)
        {
            if (history == null || history.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No status history is available for this request.",
                    "Status History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            Form historyForm = new Form();

            historyForm.Text =
                "Status History | " + issue.RequestReference;

            historyForm.StartPosition =
                FormStartPosition.CenterParent;

            historyForm.Size = new Size(900, 470);
            historyForm.MinimumSize = new Size(650, 350);
            historyForm.BackColor = background;
            historyForm.Font = new Font("Segoe UI", 9F);

            TableLayoutPanel layout =
                new TableLayoutPanel();

            layout.Dock = DockStyle.Fill;
            layout.ColumnCount = 1;
            layout.RowCount = 2;

            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 75));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Panel headingPanel = new Panel();

            headingPanel.Dock = DockStyle.Fill;
            headingPanel.BackColor = navy;

            Label heading = new Label();

            heading.Text = "STATUS HISTORY";

            heading.Font =
                new Font("Segoe UI", 15F, FontStyle.Bold);

            heading.ForeColor = Color.White;
            heading.AutoSize = true;

            heading.Location = new Point(20, 12);

            Label detail = new Label();

            detail.Text =
                "Request: " + issue.RequestReference +
                "  |  Category: " + issue.Category;

            detail.Font = new Font("Segoe UI", 9F);
            detail.ForeColor =
                Color.FromArgb(210, 220, 235);

            detail.AutoSize = true;
            detail.Location = new Point(22, 45);

            headingPanel.Controls.Add(heading);
            headingPanel.Controls.Add(detail);

            DataGridView historyGrid =
                new DataGridView();

            historyGrid.Dock = DockStyle.Fill;
            historyGrid.ReadOnly = true;

            historyGrid.AllowUserToAddRows = false;
            historyGrid.AllowUserToDeleteRows = false;

            historyGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            historyGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            historyGrid.MultiSelect = false;
            historyGrid.RowHeadersVisible = false;

            historyGrid.BackgroundColor = Color.White;
            historyGrid.BorderStyle = BorderStyle.None;

            historyGrid.EnableHeadersVisualStyles = false;

            historyGrid.ColumnHeadersDefaultCellStyle.BackColor =
                navy;

            historyGrid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            historyGrid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            historyGrid.ColumnHeadersHeight = 40;

            historyGrid.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            historyGrid.DefaultCellStyle.Padding =
                new Padding(7);

            historyGrid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 248, 252);

            historyGrid.RowTemplate.Height = 40;

            historyGrid.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            historyGrid.Columns.Add("Status", "STATUS");
            historyGrid.Columns.Add("Notes", "UPDATE NOTES");
            historyGrid.Columns.Add("UpdatedAt", "DATE AND TIME");
            historyGrid.Columns.Add("UpdatedBy", "UPDATED BY");

            historyGrid.Columns["Notes"].FillWeight = 150;

            historyGrid.Columns["Notes"].DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            foreach (DataRow row in history.Rows)
            {
                string status =
                    Convert.ToString(row["Status"]);

                string notes =
                    row["Notes"] == DBNull.Value
                        ? "No notes"
                        : Convert.ToString(row["Notes"]);

                string updatedAt = "";

                if (row["UpdatedAt"] != DBNull.Value)
                {
                    updatedAt = Convert.ToDateTime(
                        row["UpdatedAt"]).ToString(
                            "dd MMM yyyy HH:mm");
                }

                string updatedBy =
                    row["UpdatedBy"] == DBNull.Value
                        ? "Unknown"
                        : Convert.ToString(row["UpdatedBy"]);

                historyGrid.Rows.Add(
                    status,
                    notes,
                    updatedAt,
                    updatedBy);
            }

            layout.Controls.Add(headingPanel, 0, 0);
            layout.Controls.Add(historyGrid, 0, 1);

            historyForm.Controls.Add(layout);

            historyForm.ShowDialog(this);
        }

        // ==========================================
        // ADMINISTRATOR UPDATE BUTTON
        // ==========================================

        private void btnUpdateRequest_Click(
            object sender,
            EventArgs e)
        {
            string accountType =
                currentUser.AccountType ?? "";

            bool isAdministrator =
                string.Equals(accountType, "Admin",
                    StringComparison.OrdinalIgnoreCase)
                ||
                string.Equals(accountType, "SuperAdmin",
                    StringComparison.OrdinalIgnoreCase);

            if (!isAdministrator)
            {
                MessageBox.Show(
                    "Only administrators can update service requests.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Issue selectedIssue = GetSelectedRequest();

            if (selectedIssue == null)
                return;

            ShowUpdateRequestDialog(selectedIssue);
        }

        // ==========================================
        // ADMINISTRATOR UPDATE FORM
        // ==========================================

        private void ShowUpdateRequestDialog(Issue issue)
        {
            Form updateForm = new Form();

            updateForm.Text =
                "Update Request | " + issue.RequestReference;

            updateForm.StartPosition =
                FormStartPosition.CenterParent;

            updateForm.Size = new Size(560, 510);
            updateForm.MinimumSize = new Size(500, 450);

            updateForm.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            updateForm.MaximizeBox = false;
            updateForm.MinimizeBox = false;
            updateForm.BackColor = background;
            updateForm.Font = new Font("Segoe UI", 9F);

            TableLayoutPanel mainLayout =
                new TableLayoutPanel();

            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 2;

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 75));

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            Panel header = new Panel();

            header.Dock = DockStyle.Fill;
            header.BackColor = navy;

            Label title = new Label();

            title.Text = "UPDATE SERVICE REQUEST";

            title.Font =
                new Font("Segoe UI", 14F, FontStyle.Bold);

            title.ForeColor = Color.White;
            title.AutoSize = true;
            title.Location = new Point(20, 20);

            header.Controls.Add(title);

            Panel content = new Panel();

            content.Dock = DockStyle.Fill;
            content.Padding = new Padding(20);
            content.BackColor = Color.White;

            TableLayoutPanel layout =
                new TableLayoutPanel();

            layout.Dock = DockStyle.Fill;
            layout.ColumnCount = 2;
            layout.RowCount = 6;

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 125));

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 48));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 55));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 55));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 55));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 55));

            Label requestLabel = CreateFieldLabel("Request:");

            Label requestValue = new Label();

            requestValue.Text =
                issue.RequestReference + " - " + issue.Category;

            requestValue.TextAlign =
                ContentAlignment.MiddleLeft;

            requestValue.Dock = DockStyle.Fill;

            requestValue.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            Label statusLabel = CreateFieldLabel("Status:");

            ComboBox cmbStatus = new ComboBox();

            cmbStatus.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbStatus.Dock = DockStyle.Fill;

            cmbStatus.Font = new Font("Segoe UI", 9F);

            cmbStatus.Items.AddRange(new object[]
            {
                "Received",
                "In Progress",
                "Resolved",
                "Rejected"
            });

            int statusIndex =
                cmbStatus.Items.IndexOf(issue.Status);

            cmbStatus.SelectedIndex =
                statusIndex >= 0 ? statusIndex : 0;

            Label priorityLabel = CreateFieldLabel("Priority:");

            ComboBox cmbPriority = new ComboBox();

            cmbPriority.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbPriority.Dock = DockStyle.Fill;

            cmbPriority.Font = new Font("Segoe UI", 9F);

            cmbPriority.Items.AddRange(new object[]
            {
                "Critical",
                "High",
                "Medium",
                "Low"
            });

            cmbPriority.SelectedIndex =
                issue.Priority >= 1 && issue.Priority <= 4
                    ? issue.Priority - 1
                    : 2;

            Label departmentLabel =
                CreateFieldLabel("Department:");

            TextBox txtDepartment = new TextBox();

            txtDepartment.Dock = DockStyle.Fill;

            txtDepartment.Font =
                new Font("Segoe UI", 9F);

            txtDepartment.Text =
                issue.Department ?? "";

            Label notesLabel =
                CreateFieldLabel("Update Notes:");

            notesLabel.TextAlign =
                ContentAlignment.TopLeft;

            TextBox txtNotes = new TextBox();

            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Multiline = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.MaxLength = 500;

            txtNotes.Font =
                new Font("Segoe UI", 9F);

            FlowLayoutPanel buttonPanel =
                new FlowLayoutPanel();

            buttonPanel.Dock = DockStyle.Fill;

            buttonPanel.FlowDirection =
                FlowDirection.RightToLeft;

            buttonPanel.WrapContents = false;

            Button btnSave = new Button();

            btnSave.Text = "SAVE UPDATE";

            StyleButton(btnSave, green, 130);

            Button btnCancel = new Button();

            btnCancel.Text = "CANCEL";

            StyleButton(
                btnCancel,
                Color.FromArgb(110, 120, 135),
                100);

            btnCancel.DialogResult =
                DialogResult.Cancel;

            buttonPanel.Controls.Add(btnSave);
            buttonPanel.Controls.Add(btnCancel);

            layout.Controls.Add(requestLabel, 0, 0);
            layout.Controls.Add(requestValue, 1, 0);

            layout.Controls.Add(statusLabel, 0, 1);
            layout.Controls.Add(cmbStatus, 1, 1);

            layout.Controls.Add(priorityLabel, 0, 2);
            layout.Controls.Add(cmbPriority, 1, 2);

            layout.Controls.Add(departmentLabel, 0, 3);
            layout.Controls.Add(txtDepartment, 1, 3);

            layout.Controls.Add(notesLabel, 0, 4);
            layout.Controls.Add(txtNotes, 1, 4);

            layout.Controls.Add(buttonPanel, 0, 5);
            layout.SetColumnSpan(buttonPanel, 2);

            content.Controls.Add(layout);

            mainLayout.Controls.Add(header, 0, 0);
            mainLayout.Controls.Add(content, 0, 1);

            updateForm.Controls.Add(mainLayout);

            updateForm.CancelButton = btnCancel;
            updateForm.AcceptButton = btnSave;

            // ==================================
            // SAVE REQUEST UPDATE
            // ==================================

            btnSave.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    MessageBox.Show(
                        "Please enter notes explaining the update.",
                        "Update Notes Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNotes.Focus();
                    return;
                }

                if (cmbStatus.SelectedItem == null ||
                    cmbPriority.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Please select a status and priority.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string newStatus =
                    Convert.ToString(cmbStatus.SelectedItem);

                int newPriority =
                    cmbPriority.SelectedIndex + 1;

                string department =
                    txtDepartment.Text.Trim();

                string notes =
                    txtNotes.Text.Trim();

                string updatedBy =
                    string.IsNullOrWhiteSpace(currentUser.FullName)
                        ? "Administrator"
                        : currentUser.FullName;

                try
                {
                    bool success =
                        IssueStore.UpdateServiceRequest(
                            issue.Id,
                            newStatus,
                            newPriority,
                            department,
                            notes,
                            updatedBy);

                    if (!success)
                    {
                        MessageBox.Show(
                            "The service request could not be updated.",
                            "Update Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    MessageBox.Show(
                        "The service request was updated successfully.",
                        "Update Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    updateForm.DialogResult =
                        DialogResult.OK;

                    updateForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Unable to update the service request.\n\n" +
                        ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            if (updateForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadServiceRequests();
            }
        }

        // ==========================================
        // CREATE FIELD LABEL
        // ==========================================

        private Label CreateFieldLabel(string text)
        {
            Label label = new Label();

            label.Text = text;

            label.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            label.ForeColor = navy;

            label.Dock = DockStyle.Fill;

            label.TextAlign =
                ContentAlignment.MiddleLeft;

            return label;
        }
    }
}
