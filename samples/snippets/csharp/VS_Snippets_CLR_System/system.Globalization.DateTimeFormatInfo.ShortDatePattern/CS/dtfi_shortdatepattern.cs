// <Snippet1>
using System;
using System.Globalization;
                                                                                               
public class SamplesDTFI  
{
   public static void Main()  
   {
      string[]  cultures = { "en-US", "ja-JP", "fr-FR" };
      DateTime date1 = new DateTime(2011, 5, 1);

      Console.WriteLine(" {0,7} {1,19} {2,10}\n", "CULTURE", "PROPERTY VALUE", "DATE");

      foreach (var culture in cultures) {
         DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture(culture).DateTimeFormat;
         Console.WriteLine(" {0,7} {1,19} {2,10}", culture, 
                           dtfi.ShortDatePattern, 
                           date1.ToString("d", dtfi));
      }
   }
}
// The example displays the following output:
//        CULTURE      PROPERTY VALUE       DATE
//       
//          en-US            M/d/yyyy   5/1/2011
//          ja-JP          yyyy/MM/dd 2011/05/01
//          fr-FR          dd/MM/yyyy 01/05/2011
// </Snippet1>
