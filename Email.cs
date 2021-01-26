using System;
using System.Collections.ObjectModel;
using System.Net.Mail;

namespace Talrand.Core
{
    public class Email
    {
        private Collection<Recipient> Recipients = new Collection<Recipient>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromEmailAddress { get; set; }
        public SMTP SMTPSettings { get; set; }

        public struct SMTP
        {
            public string ServerName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }

            public int PortNumber { get; set; }
            public bool UseSSL { get; set; }

            public SMTP(string serverName, string userName, string password, int portNumber, bool useSSL)
            {
                ServerName = serverName;
                UserName = userName;
                Password = password;
                PortNumber = portNumber;
                UseSSL = useSSL;
            }
        }

        public struct Recipient
        {
            public string EmailAddress { get; set; }
            public RecipientType Type { get; set; }

            public Recipient(string emailAddress, RecipientType type)
            {
                EmailAddress = emailAddress;
                Type = type;
            }
        }

        public enum RecipientType
        {
            Standard,
            CC,
            BCC
        }

        /// <summary>
        /// Adds a recipient to recipients collection
        /// </summary>
        /// <param name="recipient">A Recipient object containing details of the recipient to send email to</param>
        public void AddRecipient(Recipient recipient)
        {
            Recipients.Add(recipient);
        }

        /// <summary>
        /// Send email to each recipient
        /// </summary>
        public void Send()
        {
            // Send message
            using (SmtpClient smtpClient = new SmtpClient(SMTPSettings.ServerName, SMTPSettings.PortNumber))
            {
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(SMTPSettings.UserName, SMTPSettings.Password);
                smtpClient.EnableSsl = SMTPSettings.UseSSL;
                smtpClient.Send(CreateMailMessage());
            }

            // Clear recipients to ensure recipients aren't included in the next email
            Recipients.Clear();
        }

        /// <summary>
        /// Creates a new MailMessage object from class properties
        /// </summary>
        /// <returns></returns>
        private MailMessage CreateMailMessage()
        {
            MailMessage message = new MailMessage();

            // Construct new message
            message.From = new MailAddress(FromEmailAddress);
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body = Body;

            // Add recipients
            AddRecipientsToMailMessage(ref message);

            // Return constructed message
            return message;
        }

        /// <summary>
        /// Add recipients to MailMessage based on recipient type
        /// </summary>
        /// <param name="message">MailMessage object to add recipients to</param>
        private void AddRecipientsToMailMessage(ref MailMessage message)
        {
            foreach (Recipient recipient in Recipients)
            {
                switch (recipient.Type)
                {
                    case RecipientType.Standard:
                        message.To.Add(recipient.EmailAddress);
                        break;
                    case RecipientType.CC:
                        message.CC.Add(recipient.EmailAddress);
                        break;
                    case RecipientType.BCC:
                        message.Bcc.Add(recipient.EmailAddress);
                        break;
                }
            }
        }
    }
}