// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      String[] values1 = { "Y2K", "A2000", "DC2A6", "MMXIV", "0C3" };
      String[] values2 = { "Y2", "A2000", "DC2A6", "MMXIV_0", "0C3" };


      if (Array.TrueForAll(values1, EndsWithANumber))
         Console.WriteLine("All elements end with an integer.");
      else
         Console.WriteLine("Not all elements end with an integer.");
       
      if (Array.TrueForAll(values2, EndsWithANumber))
         Console.WriteLine("All elements end with an integer.");
      else
         Console.WriteLine("Not all elements end with an integer.");
   }

   private static bool EndsWithANumber(String value) 
   {
      int s;
      return Int32.TryParse(value.Substring(value.Length - 1), out s);
   }
}
// The example displays the following output:
//       Not all elements end with an integer.
//       All elements end with an integer.
// </Snippet2>
