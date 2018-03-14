// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      String[] values = { "Y2K", "A2000", "DC2A6", "MMXIV", "0C3" };
      if (Array.TrueForAll(values, value => {
                                      int s; 
                                      return Int32.TryParse(value.Substring(value.Length - 1), out s); }
                                   ))
         Console.WriteLine("All elements end with an integer.");
      else
         Console.WriteLine("Not all elements end with an integer.");
   }
}
// The example displays the following output:
//        Not all elements end with an integer.
// </Snippet1>
