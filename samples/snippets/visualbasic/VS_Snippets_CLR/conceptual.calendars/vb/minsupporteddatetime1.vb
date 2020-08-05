' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub Main()
        Dim dat As Date = DateTime.MinValue

        ' Change the current culture to ja-JP with the Japanese Calendar.
        Dim jaJP As CultureInfo = CultureInfo.CreateSpecificCulture("ja-JP")
        jaJP.DateTimeFormat.Calendar = New JapaneseCalendar()
        Thread.CurrentThread.CurrentCulture = jaJP
        Console.WriteLine("Earliest supported date by {1} calendar: {0:d}",
                          jaJP.DateTimeFormat.Calendar.MinSupportedDateTime,
                          GetCalendarName(jaJP))
        ' Attempt to display the date.
        Console.WriteLine(dat.ToString())
        Console.WriteLine()

        ' Change the current culture to ar-EG with the Um Al Qura calendar.
        Dim arEG As CultureInfo = CultureInfo.CreateSpecificCulture("ar-EG")
        arEG.DateTimeFormat.Calendar = New UmAlQuraCalendar()
        Thread.CurrentThread.CurrentCulture = arEG
        Console.WriteLine("Earliest supported date by {1} calendar: {0:d}",
                          arEG.DateTimeFormat.Calendar.MinSupportedDateTime,
                          GetCalendarName(arEG))
        ' Attempt to display the date.
        Console.WRiteLine(dat.ToString())
        Console.WRiteLine()

        ' Change the current culture to en-US.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Console.WriteLine(dat.ToString(jaJP))
        Console.WriteLine(dat.ToString(arEG))
        Console.WriteLine(dat.ToString("d"))
    End Sub

    Private Function GetCalendarName(culture As CultureInfo) As String
        Dim cal As Calendar = culture.DateTimeFormat.Calendar
        Return cal.GetType().Name.Replace("System.Globalization.", "").Replace("Calendar", "")
    End Function
End Module
' The example displays the following output:
'       Earliest supported date by Japanese calendar: 明治 1/9/8
'       0001-01-01T00:00:00
'       
'       Earliest supported date by UmAlQura calendar: 01/01/18
'       0001-01-01T00:00:00
'       
'       0001-01-01T00:00:00
'       0001-01-01T00:00:00
'       1/1/0001
' </Snippet11>
