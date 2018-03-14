//<Snippet1>
using System;

public class Class1
{
   public static void Main()
   {
      Tuple<string, Nullable<int>>[] scores = 
                      { new Tuple<string, Nullable<int>>("Abbey", 92), 
                        new Tuple<string, Nullable<int>>("Dave", 88),
                        new Tuple<string, Nullable<int>>("Ed", null),
                        new Tuple<string, Nullable<int>>("Jack", 78),
                        new Tuple<string, Nullable<int>>("Linda", 99),
                        new Tuple<string, Nullable<int>>("Judith", 84), 
                        new Tuple<string, Nullable<int>>("Penelope", 82),
                        new Tuple<string, Nullable<int>>("Sam", 91) }; 
      foreach (var score in scores)
         Console.WriteLine(score.ToString());
   }
}
// The example displays the following output:
//       (Abbey, 92)
//       (Dave, 88)
//       (Ed, )
//       (Jack, 78)
//       (Linda, 99)
//       (Judith, 84)
//       (Penelope, 82)
//       (Sam, 91)
// </Snippet1>