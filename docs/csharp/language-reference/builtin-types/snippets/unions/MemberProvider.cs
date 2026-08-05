// <MemberProvider>
[System.Runtime.CompilerServices.Union]
public struct Outcome<T> : Outcome<T>.IUnionMembers
{
    private readonly object? _value;

    private Outcome(object? value) => _value = value;

    public interface IUnionMembers
    {
        static Outcome<T> Create(T? value) => new(value);
        static Outcome<T> Create(Exception? value) => new(value);
        object? Value { get; }

        // only when needed
        bool TryGetValue(out T value);
        bool TryGetValue(out Exception value);
    }

    object? IUnionMembers.Value => _value;

    public bool TryGetValue(out T value)
    {
        if (_value is T t)
        {
            value = t;
            return true;
        }
        value = default!;
        return false;
    }

    public bool TryGetValue(out Exception value)
    {
        if (_value is Exception e)
        {
            value = e;
            return true;
        }
        value = default!;
        return false;
    }
}
// </MemberProvider>

// <MemberProviderExample>
public static class MemberProviderScenario
{
    public static void Run()
    {
        Outcome<string> ok = "success";
        var msg = ok switch
        {
            string s => $"OK: {s}",
            Exception e => $"Error: {e.Message}",
        };
        Console.WriteLine(msg);
    }
}
// </MemberProviderExample>
