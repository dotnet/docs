' The following code example determines which cultures using the Chinese language are neutral cultures.

' <snippet1>
Imports System
Imports System.Globalization

Module Module1

   Public Sub Main()

      ' Lists the cultures that use the Chinese language and determines if each is a neutral culture.
      Dim ci As CultureInfo
      For Each ci In CultureInfo.GetCultures(CultureTypes.AllCultures)
         If ci.TwoLetterISOLanguageName = "zh" Then
            Console.Write("{0,-7} {1,-40}", ci.Name, ci.EnglishName)
            If ci.IsNeutralCulture Then
               Console.WriteLine(": neutral")
            Else
               Console.WriteLine(": specific")
            End If
         End If
      Next ci

   End Sub 'Main 

End Module


'This code produces the following output.
'
'zh-Hans Chinese (Simplified)                    : neutral
'zh-TW   Chinese (Traditional, Taiwan)           : specific
'zh-CN   Chinese (Simplified, PRC)               : specific
'zh-HK   Chinese (Traditional, Hong Kong S.A.R.) : specific
'zh-SG   Chinese (Simplified, Singapore)         : specific
'zh-MO   Chinese (Traditional, Macao S.A.R.)     : specific
'zh      Chinese                                 : neutral
'zh-Hant Chinese (Traditional)                   : neutral
'zh-CHS  Chinese (Simplified) Legacy             : neutral
'zh-CHT  Chinese (Traditional) Legacy            : neutral

' </snippet1>
