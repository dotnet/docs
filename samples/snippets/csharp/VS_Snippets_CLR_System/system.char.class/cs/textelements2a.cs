// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string result = String.Empty;
      for (int ctr = 0x10107; ctr <= 0x10110; ctr++)  // Range of Aegean numbers.
         result += Char.ConvertFromUtf32(ctr);

      StringInfo si = new StringInfo(result);
      Console.WriteLine("The string contains {0} characters.", 
                        si.LengthInTextElements); 
   }
}
// The example displays the following output:
//       The string contains 10 characters.
// </Snippet4>
