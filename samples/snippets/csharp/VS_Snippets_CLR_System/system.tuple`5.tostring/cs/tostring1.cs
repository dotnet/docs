// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Define array of tuples reflecting population change by state, 1990-2000.
      Tuple<string, int, int, int, double>[] populationChanges = 
           { Tuple.Create("California", 29760021, 33871648, 4111627, 13.8), 
             Tuple.Create("Illinois", 11430602, 12419293, 988691, 8.6), 
             Tuple.Create("Washington", 4866692, 5894121, 1027429, 21.1) };
      // Display each tuple.
      foreach (var item in populationChanges)
         Console.WriteLine(item.ToString());
   }
}
// The example displays the following output:
//       (California, 29760021, 33871648, 4111627, 13.8)
//       (Illinois, 11430602, 12419293, 988691, 8.6)
//       (Washington, 4866692, 5894121, 1027429, 21.1)
// </Snippet1>