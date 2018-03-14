' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim date1 As Date = #11/12/2011#
      Dim cultureNames() As String = { "en-US", "fr-FR", "ru-RU", "de-DE" }
      Console.WriteLine("{0,-7} {1,-20} {2:D}", "Culture", "Long Date Pattern", "Date")
      Console.WriteLine()
      For Each cultureName In cultureNames
         Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureName)
         Console.WriteLine("{0,-7} {1,-20} {2}", culture.Name, culture.DateTimeFormat.LongDatePattern, 
                           date1.ToString("D", culture))                 
      Next
   End Sub
End Module
' The example displays the following output:
'    Culture Long Date Pattern    Date
'    en-US   dddd, MMMM dd, yyyy  Saturday, November 12, 2011
'    fr-FR   dddd d MMMM yyyy     samedi 12 novembre 2011
'    ru-RU   d MMMM yyyy 'г.'     12 ноября 2011 г.
'    de-DE   dddd, d. MMMM yyyy   Samstag, 12. November 2011
' </Snippet2>
