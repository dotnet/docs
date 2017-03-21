    Public Sub Complement_Region_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' Create the second rectangle and draw it to the screen in red.
        Dim complementRect As New Rectangle(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, complementRect)

        ' create a region from the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Create a complement region.
        Dim complementRegion As New [Region](complementRect)

        ' Get the complement of myRegion when combined with
        ' complementRegion.
        myRegion.Complement(complementRegion)

        ' Fill the complement area with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub