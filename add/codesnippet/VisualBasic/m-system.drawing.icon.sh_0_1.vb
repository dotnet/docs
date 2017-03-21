    Private Sub ConstructAnIconFromAType(ByVal e As PaintEventArgs)

        Dim icon1 As New Icon(GetType(Control), "Error.ico")
        e.Graphics.DrawIcon(icon1, New Rectangle(10, 10, 50, 50))

    End Sub