    Private Sub FillEmptyRegion(ByVal e As PaintEventArgs)

        ' Create a region from a rectangle.
        Dim originalRectangle As New Rectangle(40, 40, 40, 50)
        Dim smallRegion As New Region(originalRectangle)

        ' Call MakeEmpty.
        smallRegion.MakeEmpty()

        ' Fill the region in red and draw the original rectangle
        ' in black. Note there is nothing filled in.
        e.Graphics.FillRegion(Brushes.Red, smallRegion)
        e.Graphics.DrawRectangle(Pens.Black, originalRectangle)

    End Sub