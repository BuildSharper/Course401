using BuildSharper.Course401.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Configuration;

namespace BuildSharper.Course401.Services
{
    public class EmailMessageService : IMessageService
    {
        public string Name => "Email";

        public void Send(string message)
        {
            var fromAddress = ConfigurationManager.AppSettings["EmailFromAddress"];
            var smtpServer = ConfigurationManager.AppSettings["EmailSmtpServer"];
            var username = ConfigurationManager.AppSettings["EmailUsername"];
            var password = ConfigurationManager.AppSettings["EmailPassword"];

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(fromAddress));
            email.To.Add(MailboxAddress.Parse(username));
            email.Subject = "BuildSharper.com - Interfaces - Email Service";

            //Build the body with both HTML and TEXT versions
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = message;
            bodyBuilder.HtmlBody = bodyBuilder.TextBody;

            email.Body = bodyBuilder.ToMessageBody();

            //let's send the email
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(smtpServer, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(username, password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
