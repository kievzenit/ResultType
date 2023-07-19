namespace ResultType;

public sealed class Error
{
    public string Message { get; private init; }

    public Error(string message)
    {
        Message = message;
    }

    public override int GetHashCode()
    {
        var hashCode = 27;

        unchecked
        {
            hashCode = (hashCode * 191) ^ Message.GetHashCode();
        }

        return hashCode;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is not Error error)
        {
            return false;
        }

        return error.Message == this.Message;
    }
}
