' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim localDate = DateTime.Now
      Dim cultureNames() As String = { "en-US", "en-GB", "fr-FR",
                                       "de-DE", "ru-RU" }

      For Each cultureName In cultureNames
         Dim culture As New CultureInfo(cultureName)
         Console.WriteLine("{0}: {1}", cultureName,
                           localDate.ToString(culture))
      Next
   End Sub
End Module
' The example displays the following output:
'    en-US: 6/19/2015 10:03:06 AM
'    en-GB: 19/06/2015 10:03:06
'    fr-FR: 19/06/2015 10:03:06
'    de-DE: 19.06.2015 10:03:06
'    ru-RU: 19.06.2015 10:03:06
' </Snippet2>

