' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub Main()
        Dim dateValue As Date = #6/11/2008#

        ' Get weekday number using Visual Basic Weekday function
        Console.WriteLine(Weekday(dateValue))                 ' Displays 4
        ' Compare with .NET DateTime.DayOfWeek property
        Console.WriteLine(dateValue.DayOfWeek)                ' Displays 3

        ' Get weekday name using Weekday and WeekdayName functions
        Console.WriteLine(WeekdayName(Weekday(dateValue)))    ' Displays Wednesday

        ' Change culture to de-DE
        Dim originalCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
        Thread.CurrentThread.CurrentCulture = New CultureInfo("de-DE")
        ' Get weekday name using Weekday and WeekdayName functions
        Console.WriteLine(WeekdayName(Weekday(dateValue)))   ' Displays Donnerstag

        ' Restore original culture
        Thread.CurrentThread.CurrentCulture = originalCulture
    End Sub
End Module
' </Snippet9>

