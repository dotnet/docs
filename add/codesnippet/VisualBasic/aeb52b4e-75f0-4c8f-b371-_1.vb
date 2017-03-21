    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        For i = 0 To 20
            ' With each loop through the code, the form's desktop location is 
            ' adjusted right and down by 10 pixels and its height and width 
            ' are each decreased by 10 pixels. 
            Me.SetDesktopBounds(Me.Location.X + 10, Me.Location.Y + 10, _
                Me.Width - 10, Me.Height - 10)

            ' Call Sleep to show the form gradually shrinking.
            System.Threading.Thread.Sleep(50)
        Next
    End Sub