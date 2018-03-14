' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateValue As Date = #06/01/2009 4:37PM#
      Dim cultures() As CultureInfo = {New CultureInfo("en-US"), _
                                       New CultureInfo("fr-FR"), _
                                       New CultureInfo("it-IT"), _
                                       New CultureInfo("de-DE") }
      For Each culture As CultureInfo In cultures
         Console.WriteLine("{0}: {1}", culture.Name, dateValue.ToString(culture))
      Next                                        
   End Sub
End Module
' The example displays the following output:
'       en-US: 6/1/2009 4:37:00 PM
'       fr-FR: 01/06/2009 16:37:00
'       it-IT: 01/06/2009 16.37.00
'       de-DE: 01.06.2009 16:37:00
' </Snippet3>
