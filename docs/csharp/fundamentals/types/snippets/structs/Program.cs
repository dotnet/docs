// --- Top-level statements (must precede type declarations) ---

// <ValueSemantics>
var p1 = new Point { X = 3, Y = 4 };
var p2 = p1; // copies the data
p2.X = 10;

Console.WriteLine(p1); // (3, 4)  — p1 is unchanged
Console.WriteLine(p2); // (10, 4) — only p2 was modified
// </ValueSemantics>

// <DefaultVsConstructor>
var custom = new ConnectionSettings();
Console.WriteLine($"{custom.Host}:{custom.Port} (retries: {custom.MaxRetries})");
// localhost:8080 (retries: 3)

var defaults = default(ConnectionSettings);
Console.WriteLine($"{defaults.Host ?? "(null)"}:{defaults.Port} (retries: {defaults.MaxRetries})");
// (null):0 (retries: 0)
// </DefaultVsConstructor>

// <UsingAutoDefault>
var tile = new GameTile(2, 5);
Console.WriteLine($"Tile ({tile.Row}, {tile.Column}), blocked: {tile.IsBlocked}");
// Tile (2, 5), blocked: False
// </UsingAutoDefault>

// <UsingReadonly>
var temp = new Temperature(100);
Console.WriteLine(temp); // 100.0°C (212.0°F)
// temp.Celsius = 50; // Error: property is read-only
// </UsingReadonly>

// <UsingReadonlyMembers>
var v = new Velocity { X = 3, Y = 4 };
Console.WriteLine(v.Speed); // 5
Console.WriteLine(v);       // (3, 4) speed=5.00
v.X = 6;
Console.WriteLine(v.Speed); // 7.211...
// </UsingReadonlyMembers>

// --- Type declarations ---

// <BasicStruct>
struct Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public readonly double DistanceTo(Point other)
    {
        var dx = X - other.X;
        var dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public override string ToString() => $"({X}, {Y})";
}
// </BasicStruct>

// <ParameterlessConstructor>
struct ConnectionSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public int MaxRetries { get; set; }

    public ConnectionSettings()
    {
        Host = "localhost";
        Port = 8080;
        MaxRetries = 3;
    }
}
// </ParameterlessConstructor>

// <AutoDefault>
struct GameTile
{
    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsBlocked { get; set; }

    public GameTile(int row, int column)
    {
        Row = row;
        Column = column;
        // IsBlocked is automatically initialized to false
    }
}
// </AutoDefault>

// <ReadonlyStruct>
readonly struct Temperature
{
    public double Celsius { get; }

    public Temperature(double celsius) => Celsius = celsius;

    public double Fahrenheit => Celsius * 9.0 / 5.0 + 32.0;

    public override string ToString() => $"{Celsius:F1}°C ({Fahrenheit:F1}°F)";
}
// </ReadonlyStruct>

// <ReadonlyMembers>
struct Velocity
{
    public double X
    {
        readonly get;
        set;
    }

    public double Y
    {
        readonly get;
        set;
    }

    public readonly double Speed => Math.Sqrt(X * X + Y * Y);

    public readonly override string ToString() => $"({X}, {Y}) speed={Speed:F2}";
}
// </ReadonlyMembers>
