using System;

namespace ExprBodiedReadonlyProperties;

// <Snippet1>
public class Location
{
   private string locationName;

   public Location(string name)
   {
      locationName = name;
   }

   public string Name => locationName;
}
// </Snippet1>

public class Example
{
   public static void Main()
   {
      var city = new Location("New York City");
      Console.WriteLine(city.Name);
   }
}
