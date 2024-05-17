' Visual Basic .NET Document
Option Strict On

' <Snippet19>
Module Example12
    Public Sub Main12()
        Dim midYear As Date = #07/01/2013#
        Console.WriteLine("{0:d} is a {1}.", midYear, GetDayName(midYear))
    End Sub

    Private Function GetDayName(dat As Date) As String
        Return dat.DayOfWeek.ToString("G")
    End Function
End Module
' The example displays the following output:
'       7/1/2013 is a Monday.
' </Snippet19>
