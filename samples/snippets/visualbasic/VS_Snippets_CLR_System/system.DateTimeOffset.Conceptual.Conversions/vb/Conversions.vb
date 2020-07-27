' Visual Basic .NET Document
' Conversions from DateTimeOffset to DateTime and vice versa
Option Strict On

Module modMain
    Public Sub Main()
        ' Conversions from DateTimeOffset to DateTime
        Console.WriteLine("--------------------")
        Console.WriteLine("FROM DATETIMEOFFSET TO DATETIME:")
        Console.WriteLine()
        ConvertUsingDateTime()
        Console.WriteLine()
        ConvertUtcTime()
        Console.WriteLine()
        ConvertLocalTime()
        Console.WriteLine()
        CallConversionFunction()
        Console.WriteLine()
        Console.WriteLine("--------------------")
        Console.WriteLine("FROM DATETIME TO DATETIMEOFFSET:")
        Console.WriteLine()
        ConvertUtcToDateTimeOffset()
        Console.WriteLine()
        ConvertLocalToDateTimeOffset()
        Console.WriteLine()
        ConvertUnspecifiedToDateTimeOffset1()
        Console.WriteLine()
        ConvertUnspecifiedToDateTimeOffset2()
        Console.WriteLine()
        ConvertUnspecifiedToDateTimeOffset2()
        Console.WriteLine()
        ConvertUsingLocalTimeProperty1()
        Console.WriteLine()
        ConvertUsingLocalTimeProperty2()
        Console.WriteLine()
        PerformUtcAndTypeConversion()
    End Sub

    Private Sub ConvertUsingDateTime()
        ' <Snippet5>
        Const baseTime As Date = #06/19/2008 7:00AM#
        Dim sourceTime As DateTimeOffset
        Dim targetTime As Date

        ' Convert UTC to DateTime value
        sourceTime = New DateTimeOffset(baseTime, TimeSpan.Zero)
        targetTime = sourceTime.DateTime
        Console.WriteLine("{0} converts to {1} {2}", _
                          sourceTime, _
                          targetTime, _
                          targetTime.Kind.ToString())

        ' Convert local time to DateTime value
        sourceTime = New DateTimeOffset(baseTime, _
                                        TimeZoneInfo.Local.GetUtcOffset(baseTime))
        targetTime = sourceTime.DateTime
        Console.WriteLine("{0} converts to {1} {2}", _
                          sourceTime, _
                          targetTime, _
                          targetTime.Kind.ToString())

        ' Convert Central Standard Time to a DateTime value
        Try
            Dim offset As TimeSpan = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(baseTime)
            sourceTime = New DateTimeOffset(baseTime, offset)
            targetTime = sourceTime.DateTime
            Console.WriteLine("{0} converts to {1} {2}", _
                              sourceTime, _
                              targetTime, _
                              targetTime.Kind.ToString())
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("Unable to create DateTimeOffset based on U.S. Central Standard Time.")
        End Try
        ' This example displays the following output to the console:
        '    6/19/2008 7:00:00 AM +00:00 converts to 6/19/2008 7:00:00 AM Unspecified
        '    6/19/2008 7:00:00 AM -07:00 converts to 6/19/2008 7:00:00 AM Unspecified
        '    6/19/2008 7:00:00 AM -05:00 converts to 6/19/2008 7:00:00 AM Unspecified                       
        ' </Snippet5>
    End Sub

    Private Sub ConvertUtcTime()
        ' <Snippet6>
        Dim utcTime1 As New DateTimeOffset(#06/19/2008 7:00AM#, TimeSpan.Zero)
        Dim utcTime2 As Date = utcTime1.UtcDateTime
        Console.WriteLine("{0} converted to {1} {2}", _
                          utcTime1, _
                          utcTime2, _
                          utcTime2.Kind.ToString())
        ' The example displays the following output to the console:
        '   6/19/2008 7:00:00 AM +00:00 converted to 6/19/2008 7:00:00 AM Utc                              
        ' </Snippet6>
    End Sub

    Private Sub ConvertLocalTime()
        ' <Snippet7>
        Dim sourceDate As Date = #06/19/2008 7:00AM#
        Dim utcTime1 As New DateTimeOffset(sourceDate, _
                                           TimeZoneInfo.Local.GetUtcOffset(sourceDate))
        Dim utcTime2 As Date = utcTime1.DateTime
        If utcTime1.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(utcTime1.DateTime)) Then
            utcTime2 = DateTime.SpecifyKind(utcTime2, DateTimeKind.Local)
        End If
        Console.WriteLine("{0} converted to {1} {2}", _
                          utcTime1, _
                          utcTime2, _
                          utcTime2.Kind.ToString())
        ' The example displays the following output to the console:
        '   6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local      
        ' </Snippet7>
    End Sub

    ' <Snippet8>
    Function ConvertFromDateTimeOffset(dateTime As DateTimeOffset) As Date
        If dateTime.Offset.Equals(TimeSpan.Zero) Then
            Return dateTime.UtcDateTime
        ElseIf dateTime.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(dateTime.DateTime))
            Return Date.SpecifyKind(dateTime.DateTime, DateTimeKind.Local)
        Else
            Return dateTime.DateTime
        End If
    End Function
    ' </Snippet8>

    Private Sub CallConversionFunction()
        ' <Snippet9>
        Dim timeComponent As Date = #06/19/2008 7:00AM#
        Dim returnedDate As Date

        ' Convert UTC time
        Dim utcTime As New DateTimeOffset(timeComponent, TimeSpan.Zero)
        returnedDate = ConvertFromDateTimeOffset(utcTime)
        Console.WriteLine("{0} converted to {1} {2}", _
                          utcTime, _
                          returnedDate, _
                          returnedDate.Kind.ToString())

        ' Convert local time
        Dim localTime As New DateTimeOffset(timeComponent, _
                                            TimeZoneInfo.Local.GetUtcOffset(timeComponent))
        returnedDate = ConvertFromDateTimeOffset(localTime)
        Console.WriteLine("{0} converted to {1} {2}", _
                          localTime, _
                          returnedDate, _
                          returnedDate.Kind.ToString())

        ' Convert Central Standard Time
        Dim cstTime As New DateTimeOffset(timeComponent, _
                       TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(timeComponent))
        returnedDate = ConvertFromDateTimeOffset(cstTime)
        Console.WriteLine("{0} converted to {1} {2}", _
                          cstTime, _
                          returnedDate, _
                          returnedDate.Kind.ToString())
        ' The example displays the following output to the console:
        '    6/19/2008 7:00:00 AM +00:00 converted to 6/19/2008 7:00:00 AM Utc
        '    6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local
        '    6/19/2008 7:00:00 AM -05:00 converted to 6/19/2008 7:00:00 AM Unspecified
        ' </Snippet9>
    End Sub

    Private Sub ConvertUtcToDateTimeOffset()
        ' <Snippet1>
        Dim utcTime1 As Date = Date.SpecifyKind(#06/19/2008 7:00AM#, _
                                                DateTimeKind.Utc)
        Dim utcTime2 As DateTimeOffset = utcTime1
        Console.WriteLine("Converted {0} {1} to a DateTimeOffset value of {2}", _
                          utcTime1, _
                          utcTime1.Kind.ToString(), _
                          utcTime2)
        ' This example displays the following output to the console:
        '    Converted 6/19/2008 7:00:00 AM Utc to a DateTimeOffset value of 6/19/2008 7:00:00 AM +00:00                        
        ' </Snippet1>                   
    End Sub

    Private Sub ConvertLocalToDateTimeOffset()
        ' <Snippet2>
        Dim localTime1 As Date = Date.SpecifyKind(#06/19/2008 7:00AM#, DateTimeKind.Local)
        Dim localTime2 As DateTimeOffset = localTime1
        Console.WriteLine("Converted {0} {1} to a DateTimeOffset value of {2}", _
                          localTime1, _
                          localTime1.Kind.ToString(), _
                          localTime2)
        ' This example displays the following output to the console:
        '    Converted 6/19/2008 7:00:00 AM Local to a DateTimeOffset value of 6/19/2008 7:00:00 AM -07:00
        ' </Snippet2>                        
    End Sub

    Private Sub ConvertUnspecifiedToDateTimeOffset1()
        ' <Snippet3>
        Dim time1 As Date = #06/19/2008 7:00AM#      ' Kind is DateTimeKind.Unspecified
        Dim time2 As DateTimeOffset = time1
        Console.WriteLine("Converted {0} {1} to a DateTimeOffset value of {2}", _
                          time1, _
                          time1.Kind.ToString(), _
                          time2)
        ' This example displays the following output to the console:
        '    Converted 6/19/2008 7:00:00 AM Unspecified to a DateTimeOffset value of 6/19/2008 7:00:00 AM -07:00
        ' </Snippet3>
    End Sub

    Private Sub ConvertUnspecifiedToDateTimeOffset2()
        ' <Snippet4>
        Dim time1 As Date = #06/19/2008 7:00AM#      ' Kind is DateTimeKind.Unspecified
        Try
            Dim time2 As New DateTimeOffset(time1, _
                             TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(time1))
            Console.WriteLine("Converted {0} {1} to a DateTime value of {2}", _
                              time1, _
                              time1.Kind.ToString(), _
                              time2)
            ' Handle exception if time zone is not defined in registry
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("Unable to identify target time zone for conversion.")
        End Try
        ' This example displays the following output to the console:
        '    Converted 6/19/2008 7:00:00 AM Unspecified to a DateTime value of 6/19/2008 7:00:00 AM -05:00
        ' </Snippet4>
    End Sub

    Private Sub ConvertUsingLocalTimeProperty1()
        ' <Snippet10>
        Dim sourceDate As Date = #06/19/2008 7:00AM#
        Dim localTime1 As New DateTimeOffset(sourceDate, _
                                           TimeZoneInfo.Local.GetUtcOffset(sourceDate))
        Dim localTime2 As Date = localTime1.LocalDateTime
        Console.WriteLine("{0} converted to {1} {2}", _
                          localTime1, _
                          localTime2, _
                          localTime2.Kind.ToString())
        ' The example displays the following output to the console:
        '   6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local      
        ' </Snippet10>
    End Sub

    Private Sub ConvertUsingLocalTimeProperty2()
        ' <Snippet11>
        Dim originalDate As DateTimeOffset
        Dim localDate As Date

        ' Convert time originating in a different time zone
        originalDate = New DateTimeOffset(#06/19/2008 7:00AM#, _
                                          New TimeSpan(-5, 0, 0))
        localDate = originalDate.LocalDateTime
        Console.WriteLine("{0} converted to {1} {2}", _
                          originalDate, _
                          localDate, _
                          localDate.Kind.ToString())
        ' Convert time originating in a different time zone 
        ' so local time zone's adjustment rules are applied
        originalDate = New DateTimeOffset(#11/04/2007 4:00AM#, _
                                          New TimeSpan(-5, 0, 0))
        localDate = originalDate.LocalDateTime
        Console.WriteLine("{0} converted to {1} {2}", _
                          originalDate, _
                          localDate, _
                          localDate.Kind.ToString())
        ' The example displays the following output to the console,
        ' when you run it on a machine that is set to Pacific Time (US & Canada):
        '       6/18/2008 7:00:00 AM -05:00 converted to 6/18/2008 5:00:00 AM Local
        '       11/4/2007 4:00:00 AM -05:00 converted to 11/4/2007 1:00:00 AM Local
        ' </Snippet11>
    End Sub

    Private Sub PerformUtcAndTypeConversion()
        ' <Snippet12>
        Dim originalTime As New DateTimeOffset(#6/19/2008 7:00AM#, _
                                               New TimeSpan(5, 0, 0))
        Dim utcTime As Date = originalTime.UtcDateTime
        Console.WriteLine("{0} converted to {1} {2}", _
                          originalTime, _
                          utcTime, _
                          utcTime.Kind.ToString())
        ' The example displays the following output to the console:
        '       6/19/2008 7:00:00 AM +05:00 converted to 6/19/2008 2:00:00 AM Utc
        ' </Snippet12>                        
    End Sub
End Module

