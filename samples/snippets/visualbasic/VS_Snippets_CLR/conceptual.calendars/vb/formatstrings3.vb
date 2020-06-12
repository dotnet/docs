' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim date1 As Date = #8/28/2011#
        Dim cal As New JapaneseLunisolarCalendar()
        Console.WriteLine("{0} {1:d4}/{2:d2}/{3:d2}",
                          cal.GetEra(date1),
                          cal.GetYear(date1),
                          cal.GetMonth(date1),
                          cal.GetDayOfMonth(date1))

        ' Display eras
        Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("ja-JP")
        Dim dtfi As DateTimeFormatInfo = culture.DateTimeFormat
        dtfi.Calendar = New JapaneseCalendar()

        Console.WriteLine("{0} {1:d4}/{2:d2}/{3:d2}",
                          dtfi.GetAbbreviatedEraName(cal.GetEra(date1)),
                          cal.GetYear(date1),
                          cal.GetMonth(date1),
                          cal.GetDayOfMonth(date1))
    End Sub
End Module
' The example displays the following output:
'       4 0023/07/29
'       平 0023/07/29
' </Snippet10>
