using my_portfolio_be.MailManagement.Application.Common;

namespace my_portfolio_be.MailManagement.Application.Service;

public interface IEmailService
{
    Task SendEmailAsync(EmailOptions emailOptions);
}