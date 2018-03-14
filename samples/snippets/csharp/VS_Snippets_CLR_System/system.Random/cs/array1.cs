// <Snippet10>
using System;

public class Example
{
   public static void Main()
   {
      String[] cities = { "Atlanta", "Boston", "Chicago", "Detroit", 
                          "Fort Wayne", "Greensboro", "Honolulu", "Indianapolis", 
                          "Jersey City", "Kansas City", "Los Angeles", 
                          "Milwaukee", "New York", "Omaha", "Philadelphia", 
                          "Raleigh", "San Francisco", "Tulsa", "Washington" };
      Random rnd = new Random();
      int index = rnd.Next(0, cities.Length);
      Console.WriteLine("Today's city of the day: {0}",
                        cities[index]);                           
   }
}
// The example displays output like the following:
//   Today's city of the day: Honolulu
// </Snippet10>
