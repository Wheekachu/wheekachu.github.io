namespace my_portfolio_be.Shared.Result;

public class SuccessResult<T> where T : class
{
    public T? Value { get; set; }

    public IEnumerable<T> Items { get; set; } = [];

    private SuccessResult(IEnumerable<T> value) => Items = value;

    private SuccessResult(T value) => Value = value;

    public static SuccessResult<T> Success(T value) => new(value);

    public static SuccessResult<T> Success(IEnumerable<T> values) => new(values);

    public static SuccessResult<T> Empty() => new([]);
}