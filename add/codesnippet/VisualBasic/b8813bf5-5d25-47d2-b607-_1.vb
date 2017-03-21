    Public Sub AddPieExample(ByVal e As PaintEventArgs)

        ' Create a pie slice of a circle using the AddPie method.
        Dim myPath As New GraphicsPath
        myPath.AddPie(20, 20, 70, 70, -45, 90)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub