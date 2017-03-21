    Public Sub Clone_Example(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim myPen As New Pen(Color.Black, 5)

        ' Clone myPen.
        Dim clonePen As Pen = CType(myPen.Clone(), Pen)

        ' Draw a line with clonePen.
        e.Graphics.DrawLine(clonePen, 0, 0, 100, 100)
    End Sub