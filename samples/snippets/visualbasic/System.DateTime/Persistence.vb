Imports System.Globalization
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports System.Xml.Serialization
Imports SystemDateTimeReference.DateTimeExtensions

Module Persistence
    Private Const filenameTxt As String = ".\BadDates.txt"
    Sub Snippets()
        File.Delete(filenameTxt)
        PersistAsLocalStrings()
        File.Delete(filenameTxt)
        PersistAsInvariantStrings()
        File.Delete(filenameTxt)
        File.Delete(filenameInts)
        PersistAsIntegers()
        File.Delete(filenameInts)

        File.Delete(filenameXml)
        PersistAsXml()
        File.Delete(filenameXml)

        File.Delete(filenameBin)
        PersistBinary()
        File.Delete(filenameBin)

        SaveDateWithTimeZone()
        RestoreDateWithTimeZone()
    End Sub

    ' <Snippet1>
    Public Sub PersistAsLocalStrings()
        SaveDatesAsStrings()
        RestoreDatesAsStrings()
    End Sub

    Private Sub SaveDatesAsStrings()
        Dim dates As Date() = {#6/14/2014 6:32AM#, #7/10/2014 11:49PM#,
                              #1/10/2015 1:16AM#, #12/20/2014 9:45PM#,
                              #6/2/2014 3:14PM#}
        Dim output As String = Nothing

        Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}")
        Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        For ctr As Integer = 0 To dates.Length - 1
            Console.WriteLine(dates(ctr).ToString("f"))
            output += dates(ctr).ToString() + If(ctr <> dates.Length - 1, "|", "")
        Next
        Dim sw As New StreamWriter(filenameTxt)
        sw.Write(output)
        sw.Close()
        Console.WriteLine("Saved dates...")
    End Sub

    Private Sub RestoreDatesAsStrings()
        TimeZoneInfo.ClearCachedData()
        Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        Dim sr As New StreamReader(filenameTxt)
        Dim inputValues As String() = sr.ReadToEnd().Split({"|"c}, StringSplitOptions.RemoveEmptyEntries)
        sr.Close()
        Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        For Each inputValue In inputValues
            Dim dateValue As Date
            If DateTime.TryParse(inputValue, dateValue) Then
                Console.WriteLine($"'{inputValue}' --> {dateValue:f}")
            Else
                Console.WriteLine($"Cannot parse '{inputValue}'")
            End If
        Next
        Console.WriteLine("Restored dates...")
    End Sub
    ' When saved on an en-US system, the example displays the following output:
    '       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
    '       The dates on an en-US system:
    '       Saturday, June 14, 2014 6:32 AM
    '       Thursday, July 10, 2014 11:49 PM
    '       Saturday, January 10, 2015 1:16 AM
    '       Saturday, December 20, 2014 9:45 PM
    '       Monday, June 02, 2014 3:14 PM
    '       Saved dates...
    '
    ' When restored on an en-GB system, the example displays the following output:
    '       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
    '       The dates on an en-GB system:
    '       Cannot parse '6/14/2014 6:32:00 AM'
    '       '7/10/2014 11:49:00 PM' --> 07 October 2014 23:49
    '       '1/10/2015 1:16:00 AM' --> 01 October 2015 01:16
    '       Cannot parse '12/20/2014 9:45:00 PM'
    '       '6/2/2014 3:14:00 PM' --> 06 February 2014 15:14
    '       Restored dates...
    ' </Snippet1>

    ' <Snippet2>
    Public Sub PersistAsInvariantStrings()
        SaveDatesAsInvariantStrings()
        RestoreDatesAsInvariantStrings()
    End Sub

    Private Sub SaveDatesAsInvariantStrings()
        Dim dates As Date() = {#6/14/2014 6:32AM#, #7/10/2014 11:49PM#,
                              #1/10/2015 1:16AM#, #12/20/2014 9:45PM#,
                              #6/2/2014 3:14PM#}
        Dim output As String = Nothing

        Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}")
        Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        For ctr As Integer = 0 To dates.Length - 1
            Console.WriteLine(dates(ctr).ToString("f"))
            output += dates(ctr).ToUniversalTime().ToString("O", CultureInfo.InvariantCulture) +
                                       If(ctr <> dates.Length - 1, "|", "")
        Next
        Dim sw As New StreamWriter(filenameTxt)
        sw.Write(output)
        sw.Close()
        Console.WriteLine("Saved dates...")
    End Sub

    Private Sub RestoreDatesAsInvariantStrings()
        TimeZoneInfo.ClearCachedData()
        Console.WriteLine("Current Time Zone: {0}",
                        TimeZoneInfo.Local.DisplayName)
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        Dim sr As New StreamReader(filenameTxt)
        Dim inputValues As String() = sr.ReadToEnd().Split({"|"c}, StringSplitOptions.RemoveEmptyEntries)
        sr.Close()
        Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        For Each inputValue In inputValues
            Dim dateValue As Date
            If DateTime.TryParseExact(inputValue, "O", CultureInfo.InvariantCulture,
                              DateTimeStyles.RoundtripKind, dateValue) Then
                Console.WriteLine($"'{inputValue}' --> {dateValue.ToLocalTime():f}")
            Else
                Console.WriteLine($"Cannot parse '{inputValue}'")
            End If
        Next
        Console.WriteLine("Restored dates...")
    End Sub
    ' When saved on an en-US system, the example displays the following output:
    '       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
    '       The dates on an en-US system:
    '       Saturday, June 14, 2014 6:32 AM
    '       Thursday, July 10, 2014 11:49 PM
    '       Saturday, January 10, 2015 1:16 AM
    '       Saturday, December 20, 2014 9:45 PM
    '       Monday, June 02, 2014 3:14 PM
    '       Saved dates...
    '
    ' When restored on an en-GB system, the example displays the following output:
    '       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
    '       The dates on an en-GB system:
    '       '2014-06-14T13:32:00.0000000Z' --> 14 June 2014 14:32
    '       '2014-07-11T06:49:00.0000000Z' --> 11 July 2014 07:49
    '       '2015-01-10T09:16:00.0000000Z' --> 10 January 2015 09:16
    '       '2014-12-21T05:45:00.0000000Z' --> 21 December 2014 05:45
    '       '2014-06-02T22:14:00.0000000Z' --> 02 June 2014 23:14
    '       Restored dates...
    ' </Snippet2>

    Private Const filenameInts As String = ".\IntDates.bin"

    ' <Snippet3>
    Public Sub PersistAsIntegers()
        SaveDatesAsIntegers()
        RestoreDatesAsIntegers()
    End Sub

    Private Sub SaveDatesAsIntegers()
        Dim dates As Date() = {#6/14/2014 6:32AM#, #7/10/2014 11:49PM#,
                              #1/10/2015 1:16AM#, #12/20/2014 9:45PM#,
                              #6/2/2014 3:14PM#}

        Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}")
        Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        Dim ticks(dates.Length - 1) As Long
        For ctr As Integer = 0 To dates.Length - 1
            Console.WriteLine(dates(ctr).ToString("f"))
            ticks(ctr) = dates(ctr).ToUniversalTime().Ticks
        Next
        Dim fs As New FileStream(filenameInts, FileMode.Create)
        Dim bw As New BinaryWriter(fs)
        bw.Write(ticks.Length)
        For Each tick In ticks
            bw.Write(tick)
        Next
        bw.Close()
        Console.WriteLine("Saved dates...")
    End Sub

    Private Sub RestoreDatesAsIntegers()
        TimeZoneInfo.ClearCachedData()
        Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        Dim fs As New FileStream(filenameInts, FileMode.Open)
        Dim br As New BinaryReader(fs)
        Dim items As Integer
        Dim dates As DateTime()

        Try
            items = br.ReadInt32()
            ReDim dates(items - 1)

            For ctr As Integer = 0 To items - 1
                Dim ticks As Long = br.ReadInt64()
                dates(ctr) = New DateTime(ticks).ToLocalTime()
            Next
        Catch e As EndOfStreamException
            Console.WriteLine("File corruption detected. Unable to restore data...")
            Exit Sub
        Catch e As IOException
            Console.WriteLine("Unspecified I/O error. Unable to restore data...")
            Exit Sub
        Catch e As OutOfMemoryException     'Thrown in array initialization.
            Console.WriteLine("File corruption detected. Unable to restore data...")
            Exit Sub
        Finally
            br.Close()
        End Try

        Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        For Each value In dates
            Console.WriteLine(value.ToString("f"))
        Next
        Console.WriteLine("Restored dates...")
    End Sub
    ' When saved on an en-US system, the example displays the following output:
    '       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
    '       The dates on an en-US system:
    '       Saturday, June 14, 2014 6:32 AM
    '       Thursday, July 10, 2014 11:49 PM
    '       Saturday, January 10, 2015 1:16 AM
    '       Saturday, December 20, 2014 9:45 PM
    '       Monday, June 02, 2014 3:14 PM
    '       Saved dates...
    '
    ' When restored on an en-GB system, the example displays the following output:
    '       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
    '       The dates on an en-GB system:
    '       14 June 2014 14:32
    '       11 July 2014 07:49
    '       10 January 2015 09:16
    '       21 December 2014 05:45
    '       02 June 2014 23:14
    '       Restored dates...
    ' </Snippet3>

    Private Const filenameXml As String = ".\LeapYears.xml"

    ' <Snippet4>
    Public Sub PersistAsXml()
        ' Serialize the data.
        Dim leapYears As New List(Of DateTime)()
        For year As Integer = 2000 To 2100 Step 4
            If Date.IsLeapYear(year) Then
                leapYears.Add(New Date(year, 2, 29))
            End If
        Next
        Dim dateArray As DateTime() = leapYears.ToArray()

        Dim serializer As New XmlSerializer(dateArray.GetType())
        Dim sw As TextWriter = New StreamWriter(filenameXml)

        Try
            serializer.Serialize(sw, dateArray)
        Catch e As InvalidOperationException
            Console.WriteLine(e.InnerException.Message)
        Finally
            If sw IsNot Nothing Then sw.Close()
        End Try

        ' Deserialize the data.
        Dim deserializedDates As Date()
        Using fs As New FileStream(filenameXml, FileMode.Open)
            deserializedDates = CType(serializer.Deserialize(fs), Date())
        End Using

        ' Display the dates.
        Console.WriteLine($"Leap year days from 2000-2100 on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        Dim nItems As Integer
        For Each dat In deserializedDates
            Console.Write($"   {dat:d}     ")
            nItems += 1
            If nItems Mod 5 = 0 Then Console.WriteLine()
        Next
    End Sub
    ' The example displays the following output:
    '    Leap year days from 2000-2100 on an en-GB system:
    '       29/02/2000       29/02/2004       29/02/2008       29/02/2012       29/02/2016
    '       29/02/2020       29/02/2024       29/02/2028       29/02/2032       29/02/2036
    '       29/02/2040       29/02/2044       29/02/2048       29/02/2052       29/02/2056
    '       29/02/2060       29/02/2064       29/02/2068       29/02/2072       29/02/2076
    '       29/02/2080       29/02/2084       29/02/2088       29/02/2092       29/02/2096
    ' </Snippet4>

    Private Const filenameBin As String = ".\Dates.bin"

    ' <Snippet5>
    Public Sub PersistBinary()
        SaveDatesBinary()
        RestoreDatesBinary()
    End Sub

    Private Sub SaveDatesBinary()
        Dim dates As Date() = {#6/14/2014 6:32AM#, #7/10/2014 11:49PM#,
                              #1/10/2015 1:16AM#, #12/20/2014 9:45PM#,
                              #6/2/2014 3:14PM#}
        Dim fs As New FileStream(filenameBin, FileMode.Create)
        Dim bin As New BinaryFormatter()

        Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}")
        Console.WriteLine("The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        For ctr As Integer = 0 To dates.Length - 1
            Console.WriteLine(dates(ctr).ToString("f"))
            dates(ctr) = dates(ctr).ToUniversalTime()
        Next
        bin.Serialize(fs, dates)
        fs.Close()
        Console.WriteLine("Saved dates...")
    End Sub

    Private Sub RestoreDatesBinary()
        TimeZoneInfo.ClearCachedData()
        Console.WriteLine("Current Time Zone: {TimeZoneInfo.Local.DisplayName}")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")

        Dim fs As New FileStream(filenameBin, FileMode.Open)
        Dim bin As New BinaryFormatter()
        Dim dates As DateTime() = DirectCast(bin.Deserialize(fs), Date())
        fs.Close()

        Console.WriteLine("The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:")
        For Each value In dates
            Console.WriteLine(value.ToLocalTime().ToString("f"))
        Next
        Console.WriteLine("Restored dates...")
    End Sub
    ' When saved on an en-US system, the example displays the following output:
    '       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
    '       The dates on an en-US system:
    '       Saturday, June 14, 2014 6:32 AM
    '       Thursday, July 10, 2014 11:49 PM
    '       Saturday, January 10, 2015 1:16 AM
    '       Saturday, December 20, 2014 9:45 PM
    '       Monday, June 02, 2014 3:14 PM
    '       Saved dates...
    '
    ' When restored on an en-GB system, the example displays the following output:
    '       Current Time Zone: (UTC-6:00) Central Time (US & Canada)
    '       The dates on an en-GB system:
    '       14 June 2014 08:32
    '       11 July 2014 01:49
    '       10 January 2015 03:16
    '       20 December 2014 11:45
    '       02 June 2014 17:14
    '       Restored dates...
    ' </Snippet5>

    ' <Snippet7>
    Public Sub SaveDateWithTimeZone()
        Dim dates As DateWithTimeZone() = {New DateWithTimeZone(#8/9/2014 7:30PM#,
                                          TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),
                                      New DateWithTimeZone(#8/15/2014 7:00PM#,
                                          TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")),
                                      New DateWithTimeZone(#8/22/2014 7:30PM#,
                                          TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),
                                      New DateWithTimeZone(#8/28/2014 7:00PM#,
                                          TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"))}
        Dim fs As New FileStream(".\Schedule.bin", FileMode.Create)
        Dim formatter As New BinaryFormatter()
        Try
            formatter.Serialize(fs, dates)
        Catch e As SerializationException
            Console.WriteLine($"Serialization failed. Reason: {e.Message}")
        Finally
            If fs IsNot Nothing Then fs.Close()
        End Try
        ' Display dates.
        For Each dateInfo In dates
            Dim tz As TimeZoneInfo = dateInfo.TimeZone
            Console.WriteLine($"{dateInfo.DateTime} {If(tz.IsDaylightSavingTime(dateInfo.DateTime), tz.DaylightName, tz.StandardName)}")
        Next
    End Sub
    ' The example displays the following output:
    '       8/9/2014 7:30:00 PM Eastern Daylight Time
    '       8/15/2014 7:00:00 PM Pacific Daylight Time
    '       8/22/2014 7:30:00 PM Eastern Daylight Time
    '       8/28/2014 7:00:00 PM Eastern Daylight Time
    ' </Snippet7>

    Private Const filename As String = ".\Schedule.bin"

    ' <Snippet8>
    Public Sub RestoreDateWithTimeZone()
        Dim fs As FileStream
        If File.Exists(filename) Then
            fs = New FileStream(filename, FileMode.Open)
        Else
            Console.WriteLine("Unable to find file to deserialize.")
            Exit Sub
        End If

        Dim formatter As New BinaryFormatter()
        Dim dates As DateWithTimeZone ()= Nothing
        Try
            dates = DirectCast(formatter.Deserialize(fs), DateWithTimeZone())
            ' Display dates.
            For Each dateInfo In dates
                Dim tz As TimeZoneInfo = dateInfo.TimeZone
                Console.WriteLine($"{dateInfo.DateTime} {If(tz.IsDaylightSavingTime(dateInfo.DateTime), tz.DaylightName, tz.StandardName)}")
            Next
        Catch e As SerializationException
            Console.WriteLine("Deserialization failed. Reason: {e.Message}")
        Finally
            If fs IsNot Nothing Then fs.Close()
        End Try
    End Sub
    ' The example displays the following output:
    '       8/9/2014 7:30:00 PM Eastern Daylight Time
    '       8/15/2014 7:00:00 PM Pacific Daylight Time
    '       8/22/2014 7:30:00 PM Eastern Daylight Time
    '       8/28/2014 7:00:00 PM Eastern Daylight Time
    ' </Snippet8>


End Module
