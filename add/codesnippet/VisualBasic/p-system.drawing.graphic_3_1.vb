    Private Sub ChangePageUnit(ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rectangle1 As New Rectangle(20, 20, 50, 100)

        ' Draw its outline.
        e.Graphics.DrawRectangle(Pens.SlateBlue, rectangle1)

        ' Change the page scale.  
        e.Graphics.PageUnit = GraphicsUnit.Point

        ' Draw the rectangle again.
        e.Graphics.DrawRectangle(Pens.Tomato, rectangle1)

    End Sub