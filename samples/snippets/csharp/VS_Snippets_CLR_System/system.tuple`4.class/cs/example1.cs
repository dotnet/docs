// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      Tuple<string, decimal, int, int>[] pitchers  =  
           { Tuple.Create("McHale, Joe", 240.1m, 221, 96),
             Tuple.Create("Paul, Dave", 233.1m, 231, 84), 
             Tuple.Create("Williams, Mike", 193.2m, 183, 86),
             Tuple.Create("Blair, Jack", 168.1m, 146, 65), 
             Tuple.Create("Henry, Walt", 140.1m, 96, 30),
             Tuple.Create("Lee, Adam", 137.2m, 109, 45),
             Tuple.Create("Rohr, Don", 101.0m, 110, 42) };
      Tuple<string, double, double, double>[] results= ComputeStatistics(pitchers);

      // Display the results.
      Console.WriteLine("{0,-20} {1,9} {2,11} {3,15}\n", 
                        "Pitcher", "ERA", "Hits/Inn.", "Effectiveness");
      foreach (var result in results)
         Console.WriteLine("{0,-20} {1,9:F2} {2,11:F2} {3,15:F2}",  
                        result.Item1, result.Item2, result.Item3, result.Item4);
   }

   private static Tuple<string, double, double, double>[] ComputeStatistics(Tuple<string, decimal, int, int>[] pitchers)
   {    
      var list = new List<Tuple<string, double, double, double>>();
      Tuple<string, double, double, double> result;

      foreach (var pitcher in pitchers)
      {
         // Decimal portion of innings pitched represents 1/3 of an inning
         double innings = (double) Math.Truncate(pitcher.Item2);
         innings = innings + (((double)pitcher.Item2 - innings) * .33);
         
         double ERA = pitcher.Item4/innings * 9;
         double hitsPerInning = pitcher.Item3/innings;
         double EI = (ERA * 2 + hitsPerInning * 9)/3;
         result = new Tuple<string, double, double, double>
                           (pitcher.Item1, ERA, hitsPerInning, EI);
         list.Add(result);
      }
      return list.ToArray();
   }
}
// The example displays the following output;
//       Pitcher                    ERA   Hits/Inn.   Effectiveness
//       
//       McHale, Joe               3.60        0.92            5.16
//       Paul, Dave                3.24        0.99            5.14
//       Williams, Mike            4.01        0.95            5.52
//       Blair, Jack               3.48        0.87            4.93
//       Henry, Walt               1.93        0.69            3.34
//       Lee, Adam                 2.95        0.80            4.36
//       Rohr, Don                 3.74        1.09            5.76
// </Snippet1>