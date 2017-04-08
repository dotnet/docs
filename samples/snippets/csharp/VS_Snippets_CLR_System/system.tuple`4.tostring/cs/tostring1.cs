// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Tuple<string, int, int, int>[] temperatures = 
            { Tuple.Create("New York, NY", 4, 61, 43),
              Tuple.Create("Chicago, IL", 2, 34, 18), 
              Tuple.Create("Newark, NJ", 4, 61, 43),
              Tuple.Create("Boston, MA", 6, 77, 59),
              Tuple.Create("Detroit, MI", 9, 74, 53),
              Tuple.Create("Minneapolis, MN", 8, 81, 61) }; 
      // Display the array of 4-tuple objects.
      foreach (var temperature in temperatures)
         Console.WriteLine(temperature.ToString()); 
   }
}
// The example displays the following output:
//       (New York, NY, 4, 61, 43)
//       (Chicago, IL, 2, 34, 18)
//       (Newark, NJ, 4, 61, 43)
//       (Boston, MA, 6, 77, 59)
//       (Detroit, MI, 9, 74, 53)
//       (Minneapolis, MN, 8, 81, 61)
// </Snippet1>