    Public Sub IsVisibleExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 100)
        Dim visible As Boolean = myPath.IsVisible(50, 50, e.Graphics)
        MessageBox.Show(visible.ToString())
    End Sub