' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateStrings() As String = { "08/18/2014", "01/02/2015" }
      Dim cultureNames() As String = { "en-US", "en-GB", "fr-FR", "fi-FI" }
      
      For Each cultureName In cultureNames
         Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureName)
         Console.WriteLine("Parsing strings using the {0} culture.", 
                           culture.Name)
         For Each dateStr In dateStrings
            Try
               Console.WriteLine(String.Format(culture, 
                                 "   '{0}' --> {1:D}", dateStr, 
                                 DateTime.Parse(dateStr, culture)))
            Catch e As FormatException
               Console.WriteLine("   Unable to parse '{0}'", dateStr)
            End Try
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'       Parsing strings using the en-US culture.
'          '08/18/2014' --> Monday, August 18, 2014
'          '01/02/2015' --> Friday, January 02, 2015
'       Parsing strings using the en-GB culture.
'          Unable to parse '08/18/2014'
'          '01/02/2015' --> 01 February 2015
'       Parsing strings using the fr-FR culture.
'          Unable to parse '08/18/2014'
'          '01/02/2015' --> dimanche 1 février 2015
'       Parsing strings using the fi-FI culture.
'          Unable to parse '08/18/2014'
'          '01/02/2015' --> 1. helmikuuta 2015
' </Snippet15>
