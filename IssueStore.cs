
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MunicipalServicesApp
{
    public static class IssueStore
    {
        // ==========================================
        // IN-MEMORY LIST OF ISSUES
        // ==========================================

        public static List<Issue> Issues { get; private set; }

        // ==========================================
        // DATABASE CONNECTION
        // ==========================================

        private static string connectionString =
            @"Data Source=FRANKLIN\SQLEXPRESS01;" +
            @"Initial Catalog=MunicipalServicesDB;" +
            @"Integrated Security=True";

        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        static IssueStore()
        {
            Issues = new List<Issue>();
        }

        // ==========================================
        // LOAD ISSUES FROM DATABASE
        // ==========================================

        public static void LoadIssues()
        {
            Issues.Clear();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "SELECT Id, Location, Category, Description, " +
                    "Attachment, DateReported, AccountId, Status, " +
                    "Priority, Department, LastUpdated " +
                    "FROM dbo.Issues " +
                    "ORDER BY DateReported DESC";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Issue issue = new Issue
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Location = reader["Location"].ToString(),
                                Category = reader["Category"].ToString(),
                                Description = reader["Description"].ToString(),

                                Attachment =
                                    reader["Attachment"] == DBNull.Value
                                        ? ""
                                        : reader["Attachment"].ToString(),

                                DateReported =
                                    Convert.ToDateTime(reader["DateReported"]),

                                AccountId =
                                    reader["AccountId"] == DBNull.Value
                                        ? (int?)null
                                        : Convert.ToInt32(reader["AccountId"]),

                                Status = reader["Status"].ToString(),

                                Priority = Convert.ToInt32(reader["Priority"]),

                                Department =
                                    reader["Department"] == DBNull.Value
                                        ? ""
                                        : reader["Department"].ToString(),

                                LastUpdated =
                                    Convert.ToDateTime(reader["LastUpdated"])
                            };

                            Issues.Add(issue);
                        }
                    }
                }
            }
        }

        // ==========================================
        // ADD NEW SERVICE REQUEST
        // ==========================================

        public static bool AddIssue(Issue issue)
        {
            if (issue == null)
            {
                throw new ArgumentNullException("issue");
            }

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction =
                    connection.BeginTransaction())
                {
                    try
                    {
                        issue.Status =
                            string.IsNullOrWhiteSpace(issue.Status)
                                ? "Received"
                                : issue.Status;

                        issue.Priority =
                            issue.Priority < 1 || issue.Priority > 4
                                ? 3
                                : issue.Priority;

                        if (issue.DateReported == DateTime.MinValue)
                        {
                            issue.DateReported = DateTime.Now;
                        }

                        issue.LastUpdated = DateTime.Now;

                        // Insert the service request.
                        string query =
                            "INSERT INTO dbo.Issues " +
                            "(Location, Category, Description, Attachment, " +
                            "DateReported, AccountId, Status, Priority, " +
                            "Department, LastUpdated) " +
                            "VALUES " +
                            "(@Location, @Category, @Description, @Attachment, " +
                            "@DateReported, @AccountId, @Status, @Priority, " +
                            "@Department, @LastUpdated); " +
                            "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        using (SqlCommand command =
                            new SqlCommand(query, connection, transaction))
                        {
                            command.Parameters.Add(
                                "@Location", SqlDbType.NVarChar).Value =
                                issue.Location;

                            command.Parameters.Add(
                                "@Category", SqlDbType.NVarChar).Value =
                                issue.Category;

                            command.Parameters.Add(
                                "@Description", SqlDbType.NVarChar).Value =
                                issue.Description;

                            command.Parameters.Add(
                                "@Attachment", SqlDbType.NVarChar).Value =
                                string.IsNullOrEmpty(issue.Attachment)
                                    ? (object)DBNull.Value
                                    : issue.Attachment;

                            command.Parameters.Add(
                                "@DateReported", SqlDbType.DateTime).Value =
                                issue.DateReported;

                            command.Parameters.Add(
                                "@AccountId", SqlDbType.Int).Value =
                                issue.AccountId.HasValue
                                    ? (object)issue.AccountId.Value
                                    : DBNull.Value;

                            command.Parameters.Add(
                                "@Status", SqlDbType.NVarChar, 30).Value =
                                issue.Status;

                            command.Parameters.Add(
                                "@Priority", SqlDbType.Int).Value =
                                issue.Priority;

                            command.Parameters.Add(
                                "@Department", SqlDbType.NVarChar, 100).Value =
                                string.IsNullOrWhiteSpace(issue.Department)
                                    ? (object)DBNull.Value
                                    : issue.Department;

                            command.Parameters.Add(
                                "@LastUpdated", SqlDbType.DateTime2).Value =
                                issue.LastUpdated;

                            issue.Id = Convert.ToInt32(
                                command.ExecuteScalar());
                        }

                        // Record the initial status in history.
                        string historyQuery =
                            "INSERT INTO dbo.ServiceRequestStatusHistory " +
                            "(IssueId, Status, Notes, UpdatedAt, UpdatedBy) " +
                            "VALUES " +
                            "(@IssueId, @Status, @Notes, @UpdatedAt, @UpdatedBy)";

                        using (SqlCommand historyCommand =
                            new SqlCommand(
                                historyQuery, connection, transaction))
                        {
                            historyCommand.Parameters.Add(
                                "@IssueId", SqlDbType.Int).Value = issue.Id;

                            historyCommand.Parameters.Add(
                                "@Status", SqlDbType.NVarChar, 30).Value =
                                issue.Status;

                            historyCommand.Parameters.Add(
                                "@Notes", SqlDbType.NVarChar, 500).Value =
                                "Service request submitted.";

                            historyCommand.Parameters.Add(
                                "@UpdatedAt", SqlDbType.DateTime2).Value =
                                issue.LastUpdated;

                            historyCommand.Parameters.Add(
                                "@UpdatedBy", SqlDbType.NVarChar, 100).Value =
                                "System";

                            historyCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        Issues.Add(issue);

                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ==========================================
        // FIND SERVICE REQUEST BY ID
        // ==========================================

        public static Issue FindIssueById(int issueId)
        {
            return Issues.Find(
                issue => issue.Id == issueId);
        }

        // ==========================================
        // FIND SERVICE REQUEST BY REFERENCE
        // Example: MSR-000025
        // ==========================================

        public static Issue FindIssueByReference(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
            {
                return null;
            }

            string idText = reference.Trim();

            if (idText.StartsWith(
                "MSR-", StringComparison.OrdinalIgnoreCase))
            {
                idText = idText.Substring(4);
            }

            int issueId;

            if (!int.TryParse(idText, out issueId))
            {
                return null;
            }

            return FindIssueById(issueId);
        }

        // ==========================================
        // GET SERVICE REQUEST STATUS HISTORY
        // ==========================================

        public static DataTable GetStatusHistory(int issueId)
        {
            DataTable historyTable = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                string query =
                    "SELECT Status, Notes, UpdatedAt, UpdatedBy " +
                    "FROM dbo.ServiceRequestStatusHistory " +
                    "WHERE IssueId = @IssueId " +
                    "ORDER BY UpdatedAt ASC";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@IssueId", SqlDbType.Int).Value = issueId;

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                    {
                        adapter.Fill(historyTable);
                    }
                }
            }

            return historyTable;
        }

        // ==========================================
        // UPDATE SERVICE REQUEST
        // ==========================================

        public static bool UpdateServiceRequest(
            int issueId,
            string newStatus,
            int newPriority,
            string department,
            string notes,
            string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                throw new ArgumentException(
                    "A service request status is required.");
            }

            if (newPriority < 1 || newPriority > 4)
            {
                throw new ArgumentException(
                    "Priority must be between 1 and 4.");
            }

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction =
                    connection.BeginTransaction())
                {
                    try
                    {
                        string oldStatus = null;

                        // Get the existing status.
                        string checkQuery =
                            "SELECT Status FROM dbo.Issues " +
                            "WITH (UPDLOCK, ROWLOCK) WHERE Id = @Id";

                        using (SqlCommand checkCommand =
                            new SqlCommand(
                                checkQuery, connection, transaction))
                        {
                            checkCommand.Parameters.Add(
                                "@Id", SqlDbType.Int).Value = issueId;

                            object result = checkCommand.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                transaction.Rollback();
                                return false;
                            }

                            oldStatus = result.ToString();
                        }

                        DateTime updatedAt = DateTime.Now;

                        // Update the request.
                        string updateQuery =
                            "UPDATE dbo.Issues SET " +
                            "Status = @Status, " +
                            "Priority = @Priority, " +
                            "Department = @Department, " +
                            "LastUpdated = @LastUpdated " +
                            "WHERE Id = @Id";

                        using (SqlCommand updateCommand =
                            new SqlCommand(
                                updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.Add(
                                "@Status", SqlDbType.NVarChar, 30).Value =
                                newStatus;

                            updateCommand.Parameters.Add(
                                "@Priority", SqlDbType.Int).Value =
                                newPriority;

                            updateCommand.Parameters.Add(
                                "@Department", SqlDbType.NVarChar, 100).Value =
                                string.IsNullOrWhiteSpace(department)
                                    ? (object)DBNull.Value
                                    : department;

                            updateCommand.Parameters.Add(
                                "@LastUpdated", SqlDbType.DateTime2).Value =
                                updatedAt;

                            updateCommand.Parameters.Add(
                                "@Id", SqlDbType.Int).Value = issueId;

                            updateCommand.ExecuteNonQuery();
                        }

                        // Record history only when the status changes.
                        if (!string.Equals(
                            oldStatus,
                            newStatus,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            string historyQuery =
                                "INSERT INTO dbo.ServiceRequestStatusHistory " +
                                "(IssueId, Status, Notes, UpdatedAt, UpdatedBy) " +
                                "VALUES " +
                                "(@IssueId, @Status, @Notes, @UpdatedAt, @UpdatedBy)";

                            using (SqlCommand historyCommand =
                                new SqlCommand(
                                    historyQuery, connection, transaction))
                            {
                                historyCommand.Parameters.Add(
                                    "@IssueId", SqlDbType.Int).Value =
                                    issueId;

                                historyCommand.Parameters.Add(
                                    "@Status", SqlDbType.NVarChar, 30).Value =
                                    newStatus;

                                historyCommand.Parameters.Add(
                                    "@Notes", SqlDbType.NVarChar, 500).Value =
                                    string.IsNullOrWhiteSpace(notes)
                                        ? (object)DBNull.Value
                                        : notes;

                                historyCommand.Parameters.Add(
                                    "@UpdatedAt", SqlDbType.DateTime2).Value =
                                    updatedAt;

                                historyCommand.Parameters.Add(
                                    "@UpdatedBy", SqlDbType.NVarChar, 100).Value =
                                    string.IsNullOrWhiteSpace(updatedBy)
                                        ? (object)"System"
                                        : updatedBy;

                                historyCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        // Update the in-memory issue.
                        Issue issue = FindIssueById(issueId);

                        if (issue != null)
                        {
                            issue.Status = newStatus;
                            issue.Priority = newPriority;
                            issue.Department = department;
                            issue.LastUpdated = updatedAt;
                        }

                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}

