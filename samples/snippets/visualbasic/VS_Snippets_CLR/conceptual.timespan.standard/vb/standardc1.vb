' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
    Public Sub Main()
        Dim interval1, interval2 As TimeSpan
        interval1 = New TimeSpan(7, 45, 16)
        interval2 = New TimeSpan(18, 12, 38)

        Console.WriteLine("{0:c} - {1:c} = {2:c}", interval1,
                          interval2, interval1 - interval2)
        Console.WriteLine("{0:c} + {1:c} = {2:c}", interval1,
                          interval2, interval1 + interval2)

        interval1 = New TimeSpan(0, 0, 1, 14, 365)
        interval2 = TimeSpan.FromTicks(2143756)
        Console.WriteLine("{0:c} + {1:c} = {2:c}", interval1,
                          interval2, interval1 + interval2)
    End Sub
End Module
' The example displays the following output:
'       07:45:16 - 18:12:38 = -10:27:22
'       07:45:16 + 18:12:38 = 1.01:57:54
'       00:01:14.3650000 + 00:00:00.2143756 = 00:01:14.5793756
' </Snippet1>
