namespace ResultType;

public class Result
{
    private static readonly Result _successfulResult = new();

    private readonly List<Error> _errors;

    public bool IsSuccess { get; private init; }
    public bool IsFailure => !IsSuccess;

    public IReadOnlyList<Error> Errors => _errors.ToList();

    protected Result()
    {
        IsSuccess = true;
        _errors = new(0);
    }

    protected Result(IEnumerable<Error> errors)
    {
        IsSuccess = false;
        _errors = new(errors);
    }

    protected Result(Error error)
    {
        IsSuccess = false;
        _errors = new(1);

        _errors.Add(error);
    }

    public static Result Success() => _successfulResult;
    public static Result Failure(IEnumerable<Error> errors) => new(errors);

    public static Result<T> Success<T>(T value) => new(value);
    public static Result<T> Failure<T>(IEnumerable<Error> errors) => new(errors);

    public static implicit operator Result(Error error) => new(error);
    public static implicit operator Result(Error[] errors) => new(errors);
    public static implicit operator Result(List<Error> errors) => new(errors);
}
