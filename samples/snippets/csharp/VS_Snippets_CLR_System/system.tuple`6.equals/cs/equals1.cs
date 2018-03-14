// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Get population data for New York City and Los Angeles, 1960-2000.
      Tuple<string, int, int, int, int, int>[] urbanPopulations =
           { Tuple.Create("New York", 7781984, 7894862, 7071639, 7322564, 8008278),
             Tuple.Create("Los Angeles", 2479015, 2816061, 2966850, 3485398, 3694820),
             Tuple.Create("New York City", 7781984, 7894862, 7071639, 7322564, 8008278),
             Tuple.Create("New York", 7781984, 7894862, 7071639, 7322564, 8008278) };
      // Compare each tuple with every other tuple for equality.
      for (int ctr = 0; ctr <= urbanPopulations.Length - 2; ctr++)
      {                      
         var urbanPopulation = urbanPopulations[ctr];
         Console.WriteLine(urbanPopulation.ToString() + " = ");
         for (int innerCtr = ctr +1; innerCtr <= urbanPopulations.Length - 1; innerCtr++)
            Console.WriteLine("   {0}: {1}", urbanPopulations[innerCtr], 
                              urbanPopulation.Equals(urbanPopulations[innerCtr]));
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//    (New York, 7781984, 7894862, 7071639, 7322564, 8008278) =
//       (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820): False
//       (New York City, 7781984, 7894862, 7071639, 7322564, 8008278): False
//       (New York, 7781984, 7894862, 7071639, 7322564, 8008278): True
//    
//    (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820) =
//       (New York City, 7781984, 7894862, 7071639, 7322564, 8008278): False
//       (New York, 7781984, 7894862, 7071639, 7322564, 8008278): False
//    
//    (New York City, 7781984, 7894862, 7071639, 7322564, 8008278) =
//       (New York, 7781984, 7894862, 7071639, 7322564, 8008278): False
// </Snippet1>