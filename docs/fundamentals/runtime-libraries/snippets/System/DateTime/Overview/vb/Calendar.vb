Imports System.Globalization

Module CalendarSamples
    Public Sub Snippets()
        ThaiBuddhistEra()
        ThaiBuddhistEraParse()
        InstantiateCalendar()
        CalendarFields()
        CalculateWeeks()
    End Sub

    Private Sub ThaiBuddhistEra()
        ' <Snippet1>
        Dim thTH As New CultureInfo("th-TH")
        Dim value As New DateTime(2016, 5, 28)

        Console.WriteLine(value.ToString(thTH))

        thTH.DateTimeFormat.Calendar = New GregorianCalendar()
        Console.WriteLine(value.ToString(thTH))
        ' The example displays the following output:
        '       28/5/2559 0:00:00
        '       28/5/2016 0:00:00
        ' </Snippet1>
    End Sub

    ' <Snippet2>
    Private Sub ThaiBuddhistEraParse()
        Dim thTH As New CultureInfo("th-TH")
        Dim value As DateTime = DateTime.Parse("28/5/2559", thTH)
        Console.WriteLine(value.ToString(thTH))

        thTH.DateTimeFormat.Calendar = New GregorianCalendar()
        Console.WriteLine(value.ToString(thTH))
        ' The example displays the following output:
        '       28/5/2559 0:00:00
        '       28/5/2016 0:00:00
    End Sub
    ' </Snippet2>

    Private Sub InstantiateCalendar()
        ' <Snippet3>
        Dim thTH As New CultureInfo("th-TH")
        Dim dat As New DateTime(2559, 5, 28, thTH.DateTimeFormat.Calendar)
        Console.WriteLine($"Thai Buddhist Era date: {dat.ToString("d", thTH)}")
        Console.WriteLine($"Gregorian date:   {dat:d}")
        ' The example displays the following output:
        '       Thai Buddhist Era Date:  28/5/2559
        '       Gregorian Date:     28/05/2016
        ' </Snippet3>
    End Sub

    Private Sub CalendarFields()
        ' <Snippet4>
        Dim thTH As New CultureInfo("th-TH")
        Dim cal As Calendar = thTH.DateTimeFormat.Calendar
        Dim dat As New DateTime(2559, 5, 28, cal)
        Console.WriteLine("Using the Thai Buddhist Era calendar:")
        Console.WriteLine($"Date: {dat.ToString("d", thTH)}")
        Console.WriteLine($"Year: {cal.GetYear(dat)}")
        Console.WriteLine($"Leap year: {cal.IsLeapYear(cal.GetYear(dat))}")
        Console.WriteLine()

        Console.WriteLine("Using the Gregorian calendar:")
        Console.WriteLine($"Date: {dat:d}")
        Console.WriteLine($"Year: {dat.Year}")
        Console.WriteLine($"Leap year: {DateTime.IsLeapYear(dat.Year)}")
        ' The example displays the following output:
        '       Using the Thai Buddhist Era calendar
        '       Date :   28/5/2559
        '       Year: 2559
        '       Leap year :   True
        '
        '       Using the Gregorian calendar
        '       Date :   28/05/2016
        '       Year: 2016
        '       Leap year :   True
        ' </Snippet4>
    End Sub

    Private Sub CalculateWeeks()
        ' <Snippet5>
        Dim thTH As New CultureInfo("th-TH")
        Dim thCalendar As Calendar = thTH.DateTimeFormat.Calendar
        Dim dat As New DateTime(1395, 8, 18, thCalendar)
        Console.WriteLine("Using the Thai Buddhist Era calendar:")
        Console.WriteLine($"Date: {dat.ToString("d", thTH)}")
        Console.WriteLine($"Day of Week: {thCalendar.GetDayOfWeek(dat)}")
        Console.WriteLine($"Week of year: {thCalendar.GetWeekOfYear(dat, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)}")
        Console.WriteLine()

        Dim greg As Calendar = New GregorianCalendar()
        Console.WriteLine("Using the Gregorian calendar:")
        Console.WriteLine($"Date: {dat:d}")
        Console.WriteLine($"Day of Week: {dat.DayOfWeek}")
        Console.WriteLine($"Week of year: {greg.GetWeekOfYear(dat, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)}")
        ' The example displays the following output:
        '       Using the Thai Buddhist Era calendar
        '       Date :  18/8/1395
        '       Day of Week: Sunday
        '       Week of year: 34
        '       
        '       Using the Gregorian calendar
        '       Date :  18/08/0852
        '       Day of Week: Sunday
        '       Week of year: 34
        ' </Snippet5>
    End Sub
End Module

