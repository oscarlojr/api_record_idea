namespace record_idea.Utilities;

public class Result
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }

    protected Result(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Success()
    {
        return new Result(true, string.Empty);
    }

    public static Result Failure(string message)
    {
        return new Result(false, message);
    }
}

public class Result<T> : Result
{
    public T Value { get; private set; }

    protected Result(bool isSuccess, T value, string message) : base(isSuccess, message)
    {
        Value = value;
    }

    public static new Result<T> Success(T value)
    {
        return new Result<T>(true, value, string.Empty);
    }

    public static new Result<T> Failure(string message)
    {
        return new Result<T>(false, default(T), message);
    }
}