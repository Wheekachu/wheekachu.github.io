using my_portfolio_be.MailManagement.Application.Common;
using my_portfolio_be.MailManagement.Contracts.Request;

namespace my_portfolio_be.MailManagement.Api.ContractMapping.cs;

public static class EmailContractMapping
{
    public static EmailOptions MapToEmailOption(this EmailRequest request)
    {
        return new EmailOptions
        {
            Subject = request.Subject,
            Email = request.Email,
            Message = request.Message
        };
    }
}
