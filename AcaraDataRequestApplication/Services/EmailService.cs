using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(IOptions<EmailConfiguration> options)
        {
            _emailConfiguration = options.Value;
        }

        public void SendEmail(string receivers, string subject, string message)
        {
            using (SmtpClient smtpClient = new SmtpClient(_emailConfiguration.MailServerAddress, _emailConfiguration.MailServerPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguration.UserId, _emailConfiguration.UserPassword);
                smtpClient.EnableSsl = _emailConfiguration.EnableSSL;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_emailConfiguration.FromAddress, _emailConfiguration.FromName);
                foreach (var receiver in receivers.Split(";", StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.To.Add(new MailAddress(receiver));
                }
                mailMessage.Subject = subject;
                mailMessage.Body = message;

                smtpClient.Send(mailMessage);
            }
        }
    }
}
