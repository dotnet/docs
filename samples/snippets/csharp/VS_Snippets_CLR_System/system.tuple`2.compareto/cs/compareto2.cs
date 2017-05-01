// <Snippet2>
using System;
using System.Collections;
using System.Collections.Generic;

public class ScoreComparer<T1, T2> : IComparer
{
   public int Compare(object x, object y)
   {
      Tuple<T1, T2> tX = x as Tuple<T1,T2>;
      if (tX == null)
      { 
         return 0;
      }   
      else
      {
         Tuple<T1, T2> tY = y as Tuple<T1, T2>;
         return Comparer<T2>.Default.Compare(tX.Item2, tY.Item2);             
      }
   }
}

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

      Console.WriteLine("The values in unsorted order:");
      foreach (var score in scores)
         Console.WriteLine(score.ToString());

      Console.WriteLine();

      Array.Sort(scores, new ScoreComparer<string, Nullable<int>>());

      Console.WriteLine("The values in sorted order:");
      foreach (var score in scores)
         Console.WriteLine(score.ToString());
   }
}
// The example displays the following output;
//       The values in unsorted order:
//       (Jack, 78)
//       (Abbey, 92)
//       (Dave, 88)
//       (Sam, 91)
//       (Ed, )
//       (Penelope, 82)
//       (Linda, 99)
//       (Judith, 84)
//       
//       The values in sorted order:
//       (Ed, )
//       (Jack, 78)
//       (Penelope, 82)
//       (Judith, 84)
//       (Dave, 88)
//       (Sam, 91)
//       (Abbey, 92)
//       (Linda, 99)
// </Snippet2>
