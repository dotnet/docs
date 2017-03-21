    Public Sub WidenExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 100)
        myPath.AddEllipse(100, 0, 100, 100)
        e.Graphics.DrawPath(Pens.Black, myPath)
        Dim widenPen As New Pen(Color.Black, 10)
        Dim widenMatrix As New Matrix
        widenMatrix.Translate(50, 50)
        myPath.Widen(widenPen, widenMatrix, 1.0F)
        ' Sets tension for curves.
        e.Graphics.FillPath(New SolidBrush(Color.Red), myPath)
    End Sub