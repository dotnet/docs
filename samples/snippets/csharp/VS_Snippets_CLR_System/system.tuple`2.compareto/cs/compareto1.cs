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

      Console.WriteLine("The values in unsorted order:");
      foreach (Tuple<string, Nullable<int>> score in scores)
         Console.WriteLine(score.ToString());

      Console.WriteLine();

      Array.Sort(scores);

      Console.WriteLine("The values in sorted order:");
      foreach (Tuple<string, Nullable<int>> score in scores)
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
//       (Abbey, 92)
//       (Dave, 88)
//       (Ed, )
//       (Jack, 78)
//       (Judith, 84)
//       (Linda, 99)
//       (Penelope, 82)
//       (Sam, 91)
// </Snippet1>
