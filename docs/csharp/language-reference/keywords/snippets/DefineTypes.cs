using System;

namespace Keywords;
//<snippet15>
interface IPoint
{
    // Property signatures:
    int X { get; set; }

    int Y { get; set; }

    double Distance { get; }
}

class Point : IPoint
{
    // Constructor:
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Property implementation:
    public int X { get; set; }

    public int Y { get; set; }

    // Property implementation
    public double Distance =>
       Math.Sqrt(X * X + Y * Y);
}

class MainClass
{
    static void PrintPoint(IPoint p)
    {
        Console.WriteLine("x={0}, y={1}", p.X, p.Y);
    }

    static void Main()
    {
        IPoint p = new Point(2, 3);
        Console.Write("My Point: ");
        PrintPoint(p);
    }
}
// Output: My Point: x=2, y=3
//</snippet15>

// <SnippetDerivedInterfaces>
public interface I1
{
    void M1();
}

public interface I2 : I1
{
    void M2();
}

public class C : I2
{
    // implements I1.M1
    public void M1() { }
    // implements I2.M2
    public void M2() { }
}
// </SnippetDerivedInterfaces>