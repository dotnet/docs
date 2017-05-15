// <Snippet3>
using System;

public class Class1
{
   public static void Main()
   {
      TimeSpan[] spans = { TimeSpan.Zero, new TimeSpan(-14, 0, 0, 0, 0), 
                           new TimeSpan(1, 2, 3), 
                           new TimeSpan(0, 0, 0, 0, 250), 
                           new TimeSpan(99, 23, 59, 59, 999),
                           new TimeSpan(3, 0, 0), 
                           new TimeSpan(0, 0, 0, 0, 25) };
      string[] fmts = { "c", "g", "G", @"hh\:mm\:ss", "%m' min.'" };
      foreach (TimeSpan span in spans)
      {
         foreach (string fmt in fmts)
            Console.WriteLine("{0}: {1}", fmt, span.ToString(fmt));

         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       c: 00:00:00
//       g: 0:00:00
//       G: 0:00:00:00.0000000
//       hh\:mm\:ss: 00:00:00
//       %m' min.': 0 min.
//       
//       c: -14.00:00:00
//       g: -14:0:00:00
//       G: -14:00:00:00.0000000
//       hh\:mm\:ss: 00:00:00
//       %m' min.': 0 min.
//       
//       c: 01:02:03
//       g: 1:02:03
//       G: 0:01:02:03.0000000
//       hh\:mm\:ss: 01:02:03
//       %m' min.': 2 min.
//       
//       c: 00:00:00.2500000
//       g: 0:00:00.25
//       G: 0:00:00:00.2500000
//       hh\:mm\:ss: 00:00:00
//       %m' min.': 0 min.
//       
//       c: 99.23:59:59.9990000
//       g: 99:23:59:59.999
//       G: 99:23:59:59.9990000
//       hh\:mm\:ss: 23:59:59
//       %m' min.': 59 min.
//       
//       c: 03:00:00
//       g: 3:00:00
//       G: 0:03:00:00.0000000
//       hh\:mm\:ss: 03:00:00
//       %m' min.': 0 min.
//       
//       c: 00:00:00.0250000
//       g: 0:00:00.025
//       G: 0:00:00:00.0250000
//       hh\:mm\:ss: 00:00:00
//       %m' min.': 0 min.
// </Snippet3>