    Public Sub AddLineExample(ByVal e As PaintEventArgs)

        ' Create a path and add a symetrical triangle using AddLine.
        Dim myPath As New GraphicsPath
        myPath.AddLine(30, 30, 60, 60)
        myPath.AddLine(60, 60, 0, 60)
        myPath.AddLine(0, 60, 30, 30)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub