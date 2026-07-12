using my_portfolio_be.Shared.Base;

namespace my_portfolio_be.Shared.ErrorHandling.Exception;

public class BusinessRuleValidationException : System.Exception
{
    public BusinessRuleValidationException() { }

    public BusinessRuleValidationException(IBusinessRule rule) : base(rule.Message)
    {
    }
}