// <Main>
using System.Globalization;
using System.Text.RegularExpressions;

string dateString = "7/16/2008 8:32:45.126 AM";

try
{
    DateTime dateValue = DateTime.Parse(dateString);
    DateTimeOffset dateOffsetValue = DateTimeOffset.Parse(dateString);

    // Display Millisecond component alone.
    Console.WriteLine("Millisecond component only: {0}",
                    dateValue.ToString("fff"));
    Console.WriteLine("Millisecond component only: {0}",
                    dateOffsetValue.ToString("fff"));

    // Display Millisecond component with full date and time.
    Console.WriteLine("Date and Time with Milliseconds: {0}",
                    dateValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
    Console.WriteLine("Date and Time with Milliseconds: {0}",
                    dateOffsetValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));

    string fullPattern = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern;
    
    // Create a format similar to .fff but based on the current culture.
    string millisecondFormat = $"{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}fff";

    // Append millisecond pattern to current culture's full date time pattern.
    fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", $"$1{millisecondFormat}");

    // Display Millisecond component with modified full date and time pattern.
    Console.WriteLine("Modified full date time pattern: {0}",
                    dateValue.ToString(fullPattern));
    Console.WriteLine("Modified full date time pattern: {0}",
                    dateOffsetValue.ToString(fullPattern));
}
catch (FormatException)
{
    Console.WriteLine("Unable to convert {0} to a date.", dateString);
}
// The example displays the following output if the current culture is en-US:
//    Millisecond component only: 126
//    Millisecond component only: 126
//    Date and Time with Milliseconds: 07/16/2008 08:32:45.126 AM
//    Date and Time with Milliseconds: 07/16/2008 08:32:45.126 AM
//    Modified full date time pattern: Wednesday, July 16, 2008 8:32:45.126 AM
//    Modified full date time pattern: Wednesday, July 16, 2008 8:32:45.126 AM
// </Main>

public class AdditionalSnippets
{
   public static void Show()
   {
      // <TrailingZero>
      DateTime dateValue = new DateTime(2008, 7, 16, 8, 32, 45, 180);
      Console.WriteLine(dateValue.ToString("fff"));
      Console.WriteLine(dateValue.ToString("FFF"));
      // The example displays the following output to the console:
      //    180
      //    18
      // </TrailingZero>
   }

   public static void Show2()
   {
      // <Fraction>
      DateTime dateValue = new DateTime(2008, 7, 16, 8, 32, 45, 180);
      Console.WriteLine("{0} seconds", dateValue.ToString("s.f"));
      Console.WriteLine("{0} seconds", dateValue.ToString("s.ff"));
      Console.WriteLine("{0} seconds", dateValue.ToString("s.ffff"));
      // The example displays the following output to the console:
      //    45.1 seconds
      //    45.18 seconds
      //    45.1800 seconds
      // </Fraction>
   }
}
