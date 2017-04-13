// <Snippet1>
using System;
using System.Threading;

public class Example
{
   public static void Main()
   {
      String output = "";
      for (int ctr = 0; ctr <= 20; ctr++) {
         output += String.Format("{0}\n", DateTime.Now.Millisecond);
         // Introduce a delay loop.
         for (int delay = 0; delay <= 1000; delay++)
         {}

         if (ctr == 10) {
            output += "Thread.Sleep called...\n";
            Thread.Sleep(5);
         }
      }
      Console.WriteLine(output);
   }
}
// The example displays the following output:
//       111
//       111
//       111
//       111
//       111
//       111
//       111
//       111
//       111
//       111
//       111
//       Thread.Sleep called...
//       143
//       143
//       143
//       143
//       143
//       143
//       143
//       143
//       143
//       143
// </Snippet1>