// <ManualBasicPattern>
[System.Runtime.CompilerServices.Union]
public struct Shape : System.Runtime.CompilerServices.IUnion
{
    private readonly object? _value;

    public Shape(Circle value) { _value = value; }
    public Shape(Rectangle value) { _value = value; }

    public object? Value => _value;
}

public record class Circle(double Radius);
public record class Rectangle(double Width, double Height);
// </ManualBasicPattern>

public static class ManualUnionScenario
{
    public static void Run()
    {
        ManualUnionExample();
    }

    // <ManualUnionExample>
    static void ManualUnionExample()
    {
        Shape shape = new Shape(new Circle(5.0));

        var area = shape switch
        {
            Circle c => Math.PI * c.Radius * c.Radius,
            Rectangle r => r.Width * r.Height,
        };
        Console.WriteLine($"{area:F2}"); // output: 78.54
    }
    // </ManualUnionExample>
}
