using System.Text;
using System.Text.Json;

namespace StructSerialize;

public class Program
{
    // <SerializeStruct>
    public static void Main()
    {
        var coordinates = new Coords(1.0, 2.0);
        string json = JsonSerializer.Serialize(coordinates);
        Console.WriteLine(json);

        // Output:
        // {"X":1,"Y":2}
    }

    public readonly struct Coords
    {
        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }
    // </SerializeStruct>
}
