' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim localDate = DateTime.Now
      Dim utcDate = DateTime.UtcNow
      Dim cultureNames() As String = { "en-US", "en-GB", "fr-FR",
                                       "de-DE", "ru-RU" }

      For Each cultureName In cultureNames
         Dim culture As New CultureInfo(cultureName)
         Console.WriteLine("{0}:", culture.NativeName)
         Console.WriteLine("   Local date and time: {0}, {1:G}",
                           localDate.ToString(culture), localDate.Kind)
         Console.WriteLine("   UTC date and time: {0}, {1:G}",
                           utcDate.ToString(culture), utcDate.Kind)
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       English (United States):
'          Local date and time: 6/19/2015 10:35:50 AM, Local
'          UTC date and time: 6/19/2015 5:35:50 PM, Utc
'
'       English (United Kingdom):
'          Local date and time: 19/06/2015 10:35:50, Local
'          UTC date and time: 19/06/2015 17:35:50, Utc
'
'       français (France):
'          Local date and time: 19/06/2015 10:35:50, Local
'          UTC date and time: 19/06/2015 17:35:50, Utc
'
'       Deutsch (Deutschland):
'          Local date and time: 19.06.2015 10:35:50, Local
'          UTC date and time: 19.06.2015 17:35:50, Utc
'
'       русский (Россия):
'          Local date and time: 19.06.2015 10:35:50, Local
'          UTC date and time: 19.06.2015 17:35:50, Utc
' </Snippet3>

