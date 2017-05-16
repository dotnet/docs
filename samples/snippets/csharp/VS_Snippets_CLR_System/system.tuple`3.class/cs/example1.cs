// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Tuple<string, double, int>[] scores = 
                    { Tuple.Create("Jack", 78.8, 8),
                      Tuple.Create("Abbey", 92.1, 9), 
                      Tuple.Create("Dave", 88.3, 9),
                      Tuple.Create("Sam", 91.7, 8), 
                      Tuple.Create("Ed", 71.2, 5),
                      Tuple.Create("Penelope", 82.9, 8),
                      Tuple.Create("Linda", 99.0, 9),
                      Tuple.Create("Judith", 84.3, 9) };
      var result = ComputeStatistics(scores);
      Console.WriteLine("Mean score: {0:N2} (SD={1:N2}) (n={2})", 
                        result.Item2, result.Item3, result.Item1);
   }

   private static Tuple<int, double, double> ComputeStatistics(Tuple<string, double, int>[] scores) 
   {
      int n = 0;
      double sum = 0;

      // Compute the mean.
      foreach (var score in scores)
      {
         n += score.Item3;
         sum += score.Item2 * score.Item3;
      }
      double mean = sum / n;
      
      // Compute the standard deviation.
      double ss = 0;
      foreach (var score in scores)
      {
         ss = Math.Pow(score.Item2 - mean, 2);
      }
      double sd = Math.Sqrt(ss/scores.Length);
      return Tuple.Create(scores.Length, mean, sd);
   }
}
// The example displays the following output:
//       Mean score: 87.02 (SD=0.96) (n=8)
// </Snippet1>