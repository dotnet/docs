' <Snippet1>
Public Module Example
    Public Sub Main()
        ' Define a time interval equal to 2 hours.
        Dim baseInterval As New TimeSpan( 2, 0, 0)

        ' Define an array of time intervals to compare with  
        ' the base interval.
        Dim spans() As TimeSpan = { TimeSpan.FromSeconds(-2.5),
                                    TimeSpan.FromMinutes(20),
                                    TimeSpan.FromHours(1), 
                                    TimeSpan.FromMinutes(90),
                                    baseInterval,  
                                    TimeSpan.FromDays(.5), 
                                    TimeSpan.FromDays(1) }

        ' Compare the time intervals.
        For Each span In spans
           Dim result As Integer = TimeSpan.Compare(baseInterval, span)
           Console.WriteLine("{0} {1} {2} (Compare returns {3})", 
                             baseInterval,
                             If(result = 1, ">", If(result = 0, "=", "<")),
                             span, result)
        Next
    End Sub 
End Module 
' The example displays the following output:
'       02:00:00 > -00:00:02.5000000 (Compare return
'       02:00:00 > 00:20:00 (Compare returns 1
'       02:00:00 > 01:00:00 (Compare returns 1
'       02:00:00 > 01:30:00 (Compare returns 1
'       02:00:00 = 02:00:00 (Compare returns 0
'       02:00:00 < 12:00:00 (Compare returns -1
'       02:00:00 < 1.00:00:00 (Compare returns -1
' </Snippet1>