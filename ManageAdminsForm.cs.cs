
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    internal class ManageAdminsForm : Form
    {
        private DataGridView dgvAdmins;
        private Label lblAdminCount;

        public ManageAdminsForm()
        {
            InitializeForm();
            LoadAdmins();
        }

        private void InitializeForm()
        {
            Text = "Manage Administrators";
            Size = new Size(900, 500);
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(700, 400);
            BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "MANAGE ADMINISTRATORS",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(20, 20),
                AutoSize = true
            };

            lblAdminCount = new Label
            {
                Text = "Administrators: 0",
                Font = new Font("Segoe UI", 10),
                Location = new Point(25, 65),
                AutoSize = true
            };

            dgvAdmins = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(840, 280),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                         | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };

            dgvAdmins.Columns.Add("Id", "ID");
            dgvAdmins.Columns.Add("FullName", "Full Name");
            dgvAdmins.Columns.Add("Email", "Email");
            dgvAdmins.Columns.Add("Username", "Username");
            dgvAdmins.Columns.Add("Status", "Account Status");

            Button btnRefresh = new Button
            {
                Text = "REFRESH",
                Location = new Point(20, 405),
                Size = new Size(110, 35),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnRefresh.Click += (s, e) => LoadAdmins();

            Button btnToggleStatus = new Button
            {
                Text = "ACTIVATE / DEACTIVATE",
                Location = new Point(145, 405),
                Size = new Size(200, 35),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnToggleStatus.Click += BtnToggleStatus_Click;

            Button btnClose = new Button
            {
                Text = "CLOSE",
                Location = new Point(750, 405),
                Size = new Size(110, 35),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnClose.Click += (s, e) => Close();

            Controls.Add(lblTitle);
            Controls.Add(lblAdminCount);
            Controls.Add(dgvAdmins);
            Controls.Add(btnRefresh);
            Controls.Add(btnToggleStatus);
            Controls.Add(btnClose);
        }

        private void LoadAdmins()
        {
            try
            {
                AccountStore.LoadAccounts();

                dgvAdmins.Rows.Clear();

                var admins = AccountStore.Accounts
                    .Where(a => string.Equals(
                        a.AccountType,
                        "Admin",
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();

                foreach (var admin in admins)
                {
                    dgvAdmins.Rows.Add(
                        admin.Id,
                        admin.FullName,
                        admin.Email,
                        admin.Username,
                        admin.IsActive ? "Active" : "Inactive"
                    );
                }

                lblAdminCount.Text =
                    "Administrators: " + admins.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load administrator accounts.\n\n"
                    + ex.Message,
                    "Manage Administrators",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an administrator first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int adminId = Convert.ToInt32(
                dgvAdmins.CurrentRow.Cells["Id"].Value);

            string name = Convert.ToString(
                dgvAdmins.CurrentRow.Cells["FullName"].Value);

            string status = Convert.ToString(
                dgvAdmins.CurrentRow.Cells["Status"].Value);

            bool activate = !string.Equals(
                status,
                "Active",
                StringComparison.OrdinalIgnoreCase);

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to " +
                (activate ? "activate" : "deactivate") +
                " this administrator?\n\n" + name,
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                bool updated =
                    AccountStore.SetAccountActiveStatus(
                        adminId, activate);

                if (updated)
                {
                    MessageBox.Show(
                        "Administrator account updated successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadAdmins();
                }
                else
                {
                    MessageBox.Show(
                        "The account could not be updated.",
                        "Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating account:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
