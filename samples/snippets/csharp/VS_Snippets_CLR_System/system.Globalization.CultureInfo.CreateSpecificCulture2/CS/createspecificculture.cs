// The following code example shows the results of CreateSpecificCulture with different culture types.

// <snippet1>
using System;
using System.Globalization;

public class SamplesCultureInfo
{

   public static void Main()
   {

      // Prints the header.
      Console.WriteLine("CULTURE                                              SPECIFIC CULTURE");

      // Determines the specific culture associated with each culture in the .NET Framework.
      foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
      {
         Console.Write("{0,-12} {1,-40}", ci.Name, ci.EnglishName);
         try
         {
            Console.WriteLine("{0}", CultureInfo.CreateSpecificCulture(ci.Name).Name);
         }
         catch
         {
            Console.WriteLine("(no associated specific culture)");
         }
      }

   }

}


/*
This code produces the following output.  This output has been cropped for brevity.

CULTURE                                              SPECIFIC CULTURE
ar           Arabic                                  ar-SA
bg           Bulgarian                               bg-BG
ca           Catalan                                 ca-ES
zh-Hans      Chinese (Simplified)                    zh-CN
cs           Czech                                   cs-CZ
da           Danish                                  da-DK
de           German                                  de-DE
el           Greek                                   el-GR
en           English                                 en-US
es           Spanish                                 es-ES
fi           Finnish                                 fi-FI
fr           French                                  fr-FR
he           Hebrew                                  he-IL
hu           Hungarian                               hu-HU
is           Icelandic                               is-IS
it           Italian                                 it-IT
ja           Japanese                                ja-JP
ko           Korean                                  ko-KR
nl           Dutch                                   nl-NL
no           Norwegian                               nb-NO
pl           Polish                                  pl-PL
pt           Portuguese                              pt-BR
rm           Romansh                                 rm-CH
ro           Romanian                                ro-RO
ru           Russian                                 ru-RU
hr           Croatian                                hr-HR
sk           Slovak                                  sk-SK
sq           Albanian                                sq-AL
sv           Swedish                                 sv-SE
th           Thai                                    th-TH
tr           Turkish                                 tr-TR
ur           Urdu                                    ur-PK
id           Indonesian                              id-ID
uk           Ukrainian                               uk-UA
be           Belarusian                              be-BY
sl           Slovenian                               sl-SI
et           Estonian                                et-EE
lv           Latvian                                 lv-LV
lt           Lithuanian                              lt-LT
tg           Tajik                                   tg-Cyrl-TJ
fa           Persian                                 fa-IR
vi           Vietnamese                              vi-VN
hy           Armenian                                hy-AM
az           Azerbaijani                             az-Latn-AZ
zh-TW        Chinese (Traditional, Taiwan)           zh-TW
zh-CN        Chinese (Simplified, PRC)               zh-CN
zh-HK        Chinese (Traditional, Hong Kong S.A.R.) zh-HK
zh-SG        Chinese (Simplified, Singapore)         zh-SG
zh-MO        Chinese (Traditional, Macao S.A.R.)     zh-MO
zh           Chinese                                 zh-CN
zh-Hant      Chinese (Traditional)                   zh-HK
zh-CHS       Chinese (Simplified) Legacy             zh-CN
zh-CHT       Chinese (Traditional) Legacy            zh-HK

*/
// </snippet1>
