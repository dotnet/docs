// <Snippet9>
using System;

public class Example
{
   public static void Main()
   {
      String[] values = { "one", null, "two" };
      for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
         Console.Write("{0}{1}", 
                       values[ctr] != null ? values[ctr].Trim() : "", 
                       ctr == values.GetUpperBound(0) ? "" : ", "); 
      Console.WriteLine();
   }
}
// The example displays the following output:
//       one, , two
// </Snippet9>

