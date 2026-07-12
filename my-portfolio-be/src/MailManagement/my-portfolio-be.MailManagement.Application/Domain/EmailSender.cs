using my_portfolio_be.Shared.Base;

namespace my_portfolio_be.MailManagement.Application.Domain;

public class EmailSender : ValueObject<EmailSender>
{
    private EmailSender(string subject, string email, string message)
    {
        Subject = subject;
        Email = email;
        Message = message;
    }

    public static EmailSender Create(string subject, string email, string message)
        => new(subject, email, message);

    public string Subject { get; private set; }

    public string Email { get; private set; }

    public string Message { get; private set; }

    protected override bool EqualsCore(EmailSender other)
        => Subject == other.Subject &&
        Email == other.Email &&
        Message == other.Message;

    protected override int GetHashCodeCore()
    {
        var hashCode = new HashCode();

        hashCode.Add(GetHashCode());
        hashCode.Add(Subject);
        hashCode.Add(Email);
        hashCode.Add(Message);

        return hashCode.ToHashCode();
    }
}
