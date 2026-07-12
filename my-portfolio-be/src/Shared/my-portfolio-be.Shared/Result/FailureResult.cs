using my_portfolio_be.Shared.ErrorHandling;

namespace my_portfolio_be.Shared.Result;

public class FailureResult : IFailureResult
{
    public List<Error> Errors { get; }

    public bool HasErrors { get; init; }

    private FailureResult(Error error) => Errors = [error];

    private FailureResult(List<Error> errors) => Errors = errors;

    public static FailureResult Throw(Error error) => new(error);

    public static FailureResult Throw(List<Error> errors) => new(errors);
}