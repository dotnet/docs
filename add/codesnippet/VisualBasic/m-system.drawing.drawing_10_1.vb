    Public Sub GetLastPointExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        myPath.AddLine(20, 20, 100, 20)
        Dim lastPoint As PointF = myPath.GetLastPoint()
        If lastPoint.IsEmpty = False Then
            Dim lastPointXString As String = lastPoint.X.ToString()
            Dim lastPointYString As String = lastPoint.Y.ToString()
            MessageBox.Show((lastPointXString + ", " + lastPointYString))
        Else
            MessageBox.Show("lastPoint is empty")
        End If
    End Sub