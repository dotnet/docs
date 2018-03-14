// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string str1 = "a";
      string str2 = str1 + "b";
      string str3 = str2 + "c";
      string[] strings = { "value", "part1" + "_" + "part2", str3, 
                           String.Empty, null };
      foreach (var value in strings) {
         if (value == null) continue;
         
         bool interned = String.IsInterned(value) != null;
         if (interned)
            Console.WriteLine("'{0}' is in the string intern pool.", 
                              value);
         else
            Console.WriteLine("'{0}' is not in the string intern pool.",
                              value);                      
      }
   }
}
// The example displays the following output:
//       'value' is in the string intern pool.
//       'part1_part2' is in the string intern pool.
//       'abc' is not in the string intern pool.
//       '' is in the string intern pool.
// </Snippet1>