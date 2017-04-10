' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = ci.DateTimeFormat
      dtfi.AbbreviatedMonthNames = { "of Jan", "of Feb", "of Mar", 
                                     "of Apr", "of May", "of Jun", 
                                     "of Jul", "of Aug", "of Sep", 
                                     "of Oct", "of Nov", "of Dec", "" }  
      dtfi.AbbreviatedMonthGenitiveNames = dtfi.AbbreviatedMonthNames
      Dim dat As Date = #05/28/2012#
      
      For ctr As Integer = 0 To dtfi.Calendar.GetMonthsInYear(dat.Year) - 1
         Console.WriteLine(dat.AddMonths(ctr).ToString("dd MMM yyyy", dtfi))
      Next
   End Sub
End Module
' The example displays the following output:
'       28 of May 2012
'       28 of Jun 2012
'       28 of Jul 2012
'       28 of Aug 2012
'       28 of Sep 2012
'       28 of Oct 2012
'       28 of Nov 2012
'       28 of Dec 2012
'       28 of Jan 2013
'       28 of Feb 2013
'       28 of Mar 2013
'       28 of Apr 2013
' </Snippet1>
