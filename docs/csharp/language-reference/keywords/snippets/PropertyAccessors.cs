namespace keywords;

// <GetSetAccessors>
class TimePeriod
{
    private double _seconds;

    public double Seconds
    {
        get { return _seconds; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The value of the time period must be non-negative.");
            }
            _seconds = value;
        }
    }
}
// </GetSetAccessors>

// <GetSetExpressions>
class TimePeriod2
{
    private double _seconds;

    public double Seconds
    {
        get => _seconds;
        set => _seconds = value;
    }
}
// </GetSetExpressions>

// <AutoImplementedProperties>
class TimePeriod3
{
    public double Hours { get; set; }
}
// </AutoImplementedProperties>

// <FieldBackedProperty>
class TimePeriod4
{
    public double Hours {
        get;
        set => field = (value >= 0)
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value), "The value must not be negative");
    }
}
// </FieldBackedProperty>
