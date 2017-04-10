// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      if (! Console.IsInputRedirected) {
         Console.WriteLine("This example requires that input be redirected from a file.");
         return; 
      }

      Console.WriteLine("About to call Console.ReadLine in a loop.");
      Console.WriteLine("----");
      String s;
      int ctr = 0;
      do {
         ctr++;
         s = Console.ReadLine();
         Console.WriteLine("Line {0}: {1}", ctr, s);
      } while (s != null);
      Console.WriteLine("---");
   }
}
// The example displays the following output:
//       About to call Console.ReadLine in a loop.
//       ----
//       Line 1: This is the first line.
//       Line 2: This is the second line.
//       Line 3: This is the third line.
//       Line 4: This is the fourth line.
//       Line 5:
//       ---
// </Snippet2>