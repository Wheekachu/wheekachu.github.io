namespace my_portfolio_be.MailManagement.Contracts.Request;

public class EmailRequest
{
    public required string Subject { get; set; }

    public required string Email { get; set; }

    public required string Message { get; set; }
}