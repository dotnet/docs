using System;

public class Example
{
   public static void Main()
   {
      // <Snippet9>
      string[] values = { "1,5304e16", "1.5304e16", "1,034.1233",
                          "1,03221", "1630.34034" };
      System.Globalization.CultureInfo[] cultures =
                        { new System.Globalization.CultureInfo("en-US"),
                          new System.Globalization.CultureInfo("fr-FR"),
                          new System.Globalization.CultureInfo("es-ES") };
      
      foreach (System.Globalization.CultureInfo culture in cultures)
      {
         Console.WriteLine("Conversions using {0} culture:", culture.Name);
         foreach (string value in values)
         {
            Console.Write("   {0,-15}  -->  ", value);
            try {
               Console.WriteLine("{0}", Convert.ToDouble(value, culture));
            }   
            catch (FormatException) {
               Console.WriteLine("Bad Format");
            }   
            catch (OverflowException) {
               Console.WriteLine("Overflow");
            }      
         }
         Console.WriteLine();
      }
      // The example displays the following output:
      //       Conversions using en-US culture:
      //          1,5304e16        -->  1.5304E+20
      //          1.5304e16        -->  1.5304E+16
      //          1,034.1233       -->  1034.1233
      //          1,03221          -->  103221
      //          1630.34034       -->  1630.34034
      //       
      //       Conversions using fr-FR culture:
      //          1,5304e16        -->  1.5304E+16
      //          1.5304e16        -->  Bad Format
      //          1,034.1233       -->  Bad Format
      //          1,03221          -->  1.03221
      //          1630.34034       -->  Bad Format
      //       
      //       Conversions using es-ES culture:
      //          1,5304e16        -->  1.5304E+16
      //          1.5304e16        -->  1.5304E+20
      //          1,034.1233       -->  Bad Format
      //          1,03221          -->  1.03221
      //          1630.34034       -->  163034034
      // </Snippet9>
   }
}
