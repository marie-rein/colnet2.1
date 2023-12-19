using NETCore.MailKit.Core;
using System.Net.Mail;
using System.Net;

namespace ColNet2._0.CustomModels
{
    public class EmailSender: IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Implement the email sending logic here
            // You might use an external email service or a local SMTP server

            using (var client = new SmtpClient("smtp.office365.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("mariecubaka@outlook.com", "Tumsifu2020");
                client.EnableSsl = true;

                var message = new MailMessage("mariecubaka@outlook.com", email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                };

                await client.SendMailAsync(message);
            }
        }
    }
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
