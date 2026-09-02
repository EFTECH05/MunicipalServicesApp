using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MunicipalServicesApp
{
    public static class AccountStore
    {
        public static List<Account> Accounts { get; private set; }

        private static string connectionString =
            @"Data Source=FRANKLIN\SQLEXPRESS01;" +
            @"Initial Catalog=MunicipalServicesDB;" +
            @"Integrated Security=True";

        static AccountStore()
        {
            Accounts = new List<Account>();
        }

        public static void LoadAccounts()
        {
            Accounts.Clear();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query =
                    "SELECT Id, FullName, Email, Username, Password, AccountType " +
                    "FROM Accounts";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader =
                        command.ExecuteReader())
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
                                AccountType = reader["AccountType"].ToString()
                            };

                            Accounts.Add(account);
                        }
                    }
                }
            }
        }

        public static bool UsernameExists(string username)
        {
            foreach (Account account in Accounts)
            {
                if (account.Username.Equals(
                    username,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool EmailExists(string email)
        {
            foreach (Account account in Accounts)
            {
                if (!string.IsNullOrEmpty(account.Email) &&
                    account.Email.Equals(
                        email,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

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
                        "INSERT INTO Accounts " +
                        "(FullName, Email, Username, Password, AccountType) " +
                        "VALUES (@FullName, @Email, @Username, @Password, @AccountType); " +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@FullName", fullName);

                        command.Parameters.AddWithValue(
                            "@Email", email);

                        command.Parameters.AddWithValue(
                            "@Username", username);

                        command.Parameters.AddWithValue(
                            "@Password", password);

                        command.Parameters.AddWithValue(
                            "@AccountType", accountType);

                        int newId = Convert.ToInt32(
                            command.ExecuteScalar());

                        Account newAccount = new Account
                        {
                            Id = newId,
                            FullName = fullName,
                            Email = email,
                            Username = username,
                            Password = password,
                            AccountType = accountType
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

        public static Account Login(
            string username,
            string password)
        {
            foreach (Account account in Accounts)
            {
                if (account.Username.Equals(
                        username,
                        StringComparison.OrdinalIgnoreCase)
                    && account.Password == password)
                {
                    return account;
                }
            }

            return null;
        }
    }
}