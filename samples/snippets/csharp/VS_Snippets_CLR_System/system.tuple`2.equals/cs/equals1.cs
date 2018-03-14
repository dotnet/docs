// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Tuple<string, Nullable<int>>[] scores = 
                      { new Tuple<string, Nullable<int>>("Dan", 90),
                        new Tuple<string, Nullable<int>>("Ernie", null),
                        new Tuple<string, Nullable<int>>("Jill", 88),
                        new Tuple<string, Nullable<int>>("Ernie", null), 
                        new Tuple<string, Nullable<int>>("Nancy", 88), 
                        new Tuple<string, Nullable<int>>("Dan", 90) };

      // Compare the Tuple objects
      for (int ctr = 0; ctr < scores.Length; ctr++)
      {
         Tuple<string, Nullable<int>> currentTuple = scores[ctr];
         for (int innerCtr = ctr + 1; innerCtr < scores.Length; innerCtr++)
         {
            Console.WriteLine("{0} = {1}: {2}", 
                              scores[ctr], scores[innerCtr], 
                              scores[ctr].Equals(scores[innerCtr]));
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       (Dan, 90) = (Ernie, ): False
//       (Dan, 90) = (Jill, 88): False
//       (Dan, 90) = (Ernie, ): False
//       (Dan, 90) = (Nancy, 88): False
//       (Dan, 90) = (Dan, 90): True
//       
//       (Ernie, ) = (Jill, 88): False
//       (Ernie, ) = (Ernie, ): True
//       (Ernie, ) = (Nancy, 88): False
//       (Ernie, ) = (Dan, 90): False
//       
//       (Jill, 88) = (Ernie, ): False
//       (Jill, 88) = (Nancy, 88): False
//       (Jill, 88) = (Dan, 90): False
//       
//       (Ernie, ) = (Nancy, 88): False
//       (Ernie, ) = (Dan, 90): False
//       
//       (Nancy, 88) = (Dan, 90): False
// </Snippet1>