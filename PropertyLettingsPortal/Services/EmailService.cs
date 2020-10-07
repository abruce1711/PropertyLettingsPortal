using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PropertyLettingsPortal.Data.Models;
using PropertyLettingsPortal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Services
{
    public class EmailService : IEmailService
    {

        private readonly string SmtpUsername = Environment.GetEnvironmentVariable("TTSmtpUsername");
        private readonly string SmtpPassword = Environment.GetEnvironmentVariable("TTSmtpPassword");

        public void Send(string message, string from, Property property)
        {
            var email = new MimeMessage();
            email.To.Add(new MailboxAddress(property.Manager.Name, property.Manager.Email));
            email.From.Add(new MailboxAddress("Property Lettings Tech Test", "PLettingsTechTest@gmail.com"));
            email.Subject = "Lettings Enquiry - " + property.StreetAddress;
            var builder = new BodyBuilder();
            builder.HtmlBody = message;
            email.Body = builder.ToMessageBody();

            using (var emailClient = new SmtpClient())
            {
                //The last parameter is to use SSL
                emailClient.Connect("smtp.google.com", 587, SecureSocketOptions.StartTls);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(SmtpUsername, SmtpPassword);

                emailClient.Send(email);

                emailClient.Disconnect(true);
            }
        }
    }
}
