using Microsoft.AspNetCore.Mvc;
using my_portfolio_be.MailManagement.Api.ContractMapping.cs;
using my_portfolio_be.MailManagement.Api.Routing;
using my_portfolio_be.MailManagement.Application.Service;
using my_portfolio_be.MailManagement.Contracts.Request;

namespace my_portfolio_be.MailManagement.Api.Controllers;

[ApiController]
public class EmailSenderController(IEmailService emailService)
{
    [HttpPost(ApiRoute.EmailSender)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IResult> EmailSender([FromBody] EmailRequest request)
    {
        var options = request.MapToEmailOption();

        try
        {
            await emailService.SendEmailAsync(options);
            return Results.Ok("Email sent successfully!");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Failed to send email: {ex.Message}");
        }
    }
}
