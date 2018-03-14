// <Snippet5>
using System;

public class Example
{
   public static void Main()
   {
      // Define an array of all format specifiers.
      string[] formats = { "N", "D", "B", "P", "X" };
      Guid guid = Guid.NewGuid();
      // Create an array of valid Guid string representations.
      string[] stringGuids = new string[formats.Length];
      for (int ctr = 0; ctr < formats.Length; ctr++)
         stringGuids[ctr] = guid.ToString(formats[ctr]);

      // Parse the strings in the array using the "B" format specifier.
      foreach (var stringGuid in stringGuids) {
         Guid newGuid;
         if (Guid.TryParseExact(stringGuid, "B", out newGuid))
            Console.WriteLine("Successfully parsed {0}", stringGuid);
         else 
            Console.WriteLine("Unable to parse '{0}'", stringGuid);
      }     
   }
}
// The example displays the following output:
//    Unable to parse 'c0fb150f6bf344df984a3a0611ae5e4a'
//    Unable to parse 'c0fb150f-6bf3-44df-984a-3a0611ae5e4a'
//    Successfully parsed {c0fb150f-6bf3-44df-984a-3a0611ae5e4a}
//    Unable to parse '(c0fb150f-6bf3-44df-984a-3a0611ae5e4a)'
//    Unable to parse '{0xc0fb150f,0x6bf3,0x44df,{0x98,0x4a,0x3a,0x06,0x11,0xae,0x5e,0x4a}}'
// </Snippet5>