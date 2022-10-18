using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace OutlookMailer.Services
{
    public class Mailer
    {
        public string UserEmail { get; private set; }
        public string Password { get; private set; }

        public Mailer(string userEmail, string password)
        {
            UserEmail = userEmail;
            Password = password;
        }
        
        public async Task SendEmailAsync(string sendername, string receivername, string email, string subject, string messagebody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(sendername, UserEmail));
            message.To.Add(new MailboxAddress(receivername, email));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = messagebody
            };

            using (var client = new SmtpClient())
            {   
                client.Connect("smtp-mail.outlook.com", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(UserEmail, Password);
                await client.SendAsync(message);
                client.Disconnect(true);
            }

            return;
        }
    }
}
