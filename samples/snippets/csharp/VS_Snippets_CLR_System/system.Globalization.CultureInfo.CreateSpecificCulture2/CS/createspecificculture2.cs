// <Snippet2>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // Display the header.
      Console.WriteLine("{0,-53}{1}", "CULTURE", "SPECIFIC CULTURE");

      // Get each neutral culture in the .NET Framework.
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
      // Sort the returned array by name.
      Array.Sort<CultureInfo>(cultures, new NamePropertyComparer<CultureInfo>());
      
      // Determine the specific culture associated with each neutral culture.
      foreach (var culture in cultures) 
      {
         Console.Write("{0,-12} {1,-40}", culture.Name, culture.EnglishName);
         try {
            Console.WriteLine("{0}", CultureInfo.CreateSpecificCulture(culture.Name).Name);
         }   
         catch (ArgumentException) {
            Console.WriteLine("(no associated specific culture)");
         }
      } 
   }
}

public class NamePropertyComparer<T> : IComparer<T>
{
   public int Compare(T x, T y) 
   {
      if (x == null)
         if (y == null)
            return 0;
         else
            return -1;

      PropertyInfo pX = x.GetType().GetProperty("Name");
      PropertyInfo pY = y.GetType().GetProperty("Name");             
      return String.Compare((string) pX.GetValue(x, null), (string) pY.GetValue(y, null));
   }
}
// The example displays the following output:
//    CULTURE                                              SPECIFIC CULTURE
//                 Invariant Language (Invariant Country)  
//    af           Afrikaans                               af-ZA
//    am           Amharic                                 am-ET
//    ar           Arabic                                  ar-SA
//    arn          Mapudungun                              arn-CL
//    as           Assamese                                as-IN
//    az           Azerbaijani                             az-Latn-AZ
//    az-Cyrl      Azerbaijani (Cyrillic)                  az-Cyrl-AZ
//    az-Latn      Azerbaijani (Latin)                     az-Latn-AZ
//    ba           Bashkir                                 ba-RU
//    be           Belarusian                              be-BY
//    bg           Bulgarian                               bg-BG
//    bn           Bengali                                 bn-IN
//    bo           Tibetan                                 bo-CN
//    br           Breton                                  br-FR
//    bs           Bosnian                                 bs-Latn-BA
//    bs-Cyrl      Bosnian (Cyrillic)                      bs-Cyrl-BA
//    bs-Latn      Bosnian (Latin)                         bs-Latn-BA
//    ca           Catalan                                 ca-ES
//    co           Corsican                                co-FR
//    cs           Czech                                   cs-CZ
//    cy           Welsh                                   cy-GB
//    da           Danish                                  da-DK
//    de           German                                  de-DE
//    dsb          Lower Sorbian                           dsb-DE
//    dv           Divehi                                  dv-MV
//    ...
//    ta           Tamil                                   ta-IN
//    te           Telugu                                  te-IN
//    tg           Tajik                                   tg-Cyrl-TJ
//    tg-Cyrl      Tajik (Cyrillic)                        tg-Cyrl-TJ
//    th           Thai                                    th-TH
//    tk           Turkmen                                 tk-TM
//    tn           Setswana                                tn-ZA
//    tr           Turkish                                 tr-TR
//    tt           Tatar                                   tt-RU
//    tzm          Tamazight                               tzm-Latn-DZ
//    tzm-Latn     Tamazight (Latin)                       tzm-Latn-DZ
//    ug           Uyghur                                  ug-CN
//    uk           Ukrainian                               uk-UA
//    ur           Urdu                                    ur-PK
//    uz           Uzbek                                   uz-Latn-UZ
//    uz-Cyrl      Uzbek (Cyrillic)                        uz-Cyrl-UZ
//    uz-Latn      Uzbek (Latin)                           uz-Latn-UZ
//    vi           Vietnamese                              vi-VN
//    wo           Wolof                                   wo-SN
//    xh           isiXhosa                                xh-ZA
//    yo           Yoruba                                  yo-NG
//    zh           Chinese                                 zh-CN
//    zh-CHS       Chinese (Simplified) Legacy             zh-CN
//    zh-CHT       Chinese (Traditional) Legacy            zh-HK
//    zh-Hans      Chinese (Simplified)                    zh-CN
//    zh-Hant      Chinese (Traditional)                   zh-HK
//    zu           isiZulu                                 zu-ZA
// </Snippet2>
