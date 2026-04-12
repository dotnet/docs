// <ClassUnion>
[System.Runtime.CompilerServices.Union]
public class Result<T> : System.Runtime.CompilerServices.IUnion
{
    private readonly object? _value;

    public Result(T? value) { _value = value; }
    public Result(Exception? value) { _value = value; }

    public object? Value => _value;
}
// </ClassUnion>

public static class ClassUnionScenario
{
    public static void Run()
    {
        ClassUnionExample();
    }

    // <ClassUnionExample>
    static void ClassUnionExample()
    {
        Result<string> ok = new Result<string>("success");
        Result<string> err = new Result<string>(new InvalidOperationException("failed"));

        Console.WriteLine(Describe(ok));  // output: OK: success
        Console.WriteLine(Describe(err)); // output: Error: failed

        static string Describe(Result<string> result) => result switch
        {
            string s => $"OK: {s}",
            Exception e => $"Error: {e.Message}",
            null => "null",
        };
    }
    // </ClassUnionExample>
}
