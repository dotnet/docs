Module Nested
    Public Sub Main() 
        ' Run the function as part of the WriteLine output.
        Console.WriteLine("Time Check is " & CheckIfTime() & ".")     
    End Sub

    Private Function CheckIfTime() As Boolean
        ' Determine the current day of week and hour of day.
        Dim dayW As DayOfWeek = DateTime.Now.DayOfWeek
        Dim hour As Integer = DateTime.Now.Hour

        ' Return True if Wednesday from 2 to 3:59 P.M.,
        ' or if Thursday from noon to 12:59 P.M.
        If dayW = DayOfWeek.Wednesday Then
            If hour = 14 Or hour = 15 Then
                Return True
            Else
                Return False
            End If
        ElseIf dayW = DayOfWeek.Thursday Then
            If hour = 12 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
End Module
'This example displays output like the following:
'Time Check is False.