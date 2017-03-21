    Public Sub FillPieInt(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Create start and sweep angles.
        Dim startAngle As Integer = 0
        Dim sweepAngle As Integer = 45

        ' Fill pie to screen.
        e.Graphics.FillPie(redBrush, x, y, width, height, startAngle, _
        sweepAngle)
    End Sub