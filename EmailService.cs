
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace MunicipalServicesApp
{
    internal static class EmailService
    {
        private static readonly string connectionString =
            @"Data Source=FRANKLIN\SQLEXPRESS01;" +
            @"Initial Catalog=MunicipalServicesDB;" +
            @"Integrated Security=True";

        /// <summary>
        /// Sends an email using Gmail SMTP.
        /// Requires MUNICIPAL_SMTP_EMAIL and
        /// MUNICIPAL_SMTP_APP_PASSWORD environment variables.
        /// </summary>
        internal static void SendEmail(
            string recipient,
            string subject,
            string body)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException(
                    "The recipient email address is required.",
                    nameof(recipient));
            }

            string sender =
                Environment.GetEnvironmentVariable(
                    "MUNICIPAL_SMTP_EMAIL");

            string password =
                Environment.GetEnvironmentVariable(
                    "MUNICIPAL_SMTP_APP_PASSWORD");

            if (string.IsNullOrWhiteSpace(sender))
            {
                throw new InvalidOperationException(
                    "MUNICIPAL_SMTP_EMAIL is missing. " +
                    "Configure your Gmail sender address.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException(
                    "MUNICIPAL_SMTP_APP_PASSWORD is missing. " +
                    "Configure your Google App Password.");
            }

            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(
                    sender,
                    "Municipal Services");

                message.To.Add(new MailAddress(recipient));
                message.Subject = subject ?? string.Empty;
                message.Body = body ?? string.Empty;
                message.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(
                    "smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(
                        sender,
                        password);
                    smtp.DeliveryMethod =
                        SmtpDeliveryMethod.Network;
                    smtp.Timeout = 20000;

                    smtp.Send(message);
                }
            }
        }

        /// <summary>
        /// Sends a registration verification code.
        /// Call this from your existing registration/OTP workflow.
        /// </summary>
        internal static void SendRegistrationOtp(
            string recipientEmail,
            string otp)
        {
            if (string.IsNullOrWhiteSpace(otp))
            {
                throw new ArgumentException(
                    "The verification code is required.",
                    nameof(otp));
            }

            string subject =
                "Municipal Services - Email Verification";

            string body =
                "Dear Citizen,\r\n\r\n" +
                "Your Municipal Services verification code is:\r\n\r\n" +
                otp + "\r\n\r\n" +
                "Enter this code in the application to verify " +
                "your email address.\r\n\r\n" +
                "If you did not request this code, you can ignore " +
                "this email.\r\n\r\n" +
                "Municipal Services Team";

            SendEmail(recipientEmail, subject, body);
        }

        /// <summary>
        /// Emails all active citizen accounts about a new event
        /// or announcement. Returns a delivery summary.
        /// </summary>
        internal static string NotifyActiveCitizensOfEvent(
            string title,
            string category,
            DateTime eventDate,
            string location,
            string description,
            string eventType)
        {
            List<string> recipients = new List<string>();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT DISTINCT Email
                    FROM dbo.Accounts
                    WHERE AccountType = @AccountType
                      AND IsActive = 1
                      AND Email IS NOT NULL
                      AND LTRIM(RTRIM(Email)) <> '';";

                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@AccountType",
                        SqlDbType.NVarChar,
                        50).Value = "Citizen";

                    connection.Open();

                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email =
                                reader["Email"].ToString().Trim();

                            if (!string.IsNullOrWhiteSpace(email))
                            {
                                recipients.Add(email);
                            }
                        }
                    }
                }
            }

            if (recipients.Count == 0)
            {
                return "The event was saved successfully, but " +
                       "there are no active citizens with email " +
                       "addresses to notify.";
            }

            string safeEventType =
                string.IsNullOrWhiteSpace(eventType)
                    ? "Event"
                    : eventType.Trim();

            string subject =
                "Municipal " + safeEventType + ": " + title;

            string body =
                "Dear Resident,\r\n\r\n" +
                "A new municipal " + safeEventType.ToLowerInvariant() +
                " has been published.\r\n\r\n" +
                "Title: " + title + "\r\n" +
                "Category: " + category + "\r\n" +
                "Date and time: " +
                eventDate.ToString("dd MMMM yyyy, HH:mm") + "\r\n" +
                "Location: " + location + "\r\n\r\n" +
                "Description:\r\n" + description + "\r\n\r\n" +
                "Please consult the Municipal Services Application " +
                "for further information.\r\n\r\n" +
                "Regards,\r\nMunicipal Services Team";

            int sent = 0;
            int failed = 0;
            List<string> errors = new List<string>();

            foreach (string recipient in recipients)
            {
                try
                {
                    SendEmail(recipient, subject, body);
                    sent++;
                }
                catch (Exception ex)
                {
                    failed++;

                    // Record the failure without exposing SMTP
                    // credentials or stopping other deliveries.
                    errors.Add(
                        recipient + ": " + ex.Message);
                }
            }

            string result =
                "Event saved successfully.\r\n\r\n" +
                "Notification results:\r\n" +
                "Recipients found: " + recipients.Count + "\r\n" +
                "Emails sent: " + sent + "\r\n" +
                "Emails failed: " + failed;

            if (failed > 0)
            {
                result +=
                    "\r\n\r\nSome emails could not be sent. " +
                    "Check your SMTP configuration and connection.";
            }

            return result;
        }
    }
}
