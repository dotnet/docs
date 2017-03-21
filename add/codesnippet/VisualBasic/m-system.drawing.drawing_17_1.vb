    Public Sub HasCurveExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
            New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)
        myPath.AddLines(myPoints)
        myPath.AddRectangle(myRect)
        myPath.AddEllipse(220, 220, 100, 100)

        ' Create a GraphicsPathIterator for myPath.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        Dim myHasCurve As Boolean = myPathIterator.HasCurve()
        MessageBox.Show(myHasCurve.ToString())
    End Sub