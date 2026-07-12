namespace my_portfolio_be.MailManagement.Application.Configuration;

public class MailConfiguration
{
    public string Host { get; set; } = string.Empty;

    public int Port { get; set; }

    public string ReceiverName { get; set; } = string.Empty;

    public string ReceiverEmail { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
