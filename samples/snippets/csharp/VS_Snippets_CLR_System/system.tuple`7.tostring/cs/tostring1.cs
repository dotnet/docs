// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Get population data for New York City, 1960-2000.
      var population = Tuple.Create("New York", 7891957, 7781984, 
                                    7894862, 7071639, 7322564, 8008278);
      Console.WriteLine(population.ToString());
   }
}
// The example displays the following output:
//    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
// </Snippet1>
