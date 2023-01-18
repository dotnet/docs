Imports System
Imports System.Globalization
Imports System.Text.Json

Module Program
    Sub Main(args As String())
        Console.WriteLine("---------- Date Hebrew Calendar")
        Date_HebrewCalendar()
        Console.WriteLine(vbCrLf + "---------- Date Today")
        Date_Today()
        Console.WriteLine(vbCrLf + "---------- Date Adjust")
        Date_ChangeDays()
        Console.WriteLine(vbCrLf + "---------- Date Leap Year")
        Date_ChangeLeapYear()
        Console.WriteLine(vbCrLf + "---------- Date Parsing")
        Date_Parse()
        Console.WriteLine(vbCrLf + "---------- Date Compare")
        Date_Compare()

        Console.WriteLine(vbCrLf + "---------- Time Adjust")
        Time_ChangeTime()
        Console.WriteLine(vbCrLf + "---------- Time Parsing")
        Time_Parse()
        Console.WriteLine(vbCrLf + "---------- Time Now")
        Time_Now()
        Console.WriteLine(vbCrLf + "---------- Time Between")
        Time_Between()
        Console.WriteLine(vbCrLf + "---------- Time Convert DateTime")
        Time_DateTime()
        Console.WriteLine(vbCrLf + "---------- Time Use TimeSpan")
        Time_TimeSpan()

        Console.WriteLine(vbCrLf + "---------- DateOnly and TimeOnly Serialization")
        DateOnlyAndTimeOnlySerialization()
    End Sub

    Sub Date_HebrewCalendar()

        '<hebrew>
        Dim hebrewCalendar = New System.Globalization.HebrewCalendar()
        Dim theDate = New DateOnly(5776, 2, 8, hebrewCalendar) ' 8 Cheshvan 5776

        Console.WriteLine(theDate)

        ' This example produces the following output
        '
        ' 10/21/2015
        '</hebrew>

    End Sub

    Sub Date_Today()

        '<today>
        Dim today = DateOnly.FromDateTime(DateTime.Now)
        Console.WriteLine($"Today is {today}")

        ' This example produces output similar to the following
        ' 
        ' Today is 12/28/2022
        '</today>

    End Sub

    Sub Date_ChangeDays()

        '<date_adjust>
        Dim theDate = New DateOnly(2015, 10, 21)

        Dim nextDay = theDate.AddDays(1)
        Dim previousDay = theDate.AddDays(-1)
        Dim decadeLater = theDate.AddYears(10)
        Dim lastMonth = theDate.AddMonths(-1)

        Console.WriteLine($"Date: {theDate}")
        Console.WriteLine($" Next day: {nextDay}")
        Console.WriteLine($" Previous day: {previousDay}")
        Console.WriteLine($" Decade later: {decadeLater}")
        Console.WriteLine($" Last month: {lastMonth}")

        ' This example produces the following output
        ' 
        ' Date: 10/21/2015
        '  Next day: 10/22/2015
        '  Previous day: 10/20/2015
        '  Decade later: 10/21/2025
        '  Last month: 9/21/2015
        '</date_adjust>

    End Sub

    Sub Date_ChangeLeapYear()

        '<change_leapyear>
        Dim theDate = New DateOnly(2024, 2, 29)
        Console.WriteLine(theDate)
        Console.WriteLine(theDate.AddYears(-1))

        ' This example produces the following output
        ' 
        ' 2/29/2024
        ' 2/28/2023
        '</change_leapyear>

    End Sub

    Sub Date_Parse()

        '<parse>
        Dim theDate = DateOnly.ParseExact("21 Oct 2015", "dd MMM yyyy", CultureInfo.InvariantCulture) ' Custom format
        Dim theDate2 = DateOnly.Parse("October 21, 2015", CultureInfo.InvariantCulture)

        Console.WriteLine(theDate.ToString("m", CultureInfo.InvariantCulture))     ' Month day pattern
        Console.WriteLine(theDate2.ToString("o", CultureInfo.InvariantCulture))    ' ISO 8601 format
        Console.WriteLine(theDate2.ToLongDateString())

        ' This example produces the following output
        ' 
        ' October 21
        ' 2015-10-21
        ' Wednesday, October 21, 2015
        '</parse>

    End Sub

    Sub Date_Compare()

        '<date_compare>
        Dim theDate = DateOnly.ParseExact("21 Oct 2015", "dd MMM yyyy", CultureInfo.InvariantCulture) ' Custom format
        Dim theDate2 = DateOnly.Parse("October 21, 2015", CultureInfo.InvariantCulture)
        Dim dateLater = theDate.AddMonths(6)
        Dim dateBefore = theDate.AddDays(-10)

        Console.WriteLine($"Consider {theDate}...")
        Console.WriteLine($" Is '{NameOf(theDate2)}' equal? {theDate = theDate2}")
        Console.WriteLine($" Is {dateLater} after? {dateLater > theDate} ")
        Console.WriteLine($" Is {dateLater} before? {dateLater < theDate} ")
        Console.WriteLine($" Is {dateBefore} after? {dateBefore > theDate} ")
        Console.WriteLine($" Is {dateBefore} before? {dateBefore < theDate} ")

        ' This example produces the following output
        ' 
        ' Consider 10/21/2015
        '  Is 'theDate2' equal? True
        '  Is 4/21/2016 after? True
        '  Is 4/21/2016 before? False
        '  Is 10/11/2015 after? False
        '  Is 10/11/2015 before? True
        '</date_compare>

    End Sub

    Sub Time_ChangeTime()

        '<time_adjust>
        Dim wrappedDays As Integer
        Dim wrappedDaysFromHours As Integer

        Dim theTime = New TimeOnly(7, 23, 11)

        Dim hourLater = theTime.AddHours(1)
        Dim minutesBefore = theTime.AddMinutes(-12)
        Dim secondsAfter = theTime.Add(TimeSpan.FromSeconds(10))
        Dim daysLater = theTime.Add(New TimeSpan(hours:=21, minutes:=200, seconds:=83), wrappedDays)
        Dim daysBehind = theTime.AddHours(-222, wrappedDaysFromHours)

        Console.WriteLine($"Time: {theTime}")
        Console.WriteLine($" Hours later: {hourLater}")
        Console.WriteLine($" Minutes before: {minutesBefore}")
        Console.WriteLine($" Seconds after: {secondsAfter}")
        Console.WriteLine($" {daysLater} is the time, which is {wrappedDays} days later")
        Console.WriteLine($" {daysBehind} is the time, which is {wrappedDaysFromHours} days prior")

        ' This example produces the following output
        ' 
        ' Time: 7:23 AM
        '  Hours later: 8:23 AM
        '  Minutes before: 7:11 AM
        '  Seconds after: 7:23 AM
        '  7:44 AM is the time, which is 1 days later 
        '  1:23 AM is the time, which is -9 days prior
        '</time_adjust>

    End Sub

    Sub Time_Parse()

        '<time_parse>
        Dim theTime = TimeOnly.ParseExact("5:00 pm", "h:mm tt", CultureInfo.InvariantCulture) ' Custom format
        Dim theTime2 = TimeOnly.Parse("17:30:25", CultureInfo.InvariantCulture)

        Console.WriteLine(theTime.ToString("o", CultureInfo.InvariantCulture))     ' Round-trip pattern.
        Console.WriteLine(theTime2.ToString("t", CultureInfo.InvariantCulture))    ' Long time format
        Console.WriteLine(theTime2.ToLongTimeString())

        ' This example produces the following output
        ' 
        ' 17:00:00.0000000
        ' 17:30
        ' 5:30:25 PM
        '</time_parse>

    End Sub

    Sub Time_Now()

        '<time_now>
        Dim now = TimeOnly.FromDateTime(DateTime.Now)
        Console.WriteLine($"It is {now} right now")

        ' This example produces output similar to the following
        ' 
        ' It is 2:01 PM right now
        '</time_now>

    End Sub

    Sub Time_Between()

        '<time_between>
        Dim startDate = New TimeOnly(10, 12, 1) ' 10:12:01 AM
        Dim endDate = New TimeOnly(14, 0, 53) ' 02:00:53 PM

        Dim outside = startDate.AddMinutes(-3)
        Dim inside = startDate.AddMinutes(120)

        Console.WriteLine($"Time starts at {startDate} and ends at {endDate}")
        Console.WriteLine($" Is {outside} between the start and end? {outside.IsBetween(startDate, endDate)}")
        Console.WriteLine($" Is {inside} between the start and end? {inside.IsBetween(startDate, endDate)}")
        Console.WriteLine($" Is {startDate} less than {endDate}? {startDate < endDate}")
        Console.WriteLine($" Is {startDate} greater than {endDate}? {startDate > endDate}")
        Console.WriteLine($" Does {startDate} equal {endDate}? {startDate = endDate}")
        Console.WriteLine($" The time between {startDate} and {endDate} is {endDate - startDate}")

        ' This example produces the following output
        ' 
        ' Time starts at 10:12 AM And ends at 2:00 PM
        '  Is 10:09 AM between the start And end? False
        '  Is 12:12 PM between the start And end? True
        '  Is 10:12 AM less than 2:00 PM? True
        '  Is 10:12 AM greater than 2:00 PM? False
        '  Does 10:12 AM equal 2:00 PM? False
        '  The time between 10:12 AM and 2:00 PM is 03:48:52
        '</time_between>

    End Sub

    Sub Time_TimeSpan()

        '<time_timespan>
        ' TimeSpan must in the range of 00:00:00.0000000 to 23:59:59.9999999
        Dim theTime = TimeOnly.FromTimeSpan(New TimeSpan(23, 59, 59))
        Dim theTimeSpan = theTime.ToTimeSpan()

        Console.WriteLine($"Variable '{NameOf(theTime)}' is {theTime}")
        Console.WriteLine($"Variable '{NameOf(theTimeSpan)}' is {theTimeSpan}")

        ' This example produces the following output
        ' 
        ' Variable 'theTime' is 11:59 PM
        ' Variable 'theTimeSpan' is 23:59:59
        '</time_timespan>

    End Sub

    Sub Time_DateTime()

        '<time_datetime>
        Dim theTime = New TimeOnly(11, 25, 46) ' 11:   25 PM And 46 seconds
        Dim theDate = New DateOnly(2015, 10, 21) ' October 21, 2015
        Dim theDateTime = theDate.ToDateTime(theTime)
        Dim reverseTime = TimeOnly.FromDateTime(theDateTime)

        Console.WriteLine($"Date only is {theDate}")
        Console.WriteLine($"Time only is {theTime}")
        Console.WriteLine()
        Console.WriteLine($"Combined to a DateTime type, the value is {theDateTime}")
        Console.WriteLine($"Converted back from DateTime, the time is {reverseTime}")

        ' This example produces the following output
        ' 
        ' Date only is 10/21/2015
        ' Time only is 11:25 AM
        ' 
        ' Combined to a DateTime type, the value is 10/21/2015 11:25:46 AM
        ' Converted back from DateTime, the time is 11:25 AM
        '</time_datetime>

    End Sub

    Sub DateOnlyAndTimeOnlySerialization()
        '<serialization>
        Dim originalAppointment As New Appointment With {
            .Id = Guid.NewGuid(),
            .Description = "Take dog to veterinarian.",
            .DateValue = New DateOnly(2002, 1, 13),
            .StartTime = New TimeOnly(5, 3, 1),
            .EndTime = New TimeOnly(5, 3, 1)
}
        Dim serialized As String = JsonSerializer.Serialize(originalAppointment)

        Console.WriteLine($"Resulting JSON: {serialized}")

        Dim deserializedAppointment As Appointment =
            JsonSerializer.Deserialize(Of Appointment)(serialized)

        Dim valuesAreTheSame As Boolean =
            (originalAppointment.DateValue = deserializedAppointment.DateValue AndAlso
            originalAppointment.StartTime = deserializedAppointment.StartTime AndAlso
            originalAppointment.EndTime = deserializedAppointment.EndTime AndAlso
            originalAppointment.Id = deserializedAppointment.Id AndAlso
            originalAppointment.Description = deserializedAppointment.Description)

        Console.WriteLine(
            $"Original object has the same values as the deserialized object: {valuesAreTheSame}")
        '</serialization>
    End Sub

    '<appointment>
    Public NotInheritable Class Appointment
        Public Property Id As Guid
        Public Property Description As String
        Public Property DateValue As DateOnly?
        Public Property StartTime As TimeOnly?
        Public Property EndTime As TimeOnly?
    End Class
    '</appointment>

End Module
