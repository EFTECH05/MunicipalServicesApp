


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewAccountsForm : Form
    {
        private Button btnToggleStatus;

        // Municipal colour palette
        private readonly Color navy = Color.FromArgb(22, 43, 67);
        private readonly Color municipalBlue = Color.FromArgb(39, 91, 135);
        private readonly Color municipalGreen = Color.FromArgb(0, 132, 90);
        private readonly Color gold = Color.FromArgb(232, 180, 45);
        private readonly Color background = Color.FromArgb(243, 246, 249);
        private readonly Color textDark = Color.FromArgb(42, 55, 70);

        public ViewAccountsForm()
        {
            InitializeComponent();

            ConfigureDesktopDesign();
            ConfigureAccountsGrid();
            StyleExistingButtons();
            CreateStatusButton();
            ArrangeActionButtons();
            LoadAccounts();

            dgvAccounts.SelectionChanged += dgvAccounts_SelectionChanged;
        }

        // Designer Load event handler
        private void ViewAccountsForm_Load(object sender, EventArgs e)
        {
            // Initial setup is performed in the constructor.
        }

        // Designer Paint event handler for the scroll panel
        private void pnlScroll_Paint(object sender, PaintEventArgs e)
        {
            // No custom painting is currently required.
        }

        // Designer Paint event handler for the header panel
        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            // No custom painting is currently required.
        }

        private void ConfigureDesktopDesign()
        {
            Text = "Municipal Services - Account Management";
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = background;
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 550);
        }

        private void ConfigureAccountsGrid()
        {
            dgvAccounts.SuspendLayout();

            dgvAccounts.Columns.Clear();
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.ReadOnly = true;
            dgvAccounts.MultiSelect = false;
            dgvAccounts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.BackgroundColor = Color.White;
            dgvAccounts.BorderStyle = BorderStyle.None;
            dgvAccounts.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAccounts.GridColor = Color.FromArgb(225, 231, 237);
            dgvAccounts.EnableHeadersVisualStyles = false;

            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAccounts.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAccounts.ColumnHeadersDefaultCellStyle.SelectionBackColor = navy;
            dgvAccounts.ColumnHeadersHeight = 42;

            dgvAccounts.DefaultCellStyle.BackColor = Color.White;
            dgvAccounts.DefaultCellStyle.ForeColor = textDark;
            dgvAccounts.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 235, 247);
            dgvAccounts.DefaultCellStyle.SelectionForeColor = navy;
            dgvAccounts.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvAccounts.RowTemplate.Height = 36;

            dgvAccounts.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            AddColumn("colId", "ID", 45);
            AddColumn("colFullName", "FULL NAME", 150);
            AddColumn("colEmail", "EMAIL ADDRESS", 190);
            AddColumn("colUsername", "USERNAME", 115);
            AddColumn("colAccountType", "ACCOUNT TYPE", 100);
            AddColumn("colStatus", "STATUS", 75);

            dgvAccounts.ResumeLayout();
        }

        private void AddColumn(string name, string header, float fillWeight)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();

            column.Name = name;
            column.HeaderText = header;
            column.DataPropertyName = name;
            column.FillWeight = fillWeight;
            column.SortMode = DataGridViewColumnSortMode.Automatic;

            dgvAccounts.Columns.Add(column);
        }

        private void StyleExistingButtons()
        {
            StyleButton(btnRefresh, municipalBlue);
            StyleButton(btnViewDetails, municipalGreen);
            StyleButton(btnBack, navy);
        }

        private void StyleButton(Button button, Color buttonColor)
        {
            if (button == null)
                return;

            button.BackColor = buttonColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.Height = 38;
        }

        private void CreateStatusButton()
        {
            btnToggleStatus = new Button
            {
                Name = "btnToggleStatus",
                Text = "Deactivate Account",
                Size = new Size(165, 38)
            };

            btnToggleStatus.Click += btnToggleStatus_Click;

            StyleButton(
                btnToggleStatus,
                Color.FromArgb(200, 55, 65)
            );

            if (btnViewDetails != null &&
                btnViewDetails.Parent != null)
            {
                btnViewDetails.Parent.Controls.Add(btnToggleStatus);
                btnToggleStatus.BringToFront();
            }
        }

        private void ArrangeActionButtons()
        {
            if (btnRefresh == null ||
                btnViewDetails == null ||
                btnBack == null ||
                btnToggleStatus == null)
                return;

            Control parent = btnRefresh.Parent;

            if (parent == null ||
                btnViewDetails.Parent != parent ||
                btnBack.Parent != parent ||
                btnToggleStatus.Parent != parent)
                return;

            int left = btnRefresh.Left;
            int top = btnRefresh.Top;
            int spacing = 10;

            btnRefresh.Location = new Point(left, top);

            btnViewDetails.Location =
                new Point(btnRefresh.Right + spacing, top);

            btnToggleStatus.Location =
                new Point(btnViewDetails.Right + spacing, top);

            btnBack.Location =
                new Point(btnToggleStatus.Right + spacing, top);
        }

        private void LoadAccounts()
        {
            try
            {
                AccountStore.LoadAccounts();

                List<Account> accounts = AccountStore.Accounts;

                dgvAccounts.Rows.Clear();

                foreach (Account account in accounts)
                {
                    string status = account.IsActive
                        ? "Active"
                        : "Inactive";

                    int rowIndex = dgvAccounts.Rows.Add(
                        account.Id,
                        account.FullName,
                        account.Email,
                        account.Username,
                        account.AccountType,
                        status
                    );

                    dgvAccounts.Rows[rowIndex].Tag = account;

                    DataGridViewCell statusCell =
                        dgvAccounts.Rows[rowIndex].Cells["colStatus"];

                    statusCell.Style.ForeColor = account.IsActive
                        ? municipalGreen
                        : Color.FromArgb(200, 55, 65);

                    statusCell.Style.Font =
                        new Font("Segoe UI", 9F, FontStyle.Bold);
                }

                lblAccountCount.Text =
                    $"Total Accounts: {accounts.Count}";

                dgvAccounts.ClearSelection();

                if (dgvAccounts.Rows.Count > 0)
                {
                    dgvAccounts.CurrentCell =
                        dgvAccounts.Rows[0].Cells["colFullName"];

                    dgvAccounts.Rows[0].Selected = true;
                }

                UpdateStatusButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load accounts.\n\n" + ex.Message,
                    "Account Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private Account GetSelectedAccount()
        {
            if (dgvAccounts.SelectedRows.Count == 0)
                return null;

            return dgvAccounts.SelectedRows[0].Tag as Account;
        }

        private void UpdateStatusButton()
        {
            if (btnToggleStatus == null)
                return;

            Account account = GetSelectedAccount();

            if (account == null)
            {
                btnToggleStatus.Text = "Deactivate Account";
                btnToggleStatus.Enabled = false;
                btnToggleStatus.BackColor = Color.Gray;
                return;
            }

            // Protect the Super Admin account.
            if (string.Equals(
                account.AccountType,
                "SuperAdmin",
                StringComparison.OrdinalIgnoreCase))
            {
                btnToggleStatus.Text = "Protected Account";
                btnToggleStatus.Enabled = false;
                btnToggleStatus.BackColor = Color.Gray;
                return;
            }

            btnToggleStatus.Enabled = true;

            if (account.IsActive)
            {
                btnToggleStatus.Text = "Deactivate Account";
                btnToggleStatus.BackColor =
                    Color.FromArgb(200, 55, 65);
            }
            else
            {
                btnToggleStatus.Text = "Reactivate Account";
                btnToggleStatus.BackColor = municipalGreen;
            }
        }

        private void dgvAccounts_SelectionChanged(
            object sender,
            EventArgs e)
        {
            UpdateStatusButton();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            Account account = GetSelectedAccount();

            if (account == null)
            {
                MessageBox.Show(
                    "Please select an account to view its details.",
                    "Account Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            string lastLogin = account.LastLoginAt.HasValue
                ? account.LastLoginAt.Value.ToString("dd MMM yyyy HH:mm")
                : "Never logged in";

            string createdAt =
                account.CreatedAt.ToString("dd MMM yyyy HH:mm");

            string details =
                $"Account ID: {account.Id}\n\n" +
                $"Full Name: {account.FullName}\n\n" +
                $"Email Address: {account.Email}\n\n" +
                $"Username: {account.Username}\n\n" +
                $"Account Type: {account.AccountType}\n\n" +
                $"Status: {(account.IsActive ? "Active" : "Inactive")}\n\n" +
                $"Created At: {createdAt}\n\n" +
                $"Last Login: {lastLogin}";

            MessageBox.Show(
                details,
                "Account Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            Account account = GetSelectedAccount();

            if (account == null)
            {
                MessageBox.Show(
                    "Please select an account first.",
                    "Account Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.Equals(
                account.AccountType,
                "SuperAdmin",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "The Super Admin account cannot be deactivated here.",
                    "Protected Account",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            bool newStatus = !account.IsActive;

            string action = newStatus
                ? "reactivate"
                : "deactivate";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to {action} this account?\n\n" +
                $"Name: {account.FullName}\n" +
                $"Username: {account.Username}",
                "Confirm Account Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                bool updated = AccountStore.SetAccountActiveStatus(
                    account.Id,
                    newStatus
                );

                if (!updated)
                {
                    MessageBox.Show(
                        "The account status could not be changed. " +
                        "Please verify the account and try again.",
                        "Account Management",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    LoadAccounts();
                    return;
                }

                LoadAccounts();

                MessageBox.Show(
                    "Account successfully " +
                    (newStatus ? "reactivated." : "deactivated."),
                    "Account Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update the account status.\n\n" +
                    ex.Message,
                    "Account Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
