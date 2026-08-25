using FirstRecord;

namespace RecordStructDemo;

// <RecordStructDecl>
public record struct Coordinate(double Latitude, double Longitude);

public readonly record struct Temperature(double Celsius)
{
    public double Fahrenheit => Celsius * 9.0 / 5.0 + 32.0;
}
// </RecordStructDecl>

public static class Program
{
    public static void Main()
    {
        // <RecordClassVsStruct>
        // Record class — assignment copies the reference
        var p1 = new Person("Grace", "Hopper");
        var p2 = p1; // p1 and p2 point to the same object:
        Console.WriteLine(ReferenceEquals(p1, p2)); // True

        // Record struct — assignment copies the data
        var c1 = new Coordinate(47.6062, -122.3321);
        var c2 = c1;
        c2.Longitude = 0.0; // mutating c2 doesn't affect c1
        Console.WriteLine(c1.Longitude); // -122.3321
        Console.WriteLine(c2.Longitude); // 0
        // </RecordClassVsStruct>

        // <UsingRecordStruct>
        var home = new Coordinate(47.6062, -122.3321);
        var copy = home;

        Console.WriteLine(home);           // Coordinate { Latitude = 47.6062, Longitude = -122.3321 }
        Console.WriteLine(home == copy);   // True — value equality
        // </UsingRecordStruct>

        // <RecordStructWith>
        var shifted = home with { Longitude = -122.0 };
        Console.WriteLine(shifted);        // Coordinate { Latitude = 47.6062, Longitude = -122 }
        Console.WriteLine(home == shifted); // False
        // </RecordStructWith>

        var temp = new Temperature(100);
        Console.WriteLine(temp); // Temperature { Celsius = 100 }
        Console.WriteLine($"{temp.Celsius}°C = {temp.Fahrenheit}°F");
        // 100°C = 212°F
    }
}
