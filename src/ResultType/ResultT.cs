namespace ResultType;

public sealed class Result<T> : Result
{
    public T? Value { get; private init; }

    internal Result(T value) : base()
    {
        Value = value;
    }

    internal Result(Error error) : base(error) { }

    internal Result(IEnumerable<Error> errors) : base(errors) { }

    public static explicit operator T(Result<T> result)
    {
        if (result.IsFailure)
        {
            throw new Exceptions.CannotConvertToTException(typeof(T));
        }

        return result.Value!;
    }

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Error error) => new(error);
    public static implicit operator Result<T>(Error[] errors) => new(errors);
    public static implicit operator Result<T>(List<Error> errors) => new(errors);
}
