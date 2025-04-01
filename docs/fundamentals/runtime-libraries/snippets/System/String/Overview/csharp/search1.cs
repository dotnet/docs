// <Snippet22>
using System;
using System.Globalization;

public class Example17
{
   public static void Main()
   {
      String[] cultureNames = { "da-DK", "en-US" };
      CompareInfo ci;
      String str = "aerial";
      Char ch = 'æ';  // U+00E6
      
      Console.Write("Ordinal comparison -- ");
      Console.WriteLine($"Position of '{ch}' in {str}: {str.IndexOf(ch)}");
      
      foreach (var cultureName in cultureNames) {
         ci = CultureInfo.CreateSpecificCulture(cultureName).CompareInfo;
         Console.Write("{0} cultural comparison -- ", cultureName);
         Console.WriteLine($"Position of '{ch}' in {str}: {ci.IndexOf(str, ch)}");
      }
   }
}
// The example displays the following output:
//       Ordinal comparison -- Position of 'æ' in aerial: -1
//       da-DK cultural comparison -- Position of 'æ' in aerial: -1
//       en-US cultural comparison -- Position of 'æ' in aerial: 0
// </Snippet22>
