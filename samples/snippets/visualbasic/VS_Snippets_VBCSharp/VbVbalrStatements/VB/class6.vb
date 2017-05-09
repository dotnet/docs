Public Class Class6
    ' 790068a2-1307-4e28-8a72-be5ebda099e9
    ' If...Then...Else Statement (Visual Basic)


    Public Sub TestSome()
        MessageBox.Show(Multiline().ToString)
        MessageBox.Show(CheckIfTime)
    End Sub

    Private Function Multiline() As String
        '<Snippet101>
        Dim count As Integer = 0
        Dim message As String

        If count = 0 Then
            message = "There are no items."
        ElseIf count = 1 Then
            message = "There is 1 item."
        Else
            message = "There are " & count & " items."
        End If

        '</Snippet101>
        Return message
    End Function

    '<Snippet102>
    Private Function CheckIfTime() As Boolean
        ' Determine the current day of week and hour of day.
        Dim dayW As DayOfWeek = DateTime.Now.DayOfWeek
        Dim hour As Integer = DateTime.Now.Hour

        ' Return True if Wednesday from 2 to 4 P.M.,
        ' or if Thursday from noon to 1 P.M.
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
    '</Snippet102>

    Private Sub SingleLine()
        Dim A, B, C As Integer
        '<Snippet103>
        ' If A > 10, execute the three colon-separated statements in the order
        ' that they appear
        If A > 10 Then A = A + 1 : B = B + A : C = C + B
        '</Snippet103>
    End Sub


End Class
