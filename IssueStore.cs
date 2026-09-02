using System;
using System.Collections.Generic;
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
                    "Attachment, DateReported " +
                    "FROM Issues " +
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
                                Id =
                                    Convert.ToInt32(
                                        reader["Id"]),

                                Location =
                                    reader["Location"].ToString(),

                                Category =
                                    reader["Category"].ToString(),

                                Description =
                                    reader["Description"].ToString(),

                                Attachment =
                                    reader["Attachment"] == DBNull.Value
                                        ? ""
                                        : reader["Attachment"].ToString(),

                                DateReported =
                                    Convert.ToDateTime(
                                        reader["DateReported"])
                            };

                            // Add database issue
                            // to the in-memory list.
                            Issues.Add(issue);
                        }
                    }
                }
            }
        }

        // ==========================================
        // ADD ISSUE
        // ==========================================
        public static bool AddIssue(Issue issue)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query =
                        "INSERT INTO Issues " +
                        "(Location, Category, Description, Attachment) " +
                        "VALUES " +
                        "(@Location, @Category, @Description, @Attachment); " +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        // ----------------------------------
                        // LOCATION
                        // ----------------------------------
                        command.Parameters.AddWithValue(
                            "@Location",
                            issue.Location);

                        // ----------------------------------
                        // CATEGORY
                        // ----------------------------------
                        command.Parameters.AddWithValue(
                            "@Category",
                            issue.Category);

                        // ----------------------------------
                        // DESCRIPTION
                        // ----------------------------------
                        command.Parameters.AddWithValue(
                            "@Description",
                            issue.Description);

                        // ----------------------------------
                        // ATTACHMENT
                        // ----------------------------------
                        if (string.IsNullOrEmpty(
                            issue.Attachment))
                        {
                            command.Parameters.AddWithValue(
                                "@Attachment",
                                DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(
                                "@Attachment",
                                issue.Attachment);
                        }

                        // ----------------------------------
                        // INSERT INTO DATABASE
                        // ----------------------------------
                        int newId =
                            Convert.ToInt32(
                                command.ExecuteScalar());

                        // ----------------------------------
                        // UPDATE ISSUE OBJECT
                        // ----------------------------------
                        issue.Id = newId;

                        issue.DateReported =
                            DateTime.Now;

                        // ----------------------------------
                        // ADD TO IN-MEMORY LIST
                        // ----------------------------------
                        Issues.Add(issue);

                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Throw the database error so that
                // the form can display the real reason.
                throw new Exception(
                    "A database error occurred while saving the issue.\n\n" +
                    ex.Message,
                    ex);
            }
            catch (Exception ex)
            {
                // Handle other errors.
                throw new Exception(
                    "An error occurred while saving the issue.\n\n" +
                    ex.Message,
                    ex);
            }
        }
    }
}