using System.Runtime.CompilerServices;

namespace SmartHome.Core;

// <QuantityUnion>
// A custom union type. The 'union' shorthand boxes value-type cases, so a
// performance-sensitive type can implement the union pattern by hand to store
// the value without boxing. The [Union] attribute opts the struct into union
// behaviors; the non-boxing access members (HasValue and TryGetValue) let the
// compiler match each case without boxing.
[Union]
public readonly struct Quantity
{
    private readonly double _value;
    private readonly bool _isCount;

    public Quantity(int count) => (_value, _isCount) = (count, true);
    public Quantity(double measure) => (_value, _isCount) = (measure, false);

    public object Value => _isCount ? (int)_value : _value;

    public bool HasValue => true;
    public bool TryGetValue(out int value)
    {
        value = (int)_value;
        return _isCount;
    }
    public bool TryGetValue(out double value)
    {
        value = _value;
        return !_isCount;
    }
}
// </QuantityUnion>

public static class QuantityReporter
{
    // <QuantityConsume>
    public static string Describe(Quantity quantity) => quantity switch
    {
        int count => $"{count} items",
        double measure => $"{measure:F2} units",
    };
    // </QuantityConsume>
}
