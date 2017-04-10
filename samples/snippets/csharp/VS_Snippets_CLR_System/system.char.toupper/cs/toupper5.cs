// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo[] cultures= { CultureInfo.CreateSpecificCulture("en-US"), 
                                CultureInfo.InvariantCulture, 
                                CultureInfo.CreateSpecificCulture("tr-TR") };
      Char[] chars = {'ä', 'e', 'E', 'i', 'I' };

      Console.WriteLine("Character     en-US     Invariant     tr-TR");
      foreach (var ch in chars) {
         Console.Write("    {0}", ch);
         foreach (var culture in cultures) 
            Console.Write("{0,12}", Char.ToUpper(ch, culture));

         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//       Character     en-US     Invariant     tr-TR
//           ä           Ä           Ä           Ä
//           e           E           E           E
//           E           E           E           E
//           i           I           I           İ
//           I           I           I           I
// </Snippet2>