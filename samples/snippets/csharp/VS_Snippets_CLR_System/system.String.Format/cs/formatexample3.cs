// <Snippet3>
using System;

public enum Color {Yellow = 1, Blue, Green};

class Example
{
   static DateTime thisDate = new DateTime(2009, 6, 30, 19, 14, 0);

   public static void Main() 
   {
      // Store the output of the String.Format method in a string.
      string s = "";
   
      // Format a negative integer or floating-point number in various ways.
      Console.WriteLine("Standard Numeric Format Strings");
      s = String.Format( 
          "(C) Currency: . . . . . . . . {0:C}\n" +
          "(D) Decimal:. . . . . . . . . {0:D}\n" +
          "(E) Scientific: . . . . . . . {1:E}\n" +
          "(F) Fixed point:. . . . . . . {1:F}\n" +
          "(G) General:. . . . . . . . . {0:G}\n" +
          "    (default):. . . . . . . . {0} (default = 'G')\n" +
          "(N) Number: . . . . . . . . . {0:N}\n" +
          "(P) Percent:. . . . . . . . . {2:P}\n" +
          "(R) Round-trip: . . . . . . . {3:R}\n" +
          "(X) Hexadecimal:. . . . . . . {0:X}\n",
          -123, -123.45, -.126, -1.5322980781265591); 
      Console.WriteLine(s);
   
      // Format a date in various ways.
      Console.WriteLine("Standard Date and Time Format Strings");
      s = String.Format(  
          "(d) Short date: . . . . . . . {0:d}\n" +
          "(D) Long date:. . . . . . . . {0:D}\n" +
          "(t) Short time: . . . . . . . {0:t}\n" +
          "(T) Long time:. . . . . . . . {0:T}\n" +
          "(f) Full date/short time: . . {0:f}\n" +
          "(F) Full date/long time:. . . {0:F}\n" +
          "(g) General date/short time:. {0:g}\n" +
          "(G) General date/long time: . {0:G}\n" +
          "    (default):. . . . . . . . {0} (default = 'G')\n" +
          "(M) Month:. . . . . . . . . . {0:M}\n" +
          "(R) RFC1123:. . . . . . . . . {0:R}\n" +
          "(s) Sortable: . . . . . . . . {0:s}\n" +
          "(u) Universal sortable: . . . {0:u} (invariant)\n" +
          "(U) Universal full: . . . . . {0:U}\n" +
          "(Y) Year: . . . . . . . . . . {0:Y}\n", 
          thisDate);
      Console.WriteLine(s);
   
      // Format an enumeration value in various ways.
      Console.WriteLine("Standard Enumeration Format Specifiers");
      s = String.Format(
          "(G) General:. . . . . . . . . {0:G}\n" +
          "    (default):. . . . . . . . {0} (default = 'G')\n" +
          "(F) Flags:. . . . . . . . . . {1:F}\n" +
          "(D) Decimal number: . . . . . {0:D}\n" +
          "(X) Hexadecimal:. . . . . . . {0:X}\n", 
          Color.Green, AttributeTargets.Class | AttributeTargets.Struct);       
      Console.WriteLine(s);
   }
}
// The example displays the following output:
//    Standard Numeric Format Specifiers
//    (C) Currency: . . . . . . . . (¤123.00)
//    (D) Decimal:. . . . . . . . . -123
//    (E) Scientific: . . . . . . . -1.234500E+002
//    (F) Fixed point:. . . . . . . -123.45
//    (G) General:. . . . . . . . . -123
//        (default):. . . . . . . . -123 (default = 'G')
//    (N) Number: . . . . . . . . . -123.00
//    (P) Percent:. . . . . . . . . -12,345.00 %
//    (R) Round-trip: . . . . . . . -123.45
//    (X) Hexadecimal:. . . . . . . FFFFFF85
//    
//    Standard DateTime Format Specifiers
//    (d) Short date: . . . . . . . 07/09/2007
//    (D) Long date:. . . . . . . . Monday, 09 July 2007
//    (t) Short time: . . . . . . . 13:48
//    (T) Long time:. . . . . . . . 13:48:05
//    (f) Full date/short time: . . Monday, 09 July 2007 13:48
//    (F) Full date/long time:. . . Monday, 09 July 2007 13:48:05
//    (g) General date/short time:. 07/09/2007 13:48
//    (G) General date/long time: . 07/09/2007 13:48:05
//        (default):. . . . . . . . 07/09/2007 13:48:05 (default = 'G')
//    (M) Month:. . . . . . . . . . July 09
//    (R) RFC1123:. . . . . . . . . Mon, 09 Jul 2007 13:48:05 GMT
//    (s) Sortable: . . . . . . . . 2007-07-09T13:48:05
//    (u) Universal sortable: . . . 2007-07-09 13:48:05Z (invariant)
//    (U) Universal full: . . . . . Monday, 09 July 2007 20:48:05
//    (Y) Year: . . . . . . . . . . 2007 July
//    
//    Standard Enumeration Format Specifiers
//    (G) General:. . . . . . . . . Green
//        (default):. . . . . . . . Green (default = 'G')
//    (F) Flags:. . . . . . . . . . Green (flags or integer)
//    (D) Decimal number: . . . . . 3
//    (X) Hexadecimal:. . . . . . . 00000003
// </Snippet3>
