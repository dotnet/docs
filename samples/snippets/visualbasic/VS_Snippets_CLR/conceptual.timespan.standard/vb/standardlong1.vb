﻿' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim interval1, interval2 As TimeSpan
        interval1 = New TimeSpan(7, 45, 16)
        interval2 = New TimeSpan(18, 12, 38)

        Console.WriteLine("{0:G} - {1:G} = {2:G}", interval1,
                          interval2, interval1 - interval2)
        Console.WriteLine(String.Format(New CultureInfo("fr-FR"),
                          "{0:G} + {1:G} = {2:G}", interval1,
                          interval2, interval1 + interval2))

        interval1 = New TimeSpan(0, 0, 1, 14, 36)
        interval2 = TimeSpan.FromTicks(2143756)
        Console.WriteLine("{0:G} + {1:G} = {2:G}", interval1,
                          interval2, interval1 + interval2)
    End Sub
End Module
' The example displays the following output:
'       0:07:45:16.0000000 - 0:18:12:38.0000000 = -0:10:27:22.0000000
'       0:07:45:16,0000000 + 0:18:12:38,0000000 = 1:01:57:54,0000000
'       0:00:01:14.0360000 + 0:00:00:00.2143756 = 0:00:01:14.2503756
' </Snippet5>
