namespace SmartHome.Core;

// <ResultBefore>
// A conventional result type. Callers must remember to check 'IsSuccess' before
// they read 'Value', and nothing stops them from reading the wrong field.
public sealed class QueryResult<T>
{
    private QueryResult(bool isSuccess, T? value, Exception? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public bool IsSuccess { get; }
    public T? Value { get; }
    public Exception? Error { get; }

    public static QueryResult<T> Success(T value) => new(true, value, null);
    public static QueryResult<T> Failure(Exception error) => new(false, default, error);
}
// </ResultBefore>

// <ResultUnion>
// The same idea as a union declaration. A Result<T> holds either a T or an Exception.
public union Result<T>(T, Exception);
// </ResultUnion>

public static class ResultReporter
{
    // <ResultConsume>
    public static string Describe<T>(Result<T> result) => result switch
    {
        T value => $"Success: {value}",
        Exception error => $"Failure: {error.Message}",
        null => "Failure: no value",
    };
    // </ResultConsume>
}
