
// The following code example shows the results of CreateSpecificCulture with different culture types.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Prints the header.
   Console::WriteLine( "CULTURE                                              SPECIFIC CULTURE" );
   
   // Determines the specific culture associated with each culture in the .NET Framework.
   System::Collections::IEnumerator^ myEnum = CultureInfo::GetCultures( CultureTypes::AllCultures )->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      CultureInfo^ ci = dynamic_cast<CultureInfo^>(myEnum->Current);
      Console::Write( "{0, -12} {1, -40}", ci->Name, ci->EnglishName );
      try
      {
         Console::WriteLine( "{0}", CultureInfo::CreateSpecificCulture( ci->Name )->Name );
      }
      catch ( Exception^ ) 
      {
         Console::WriteLine( "(no associated specific culture)" );
      }

   }
}

/*
 The example displays the following output.  This output has been cropped for brevity.
    CULTURE                                              SPECIFIC CULTURE
               Invariant Language (Invariant Country)  
    aa           Afar                                    aa-ET
    af           Afrikaans                               af-ZA
    agq          Aghem                                   agq-CM
    ak           Akan                                    ak-GH
    am           Amharic                                 am-ET
    ar           Arabic                                  ar-SA
    arn          Mapudungun                              arn-CL
    as           Assamese                                as-IN
    asa          Asu                                     asa-TZ
    ast          Asturian                                ast-ES
    az           Azerbaijani                             az-Latn-AZ
    az-Cyrl      Azerbaijani (Cyrillic)                  az-Cyrl-AZ
    az-Latn      Azerbaijani (Latin)                     az-Latn-AZ
    ba           Bashkir                                 ba-RU
    bas          Basaa                                   bas-CM
    be           Belarusian                              be-BY
    bem          Bemba                                   bem-ZM
    bez          Bena                                    bez-TZ
    bg           Bulgarian                               bg-BG
    bin          Edo                                     bin-NG
    bm           Bamanankan                              bm-Latn-ML
    bm-Latn      Bamanankan (Latin)                      bm-Latn-ML
    bn           Bangla                                  bn-BD
    bo           Tibetan                                 bo-CN
    br           Breton                                  br-FR
    brx          Bodo                                    brx-IN
    bs           Bosnian                                 bs-Latn-BA
    bs-Cyrl      Bosnian (Cyrillic)                      bs-Cyrl-BA
    bs-Latn      Bosnian (Latin)                         bs-Latn-BA
    byn          Blin                                    byn-ER
    ca           Catalan                                 ca-ES
    ce           Chechen                                 ce-RU
    cgg          Chiga                                   cgg-UG
    chr          Cherokee                                chr-Cher-US
    chr-Cher     Cherokee                                chr-Cher-US
    co           Corsican                                co-FR
    cs           Czech                                   cs-CZ
    cu           Church Slavic                           cu-RU
    cy           Welsh                                   cy-GB
    da           Danish                                  da-DK
    dav          Taita                                   dav-KE
    de           German                                  de-DE
    dje          Zarma                                   dje-NE
    dsb          Lower Sorbian                           dsb-DE
    dua          Duala                                   dua-CM
    dv           Divehi                                  dv-MV
    ...
    ta           Tamil                                   ta-IN
    te           Telugu                                  te-IN
    teo          Teso                                    teo-UG
    tg           Tajik                                   tg-Cyrl-TJ
    tg-Cyrl      Tajik (Cyrillic)                        tg-Cyrl-TJ
    th           Thai                                    th-TH
    ti           Tigrinya                                ti-ER
    tig          Tigre                                   tig-ER
    tk           Turkmen                                 tk-TM
    tn           Setswana                                tn-ZA
    to           Tongan                                  to-TO
    tr           Turkish                                 tr-TR
    ts           Tsonga                                  ts-ZA
    tt           Tatar                                   tt-RU
    twq          Tasawaq                                 twq-NE
    tzm          Central Atlas Tamazight                 tzm-Latn-DZ
    tzm-Arab     Central Atlas Tamazight (Arabic)        tzm-Arab-MA
    tzm-Latn     Central Atlas Tamazight (Latin)         tzm-Latn-DZ
    tzm-Tfng     Central Atlas Tamazight (Tifinagh)      tzm-Tfng-MA
    ug           Uyghur                                  ug-CN
    uk           Ukrainian                               uk-UA
    ur           Urdu                                    ur-PK
    uz           Uzbek                                   uz-Latn-UZ
    uz-Arab      Uzbek (Perso-Arabic)                    uz-Arab-AF
    uz-Cyrl      Uzbek (Cyrillic)                        uz-Cyrl-UZ
    uz-Latn      Uzbek (Latin)                           uz-Latn-UZ
    vai          Vai                                     vai-Vaii-LR
    vai-Latn     Vai (Latin)                             vai-Latn-LR
    vai-Vaii     Vai (Vai)                               vai-Vaii-LR
    ve           Venda                                   ve-ZA
    vi           Vietnamese                              vi-VN
    vo           Volapük                                 vo-001
    vun          Vunjo                                   vun-TZ
    wae          Walser                                  wae-CH
    wal          Wolaytta                                wal-ET
    wo           Wolof                                   wo-SN
    xh           isiXhosa                                xh-ZA
    xog          Soga                                    xog-UG
    yav          Yangben                                 yav-CM
    yi           Yiddish                                 yi-001
    yo           Yoruba                                  yo-NG
    zgh          Standard Moroccan Tamazight             zgh-Tfng-MA
    zgh-Tfng     Standard Moroccan Tamazight (Tifinagh)  zgh-Tfng-MA
    zh           Chinese                                 zh-CN
    zh-CHS       Chinese (Simplified) Legacy             zh-CN
    zh-CHT       Chinese (Traditional) Legacy            zh-HK
    zh-Hans      Chinese (Simplified)                    zh-CN
    zh-Hant      Chinese (Traditional)                   zh-HK
    zu           isiZulu                                 zu-ZA
*/
// </snippet1>
