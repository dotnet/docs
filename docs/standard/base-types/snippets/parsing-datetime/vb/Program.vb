Imports System.Globalization

Module Program
    Sub Main(args As String())
        Console.WriteLine("=== DateTime Parsing Examples ===")
        DateTimeParseExample()
        DateTimeParseGermanExample()
        DateTimeParseNoDefaultExample()
        DateTimeParseExactExample()

        Console.WriteLine(Environment.NewLine & "=== DateOnly Parsing Examples ===")
        DateOnlyParseExample()
        DateOnlyParseExactExample()

        Console.WriteLine(Environment.NewLine & "=== TimeOnly Parsing Examples ===")
        TimeOnlyParseExample()
        TimeOnlyParseExactExample()
    End Sub

    '<datetime-parse>
    Sub DateTimeParseExample()
        ' Parse common date and time formats using current culture
        Dim dateTime1 = DateTime.Parse("1/15/2025 3:30 PM")
        Dim dateTime2 = DateTime.Parse("January 15, 2025")
        Dim dateTime3 = DateTime.Parse("15:30:45")

        Console.WriteLine($"Parsed: {dateTime1}")
        Console.WriteLine($"Parsed: {dateTime2}")
        Console.WriteLine($"Parsed: {dateTime3}")

        ' Parse with specific culture
        Dim germanDate = DateTime.Parse("15.01.2025", New CultureInfo("de-DE"))
        Console.WriteLine($"German date parsed: {germanDate}")
    End Sub
    '</datetime-parse>

    '<datetime-parseexact>
    Sub DateTimeParseExactExample()
        ' Parse exact format
        Dim exactDate = DateTime.ParseExact("2025-01-15T14:30:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)
        Console.WriteLine($"Exact parse: {exactDate}")

        ' Parse with custom format
        Dim customDate = DateTime.ParseExact("15/Jan/2025 2:30 PM", "dd/MMM/yyyy h:mm tt", CultureInfo.InvariantCulture)
        Console.WriteLine($"Custom format: {customDate}")
    End Sub
    '</datetime-parseexact>

    '<datetime_parse_culture>
    Sub DateTimeParseGermanExample()
        Dim MyCultureInfo As New CultureInfo("de-DE")
        Dim MyString As String = "12 Juni 2008"
        Dim MyDateTime As DateTime = DateTime.Parse(MyString, MyCultureInfo)
        Console.WriteLine(MyDateTime)
        ' The example displays the following output:
        '       6/12/2008 00:00:00
    End Sub
    '</datetime_parse_culture>

    '<datetime-parse-nodefault>
    Sub DateTimeParseNoDefaultExample()
        Dim MyCultureInfo As New CultureInfo("de-DE")
        Dim MyString As String = "12 Juni 2008"
        Dim MyDateTime As DateTime = DateTime.Parse(MyString, MyCultureInfo,
                                   DateTimeStyles.NoCurrentDateDefault)
        Console.WriteLine(MyDateTime)
        ' The example displays the following output if the current culture is en-US:
        '       6/12/2008 00:00:00
    End Sub
    '</datetime-parse-nodefault>

    '<dateonly-parse>
    Sub DateOnlyParseExample()
        ' Parse common date formats
        Dim date1 = DateOnly.Parse("1/15/2025")
        Dim date2 = DateOnly.Parse("January 15, 2025", CultureInfo.InvariantCulture)
        Dim date3 = DateOnly.Parse("2025-01-15")

        Console.WriteLine($"Parsed date: {date1}")
        Console.WriteLine($"Parsed date: {date2.ToString("D")}") ' Long date format
        Console.WriteLine($"Parsed date: {date3.ToString("yyyy-MM-dd")}")

        ' Parse with specific culture
        Dim germanDate = DateOnly.Parse("15.01.2025", New CultureInfo("de-DE"))
        Console.WriteLine($"German date: {germanDate}")
    End Sub
    '</dateonly-parse>

    '<dateonly-parseexact>
    Sub DateOnlyParseExactExample()
        ' Parse exact format
        Dim exactDate = DateOnly.ParseExact("21 Oct 2015", "dd MMM yyyy", CultureInfo.InvariantCulture)
        Console.WriteLine($"Exact date: {exactDate}")

        ' Parse ISO format
        Dim isoDate = DateOnly.ParseExact("2025-01-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
        Console.WriteLine($"ISO date: {isoDate}")

        ' Parse with multiple possible formats
        Dim formats() As String = {"MM/dd/yyyy", "M/d/yyyy", "dd/MM/yyyy"}
        Dim flexibleDate = DateOnly.ParseExact("1/15/2025", formats, CultureInfo.InvariantCulture, DateTimeStyles.None)
        Console.WriteLine($"Flexible parse: {flexibleDate}")
    End Sub
    '</dateonly-parseexact>

    '<timeonly-parse>
    Sub TimeOnlyParseExample()
        ' Parse common time formats
        Dim time1 = TimeOnly.Parse("14:30:15")
        Dim time2 = TimeOnly.Parse("2:30 PM", CultureInfo.InvariantCulture)
        Dim time3 = TimeOnly.Parse("17:45")

        Console.WriteLine($"Parsed time: {time1}")
        Console.WriteLine($"Parsed time: {time2.ToString("t")}") ' Short time format
        Console.WriteLine($"Parsed time: {time3.ToString("HH:mm")}")

        ' Parse with milliseconds
        Dim preciseTime = TimeOnly.Parse("14:30:15.123")
        Console.WriteLine($"Precise time: {preciseTime.ToString("HH:mm:ss.fff")}")
    End Sub
    '</timeonly-parse>

    '<timeonly-parseexact>
    Sub TimeOnlyParseExactExample()
        ' Parse exact format
        Dim exactTime = TimeOnly.ParseExact("5:00 pm", "h:mm tt", CultureInfo.InvariantCulture)
        Console.WriteLine($"Exact time: {exactTime}")

        ' Parse 24-hour format
        Dim militaryTime = TimeOnly.ParseExact("17:30:25", "HH:mm:ss", CultureInfo.InvariantCulture)
        Console.WriteLine($"Military time: {militaryTime}")

        ' Parse with multiple possible formats
        Dim timeFormats() As String = {"h:mm tt", "HH:mm", "H:mm"}
        Dim flexibleTime = TimeOnly.ParseExact("2:30 PM", timeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None)
        Console.WriteLine($"Flexible time parse: {flexibleTime}")
    End Sub
    '</timeonly-parseexact>
End Module