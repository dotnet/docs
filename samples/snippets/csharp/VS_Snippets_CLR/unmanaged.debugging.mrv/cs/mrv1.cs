using System;

public class Example
{
   public static void Main()
   {
      String s = "0001";
      ConvertNumericString(s);
   }

   // <Snippet1>
   private static int ConvertNumericString(string s)
   {
      int number;
      if (s.Trim().Length == 8)
         Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber,
                        null, out number);
      else
         Int32.TryParse(s, out number);

      return number;
   }   
   // </Snippet1>
}
