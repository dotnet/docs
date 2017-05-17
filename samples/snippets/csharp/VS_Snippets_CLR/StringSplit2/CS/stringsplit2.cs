// <snippet1>
using System;

public class Example
{
   public static void Main() 
   {
      string delimStr = " ,.:";
      char [] delimiter = delimStr.ToCharArray();
      string words = "one two,three:four.";
      string [] split = null;

      Console.WriteLine("The delimiters are -{0}-", delimStr);
      for (int x = 1; x <= 5; x++) {
         split = words.Split(delimiter, x);
         Console.WriteLine("\ncount = {0,2} ..............", x);
         foreach (var s in split) {
             Console.WriteLine("-{0}-", s);
         }
      }
   }
}
// The example displays the following output:
//       The delimiters are - ,.:-
//       count =  1 ..............
//       -one two,three:four.-
//       count =  2 ..............
//       -one-
//       -two,three:four.-
//       count =  3 ..............
//       -one-
//       -two-
//       -three:four.-
//       count =  4 ..............
//       -one-
//       -two-
//       -three-
//       -four.-
//       count =  5 ..............
//       -one-
//       -two-
//       -three-
//       -four-
//       --
// </snippet1>
