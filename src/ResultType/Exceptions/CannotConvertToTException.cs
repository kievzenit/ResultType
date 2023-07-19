namespace ResultType.Exceptions;

public sealed class CannotConvertToTException : ApplicationException
{
    public CannotConvertToTException(Type type)
        : base($"Result<T> cannot be converted to {type}, because Result is failure a result.") { }
}
