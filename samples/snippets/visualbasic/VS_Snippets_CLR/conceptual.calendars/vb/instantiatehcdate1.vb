' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim hc As New HebrewCalendar()

        Dim date1 As New Date(5771, 6, 1, hc)
        Dim date2 As Date = hc.ToDateTime(5771, 6, 1, 0, 0, 0, 0)

        Console.WriteLine("{0:d} (Gregorian) = {1:d2}/{2:d2}/{3:d4} ({4}): {5}",
                          date1,
                          hc.GetMonth(date2),
                          hc.GetDayOfMonth(date2),
                          hc.GetYear(date2),
                          GetCalendarName(hc),
                          date1.Equals(date2))
    End Sub

    Private Function GetCalendarName(cal As Calendar) As String
        Return cal.ToString().Replace("System.Globalization.", "").
                              Replace("Calendar", "")
    End Function
End Module
' The example displays the following output:
'   2/5/2011 (Gregorian) = 06/01/5771 (Hebrew): True
' </Snippet4>
