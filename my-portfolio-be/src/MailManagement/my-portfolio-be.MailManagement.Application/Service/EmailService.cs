using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using my_portfolio_be.MailManagement.Application.Common;
using my_portfolio_be.MailManagement.Application.Configuration;

namespace my_portfolio_be.MailManagement.Application.Service;

public class EmailService : IEmailService
{
    private readonly MailConfiguration _mailConfiguration;

    public EmailService(IOptions<MailConfiguration> mailConfiguration)
    {
        _mailConfiguration = mailConfiguration.Value;
    }

    public async Task SendEmailAsync(EmailOptions emailOptions)
    {
        // 1. Create the MIME message
        var email = new MimeMessage();
        email.To.Add(new MailboxAddress(_mailConfiguration.ReceiverName, _mailConfiguration.ReceiverEmail));
        email.From.Add(MailboxAddress.Parse(emailOptions.Email));
        email.Subject = emailOptions.Subject;

        // Use BodyBuilder to easily specify HTML content
        var builder = new BodyBuilder { HtmlBody = emailOptions.Message };
        email.Body = builder.ToMessageBody();

        // 2. Use MailKit's SmtpClient (Do NOT use System.Net.Mail.SmtpClient)
        using var smtp = new SmtpClient();

        try
        {
            // Connect using STARTTLS (Port 587). For SSL (Port 465), use SecureSocketOptions.SslOnConnect
            await smtp.ConnectAsync(_mailConfiguration.Host, _mailConfiguration.Port, SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(_mailConfiguration.ReceiverEmail, _mailConfiguration.Password);
            await smtp.SendAsync(email);
        }
        finally
        {
            await smtp.DisconnectAsync(true);
        }
    }
}
