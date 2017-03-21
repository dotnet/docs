    Private Sub DrawIconInt(ByVal e As PaintEventArgs)

        ' Create icon.
        Dim newIcon As New Icon("SampIcon.ico")

        ' Create coordinates for upper-left corner of icon.
        Dim x As Integer = 100
        Dim y As Integer = 100

        ' Draw icon to screen.
        e.Graphics.DrawIcon(newIcon, x, y)
    End Sub