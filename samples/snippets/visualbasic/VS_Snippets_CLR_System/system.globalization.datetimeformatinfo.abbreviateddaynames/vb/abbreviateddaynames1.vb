' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = ci.DateTimeFormat
      dtfi.AbbreviatedDayNames = { "Su", "M", "Tu", "W", "Th",  
                                   "F", "Sa" }  
      Dim dat As Date = #05/28/2014#

      For ctr As Integer = 0 To 6 
         Dim output As String = String.Format(ci, "{0:ddd MMM dd, yyyy}", dat.AddDays(ctr))
         Console.WriteLine(output)
      Next 
   End Sub 
End Module 
' The example displays the following output:
'       W May 28, 2014
'       Th May 29, 2014
'       F May 30, 2014
'       Sa May 31, 2014
'       Su Jun 01, 2014
'       M Jun 02, 2014
'       Tu Jun 03, 2014
' </Snippet1>