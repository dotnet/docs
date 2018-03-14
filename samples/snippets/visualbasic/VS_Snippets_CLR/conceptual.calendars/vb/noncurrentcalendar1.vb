' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim julian As New JulianCalendar()
      Dim date1 As New Date(1905, 1, 9, julian)
      
      Console.WriteLine("Date ({0}): {1:d}", 
                        CultureInfo.CurrentCulture.Calendar,
                        date1)
      Console.WriteLine("Date in Julian calendar: {0:d2}/{1:d2}/{2:d4}",
                        julian.GetMonth(date1),
                        julian.GetDayOfMonth(date1),
                        julian.GetYear(date1))
   End Sub
End Module
' The example displays the following output:
'    Date (System.Globalization.GregorianCalendar): 1/22/1905
'    Date in Julian calendar: 01/09/1905
' </Snippet6>

