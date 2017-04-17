//  <Snippet6>
using System;

class Example
{
   static void Main()
   {
      for (decimal value = 4.2m; value <= 4.8m; value+=.1m )
         Console.WriteLine("{0} --> {1}", value, Math.Round(value));
   }
}
// The example displays the following output:
//       4.2 --> 4
//       4.3 --> 4
//       4.4 --> 4
//       4.5 --> 4
//       4.6 --> 5
//       4.7 --> 5
//       4.8 --> 5
// </Snippet6>
