    Public Sub TransformExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in blue.
        Dim regionRect As New Rectangle(100, 50, 100, 100)
        e.Graphics.DrawRectangle(Pens.Blue, regionRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Create a transform matrix and set it to have a 45 degree
        ' rotation.
        Dim transformMatrix As New Matrix
        transformMatrix.RotateAt(45, New PointF(100, 50))

        ' Apply the transform to the region.
        myRegion.Transform(transformMatrix)

        ' Fill the transformed region with red and draw it to the
        ' screen in red.
        Dim myBrush As New SolidBrush(Color.Red)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub