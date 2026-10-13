
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        private EventManager eventManager;
        private readonly bool administratorMode;

        private ComboBox cmbCategory;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private CheckBox chkUseDateRange;
        private Button btnSearch;
        private Button btnReset;
        private Button btnRefresh;

        private Button btnAdminCreateEvent;
        private Button btnEditEvent;
        private Button btnDeleteEvent;

        private DataGridView dgvEvents;
        private ListBox lstRecommendations;
        private ListBox lstRecentSearches;

        private Label lblStatus;
        private Label lblEventCount;

        // Normal citizen mode.
        public LocalEventsForm() : this(false)
        {
        }

        // Administrator mode.
        public LocalEventsForm(bool isAdministrator)
        {
            InitializeComponent();

            administratorMode = isAdministrator;
            eventManager = new EventManager();

            // Ensure the Load event is registered only once.
            Load -= LocalEventsForm_Load;
            Load += LocalEventsForm_Load;

            BuildEventsInterface();
        }

        private void BuildEventsInterface()
        {
            SuspendLayout();

            Text = administratorMode
                ? "Manage Local Events and Announcements"
                : "Local Events and Announcements";

            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1150, 750);
            MinimumSize = new Size(900, 600);
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 85,
                BackColor = Color.FromArgb(24, 45, 75)
            };

            Label lblTitle = new Label
            {
                Text = administratorMode
                    ? "Manage Events and Announcements"
                    : "Local Events and Announcements",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                Location = new Point(22, 12),
                AutoSize = true
            };

            Label lblSubtitle = new Label
            {
                Text = administratorMode
                    ? "Create, edit, delete and review community events."
                    : "Discover upcoming community events and public announcements.",
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(25, 49),
                AutoSize = true
            };

            header.Controls.Add(lblTitle);
            header.Controls.Add(lblSubtitle);

            Panel filters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 155,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            Label lblCategory = new Label
            {
                Text = "Category",
                Location = new Point(20, 15),
                AutoSize = true
            };

            cmbCategory = new ComboBox
            {
                Location = new Point(20, 38),
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            chkUseDateRange = new CheckBox
            {
                Text = "Filter by date range",
                Location = new Point(265, 15),
                AutoSize = true
            };

            Label lblStart = new Label
            {
                Text = "Start date",
                Location = new Point(265, 43),
                AutoSize = true
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(265, 65),
                Width = 180,
                Format = DateTimePickerFormat.Short,
                Enabled = false
            };

            Label lblEnd = new Label
            {
                Text = "End date",
                Location = new Point(465, 43),
                AutoSize = true
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(465, 65),
                Width = 180,
                Format = DateTimePickerFormat.Short,
                Enabled = false
            };

            btnSearch = new Button
            {
                Text = "Search Events",
                Location = new Point(670, 36),
                Size = new Size(130, 38),
                BackColor = Color.FromArgb(35, 105, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnReset = new Button
            {
                Text = "Reset",
                Location = new Point(810, 36),
                Size = new Size(90, 38),
                BackColor = Color.FromArgb(230, 233, 238),
                FlatStyle = FlatStyle.Flat
            };

            btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(910, 36),
                Size = new Size(90, 38),
                BackColor = Color.FromArgb(230, 233, 238),
                FlatStyle = FlatStyle.Flat
            };

            btnSearch.Click += btnSearch_Click;
            btnReset.Click += btnReset_Click;
            btnRefresh.Click += btnRefresh_Click;

            chkUseDateRange.CheckedChanged +=
                chkUseDateRange_CheckedChanged;

            filters.Controls.Add(lblCategory);
            filters.Controls.Add(cmbCategory);
            filters.Controls.Add(chkUseDateRange);
            filters.Controls.Add(lblStart);
            filters.Controls.Add(dtpStartDate);
            filters.Controls.Add(lblEnd);
            filters.Controls.Add(dtpEndDate);
            filters.Controls.Add(btnSearch);
            filters.Controls.Add(btnReset);
            filters.Controls.Add(btnRefresh);

            // Only show event-management buttons to administrators.
            btnAdminCreateEvent = new Button
            {
                Text = "CREATE EVENT",
                Location = new Point(20, 105),
                Size = new Size(145, 32),
                BackColor = Color.FromArgb(0, 103, 71),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Visible = administratorMode
            };

            btnEditEvent = new Button
            {
                Text = "EDIT SELECTED",
                Location = new Point(175, 105),
                Size = new Size(145, 32),
                BackColor = Color.FromArgb(35, 105, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Visible = administratorMode
            };

            btnDeleteEvent = new Button
            {
                Text = "DELETE SELECTED",
                Location = new Point(330, 105),
                Size = new Size(145, 32),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Visible = administratorMode
            };

            btnAdminCreateEvent.Click += btnAdminCreateEvent_Click;
            btnEditEvent.Click += btnEditEvent_Click;
            btnDeleteEvent.Click += btnDeleteEvent_Click;

            filters.Controls.Add(btnAdminCreateEvent);
            filters.Controls.Add(btnEditEvent);
            filters.Controls.Add(btnDeleteEvent);

            Panel content = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(245, 247, 250)
            };

            Panel eventsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            Label lblEventsTitle = new Label
            {
                Text = "Available Events",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(12, 10),
                AutoSize = true
            };

            lblEventCount = new Label
            {
                Text = "Events: 0",
                ForeColor = Color.DimGray,
                Location = new Point(15, 40),
                AutoSize = true
            };

            dgvEvents = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(5)
            };

            dgvEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                FillWeight = 35
            });

            dgvEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Event",
                DataPropertyName = "Title",
                FillWeight = 150
            });

            dgvEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category",
                FillWeight = 80
            });

            dgvEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EventDate",
                HeaderText = "Date",
                DataPropertyName = "EventDate",
                FillWeight = 85,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd MMM yyyy HH:mm"
                }
            });

            dgvEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Location",
                HeaderText = "Location",
                DataPropertyName = "Location",
                FillWeight = 100
            });

            dgvEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EventType",
                HeaderText = "Type",
                DataPropertyName = "EventType",
                FillWeight = 65
            });

            dgvEvents.CellDoubleClick += dgvEvents_CellDoubleClick;

            eventsPanel.Controls.Add(dgvEvents);
            eventsPanel.Controls.Add(lblEventCount);
            eventsPanel.Controls.Add(lblEventsTitle);

            lblEventsTitle.BringToFront();
            lblEventCount.BringToFront();

            Panel sidePanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 280,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(10, 0, 0, 0)
            };

            GroupBox recommendationsGroup = new GroupBox
            {
                Text = "Recommended for You",
                Dock = DockStyle.Top,
                Height = 260,
                BackColor = Color.White,
                Padding = new Padding(8)
            };

            lstRecommendations = new ListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                IntegralHeight = false
            };

            lstRecommendations.DoubleClick +=
                lstRecommendations_DoubleClick;

            recommendationsGroup.Controls.Add(lstRecommendations);

            GroupBox historyGroup = new GroupBox
            {
                Text = "Recent Searches",
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(8)
            };

            lstRecentSearches = new ListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                IntegralHeight = false
            };

            historyGroup.Controls.Add(lstRecentSearches);

            sidePanel.Controls.Add(historyGroup);
            sidePanel.Controls.Add(recommendationsGroup);
            recommendationsGroup.BringToFront();

            content.Controls.Add(eventsPanel);
            content.Controls.Add(sidePanel);

            Panel footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 35,
                BackColor = Color.White
            };

            lblStatus = new Label
            {
                Text = "Ready",
                Location = new Point(15, 9),
                AutoSize = true,
                ForeColor = Color.DimGray
            };

            footer.Controls.Add(lblStatus);

            Controls.Add(content);
            Controls.Add(filters);
            Controls.Add(header);
            Controls.Add(footer);

            ResumeLayout(true);
        }

        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            LoadEventsFromDatabase();
        }

        private void LoadEventsFromDatabase()
        {
            try
            {
                eventManager.LoadEvents();

                PopulateCategories();

                DisplayEvents(
                    eventManager.SearchEvents(
                        "All Categories",
                        null,
                        null));

                LoadRecommendations();
                LoadRecentSearches();

                lblStatus.Text = "Events loaded successfully.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Could not load events.";

                MessageBox.Show(
                    "Unable to load events from the database.\n\n" +
                    "Please check your SQL Server connection and the Events table.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PopulateCategories()
        {
            string selectedCategory = "All Categories";

            if (cmbCategory.SelectedItem != null)
            {
                selectedCategory = cmbCategory.SelectedItem.ToString();
            }

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            List<Event> allEvents =
                eventManager.SearchEvents("All Categories", null, null);

            foreach (string category in allEvents
                .Where(ev => !string.IsNullOrWhiteSpace(ev.Category))
                .Select(ev => ev.Category)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(category => category))
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedItem =
                cmbCategory.Items.Contains(selectedCategory)
                    ? selectedCategory
                    : "All Categories";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? startDate = null;
                DateTime? endDate = null;

                if (chkUseDateRange.Checked)
                {
                    if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
                    {
                        MessageBox.Show(
                            "The end date cannot be earlier than the start date.",
                            "Invalid Date Range",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    startDate = dtpStartDate.Value.Date;
                    endDate = dtpEndDate.Value.Date
                        .AddDays(1).AddTicks(-1);
                }

                string category = cmbCategory.SelectedItem == null
                    ? "All Categories"
                    : cmbCategory.SelectedItem.ToString();

                List<Event> results =
                    eventManager.SearchEvents(category, startDate, endDate);

                DisplayEvents(results);
                LoadRecommendations();
                LoadRecentSearches();

                lblStatus.Text = "Search completed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search events.\n\n" + ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedItem = "All Categories";
            chkUseDateRange.Checked = false;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(30);

            try
            {
                DisplayEvents(
                    eventManager.SearchEvents("All Categories", null, null));

                LoadRecommendations();
                LoadRecentSearches();
                lblStatus.Text = "Filters have been reset.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to reset the event list.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEventsFromDatabase();
        }

        private void chkUseDateRange_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = chkUseDateRange.Checked;
            dtpEndDate.Enabled = chkUseDateRange.Checked;
        }

        private void DisplayEvents(List<Event> events)
        {
            dgvEvents.DataSource = null;
            dgvEvents.DataSource = events
                .OrderBy(ev => ev.EventDate)
                .ToList();

            lblEventCount.Text = "Events: " + events.Count;

            if (events.Count == 0)
            {
                lblStatus.Text =
                    "No events matched your search. Try another category or date range.";
            }
        }

        private void LoadRecommendations()
        {
            lstRecommendations.Items.Clear();

            List<Event> recommendations =
                eventManager.GetRecommendedEvents(10);

            foreach (Event ev in recommendations)
            {
                lstRecommendations.Items.Add(
                    ev.EventDate.ToString("dd MMM") + " - " +
                    ev.Title + " (" + ev.Category + ")");
            }

            if (recommendations.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "No upcoming recommendations yet.");
            }
        }

        private void LoadRecentSearches()
        {
            lstRecentSearches.Items.Clear();

            List<string> searches = eventManager.GetRecentSearches(10);

            foreach (string search in searches)
            {
                lstRecentSearches.Items.Add(search);
            }

            if (searches.Count == 0)
            {
                lstRecentSearches.Items.Add(
                    "Your searches will appear here.");
            }
        }

        private void dgvEvents_CellDoubleClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEvents.Rows.Count)
                return;

            Event selectedEvent =
                dgvEvents.Rows[e.RowIndex].DataBoundItem as Event;

            if (selectedEvent != null)
                ShowEventDetails(selectedEvent);
        }

        private void lstRecommendations_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = lstRecommendations.SelectedIndex;

            if (selectedIndex < 0)
                return;

            List<Event> recommendations =
                eventManager.GetRecommendedEvents(10);

            if (selectedIndex < recommendations.Count)
                ShowEventDetails(recommendations[selectedIndex]);
        }

        private void ShowEventDetails(Event ev)
        {
            MessageBox.Show(
                "Title: " + ev.Title + "\n\n" +
                "Category: " + ev.Category + "\n" +
                "Type: " + ev.EventType + "\n" +
                "Date: " + ev.EventDate.ToString("dd MMMM yyyy, HH:mm") + "\n" +
                "Location: " + ev.Location + "\n\n" +
                "Description:\n" + ev.Description,
                "Event Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private Event GetSelectedEvent()
        {
            if (dgvEvents.CurrentRow == null)
                return null;

            return dgvEvents.CurrentRow.DataBoundItem as Event;
        }

        private void btnAdminCreateEvent_Click(object sender, EventArgs e)
        {
            if (!administratorMode)
                return;

            using (CreateEventForm form = new CreateEventForm())
            {
                form.ShowDialog(this);
            }

            LoadEventsFromDatabase();
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (!administratorMode)
                return;

            Event selectedEvent = GetSelectedEvent();

            if (selectedEvent == null)
            {
                MessageBox.Show(
                    "Please select an event to edit.",
                    "No Event Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (EventEditForm form = new EventEditForm(selectedEvent))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        eventManager.UpdateEvent(form.EditedEvent);
                        LoadEventsFromDatabase();

                        lblStatus.Text = "Event updated successfully.";

                        MessageBox.Show(
                            "The event was updated successfully.",
                            "Update Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Unable to update the event.\n\n" + ex.Message,
                            "Update Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (!administratorMode)
                return;

            Event selectedEvent = GetSelectedEvent();

            if (selectedEvent == null)
            {
                MessageBox.Show(
                    "Please select an event to delete.",
                    "No Event Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this event?\n\n" +
                selectedEvent.Title + "\n" +
                selectedEvent.EventDate.ToString("dd MMMM yyyy, HH:mm") +
                "\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                eventManager.DeleteEvent(selectedEvent.Id);
                LoadEventsFromDatabase();

                lblStatus.Text = "Event deleted successfully.";

                MessageBox.Show(
                    "The event was deleted successfully.",
                    "Delete Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete the event.\n\n" + ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
