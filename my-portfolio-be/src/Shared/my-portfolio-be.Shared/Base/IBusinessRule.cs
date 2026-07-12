namespace my_portfolio_be.Shared.Base;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}