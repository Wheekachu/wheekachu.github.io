namespace my_portfolio_be.Shared.ErrorHandling;

public sealed record ErrorResponse(string Code, int ErrorType, string Message);