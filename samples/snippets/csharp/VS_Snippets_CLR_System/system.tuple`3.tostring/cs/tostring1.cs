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
      Array.Sort(scores);
      foreach (var score in scores)
         Console.WriteLine(score.ToString());
   }
}
// The example displays the following output;
//    (Abbey, 92.1, 9)
//    (Dave, 88.3, 9)
//    (Ed, 71.2, 5)
//    (Jack, 78.8, 8)
//    (Judith, 84.3, 9)
//    (Linda, 99, 9)
//    (Penelope, 82.9, 8)
//    (Sam, 91.7, 8)
// </Snippet1>
