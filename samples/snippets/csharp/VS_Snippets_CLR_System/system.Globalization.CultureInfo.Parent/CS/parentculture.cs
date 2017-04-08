// The following code example displays the parent culture of each specific culture using the Chinese language.

// <snippet1>
using System;
using System.Globalization;

public class SamplesCultureInfo
{

   public static void Main()
   {

      // Prints the header.
      Console.WriteLine("SPECIFIC CULTURE                                     PARENT CULTURE");

      // Determines the specific cultures that use the Chinese language, and displays the parent culture.
      foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
      {
         if (ci.TwoLetterISOLanguageName == "zh")
         {
            Console.Write("0x{0} {1} {2,-40}", ci.LCID.ToString("X4"), ci.Name, ci.EnglishName);
            Console.WriteLine("0x{0} {1} {2}", ci.Parent.LCID.ToString("X4"), ci.Parent.Name, ci.Parent.EnglishName);
         }
      }

   }

}

/*
This code produces the following output.

SPECIFIC CULTURE                                     PARENT CULTURE
0x0404 zh-TW Chinese (Traditional, Taiwan)           0x7C04 zh-CHT Chinese (Traditional) Legacy
0x0804 zh-CN Chinese (Simplified, PRC)               0x0004 zh-CHS Chinese (Simplified) Legacy
0x0C04 zh-HK Chinese (Traditional, Hong Kong S.A.R.) 0x7C04 zh-CHT Chinese (Traditional) Legacy
0x1004 zh-SG Chinese (Simplified, Singapore)         0x0004 zh-CHS Chinese (Simplified) Legacy
0x1404 zh-MO Chinese (Traditional, Macao S.A.R.)     0x7C04 zh-CHT Chinese (Traditional) Legacy

*/
// </snippet1>
