' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Main()
        dSpecifier()
        Console.WriteLine("-------")
        ddSpecifier()
        Console.WriteLine("-------")
        hSpecifier()
        Console.WriteLine("-------")
        ParseH()
        Console.WriteLine("-------")
        ParseHH()
        Console.WriteLine("-------")
        hhSpecifier()
        Console.WriteLine("-------")
        ParseM()
        Console.WriteLine("-------")
        mSpecifier()
        Console.WriteLine("-------")
        ParseMM()
        Console.WriteLine("-------")
        mmSpecifier()
        Console.WriteLine("-------")
        sSpecifier()
        Console.WriteLine("-------")
        ParseS()
        Console.WriteLine("-------")
        ParseSS()
        Console.WriteLine("-------")
        ssSpecifier()
        Console.WriteLine("-------")
    End Sub

    Private Sub dSpecifier()
        ' <Snippet3>
        Dim ts As New TimeSpan(16, 4, 3, 17, 250)
        Console.WriteLine(ts.ToString("%d"))
        ' Displays 16   
        ' </Snippet3>
        Console.WriteLine()

        ' <Snippet4>
        Dim ts2 As New TimeSpan(4, 3, 17)
        Console.WriteLine(ts2.ToString("d\.hh\:mm\:ss"))

        Dim ts3 As New TimeSpan(3, 4, 3, 17)
        Console.WriteLine(ts3.ToString("d\.hh\:mm\:ss"))
        ' The example displays the following output:
        '       0.04:03:17
        '       3.04:03:17      
        ' </Snippet4>
    End Sub

    Private Sub ddSpecifier()
        ' <Snippet5>
        Dim ts1 As New TimeSpan(0, 23, 17, 47)
        Dim ts2 As New TimeSpan(365, 21, 19, 45)

        For ctr As Integer = 2 To 8
            Dim fmt As String = New String("d"c, ctr) + "\.hh\:mm\:ss"
            Console.WriteLine("{0} --> {1:" + fmt + "}", fmt, ts1)
            Console.WriteLine("{0} --> {1:" + fmt + "}", fmt, ts2)
            Console.WriteLine()
        Next
        ' The example displays the following output:
        '       dd\.hh\:mm\:ss --> 00.23:17:47
        '       dd\.hh\:mm\:ss --> 365.21:19:45
        '       
        '       ddd\.hh\:mm\:ss --> 000.23:17:47
        '       ddd\.hh\:mm\:ss --> 365.21:19:45
        '       
        '       dddd\.hh\:mm\:ss --> 0000.23:17:47
        '       dddd\.hh\:mm\:ss --> 0365.21:19:45
        '       
        '       ddddd\.hh\:mm\:ss --> 00000.23:17:47
        '       ddddd\.hh\:mm\:ss --> 00365.21:19:45
        '       
        '       dddddd\.hh\:mm\:ss --> 000000.23:17:47
        '       dddddd\.hh\:mm\:ss --> 000365.21:19:45
        '       
        '       ddddddd\.hh\:mm\:ss --> 0000000.23:17:47
        '       ddddddd\.hh\:mm\:ss --> 0000365.21:19:45
        '       
        '       dddddddd\.hh\:mm\:ss --> 00000000.23:17:47
        '       dddddddd\.hh\:mm\:ss --> 00000365.21:19:45      
        ' </Snippet5>
    End Sub

    Private Sub hSpecifier()
        ' <Snippet6>
        Dim ts As New TimeSpan(3, 42, 0)
        Console.WriteLine("{0:%h} hours {0:%m} minutes", ts)
        ' The example displays the following output:
        '       3 hours 42 minutes
        ' </Snippet6>
        Console.WriteLine()

        ' <Snippet7>
        Dim ts1 As New TimeSpan(14, 3, 17)
        Console.WriteLine(ts1.ToString("d\.h\:mm\:ss"))

        Dim ts2 As New TimeSpan(3, 4, 3, 17)
        Console.WriteLine(ts2.ToString("d\.h\:mm\:ss"))
        ' The example displays the following output:
        '       0.14:03:17
        '       3.4:03:17
        ' </Snippet7>
    End Sub

    Public Sub ParseH()
        ' <Snippet8>
        Dim value As String = "8"
        Dim interval As TimeSpan
        If TimeSpan.TryParseExact(value, "%h", Nothing, interval) Then
            Console.WriteLine(interval.ToString("c"))
        Else
            Console.WriteLine("Unable to convert '{0}' to a time interval",
                              value)
        End If
        ' The example displays the following output:
        '       08:00:00                              
        ' </Snippet8>
    End Sub

    Public Sub ParseHH()
        ' <Snippet9>
        Dim value As String = "08"
        Dim interval As TimeSpan
        If TimeSpan.TryParseExact(value, "hh", Nothing, interval) Then
            Console.WriteLine(interval.ToString("c"))
        Else
            Console.WriteLine("Unable to convert '{0}' to a time interval",
                              value)
        End If
        ' The example displays the following output:
        '       08:00:00                              
        ' </Snippet9>
    End Sub

    Private Sub hhSpecifier()
        ' <Snippet10>
        Dim ts1 As New TimeSpan(14, 3, 17)
        Console.WriteLine(ts1.ToString("d\.hh\:mm\:ss"))

        Dim ts2 As New TimeSpan(3, 4, 3, 17)
        Console.WriteLine(ts2.ToString("d\.hh\:mm\:ss"))
        ' The example displays the following output:
        '       0.14:03:17
        '       3.04:03:17
        ' </Snippet10>
    End Sub

    Public Sub ParseM()
        ' <Snippet11>
        Dim value As String = "3"
        Dim interval As TimeSpan
        If TimeSpan.TryParseExact(value, "%m", Nothing, interval) Then
            Console.WriteLine(interval.ToString("c"))
        Else
            Console.WriteLine("Unable to convert '{0}' to a time interval",
                              value)
        End If
        ' The example displays the following output:
        '       00:03:00                              
        ' </Snippet11>
    End Sub

    Private Sub mSpecifier()
        ' <Snippet12>
        Dim ts1 As New TimeSpan(0, 6, 32)
        Console.WriteLine("{0:m\:ss} minutes", ts1)

        Dim ts2 As New TimeSpan(0, 18, 44)
        Console.WriteLine("Elapsed time: {0:m\:ss}", ts2)
        ' The example displays the following output:
        '       6:32 minutes
        '       Elapsed time: 18:44
        ' </Snippet12>
    End Sub

    Public Sub ParseMM()
        ' <Snippet13>
        Dim value As String = "05"
        Dim interval As TimeSpan
        If TimeSpan.TryParseExact(value, "mm", Nothing, interval) Then
            Console.WriteLine(interval.ToString("c"))
        Else
            Console.WriteLine("Unable to convert '{0}' to a time interval",
                              value)
        End If
        ' The example displays the following output:
        '       00:05:00           
        ' </Snippet13>
    End Sub

    Private Sub mmSpecifier()
        ' <Snippet14>
        Dim departTime As New TimeSpan(11, 12, 00)
        Dim arriveTime As New TimeSpan(16, 28, 00)
        Console.WriteLine("Travel time: {0:hh\:mm}",
                          arriveTime - departTime)
        ' The example displays the following output:
        '       Travel time: 05:16      
        ' </Snippet14>
    End Sub

    Private Sub sSpecifier()
        ' <Snippet15>
        Dim ts As TimeSpan = TimeSpan.FromSeconds(12.465)
        Console.WriteLine(ts.ToString("%s"))
        ' The example displays the following output:
        '       12
        ' </Snippet15>
        Console.WriteLine()

        ' <Snippet16>
        Dim startTime As New TimeSpan(0, 12, 30, 15, 0)
        Dim endTime As New TimeSpan(0, 12, 30, 21, 3)
        Console.WriteLine("Elapsed Time: {0:s\:fff} seconds",
                          endTime - startTime)
        ' The example displays the following output:
        '       Elapsed Time: 6:003 seconds      
        ' </Snippet16>
    End Sub

    Public Sub ParseS()
        ' <Snippet17>
        Dim value As String = "9"
        Dim interval As TimeSpan
        If TimeSpan.TryParseExact(value, "%s", Nothing, interval) Then
            Console.WriteLine(interval.ToString("c"))
        Else
            Console.WriteLine("Unable to convert '{0}' to a time interval",
                              value)
        End If
        ' The example displays the following output:
        '       00:00:09
        ' </Snippet17>
    End Sub

    Public Sub ParseSS()
        ' <Snippet18>
        Dim values() As String = {"49", "9", "06"}
        Dim interval As TimeSpan
        For Each value As String In values
            If TimeSpan.TryParseExact(value, "ss", Nothing, interval) Then
                Console.WriteLine(interval.ToString("c"))
            Else
                Console.WriteLine("Unable to convert '{0}' to a time interval",
                                  value)
            End If
        Next
        ' The example displays the following output:
        '       00:00:49
        '       Unable to convert '9' to a time interval
        '       00:00:06
        ' </Snippet18>
    End Sub

    Private Sub ssSpecifier()
        ' <Snippet19>
        Dim interval1 As TimeSpan = TimeSpan.FromSeconds(12.60)
        Console.WriteLine(interval1.ToString("ss\.fff"))
        Dim interval2 As TimeSpan = TimeSpan.FromSeconds(6.485)
        Console.WriteLine(interval2.ToString("ss\.fff"))
        ' The example displays the following output:
        '       12.600
        '       06.485
        ' </Snippet19>
    End Sub
End Module

