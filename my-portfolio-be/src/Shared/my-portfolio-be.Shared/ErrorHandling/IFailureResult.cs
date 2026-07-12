namespace my_portfolio_be.Shared.ErrorHandling;

public interface IFailureResult
{
    List<Error> Errors { get; }

    bool HasErrors { get; init; }
}