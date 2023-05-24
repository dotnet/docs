using System;

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
// </Snippet1>

public class Example
{
   public static void Main()
   {
      var city = new Location("New York City");
      Console.WriteLine(city.Name);
   }
}