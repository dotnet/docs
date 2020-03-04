' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Reflection

Public Class Example
   Public Shared Sub Main()
      ' Display the header.
      Console.WriteLine("{0,-53}{1}", "CULTURE", "SPECIFIC CULTURE")

      ' Get each neutral culture in the .NET Framework.
      Dim cultures() As CultureInfo = CultureInfo.GetCultures(CultureTypes.NeutralCultures)
      ' Sort the returned array by name.
      Array.Sort(Of CultureInfo)(cultures, New NamePropertyComparer(Of CultureInfo)())
      
      ' Determine the specific culture associated with each neutral culture.
      For Each culture As CultureInfo In cultures
         Console.Write("{0,-12} {1,-40}", culture.Name, culture.EnglishName)
         Try
            Console.WriteLine("{0}", CultureInfo.CreateSpecificCulture(culture.Name).Name)
         Catch e As ArgumentException
            Console.WriteLine("(no associated specific culture)")
         End Try
      Next 
   End Sub
End Class

Public Class NamePropertyComparer(Of T) : Implements IComparer(Of T)
   Public Function Compare(x As T, y As T) As Integer _
                   Implements IComparer(Of T).Compare
      If x Is Nothing Then
         If y Is Nothing Then
            Return 0
         Else
            Return -1
         End If
      End If 
      Dim pX As PropertyInfo = x.GetType().GetProperty("Name")
      Dim pY As PropertyInfo = y.GetType().GetProperty("Name")             
      Return String.Compare(CStr(pX.GetValue(x, Nothing)), CStr(pY.GetValue(y, Nothing)))
   End Function
End Class
' The example displays the following output on a Windows system.  This output has been cropped for brevity.
'    CULTURE                                              SPECIFIC CULTURE
               Invariant Language (Invariant Country)  
'    aa           Afar                                    aa-ET
'    af           Afrikaans                               af-ZA
'    agq          Aghem                                   agq-CM
'    ak           Akan                                    ak-GH
'    am           Amharic                                 am-ET
'    ar           Arabic                                  ar-SA
'    arn          Mapudungun                              arn-CL
'    as           Assamese                                as-IN
'    asa          Asu                                     asa-TZ
'    ast          Asturian                                ast-ES
'    az           Azerbaijani                             az-Latn-AZ
'    az-Cyrl      Azerbaijani (Cyrillic)                  az-Cyrl-AZ
'    az-Latn      Azerbaijani (Latin)                     az-Latn-AZ
'    ba           Bashkir                                 ba-RU
'    bas          Basaa                                   bas-CM
'    be           Belarusian                              be-BY
'    bem          Bemba                                   bem-ZM
'    bez          Bena                                    bez-TZ
'    bg           Bulgarian                               bg-BG
'    bin          Edo                                     bin-NG
'    bm           Bamanankan                              bm-Latn-ML
'    bm-Latn      Bamanankan (Latin)                      bm-Latn-ML
'    bn           Bangla                                  bn-BD
'    bo           Tibetan                                 bo-CN
'    br           Breton                                  br-FR
'    brx          Bodo                                    brx-IN
'    bs           Bosnian                                 bs-Latn-BA
'    bs-Cyrl      Bosnian (Cyrillic)                      bs-Cyrl-BA
'    bs-Latn      Bosnian (Latin)                         bs-Latn-BA
'    byn          Blin                                    byn-ER
'    ca           Catalan                                 ca-ES
'    ce           Chechen                                 ce-RU
'    cgg          Chiga                                   cgg-UG
'    chr          Cherokee                                chr-Cher-US
'    chr-Cher     Cherokee                                chr-Cher-US
'    co           Corsican                                co-FR
'    cs           Czech                                   cs-CZ
'    cu           Church Slavic                           cu-RU
'    cy           Welsh                                   cy-GB
'    da           Danish                                  da-DK
'    dav          Taita                                   dav-KE
'    de           German                                  de-DE
'    dje          Zarma                                   dje-NE
'    dsb          Lower Sorbian                           dsb-DE
'    dua          Duala                                   dua-CM
'    dv           Divehi                                  dv-MV
'    ...
'    ta           Tamil                                   ta-IN
'    te           Telugu                                  te-IN
'    teo          Teso                                    teo-UG
'    tg           Tajik                                   tg-Cyrl-TJ
'    tg-Cyrl      Tajik (Cyrillic)                        tg-Cyrl-TJ
'    th           Thai                                    th-TH
'    ti           Tigrinya                                ti-ER
'    tig          Tigre                                   tig-ER
'    tk           Turkmen                                 tk-TM
'    tn           Setswana                                tn-ZA
'    to           Tongan                                  to-TO
'    tr           Turkish                                 tr-TR
'    ts           Tsonga                                  ts-ZA
'    tt           Tatar                                   tt-RU
'    twq          Tasawaq                                 twq-NE
'    tzm          Central Atlas Tamazight                 tzm-Latn-DZ
'    tzm-Arab     Central Atlas Tamazight (Arabic)        tzm-Arab-MA
'    tzm-Latn     Central Atlas Tamazight (Latin)         tzm-Latn-DZ
'    tzm-Tfng     Central Atlas Tamazight (Tifinagh)      tzm-Tfng-MA
'    ug           Uyghur                                  ug-CN
'    uk           Ukrainian                               uk-UA
'    ur           Urdu                                    ur-PK
'    uz           Uzbek                                   uz-Latn-UZ
'    uz-Arab      Uzbek (Perso-Arabic)                    uz-Arab-AF
'    uz-Cyrl      Uzbek (Cyrillic)                        uz-Cyrl-UZ
'    uz-Latn      Uzbek (Latin)                           uz-Latn-UZ
'    vai          Vai                                     vai-Vaii-LR
'    vai-Latn     Vai (Latin)                             vai-Latn-LR
'    vai-Vaii     Vai (Vai)                               vai-Vaii-LR
'    ve           Venda                                   ve-ZA
'    vi           Vietnamese                              vi-VN
'    vo           Volapük                                 vo-001
'    vun          Vunjo                                   vun-TZ
'    wae          Walser                                  wae-CH
'    wal          Wolaytta                                wal-ET
'    wo           Wolof                                   wo-SN
'    xh           isiXhosa                                xh-ZA
'    xog          Soga                                    xog-UG
'    yav          Yangben                                 yav-CM
'    yi           Yiddish                                 yi-001
'    yo           Yoruba                                  yo-NG
'    zgh          Standard Moroccan Tamazight             zgh-Tfng-MA
'    zgh-Tfng     Standard Moroccan Tamazight (Tifinagh)  zgh-Tfng-MA
'    zh           Chinese                                 zh-CN
'    zh-CHS       Chinese (Simplified) Legacy             zh-CN
'    zh-CHT       Chinese (Traditional) Legacy            zh-HK
'    zh-Hans      Chinese (Simplified)                    zh-CN
'    zh-Hant      Chinese (Traditional)                   zh-HK
'    zu           isiZulu                                 zu-ZA
' The example displays output like the following on a Unix-based system. The output has been cropped for brevity.
CULTURE                                              SPECIFIC CULTURE
'                 Invariant Language (Invariant Country)
'    af           Afrikaans                               af-ZA
'    agq          Aghem                                   agq-CM
'    ak           Akan                                    ak-GH
'    am           Amharic                                 am-ET
'    ar           Arabic                                  ar-SA
'    as           Assamese                                as-IN
'    asa          Asu                                     asa-TZ
'    ast          Asturian                                ast-ES
'    az           Azerbaijani                             az-Latn-AZ
'    az-Cyrl      Azerbaijani                             az-Cyrl-AZ
'    az-Latn      Azerbaijani                             az-Latn-AZ
'    bas          Basaa                                   bas-CM
'    be           Belarusian                              be-BY
'    bem          Bemba                                   bem-ZM
'    bez          Bena                                    bez-TZ
'    bg           Bulgarian                               bg-BG
'    bm           Bambara                                 bm-Latn-ML
'    bn           Bangla                                  bn-BD
'    bo           Tibetan                                 bo-CN
'    br           Breton                                  br-FR
'    brx          Bodo                                    brx-IN
'    bs           Bosnian                                 bs-Latn-BA
'    bs-Cyrl      Bosnian                                 bs-Cyrl-BA
'    bs-Latn      Bosnian                                 bs-Latn-BA
'    ca           Catalan                                 ca-ES
'    ccp          Chakma
'    ce           Chechen                                 ce-RU
'    cgg          Chiga                                   cgg-UG
'    chr          Cherokee                                chr-Cher-US
'    ckb          Central Kurdish
'    cs           Czech                                   cs-CZ
'    cy           Welsh                                   cy-GB
'    da           Danish                                  da-DK
'    dav          Taita                                   dav-KE
'    de           German                                  de-DE
'    dje          Zarma                                   dje-NE
'    dsb          Lower Sorbian                           dsb-DE
'    dua          Duala                                   dua-CM
'    ...
'    ta           Tamil                                   ta-IN
'    te           Telugu                                  te-IN
'    teo          Teso                                    teo-UG
'    tg           Tajik                                   tg-Cyrl-TJ
'    th           Thai                                    th-TH
'    ti           Tigrinya                                ti-ER
'    to           Tongan                                  to-TO
'    tr           Turkish                                 tr-TR
'    tt           Tatar                                   tt-RU
'    twq          Tasawaq                                 twq-NE
'    tzm          Central Atlas Tamazight                 tzm-Latn-DZ
'    ug           Uyghur                                  ug-CN
'    uk           Ukrainian                               uk-UA
'    ur           Urdu                                    ur-PK
'    uz           Uzbek                                   uz-Latn-UZ
'    uz-Arab      Uzbek                                   uz-Arab-AF
'    uz-Cyrl      Uzbek                                   uz-Cyrl-UZ
'    uz-Latn      Uzbek                                   uz-Latn-UZ
'    vai          Vai                                     vai-Vaii-LR
'    vai-Latn     Vai                                     vai-Latn-LR
'    vai-Vaii     Vai                                     vai-Vaii-LR
'    vi           Vietnamese                              vi-VN
'    vun          Vunjo                                   vun-TZ
'    wae          Walser                                  wae-CH
'    wo           Wolof                                   wo-SN
'    xog          Soga                                    xog-UG
'    yav          Yangben                                 yav-CM
'    yi           Yiddish                                 yi-001
'    yo           Yoruba                                  yo-NG
'    yue          Cantonese                               yue-HK
'    yue-Hans     Cantonese
'    yue-Hant     Cantonese
'    zgh          Standard Moroccan Tamazight             zgh-Tfng-MA
'    zh           Chinese                                 zh-CN
'    zh-Hans      Chinese                                 zh-CN
'    zh-Hant      Chinese                                 zh-HK
'    zu           Zulu                                    zu-ZA
' </Snippet2>
