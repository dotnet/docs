' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Get all available cultures on the current system.
      Dim cultures() As CultureInfo = CultureInfo.GetCultures(CultureTypes.AllCultures)

      Console.WriteLine("{0,-32} {1,-13} {2,-6}", "Display Name", 
                        "Name", "TwoLetterISOLanguageName")
      Console.WriteLine()
      For Each culture In cultures
         ' Exclude custom cultures.
         If (culture.CultureTypes And CultureTypes.UserCustomCulture) = CultureTypes.UserCustomCulture Then 
            Continue For
         End If
         
         ' Exclude all two-letter codes.
         If culture.TwoLetterISOLanguageName.Length = 2 Then Continue For
         
         Console.WriteLine("{0,-32} {1,-13} {2,-6}", culture.DisplayName,
                           culture.Name, culture.TwoLetterISOLanguageName)
      Next   
   End Sub
End Module
' The example output like the following:
'       Display Name                     Name          TwoLetterISOLanguageName
'       
'       Upper Sorbian                    hsb           hsb
'       Konkani                          kok           kok
'       Syriac                           syr           syr
'       Tamazight                        tzm           tzm
'       Filipino                         fil           fil
'       Quechua                          quz           quz
'       Sesotho sa Leboa                 nso           nso
'       Mapudungun                       arn           arn
'       Mohawk                           moh           moh
'       Alsatian                         gsw           gsw
'       Sakha                            sah           sah
'       K'iche                           qut           qut
'       Dari                             prs           prs
'       Upper Sorbian (Germany)          hsb-DE        hsb
'       Konkani (India)                  kok-IN        kok
'       Syriac (Syria)                   syr-SY        syr
'       Filipino (Philippines)           fil-PH        fil
'       Quechua (Bolivia)                quz-BO        quz
'       Sesotho sa Leboa (South Africa)  nso-ZA        nso
'       Mapudungun (Chile)               arn-CL        arn
'       Mohawk (Mohawk)                  moh-CA        moh
'       Alsatian (France)                gsw-FR        gsw
'       Sakha (Russia)                   sah-RU        sah
'       K'iche (Guatemala)               qut-GT        qut
'       Dari (Afghanistan)               prs-AF        prs
'       Lower Sorbian (Germany)          dsb-DE        dsb
'       Tamazight (Latin, Algeria)       tzm-Latn-DZ   tzm
'       Quechua (Ecuador)                quz-EC        quz
'       Quechua (Peru)                   quz-PE        quz
'       Sami, Lule (Norway)              smj-NO        smj
'       Sami, Lule (Sweden)              smj-SE        smj
'       Sami, Southern (Norway)          sma-NO        sma
'       Sami, Southern (Sweden)          sma-SE        sma
'       Sami, Skolt (Finland)            sms-FI        sms
'       Sami, Inari (Finland)            smn-FI        smn
'       Sami (Inari)                     smn           smn
'       Sami (Skolt)                     sms           sms
'       Sami (Southern)                  sma           sma
'       Lower Sorbian                    dsb           dsb
'       Sami (Lule)                      smj           smj
'       Tamazight (Latin)                tzm-Latn      tzm
' </Snippet1>
