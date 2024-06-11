using System.Net;
using System.Net.Mail;

namespace GasDetector.Helper
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("erick_goldberg@hotmail.com", "x"),
                EnableSsl = true,
            };
        }

        public void SendEmail(string to, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("erick_goldberg@hotmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(to);

            _smtpClient.Send(mailMessage);
        }
    }
}
