    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Dim p As New System.Drawing.Point(e.X, e.Y)
        Dim s As System.Windows.Forms.Screen = Screen.FromPoint(p)

        If s.Primary = True Then
            MessageBox.Show("You clicked the primary screen")
        Else
            MessageBox.Show("This isn't the primary screen")
        End If
    End Sub