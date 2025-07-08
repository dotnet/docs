using System;

namespace ExprBodied;

// <Snippet1>
public class Location
{
   private string locationName;

   public Location(string name) => Name = name;

   public string Name
   {
      get => locationName;
      set => locationName = value;
   }
}

// Example with multiple parameters
public class Point
{
   public double X { get; }
   public double Y { get; }
   
   // Constructor with multiple parameters
   public Point(double x, double y) => (X, Y) = (x, y);
   
   // Constructor with single parameter (creates point at origin on axis)
   public Point(double coordinate) => (X, Y) = (coordinate, 0);
}
// </Snippet1>

public class Example
{
   public static void Main()
   {
      var city = new Location("New York City");
      Console.WriteLine(city.Name);
      
      // Examples with multiple constructor parameters
      var point1 = new Point(3.0, 4.0);
      var point2 = new Point(5.0);
      Console.WriteLine($"Point 1: ({point1.X}, {point1.Y})");
      Console.WriteLine($"Point 2: ({point2.X}, {point2.Y})");
   }
}