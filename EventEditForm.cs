

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class EventEditForm : Form
    {
        private readonly Event originalEvent;

        private TextBox txtTitle;
        private TextBox txtCategory;
        private TextBox txtLocation;
        private TextBox txtDescription;
        private DateTimePicker dtpEventDate;
        private ComboBox cmbEventType;

        public Event EditedEvent { get; private set; }

        public EventEditForm(Event selectedEvent)
        {
            if (selectedEvent == null)
                throw new ArgumentNullException(nameof(selectedEvent));

            originalEvent = selectedEvent;

            InitializeComponent();

            Text = "Edit Event or Announcement";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(575, 480);
            MinimumSize = new Size(591, 519);
            MaximumSize = new Size(591, 519);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 9F);

            BuildInterface();
            PopulateFields();
        }

        private void EventEditForm_Load(object sender, EventArgs e)
        {
            // The event fields are populated by the constructor.
        }

        private void BuildInterface()
        {
            Label lblHeading = new Label
            {
                Text = "Edit Event or Announcement",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 45, 75),
                Location = new Point(25, 20),
                AutoSize = true
            };

            Controls.Add(lblHeading);

            int labelX = 25;
            int inputX = 165;
            int inputWidth = 375;
            int top = 75;
            int gap = 55;

            AddLabel("Title", labelX, top);

            txtTitle = new TextBox
            {
                Location = new Point(inputX, top - 4),
                Size = new Size(inputWidth, 28)
            };
            Controls.Add(txtTitle);

            top += gap;
            AddLabel("Category", labelX, top);

            txtCategory = new TextBox
            {
                Location = new Point(inputX, top - 4),
                Size = new Size(inputWidth, 28)
            };
            Controls.Add(txtCategory);

            top += gap;
            AddLabel("Date and time", labelX, top);

            dtpEventDate = new DateTimePicker
            {
                Location = new Point(inputX, top - 4),
                Size = new Size(inputWidth, 28),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd MMMM yyyy HH:mm",
                ShowUpDown = false
            };
            Controls.Add(dtpEventDate);

            top += gap;
            AddLabel("Location", labelX, top);

            txtLocation = new TextBox
            {
                Location = new Point(inputX, top - 4),
                Size = new Size(inputWidth, 28)
            };
            Controls.Add(txtLocation);

            top += gap;
            AddLabel("Type", labelX, top);

            cmbEventType = new ComboBox
            {
                Location = new Point(inputX, top - 4),
                Size = new Size(inputWidth, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbEventType.Items.Add("Event");
            cmbEventType.Items.Add("Announcement");

            Controls.Add(cmbEventType);

            top += gap;
            AddLabel("Description", labelX, top);

            txtDescription = new TextBox
            {
                Location = new Point(inputX, top - 4),
                Size = new Size(inputWidth, 65),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(txtDescription);

            Button btnSave = new Button
            {
                Text = "SAVE CHANGES",
                Location = new Point(285, 425),
                Size = new Size(125, 35),
                BackColor = Color.FromArgb(0, 103, 71),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            Button btnCancel = new Button
            {
                Text = "CANCEL",
                Location = new Point(420, 425),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(230, 233, 238),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };

            btnSave.Click += btnSave_Click;

            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void AddLabel(string text, int x, int y)
        {
            Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            });
        }

        private void PopulateFields()
        {
            txtTitle.Text = originalEvent.Title ?? string.Empty;
            txtCategory.Text = originalEvent.Category ?? string.Empty;
            txtLocation.Text = originalEvent.Location ?? string.Empty;
            txtDescription.Text = originalEvent.Description ?? string.Empty;

            DateTime date = originalEvent.EventDate;

            if (date < dtpEventDate.MinDate)
                date = dtpEventDate.MinDate;

            if (date > dtpEventDate.MaxDate)
                date = dtpEventDate.MaxDate;

            dtpEventDate.Value = date;

            string type = originalEvent.EventType ?? "Event";

            cmbEventType.SelectedItem =
                string.Equals(
                    type,
                    "Announcement",
                    StringComparison.OrdinalIgnoreCase)
                ? "Announcement"
                : "Event";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                ShowValidationMessage(
                    "Please enter the event title.", txtTitle);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                ShowValidationMessage(
                    "Please enter the event category.", txtCategory);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                ShowValidationMessage(
                    "Please enter the event location.", txtLocation);
                return;
            }

            if (cmbEventType.SelectedItem == null)
            {
                ShowValidationMessage(
                    "Please select Event or Announcement.",
                    cmbEventType);
                return;
            }

            EditedEvent = new Event
            {
                Id = originalEvent.Id,
                Title = txtTitle.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                EventDate = dtpEventDate.Value,
                Location = txtLocation.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                EventType = cmbEventType.SelectedItem.ToString(),
                CreatedAt = originalEvent.CreatedAt
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowValidationMessage(string message, Control control)
        {
            MessageBox.Show(
                message,
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control.Focus();
        }
    }
}
