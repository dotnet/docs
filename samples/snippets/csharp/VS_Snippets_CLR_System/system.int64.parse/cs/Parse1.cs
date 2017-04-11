// <Snippet1>
using System;

public class ParseInt64
{
   public static void Main()
   {
      Convert("  179042  ");
      Convert(" -2041326 ");
      Convert(" +8091522 ");
      Convert("   1064.0   ");
      Convert("  178.3");
      Convert(String.Empty);
      Convert(((decimal) Int64.MaxValue) + 1.ToString());
   }

   private static void Convert(string value)
   {
      try
      {
         long number = Int64.Parse(value);
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to convert '{0}'.", value);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0}' is out of range.", value);
      }
   }
}
// This example displays the following output to the console:
//       Converted '  179042  ' to 179042.
//       Converted ' -2041326 ' to -2041326.
//       Converted ' +8091522 ' to 8091522.
//       Unable to convert '   1064.0   '.
//       Unable to convert '  178.3'.
//       Unable to convert ''.
//       '92233720368547758071' is out of range.
// </Snippet1>
