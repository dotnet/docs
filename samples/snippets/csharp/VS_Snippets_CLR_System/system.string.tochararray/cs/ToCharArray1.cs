// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      String s = "AaBbCcDd";
      var chars = s.ToCharArray();
      Console.WriteLine("Original string: {0}", s);
      Console.WriteLine("Character array:");
      for (int ctr = 0; ctr < chars.Length; ctr++)
         Console.WriteLine("   {0}: {1}", ctr, chars[ctr]);
   }
}

// The example displays the following output:
//     Original string: AaBbCcDd
//     Character array:
//        0: A
//        1: a
//        2: B
//        3: b
//        4: C
//        5: c
//        6: D
//        7: d
// </Snippet1>

