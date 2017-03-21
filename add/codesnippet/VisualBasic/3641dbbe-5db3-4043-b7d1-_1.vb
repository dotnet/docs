    Public Sub FlattenExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(0, 10)
        Dim point1 As New Point(20, 100)
        Dim point2 As New Point(70, 10)
        Dim point3 As New Point(130, 200)
        Dim point4 As New Point(180, 100)
        Dim points As Point() = {point1, point2, point3, point4}
        myPath.AddCurve(points)
        e.Graphics.DrawPath(New Pen(Color.Black, 2), myPath)
        myPath.Flatten(translateMatrix, 10.0F)
        e.Graphics.DrawPath(New Pen(Color.Red, 1), myPath)
    End Sub
    'FlattenExample