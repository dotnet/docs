' Visual Basic .NET Document
Option Strict On

' <Snippet20>
Imports System.Globalization
Imports System.Threading

Module Example13
    Public Sub Main13()
        ' Set the current culture to French (France).
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR")

        Dim midYear As Date = #07/01/2013#
        Console.WriteLine("{0:d} is a {1}.", midYear, DateUtilities.GetDayName(midYear))
        Console.WriteLine("{0:d} is a {1}.", midYear, DateUtilities.GetDayName(midYear.DayOfWeek))
        Console.WriteLine("{0:d} is in {1}.", midYear, DateUtilities.GetMonthName(midYear))
        Console.WriteLine("{0:d} is in {1}.", midYear, DateUtilities.GetMonthName(midYear.Month))
    End Sub
End Module

Public Class DateUtilities
    Public Shared Function GetDayName(dayOfWeek As Integer) As String
        If dayOfWeek < 0 Or dayOfWeek > DateTimeFormatInfo.CurrentInfo.DayNames.Length Then
            Return String.Empty
        Else
            Return DateTimeFormatInfo.CurrentInfo.DayNames(dayOfWeek)
        End If
    End Function

    Public Shared Function GetDayName(dat As Date) As String
        Return dat.ToString("dddd")
    End Function

    Public Shared Function GetMonthName(month As Integer) As String
        If month < 1 Or month > DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1 Then
            Return String.Empty
        Else
            Return DateTimeFormatInfo.CurrentInfo.MonthNames(month - 1)
        End If
    End Function

    Public Shared Function GetMonthName(dat As Date) As String
        Return dat.ToString("MMMM")
    End Function
End Class
' The example displays the following output:
'       01/07/2013 is a lundi.
'       01/07/2013 is a lundi.
'       01/07/2013 is in juillet.
'       01/07/2013 is in juillet.
' </Snippet20>
