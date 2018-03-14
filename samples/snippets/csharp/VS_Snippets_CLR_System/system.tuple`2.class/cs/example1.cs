// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Tuple<string, Nullable<int>>[] scores = 
                    { new Tuple<string, Nullable<int>>("Jack", 78),
                      new Tuple<string, Nullable<int>>("Abbey", 92), 
                      new Tuple<string, Nullable<int>>("Dave", 88),
                      new Tuple<string, Nullable<int>>("Sam", 91), 
                      new Tuple<string, Nullable<int>>("Ed", null),
                      new Tuple<string, Nullable<int>>("Penelope", 82),
                      new Tuple<string, Nullable<int>>("Linda", 99),
                      new Tuple<string, Nullable<int>>("Judith", 84) };
      int number;
      double mean = ComputeMean(scores, out number);
      Console.WriteLine("Average test score: {0:N2} (n={1})", mean, number);
   }

   private static double ComputeMean(Tuple<string, Nullable<int>>[] scores, out int n) 
   {
      n = 0;      
      int sum = 0;
      foreach (var score in scores)
      {
         if (score.Item2.HasValue)
         { 
            n += 1;
            sum += score.Item2.Value;
         }
      }     
      if (n > 0)
         return sum / (double) n;
      else
         return 0;
   }
}
// The example displays the following output:
//       Average test score: 88 (n=7)
// </Snippet1>