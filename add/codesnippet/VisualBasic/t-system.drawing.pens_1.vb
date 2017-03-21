    Private Sub UsePensClass(ByVal e As PaintEventArgs)
        e.Graphics.DrawEllipse(Pens.SlateBlue, _
            New Rectangle(40, 40, 140, 140))
    End Sub