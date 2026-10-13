
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class CreateEventForm : Form
    {
        private readonly string connectionString =
            @"Data Source=FRANKLIN\SQLEXPRESS01;" +
            @"Initial Catalog=MunicipalServicesDB;" +
            @"Integrated Security=True";

        private TextBox txtTitle;
        private ComboBox cmbCategory;
        private DateTimePicker dtpEventDate;
        private DateTimePicker dtpEventTime;
        private TextBox txtLocation;
        private ComboBox cmbEventType;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnClear;
        private Button btnCancel;
        private Label lblStatus;

        public CreateEventForm()
        {
            InitializeComponent();
            BuildInterface();
        }

        private void BuildInterface()
        {
            Text = "Create Municipal Event";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(760, 720);
            MinimumSize = new Size(700, 650);
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 10F);
            AutoScroll = true;

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(20, 55, 100)
            };

            Label lblTitle = new Label
            {
                Text = "Create Event / Announcement",
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 18),
                AutoSize = true
            };

            Label lblSubtitle = new Label
            {
                Text = "Publish information for municipal residents.",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(28, 59),
                AutoSize = true
            };

            header.Controls.Add(lblTitle);
            header.Controls.Add(lblSubtitle);
            Controls.Add(header);

            Panel content = new Panel
            {
                Location = new Point(25, 120),
                Size = new Size(690, 510),
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Left |
                         AnchorStyles.Right,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Controls.Add(content);

            int leftLabel = 22;
            int inputLeft = 190;
            int inputWidth = 455;
            int y = 22;
            int rowGap = 48;

            AddLabel(content, "Event title:", leftLabel, y);
            txtTitle = AddTextBox(content, inputLeft, y - 4,
                inputWidth, 28);
            y += rowGap;

            AddLabel(content, "Category:", leftLabel, y);
            cmbCategory = AddComboBox(content, inputLeft, y - 4,
                inputWidth, new string[]
                {
                    "Community",
                    "Education",
                    "Environment",
                    "Health",
                    "Public Safety",
                    "Transport",
                    "Water and Electricity",
                    "Other"
                });
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
            y += rowGap;

            AddLabel(content, "Event date:", leftLabel, y);
            dtpEventDate = new DateTimePicker
            {
                Location = new Point(inputLeft, y - 4),
                Width = 220,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd MMMM yyyy",
                MinDate = DateTime.Today
            };
            content.Controls.Add(dtpEventDate);
            y += rowGap;

            AddLabel(content, "Event time:", leftLabel, y);
            dtpEventTime = new DateTimePicker
            {
                Location = new Point(inputLeft, y - 4),
                Width = 220,
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };
            content.Controls.Add(dtpEventTime);
            y += rowGap;

            AddLabel(content, "Location:", leftLabel, y);
            txtLocation = AddTextBox(content, inputLeft, y - 4,
                inputWidth, 28);
            y += rowGap;

            AddLabel(content, "Type:", leftLabel, y);
            cmbEventType = AddComboBox(content, inputLeft, y - 4,
                inputWidth, new string[]
                {
                    "Event",
                    "Announcement"
                });
            cmbEventType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEventType.SelectedIndex = 0;
            y += rowGap;

            AddLabel(content, "Description:", leftLabel, y);
            txtDescription = new TextBox
            {
                Location = new Point(inputLeft, y - 4),
                Size = new Size(inputWidth, 95),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                MaxLength = 1000
            };
            content.Controls.Add(txtDescription);

            btnSave = new Button
            {
                Text = "PUBLISH",
                Location = new Point(190, 425),
                Size = new Size(140, 38),
                BackColor = Color.FromArgb(20, 110, 105),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;
            content.Controls.Add(btnSave);

            btnClear = new Button
            {
                Text = "CLEAR",
                Location = new Point(345, 425),
                Size = new Size(120, 38),
                BackColor = Color.FromArgb(235, 239, 244),
                ForeColor = Color.FromArgb(35, 45, 60),
                FlatStyle = FlatStyle.Flat
            };
            btnClear.Click += btnClear_Click;
            content.Controls.Add(btnClear);

            btnCancel = new Button
            {
                Text = "CLOSE",
                Location = new Point(480, 425),
                Size = new Size(120, 38),
                BackColor = Color.FromArgb(190, 55, 55),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.Click += (sender, e) => Close();
            content.Controls.Add(btnCancel);

            lblStatus = new Label
            {
                Location = new Point(25, 640),
                Size = new Size(680, 30),
                ForeColor = Color.FromArgb(55, 105, 80),
                Text = "Complete the fields and publish your event.",
                AutoSize = false
            };
            Controls.Add(lblStatus);
        }

        private void AddLabel(
            Control parent,
            string text,
            int x,
            int y)
        {
            Label label = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(155, 28),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(35, 45, 60)
            };

            parent.Controls.Add(label);
        }

        private TextBox AddTextBox(
            Control parent,
            int x,
            int y,
            int width,
            int height)
        {
            TextBox textBox = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                MaxLength = 200
            };

            parent.Controls.Add(textBox);
            return textBox;
        }

        private ComboBox AddComboBox(
            Control parent,
            int x,
            int y,
            int width,
            string[] options)
        {
            ComboBox comboBox = new ComboBox
            {
                Location = new Point(x, y),
                Width = width,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            comboBox.Items.AddRange(options);
            comboBox.SelectedIndex = 0;

            parent.Controls.Add(comboBox);
            return comboBox;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string category = cmbCategory.Text.Trim();
            string location = txtLocation.Text.Trim();
            string description = txtDescription.Text.Trim();
            string eventType = cmbEventType.Text;

            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(category) ||
                string.IsNullOrWhiteSpace(location) ||
                string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(
                    "Please complete all fields before publishing.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (title.Length > 150 ||
                category.Length > 80 ||
                location.Length > 200 ||
                description.Length > 1000)
            {
                MessageBox.Show(
                    "One or more fields exceed the database column limits.",
                    "Invalid Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DateTime eventDate = dtpEventDate.Value.Date
                .Add(dtpEventTime.Value.TimeOfDay);

            if (eventDate < DateTime.Now)
            {
                MessageBox.Show(
                    "Please select a future date and time.",
                    "Invalid Event Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query =
                        @"INSERT INTO dbo.Events
                          (Title, Category, EventDate, Location,
                           Description, EventType)
                          VALUES
                          (@Title, @Category, @EventDate, @Location,
                           @Description, @EventType);";

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(
                            "@Title", SqlDbType.NVarChar, 150).Value = title;

                        command.Parameters.Add(
                            "@Category", SqlDbType.NVarChar, 80).Value = category;

                        command.Parameters.Add(
                            "@EventDate", SqlDbType.DateTime).Value = eventDate;

                        command.Parameters.Add(
                            "@Location", SqlDbType.NVarChar, 200).Value = location;

                        command.Parameters.Add(
                            "@Description", SqlDbType.NVarChar, 1000).Value = description;

                        command.Parameters.Add(
                            "@EventType", SqlDbType.NVarChar, 30).Value = eventType;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "The event or announcement has been published successfully.",
                    "Published",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                lblStatus.Text = "Event published successfully.";
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "The event could not be saved to the database.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            lblStatus.Text = "Fields cleared.";
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            cmbCategory.SelectedIndex = 0;
            dtpEventDate.Value = DateTime.Today;
            dtpEventTime.Value = DateTime.Now;
            txtLocation.Clear();
            cmbEventType.SelectedIndex = 0;
            txtDescription.Clear();
            txtTitle.Focus();
        }
    }
}
