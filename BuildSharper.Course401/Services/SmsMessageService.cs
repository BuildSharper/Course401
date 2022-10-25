using BuildSharper.Course401.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BuildSharper.Course401.Services
{
    public class SmsMessageService : IMessageService
    {
        public string Name => "SMS";

        public void Send(string message)
        {
            var toAddress = ConfigurationManager.AppSettings["SmsToAddress"];
            var username = ConfigurationManager.AppSettings["SmsUsername"];
            var password = ConfigurationManager.AppSettings["SmsPassword"];
            var smtpServer = ConfigurationManager.AppSettings["SmsSmtpServer"];

            using (var client = new SmtpClient(smtpServer, 587))
            {
                client.Credentials = new NetworkCredential(username, password);
                client.EnableSsl = true;

                var msg = new MailMessage();
                msg.To.Add(toAddress);
                msg.From = new MailAddress(username);
                msg.Subject = "BuildSharper.com - Interfaces - SMS Service";
                msg.Body = message;

                client.Send(msg);
            }
        }
    }
}
