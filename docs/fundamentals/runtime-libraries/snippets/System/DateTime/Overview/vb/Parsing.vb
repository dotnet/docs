Imports System.Globalization
Imports System.Threading

Module Parsing
    Public Sub Snippets()
        ParseStandardFormats()
    End Sub

    Private Sub ParseStandardFormats()
        ' <Snippet1>
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")

        Dim date1 As New DateTime(2013, 6, 1, 12, 32, 30)
        Dim badFormats As New List(Of String)

        Console.WriteLine($"{"Date String",-37} {"Date",-19}")
        Console.WriteLine()
        For Each dateString As String In date1.GetDateTimeFormats()
            Dim parsedDate As DateTime
            If DateTime.TryParse(dateString, parsedDate) Then
                Console.WriteLine($"{dateString,-37} {DateTime.Parse(dateString),-19:g}")
            Else
                badFormats.Add(dateString)
            End If
        Next

        ' Display strings that could not be parsed.
        If badFormats.Count > 0 Then
            Console.WriteLine()
            Console.WriteLine("Strings that could not be parsed: ")
            For Each badFormat In badFormats
                Console.WriteLine($"   {badFormat}")
            Next
        End If
        ' The example displays the following output:
        '       Date String                           Date               
        '       
        '       01/06/2013                            01/06/2013 00:00:00
        '       01/06/13                              01/06/2013 00:00:00
        '       1/6/13                                01/06/2013 00:00:00
        '       1.6.13                                01/06/2013 00:00:00
        '       2013-06-01                            01/06/2013 00:00:00
        '       01 June 2013                          01/06/2013 00:00:00
        '       1 June 2013                           01/06/2013 00:00:00
        '       01 June 2013 12:32                    01/06/2013 12:32:00
        '       01 June 2013 12:32                    01/06/2013 12:32:00
        '       01 June 2013 12:32 PM                 01/06/2013 12:32:00
        '       01 June 2013 12:32 PM                 01/06/2013 12:32:00
        '       1 June 2013 12:32                     01/06/2013 12:32:00
        '       1 June 2013 12:32                     01/06/2013 12:32:00
        '       1 June 2013 12:32 PM                  01/06/2013 12:32:00
        '       1 June 2013 12:32 PM                  01/06/2013 12:32:00
        '       01 June 2013 12:32:30                 01/06/2013 12:32:30
        '       01 June 2013 12:32:30                 01/06/2013 12:32:30
        '       01 June 2013 12:32:30 PM              01/06/2013 12:32:30
        '       01 June 2013 12:32:30 PM              01/06/2013 12:32:30
        '       1 June 2013 12:32:30                  01/06/2013 12:32:30
        '       1 June 2013 12:32:30                  01/06/2013 12:32:30
        '       1 June 2013 12:32:30 PM               01/06/2013 12:32:30
        '       1 June 2013 12:32:30 PM               01/06/2013 12:32:30
        '       01/06/2013 12:32                      01/06/2013 12:32:00
        '       01/06/2013 12:32                      01/06/2013 12:32:00
        '       01/06/2013 12:32 PM                   01/06/2013 12:32:00
        '       01/06/2013 12:32 PM                   01/06/2013 12:32:00
        '       01/06/13 12:32                        01/06/2013 12:32:00
        '       01/06/13 12:32                        01/06/2013 12:32:00
        '       01/06/13 12:32 PM                     01/06/2013 12:32:00
        '       01/06/13 12:32 PM                     01/06/2013 12:32:00
        '       1/6/13 12:32                          01/06/2013 12:32:00
        '       1/6/13 12:32                          01/06/2013 12:32:00
        '       1/6/13 12:32 PM                       01/06/2013 12:32:00
        '       1/6/13 12:32 PM                       01/06/2013 12:32:00
        '       1.6.13 12:32                          01/06/2013 12:32:00
        '       1.6.13 12:32                          01/06/2013 12:32:00
        '       1.6.13 12:32 PM                       01/06/2013 12:32:00
        '       1.6.13 12:32 PM                       01/06/2013 12:32:00
        '       2013-06-01 12:32                      01/06/2013 12:32:00
        '       2013-06-01 12:32                      01/06/2013 12:32:00
        '       2013-06-01 12:32 PM                   01/06/2013 12:32:00
        '       2013-06-01 12:32 PM                   01/06/2013 12:32:00
        '       01/06/2013 12:32:30                   01/06/2013 12:32:30
        '       01/06/2013 12:32:30                   01/06/2013 12:32:30
        '       01/06/2013 12:32:30 PM                01/06/2013 12:32:30
        '       01/06/2013 12:32:30 PM                01/06/2013 12:32:30
        '       01/06/13 12:32:30                     01/06/2013 12:32:30
        '       01/06/13 12:32:30                     01/06/2013 12:32:30
        '       01/06/13 12:32:30 PM                  01/06/2013 12:32:30
        '       01/06/13 12:32:30 PM                  01/06/2013 12:32:30
        '       1/6/13 12:32:30                       01/06/2013 12:32:30
        '       1/6/13 12:32:30                       01/06/2013 12:32:30
        '       1/6/13 12:32:30 PM                    01/06/2013 12:32:30
        '       1/6/13 12:32:30 PM                    01/06/2013 12:32:30
        '       1.6.13 12:32:30                       01/06/2013 12:32:30
        '       1.6.13 12:32:30                       01/06/2013 12:32:30
        '       1.6.13 12:32:30 PM                    01/06/2013 12:32:30
        '       1.6.13 12:32:30 PM                    01/06/2013 12:32:30
        '       2013-06-01 12:32:30                   01/06/2013 12:32:30
        '       2013-06-01 12:32:30                   01/06/2013 12:32:30
        '       2013-06-01 12:32:30 PM                01/06/2013 12:32:30
        '       2013-06-01 12:32:30 PM                01/06/2013 12:32:30
        '       01 June                               01/06/2013 00:00:00
        '       01 June                               01/06/2013 00:00:00
        '       2013-06-01T12:32:30.0000000           01/06/2013 12:32:30
        '       2013-06-01T12:32:30.0000000           01/06/2013 12:32:30
        '       Sat, 01 Jun 2013 12:32:30 GMT         01/06/2013 05:32:30
        '       Sat, 01 Jun 2013 12:32:30 GMT         01/06/2013 05:32:30
        '       2013-06-01T12:32:30                   01/06/2013 12:32:30
        '       12:32                                 22/04/2013 12:32:00
        '       12:32                                 22/04/2013 12:32:00
        '       12:32 PM                              22/04/2013 12:32:00
        '       12:32 PM                              22/04/2013 12:32:00
        '       12:32:30                              22/04/2013 12:32:30
        '       12:32:30                              22/04/2013 12:32:30
        '       12:32:30 PM                           22/04/2013 12:32:30
        '       12:32:30 PM                           22/04/2013 12:32:30
        '       2013-06-01 12:32:30Z                  01/06/2013 05:32:30
        '       01 June 2013 19:32:30                 01/06/2013 19:32:30
        '       01 June 2013 19:32:30                 01/06/2013 19:32:30
        '       01 June 2013 07:32:30 PM              01/06/2013 19:32:30
        '       01 June 2013 7:32:30 PM               01/06/2013 19:32:30
        '       1 June 2013 19:32:30                  01/06/2013 19:32:30
        '       1 June 2013 19:32:30                  01/06/2013 19:32:30
        '       1 June 2013 07:32:30 PM               01/06/2013 19:32:30
        '       1 June 2013 7:32:30 PM                01/06/2013 19:32:30
        '       June 2013                             01/06/2013 00:00:00
        '       June 2013                             01/06/2013 00:00:00
        ' </Snippet1>
    End Sub

    Private Sub ParseCustomFormats()
        ' <Snippet2>
        Dim formats() As String = {"yyyyMMdd", "HHmmss"}
        Dim dateStrings() As String = {"20130816", "20131608",
                                      "  20130816   ", "115216",
                                      "521116", "  115216  "}
        Dim parsedDate As DateTime

        For Each dateString As String In dateStrings
            If DateTime.TryParseExact(dateString, formats, Nothing,
                                   DateTimeStyles.AllowWhiteSpaces Or
                                   DateTimeStyles.AdjustToUniversal,
                                   parsedDate) Then
                Console.WriteLine($"{dateString} --> {parsedDate:g}")
            Else
                Console.WriteLine($"Cannot convert {dateString}")
            End If
        Next
        ' The example displays the following output:
        '       20130816 --> 8/16/2013 12:00 AM
        '       Cannot convert 20131608
        '         20130816    --> 8/16/2013 12:00 AM
        '       115216 --> 4/22/2013 11:52 AM
        '       Cannot convert 521116
        '         115216   --> 4/22/2013 11:52 AM
        ' </Snippet2>
    End Sub

    Private Sub ParseISO8601()
        ' <Snippet3>
        Dim iso8601String As String = "20080501T08:30:52Z"
        Dim dateISO8602 As DateTime = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ", CultureInfo.InvariantCulture)
        Console.WriteLine($"{iso8601String} --> {dateISO8602:g}")
        ' </Snippet3>

    End Sub
End Module
