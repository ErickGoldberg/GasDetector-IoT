using System.Net;
using System.Net.Mail;

namespace GasDetector.Helper
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("josesilvio.bs@gmail.com", "wyyi htbn yphf bvgx"),
                EnableSsl = true,
                UseDefaultCredentials = false
            };
        }

        public void SendEmail(string to, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("josesilvio.bs@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false,
            };
            mailMessage.To.Add(to);

            _smtpClient.Send(mailMessage);
        }
    }
}
