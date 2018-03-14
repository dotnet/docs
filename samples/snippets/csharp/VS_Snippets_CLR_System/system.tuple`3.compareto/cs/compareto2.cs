// <Snippet2>
using System;
using System.Collections;
using System.Collections.Generic;

public class ScoreComparer<T1, T2, T3> : IComparer
{
   public int Compare(object x, object y)
   {
      Tuple<T1, T2, T3> tX = x as Tuple<T1,T2, T3>;
      if (tX == null)
      { 
         return 0;
      }   
      else
      {
         Tuple<T1, T2, T3> tY = y as Tuple<T1, T2, T3>;
         return Comparer<T2>.Default.Compare(tX.Item2, tY.Item2);             
      }
   }
}

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

      Console.WriteLine("The values in unsorted order:");
      foreach (var score in scores)
         Console.WriteLine(score.ToString());

      Console.WriteLine();

      Array.Sort(scores, new ScoreComparer<string, double, int>());

      Console.WriteLine("The values in sorted order:");
      foreach (var score in scores)
         Console.WriteLine(score.ToString());
   }
}
// The example displays the following output;
//       The values in unsorted order:
//       (Jack, 78.8, 8)
//       (Abbey, 92.1, 9)
//       (Dave, 88.3, 9)
//       (Sam, 91.7, 8)
//       (Ed, 71.2, 5)
//       (Penelope, 82.9, 8)
//       (Linda, 99, 9)
//       (Judith, 84.3, 9)
//       
//       The values in sorted order:
//       (Ed, 71.2, 5)
//       (Jack, 78.8, 8)
//       (Penelope, 82.9, 8)
//       (Judith, 84.3, 9)
//       (Dave, 88.3, 9)
//       (Sam, 91.7, 8)
//       (Abbey, 92.1, 9)
//       (Linda, 99, 9)
// </Snippet2>
