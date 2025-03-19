// <Snippet2>
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Class1
{
   public static void Main()
   {
      string dateString = DateTime.Today.ToString("d",
                                        DateTimeFormatInfo.InvariantInfo);
      string resultString = MDYToDMY(dateString);
      Console.WriteLine($"Converted {dateString} to {resultString}.");
   }

   // <Snippet1>
   static string MDYToDMY(string input)
   {
      try {
         return Regex.Replace(input,
                @"\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b",
               "${day}-${month}-${year}", RegexOptions.None,
               TimeSpan.FromMilliseconds(150));
      }
      catch (RegexMatchTimeoutException) {
         return input;
      }
   }
   // </Snippet1>
}
// The example displays the following output to the console if run on 8/21/2007:
//      Converted 08/21/2007 to 21-08-2007.
// </Snippet2>
