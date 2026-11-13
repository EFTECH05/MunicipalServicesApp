
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewCitizensForm : Form
    {
        private Button btnDeactivateCitizen;
        private Button btnReactivateCitizen;
        private DataGridViewTextBoxColumn statusColumn;

        public ViewCitizensForm()
        {
            InitializeComponent();

            ConfigureCitizenGrid();
            AddAccountStatusButtons();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void ViewCitizensForm_Load(
            object sender,
            EventArgs e)
        {
            LoadCitizens();
        }

        // ==========================================
        // CONFIGURE CITIZEN GRID
        // ==========================================
        private void ConfigureCitizenGrid()
        {
            // Ensure the grid supports selecting a citizen
            // by clicking any cell in their row.
            dgvCitizens.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCitizens.MultiSelect = false;

            // Add the Status column if it does not exist.
            statusColumn = null;

            foreach (DataGridViewColumn column in dgvCitizens.Columns)
            {
                if (column.Name == "colAccountStatus")
                {
                    statusColumn = column as DataGridViewTextBoxColumn;
                    break;
                }
            }

            if (statusColumn == null)
            {
                statusColumn = new DataGridViewTextBoxColumn
                {
                    Name = "colAccountStatus",
                    HeaderText = "Account Status",
                    ReadOnly = true,
                    Width = 120
                };

                dgvCitizens.Columns.Add(statusColumn);
            }
        }

        // ==========================================
        // ADD DEACTIVATE / REACTIVATE BUTTONS
        // ==========================================
        private void AddAccountStatusButtons()
        {
            btnDeactivateCitizen = new Button
            {
                Name = "btnDeactivateCitizen",
                Text = "Deactivate Citizen",
                Size = new Size(150, 35),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btnDeactivateCitizen.FlatAppearance.BorderSize = 0;
            btnDeactivateCitizen.Click +=
                btnDeactivateCitizen_Click;

            btnReactivateCitizen = new Button
            {
                Name = "btnReactivateCitizen",
                Text = "Reactivate Citizen",
                Size = new Size(150, 35),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btnReactivateCitizen.FlatAppearance.BorderSize = 0;
            btnReactivateCitizen.Click +=
                btnReactivateCitizen_Click;

            // Add the buttons to the form.
            // Position them near the bottom without replacing
            // existing controls.
            Controls.Add(btnDeactivateCitizen);
            Controls.Add(btnReactivateCitizen);

            btnDeactivateCitizen.Anchor =
                AnchorStyles.Bottom | AnchorStyles.Right;

            btnReactivateCitizen.Anchor =
                AnchorStyles.Bottom | AnchorStyles.Right;

            PositionStatusButtons();

            // Keep the buttons visible above other controls.
            btnDeactivateCitizen.BringToFront();
            btnReactivateCitizen.BringToFront();

            // Reposition if the form is resized.
            Resize += (sender, e) => PositionStatusButtons();
        }

        private void PositionStatusButtons()
        {
            if (btnDeactivateCitizen == null ||
                btnReactivateCitizen == null)
            {
                return;
            }

            int bottomMargin = 20;
            int rightMargin = 20;
            int buttonGap = 10;

            btnReactivateCitizen.Location = new Point(
                ClientSize.Width - rightMargin -
                    btnReactivateCitizen.Width,
                ClientSize.Height - bottomMargin -
                    btnReactivateCitizen.Height
            );

            btnDeactivateCitizen.Location = new Point(
                btnReactivateCitizen.Left - buttonGap -
                    btnDeactivateCitizen.Width,
                btnReactivateCitizen.Top
            );
        }

        // ==========================================
        // LOAD CITIZENS FROM DATABASE
        // ==========================================
        private void LoadCitizens()
        {
            try
            {
                AccountStore.LoadAccounts();

                dgvCitizens.Rows.Clear();

                int citizenCount = 0;

                foreach (Account account in AccountStore.Accounts)
                {
                    if (account.AccountType != null &&
                        account.AccountType.Equals(
                            "Citizen",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        int rowIndex = dgvCitizens.Rows.Add(
                            account.Id,
                            account.FullName,
                            account.Email,
                            account.Username,
                            account.IsActive ? "Active" : "Deactivated"
                        );

                        DataGridViewRow row =
                            dgvCitizens.Rows[rowIndex];

                        row.Tag = account.Id;

                        if (!account.IsActive)
                        {
                            row.DefaultCellStyle.ForeColor =
                                Color.Firebrick;
                        }

                        citizenCount++;
                    }
                }

                lblCitizenCount.Text =
                    "Total Citizens: " + citizenCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The citizens could not be loaded.\n\n" +
                    "Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // GET SELECTED CITIZEN
        // ==========================================
        private Account GetSelectedCitizen()
        {
            if (dgvCitizens.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a citizen first.",
                    "No Citizen Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            DataGridViewRow row = dgvCitizens.SelectedRows[0];

            if (row.IsNewRow || row.Tag == null)
            {
                MessageBox.Show(
                    "Please select a valid citizen.",
                    "Invalid Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            int citizenId;

            if (!int.TryParse(row.Tag.ToString(), out citizenId))
            {
                MessageBox.Show(
                    "The selected citizen ID is invalid.",
                    "Invalid Citizen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return null;
            }

            foreach (Account account in AccountStore.Accounts)
            {
                if (account.Id == citizenId &&
                    account.AccountType != null &&
                    account.AccountType.Equals(
                        "Citizen",
                        StringComparison.OrdinalIgnoreCase))
                {
                    return account;
                }
            }

            MessageBox.Show(
                "The selected citizen could not be found. " +
                "Please refresh the list and try again.",
                "Citizen Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return null;
        }

        // ==========================================
        // DEACTIVATE CITIZEN
        // ==========================================
        private void btnDeactivateCitizen_Click(
            object sender,
            EventArgs e)
        {
            Account citizen = GetSelectedCitizen();

            if (citizen == null)
            {
                return;
            }

            if (!citizen.IsActive)
            {
                MessageBox.Show(
                    "This citizen account is already deactivated.",
                    "Account Already Deactivated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to deactivate this citizen?\n\n" +
                "Name: " + citizen.FullName + "\n" +
                "Username: " + citizen.Username + "\n\n" +
                "The citizen will no longer be able to log in.",
                "Confirm Deactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool success = AccountStore.SetAccountActiveStatus(
                    citizen.Id,
                    false
                );

                if (success)
                {
                    LoadCitizens();

                    MessageBox.Show(
                        "The citizen account has been deactivated.\n\n" +
                        "The citizen will be prevented from logging in.",
                        "Account Deactivated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "The account could not be deactivated.\n\n" +
                        "Please refresh the list and try again.",
                        "Deactivation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while deactivating the account.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // REACTIVATE CITIZEN
        // ==========================================
        private void btnReactivateCitizen_Click(
            object sender,
            EventArgs e)
        {
            Account citizen = GetSelectedCitizen();

            if (citizen == null)
            {
                return;
            }

            if (citizen.IsActive)
            {
                MessageBox.Show(
                    "This citizen account is already active.",
                    "Account Already Active",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to reactivate this citizen?\n\n" +
                "Name: " + citizen.FullName + "\n" +
                "Username: " + citizen.Username + "\n\n" +
                "The citizen will be allowed to log in again.",
                "Confirm Reactivation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool success = AccountStore.SetAccountActiveStatus(
                    citizen.Id,
                    true
                );

                if (success)
                {
                    LoadCitizens();

                    MessageBox.Show(
                        "The citizen account has been reactivated.\n\n" +
                        "The citizen can now log in again.",
                        "Account Reactivated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "The account could not be reactivated.\n\n" +
                        "Please refresh the list and try again.",
                        "Reactivation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while reactivating the account.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // REFRESH CITIZENS
        // ==========================================
        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadCitizens();

            MessageBox.Show(
                "The citizen list has been refreshed.",
                "Refresh Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // VIEW CITIZEN DETAILS
        // ==========================================
        private void btnViewDetails_Click(
            object sender,
            EventArgs e)
        {
            Account citizen = GetSelectedCitizen();

            if (citizen == null)
            {
                return;
            }

            string details =
                "Citizen ID: " + citizen.Id +
                "\n\n" +
                "Full Name: " + citizen.FullName +
                "\n\n" +
                "Email: " + citizen.Email +
                "\n\n" +
                "Username: " + citizen.Username +
                "\n\n" +
                "Account Type: Citizen" +
                "\n\n" +
                "Account Status: " +
                (citizen.IsActive ? "Active" : "Deactivated");

            MessageBox.Show(
                details,
                "Citizen Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // BACK TO SUPER ADMIN DASHBOARD
        // ==========================================
        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        // ==========================================
        // EXISTING PANEL PAINT EVENT
        // ==========================================
        private void pnlScroll_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}
