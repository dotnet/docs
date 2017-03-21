    Public Sub IsOutlineVisibleExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(20, 20, 100, 100)
        myPath.AddRectangle(rect)
        Dim testPen As New Pen(Color.Black, 20)
        myPath.Widen(testPen)
        e.Graphics.FillPath(Brushes.Black, myPath)
        Dim visible As Boolean = myPath.IsOutlineVisible(100, 50, _
        testPen, e.Graphics)
        MessageBox.Show(("visible = " + visible.ToString()))
    End Sub