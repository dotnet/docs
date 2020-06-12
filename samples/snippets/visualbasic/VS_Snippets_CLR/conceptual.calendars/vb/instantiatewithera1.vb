Imports System.Globalization

Module Example
    Public Sub Main()
        Dim year As Integer = 2
        Dim month As Integer = 1
        Dim day As Integer = 1
        Dim cal As New JapaneseCalendar()

        Console.WriteLine("Date instantiated without an era:")
        Dim date1 As New Date(year, month, day, 0, 0, 0, 0, cal)
        Console.WriteLine("{0}/{1}/{2} in Japanese Calendar -> {3:d} in Gregorian",
                          cal.GetMonth(date1), cal.GetDayOfMonth(date1),
                          cal.GetYear(date1), date1)
        Console.WriteLine()

        Console.WriteLine("Dates instantiated with eras:")
        For Each era As Integer In cal.Eras
            Dim date2 As Date = cal.ToDateTime(year, month, day, 0, 0, 0, 0, era)
            Console.WriteLine("{0}/{1}/{2} era {3} in Japanese Calendar -> {4:d} in Gregorian",
                              cal.GetMonth(date2), cal.GetDayOfMonth(date2),
                              cal.GetYear(date2), cal.GetEra(date2), date2)
        Next
    End Sub
End Module

