
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public static class AccountStore
    {
        public static List<Account> Accounts { get; private set; }

        private static readonly string connectionString =
            @"Data Source=FRANKLIN\SQLEXPRESS01;" +
            @"Initial Catalog=MunicipalServicesDB;" +
            @"Integrated Security=True";

        static AccountStore()
        {
            Accounts = new List<Account>();
        }

        // ==========================================
        // LOAD ACCOUNTS
        // ==========================================
        public static void LoadAccounts()
        {
            Accounts.Clear();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "SELECT Id, FullName, Email, Username, Password, " +
                    "AccountType, IsActive, CreatedAt, LastLoginAt " +
                    "FROM dbo.Accounts";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account account = new Account
                        {
                            Id = Convert.ToInt32(reader["Id"]),

                            FullName = reader["FullName"].ToString(),

                            Email = reader["Email"] == DBNull.Value
                                ? ""
                                : reader["Email"].ToString(),

                            Username = reader["Username"].ToString(),

                            Password = reader["Password"].ToString(),

                            AccountType = reader["AccountType"].ToString(),

                            IsActive = Convert.ToBoolean(
                                reader["IsActive"]),

                            CreatedAt = Convert.ToDateTime(
                                reader["CreatedAt"]),

                            LastLoginAt =
                                reader["LastLoginAt"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(
                                        reader["LastLoginAt"])
                        };

                        Accounts.Add(account);
                    }
                }
            }
        }

        // ==========================================
        // AUTOMATICALLY DELETE INACTIVE CITIZENS
        // Delete Citizens after six months without
        // a successful login.
        // Use CreatedAt if they never logged in.
        // Admin and SuperAdmin accounts are protected.
        // ==========================================
        public static int DeleteInactiveCitizens()
        {
            int deletedCount;

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "DELETE FROM dbo.Accounts " +
                    "WHERE AccountType = @AccountType " +
                    "AND COALESCE(LastLoginAt, CreatedAt) " +
                    "<= DATEADD(MONTH, -6, SYSDATETIME()); " +
                    "SELECT @@ROWCOUNT;";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@AccountType", SqlDbType.NVarChar).Value =
                        "Citizen";

                    deletedCount = Convert.ToInt32(
                        command.ExecuteScalar());
                }
            }

            LoadAccounts();

            return deletedCount;
        }

        // ==========================================
        // CHECK USERNAME
        // ==========================================
        public static bool UsernameExists(string username)
        {
            foreach (Account account in Accounts)
            {
                if (string.Equals(
                    account.Username,
                    username,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        // ==========================================
        // CHECK EMAIL
        // ==========================================
        public static bool EmailExists(string email)
        {
            foreach (Account account in Accounts)
            {
                if (!string.IsNullOrEmpty(account.Email) &&
                    string.Equals(
                        account.Email,
                        email,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        // ==========================================
        // REGISTER ACCOUNT
        // CreatedAt is set by SQL Server.
        // ==========================================
        public static bool AddAccount(
            string username,
            string password,
            string fullName,
            string accountType,
            string email)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query =
                        "INSERT INTO dbo.Accounts " +
                        "(FullName, Email, Username, Password, AccountType) " +
                        "VALUES (@FullName, @Email, @Username, " +
                        "@Password, @AccountType); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(
                            "@FullName", SqlDbType.NVarChar).Value =
                            fullName;

                        command.Parameters.Add(
                            "@Email", SqlDbType.NVarChar).Value =
                            (object)email ?? DBNull.Value;

                        command.Parameters.Add(
                            "@Username", SqlDbType.NVarChar).Value =
                            username;

                        command.Parameters.Add(
                            "@Password", SqlDbType.NVarChar).Value =
                            password;

                        command.Parameters.Add(
                            "@AccountType", SqlDbType.NVarChar).Value =
                            accountType;

                        int newId = Convert.ToInt32(
                            command.ExecuteScalar());

                        Account newAccount = new Account
                        {
                            Id = newId,
                            FullName = fullName,
                            Email = email ?? "",
                            Username = username,
                            Password = password,
                            AccountType = accountType,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            LastLoginAt = null
                        };

                        Accounts.Add(newAccount);

                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // ==========================================
        // LOGIN
        // Refresh accounts from SQL Server.
        // Reject inactive Citizen and Admin accounts.
        // SuperAdmin accounts are protected.
        // Update LastLoginAt after successful login.
        // ==========================================
        public static Account Login(
            string username,
            string password)
        {
            LoadAccounts();

            foreach (Account account in Accounts)
            {
                if (string.Equals(
                        account.Username,
                        username,
                        StringComparison.OrdinalIgnoreCase)
                    && account.Password == password)
                {
                    // Reject deactivated Citizen and Admin accounts.
                    if ((string.Equals(
                             account.AccountType,
                             "Citizen",
                             StringComparison.OrdinalIgnoreCase)
                         || string.Equals(
                             account.AccountType,
                             "Admin",
                             StringComparison.OrdinalIgnoreCase))
                        && !account.IsActive)
                    {
                        return null;
                    }

                    // Update the successful login timestamp.
                    using (SqlConnection connection =
                        new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query =
                            "UPDATE dbo.Accounts " +
                            "SET LastLoginAt = SYSDATETIME() " +
                            "WHERE Id = @Id AND Username = @Username;";

                        using (SqlCommand command =
                            new SqlCommand(query, connection))
                        {
                            command.Parameters.Add(
                                "@Id", SqlDbType.Int).Value =
                                account.Id;

                            command.Parameters.Add(
                                "@Username", SqlDbType.NVarChar).Value =
                                account.Username;

                            // TEMPORARY DEBUG MESSAGE.
                            // Remove after testing the login timestamp.
                            MessageBox.Show(
                                "Updating login timestamp for: " +
                                account.Username,
                                "Login Debug",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            int rowsAffected =
                                command.ExecuteNonQuery();

                            if (rowsAffected != 1)
                            {
                                throw new InvalidOperationException(
                                    "The login timestamp could not be updated. " +
                                    "Rows affected: " + rowsAffected);
                            }
                        }

                        // Read the timestamp saved by SQL Server.
                        string timestampQuery =
                            "SELECT LastLoginAt " +
                            "FROM dbo.Accounts WHERE Id = @Id;";

                        using (SqlCommand timestampCommand =
                            new SqlCommand(timestampQuery, connection))
                        {
                            timestampCommand.Parameters.Add(
                                "@Id", SqlDbType.Int).Value =
                                account.Id;

                            object result =
                                timestampCommand.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                throw new InvalidOperationException(
                                    "The saved login timestamp could not be read.");
                            }

                            account.LastLoginAt =
                                Convert.ToDateTime(result);
                        }
                    }

                    return account;
                }
            }

            return null;
        }

        // ==========================================
        // CHANGE ACCOUNT STATUS
        // SuperAdmin can deactivate/reactivate
        // Citizens and Admins.
        // SuperAdmin accounts cannot be changed.
        // ==========================================
        public static bool SetAccountActiveStatus(
            int accountId,
            bool isActive)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "UPDATE dbo.Accounts " +
                    "SET IsActive = @IsActive " +
                    "WHERE Id = @Id " +
                    "AND AccountType IN (@Citizen, @Admin);";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@IsActive", SqlDbType.Bit).Value =
                        isActive;

                    command.Parameters.Add(
                        "@Id", SqlDbType.Int).Value =
                        accountId;

                    command.Parameters.Add(
                        "@Citizen", SqlDbType.NVarChar).Value =
                        "Citizen";

                    command.Parameters.Add(
                        "@Admin", SqlDbType.NVarChar).Value =
                        "Admin";

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        LoadAccounts();
                        return true;
                    }

                    return false;
                }
            }
        }
    }
}
