// <Snippet14>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      char[] chars = { 'a', 'X', '8', ',', ' ', '\u0009', '!' };

      foreach (char ch in chars)
         Console.WriteLine($"'{Regex.Escape(ch.ToString())}': {Char.GetUnicodeCategory(ch)}");
   }
}
// The example displays the following output:
//       'a': LowercaseLetter
//       'X': UppercaseLetter
//       '8': DecimalDigitNumber
//       ',': OtherPunctuation
//       '\ ': SpaceSeparator
//       '\t': Control
//       '!': OtherPunctuation
// </Snippet14>
