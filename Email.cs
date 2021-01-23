using System;
using System.Collections.ObjectModel;
using System.Net.Mail;

namespace Talrand.Core
{
    public class Email
    {
        private Collection<string> Recipients = new Collection<string>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromEmail { get; set; }
        public SMTP SMTPSettings { get; set; }

        public struct SMTP
        {
            public string Server { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }

            public int Port { get; set; }
            public bool UseSSL { get; set; }

            public SMTP(string server, string userName, string password, int port, bool useSSL)
            {
                Server = server;
                UserName = userName;
                Password = password;
                Port = port;
                UseSSL = useSSL;
            }
        }

        /// <summary>
        /// Add email address to recipients collection
        /// </summary>
        /// <param name="emailAddress">Email address to add to recipient collection</param>
        public void AddRecipient(string emailAddress)
        {
            Recipients.Add(emailAddress);
        }

        /// <summary>
        /// Send email to each recipient
        /// </summary>
        public void Send()
        {
            for (int i = 0; i < Recipients.Count; i++)
            {
                using (MailMessage message = new MailMessage())
                {
                    // Construct new message
                    message.From = new MailAddress(FromEmail);
                    message.To.Add(Recipients[i]);
                    message.Subject = Subject;
                    message.IsBodyHtml = true;
                    message.Body = Body;

                    // Send message
                    using (SmtpClient smtpClient = new SmtpClient(SMTPSettings.Server, SMTPSettings.Port))
                    {
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new System.Net.NetworkCredential(SMTPSettings.UserName, SMTPSettings.Password);
                        smtpClient.EnableSsl = SMTPSettings.UseSSL;
                        smtpClient.Send(message);
                    }
                }
            }
        }
    }
}