namespace my_portfolio_be.Shared.ErrorHandling.Exception;

public class ApplicationFilingException : System.Exception
{
    public ApplicationFilingException()
    {
    }

    public ApplicationFilingException(string message) : base(message)
    {
    }
}