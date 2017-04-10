// <Snippet16>
using System;

public class Example
{
   public static void Main()
   {
      int[] baseValues = { 2, 8, 16};
      string[] values = { "FF", "81", "03", "11", "8F", "01", "1C", "111", 
                          "123", "18A" }; 
   
      // Convert to each supported base.
      foreach (int baseValue in baseValues)
      {
         Console.WriteLine("Converting strings in base {0}:", baseValue);
         foreach (string value in values)
         {
            Console.Write("   '{0,-5}  -->  ", value + "'");
            try {
               Console.WriteLine(Convert.ToSByte(value, baseValue));
            }   
            catch (FormatException) {
               Console.WriteLine("Bad Format");
            }   
            catch (OverflowException) {
               Console.WriteLine("Out of Range");
            }
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       Converting strings in base 2:
//          'FF'    -->  Bad Format
//          '81'    -->  Bad Format
//          '03'    -->  Bad Format
//          '11'    -->  3
//          '8F'    -->  Bad Format
//          '01'    -->  1
//          '1C'    -->  Bad Format
//          '111'   -->  7
//          '123'   -->  Bad Format
//          '18A'   -->  Bad Format
//       
//       Converting strings in base 8:
//          'FF'    -->  Bad Format
//          '81'    -->  Bad Format
//          '03'    -->  3
//          '11'    -->  9
//          '8F'    -->  Bad Format
//          '01'    -->  1
//          '1C'    -->  Bad Format
//          '111'   -->  73
//          '123'   -->  83
//          '18A'   -->  Bad Format
//       
//       Converting strings in base 16:
//          'FF'    -->  -1
//          '81'    -->  -127
//          '03'    -->  3
//          '11'    -->  17
//          '8F'    -->  -113
//          '01'    -->  1
//          '1C'    -->  28
//          '111'   -->  Out of Range
//          '123'   -->  Out of Range
//          '18A'   -->  Out of Range
// </Snippet16>
