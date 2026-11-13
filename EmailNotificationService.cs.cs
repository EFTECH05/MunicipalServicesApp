
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace MunicipalServicesApp
{
    public class EmailNotificationResult
    {
        public int TotalRecipients { get; set; }
        public int Sent { get; set; }
        public int Failed { get; set; }
        public string Message { get; set; }
    }

    public static class EmailNotificationService
    {
        private static readonly string connectionString =
            @"Data Source=FRANKLIN\SQLEXPRESS01;" +
            @"Initial Catalog=MunicipalServicesDB;" +
            @"Integrated Security=True";

        public static EmailNotificationResult SendAnnouncement(
            string title,
            string category,
            DateTime eventDate,
            string location,
            string description,
            string eventType)
        {
            EmailNotificationResult result =
                new EmailNotificationResult();

            string senderEmail =
                Environment.GetEnvironmentVariable("MUNICIPAL_SMTP_EMAIL");

            string appPassword =
                Environment.GetEnvironmentVariable(
                    "MUNICIPAL_SMTP_APP_PASSWORD");

            if (string.IsNullOrWhiteSpace(senderEmail) ||
                string.IsNullOrWhiteSpace(appPassword))
            {
                result.Message =
                    "Email credentials are not configured. " +
                    "The announcement was saved, but emails were not sent.";
                return result;
            }

            List<string> recipients = new List<string>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(
                    @"SELECT DISTINCT Email
                      FROM dbo.Accounts
                      WHERE AccountType = @AccountType
                        AND Email IS NOT NULL
                        AND LTRIM(RTRIM(Email)) <> ''",
                    connection))
                {
                    command.Parameters.AddWithValue(
                        "@AccountType", "Citizen");

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email = reader["Email"].ToString().Trim();

                            try
                            {
                                MailAddress address = new MailAddress(email);
                                recipients.Add(address.Address);
                            }
                            catch (FormatException)
                            {
                                // Skip invalid email addresses.
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                result.Message =
                    "The announcement was saved, but citizen email " +
                    "addresses could not be loaded.";
                return result;
            }

            result.TotalRecipients = recipients.Count;

            if (recipients.Count == 0)
            {
                result.Message =
                    "No registered citizens with valid email addresses " +
                    "were found.";
                return result;
            }

            string subject = "Municipal " + eventType + ": " + title;

            string body =
                "Dear Resident,\r\n\r\n" +
                "A new municipal " + eventType.ToLowerInvariant() +
                " has been published.\r\n\r\n" +
                "Title: " + title + "\r\n" +
                "Category: " + category + "\r\n" +
                "Date and time: " +
                eventDate.ToString("dd MMMM yyyy, HH:mm") + "\r\n" +
                "Location: " + location + "\r\n\r\n" +
                "Description:\r\n" + description + "\r\n\r\n" +
                "Cape Town Municipal Services";

            foreach (string recipient in recipients)
            {
                try
                {
                    using (MailMessage message = new MailMessage())
                    {
                        message.From = new MailAddress(senderEmail);
                        message.To.Add(recipient);
                        message.Subject = subject;
                        message.Body = body;

                        using (SmtpClient smtp =
                            new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.EnableSsl = true;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(
                                senderEmail, appPassword);
                            smtp.Timeout = 15000;
                            smtp.Send(message);
                        }
                    }

                    result.Sent++;
                }
                catch (Exception)
                {
                    result.Failed++;
                }
            }

            result.Message = "Email notification process completed.";
            return result;
        }
    }
}
