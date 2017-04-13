// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      int[] frequency = new int[10];
      double number;
      Random rnd = new Random();
      
      for (int ctr = 0; ctr <= 99; ctr++) {
         number = rnd.NextDouble();
         frequency[(int) Math.Floor(number*10)] ++;
      }
      Console.WriteLine("Distribution of Random Numbers:");
      for (int ctr = frequency.GetLowerBound(0); ctr <= frequency.GetUpperBound(0); ctr++)
         Console.WriteLine("0.{0}0-0.{0}9       {1}", ctr, frequency[ctr]);
   }
}
// The following example displays output similar to the following:
//       Distribution of Random Numbers:
//       0.00-0.09       16
//       0.10-0.19       8
//       0.20-0.29       8
//       0.30-0.39       11
//       0.40-0.49       9
//       0.50-0.59       6
//       0.60-0.69       13
//       0.70-0.79       6
//       0.80-0.89       9
//       0.90-0.99       14
// </Snippet2>
