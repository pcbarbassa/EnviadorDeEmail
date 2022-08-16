using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using PCB.EnviadorDeEmail.Domain.Entities;

namespace PCB.EnviadorDeEmail.Service
{
    public class ServicoEmail : IServicoEmail

    {
        public readonly IConfiguration _config;
        public ServicoEmail(IConfiguration config)
        {
            _config = config;
        }

        public void EnviarEmail(Email email)
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            mail.To.Add(MailboxAddress.Parse(email.Destinatario));
            mail.Subject = email.Assunto;
            mail.Body = new TextPart(TextFormat.Html) { Text = email.Mensagem };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(mail);
            smtp.Disconnect(true);
        }
    }
}
