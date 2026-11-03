// <NonBoxingAccessPattern>
[System.Runtime.CompilerServices.Union]
public struct IntOrBool : System.Runtime.CompilerServices.IUnion
{
    private readonly int _intValue;
    private readonly bool _boolValue;
    private readonly byte _tag; // 0 = none, 1 = int, 2 = bool

    public IntOrBool(int? value)
    {
        if (value.HasValue)
        {
            _intValue = value.Value;
            _tag = 1;
        }
    }

    public IntOrBool(bool? value)
    {
        if (value.HasValue)
        {
            _boolValue = value.Value;
            _tag = 2;
        }
    }

    public object? Value => _tag switch
    {
        1 => _intValue,
        2 => _boolValue,
        _ => null
    };

    public bool HasValue => _tag != 0;

    public bool TryGetValue(out int value)
    {
        value = _intValue;
        return _tag == 1;
    }

    public bool TryGetValue(out bool value)
    {
        value = _boolValue;
        return _tag == 2;
    }
}
// </NonBoxingAccessPattern>

public static class NonBoxingAccessScenario
{
    public static void Run()
    {
        NonBoxingExample();
    }

    // <NonBoxingExample>
    static void NonBoxingExample()
    {
        IntOrBool val = new IntOrBool((int?)42);

        var description = val switch
        {
            int i => $"int: {i}",
            bool b => $"bool: {b}",
        };
        Console.WriteLine(description); // output: int: 42
    }
    // </NonBoxingExample>
}
