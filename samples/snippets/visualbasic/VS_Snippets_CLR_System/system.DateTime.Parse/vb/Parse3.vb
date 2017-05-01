' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module ParseDate
   Public Sub Main()
      ' Define cultures to be used to parse dates.
      Dim cultures() As CultureInfo = {CultureInfo.CreateSpecificCulture("en-US"), _
                                       CultureInfo.CreateSpecificCulture("fr-FR"), _
                                       CultureInfo.CreateSpecificCulture("de-DE")}
      ' Define string representations of a date to be parsed.
      Dim dateStrings() As String = {"01/10/2009 7:34 PM", _
                                     "10.01.2009 19:34", _
                                     "10-1-2009 19:34" }
      ' Parse dates using each culture.
      For Each culture As CultureInfo In cultures
         Dim dateValue As Date
         Console.WriteLine("Attempted conversions using {0} culture.", culture.Name)
         For Each dateString As String In dateStrings
            Try
               dateValue = Date.Parse(dateString, culture)
               Console.WriteLine("   Converted '{0}' to {1}.", _
                                 dateString, dateValue.ToString("f", culture))
            Catch e As FormatException
               Console.WriteLine("   Unable to convert '{0}' for culture {1}.", _
                                 dateString, culture.Name)
            End Try                                                
         Next
         Console.WriteLine()
      Next                                                                                     
   End Sub
End Module
' The example displays the following output to the console:
'       Attempted conversions using en-US culture.
'          Converted '01/10/2009 7:34 PM' to Saturday, January 10, 2009 7:34 PM.
'          Converted '10.01.2009 19:34' to Thursday, October 01, 2009 7:34 PM.
'          Converted '10-1-2009 19:34' to Thursday, October 01, 2009 7:34 PM.
'       
'       Attempted conversions using fr-FR culture.
'          Converted '01/10/2009 7:34 PM' to jeudi 1 octobre 2009 19:34.
'          Converted '10.01.2009 19:34' to samedi 10 janvier 2009 19:34.
'          Converted '10-1-2009 19:34' to samedi 10 janvier 2009 19:34.
'       
'       Attempted conversions using de-DE culture.
'          Converted '01/10/2009 7:34 PM' to Donnerstag, 1. Oktober 2009 19:34.
'          Converted '10.01.2009 19:34' to Samstag, 10. Januar 2009 19:34.
'          Converted '10-1-2009 19:34' to Samstag, 10. Januar 2009 19:34.
' </Snippet3>

