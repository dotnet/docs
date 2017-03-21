    Public Sub Complement_Path_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' Create the second rectangle and draw it to the screen in red.
        Dim complementRect As New Rectangle(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, complementRect)

        ' Create a graphics path and add the second rectangle to it.
        Dim complementPath As New GraphicsPath
        complementPath.AddRectangle(complementRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the complement of myRegion when combined with
        ' complementPath.
        myRegion.Complement(complementPath)

        ' Fill the complement area with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub