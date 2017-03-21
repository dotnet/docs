    Public Sub SetLineCap_Example(ByVal e As PaintEventArgs)

        ' Create a Pen object with a dash pattern.
        Dim capPen As New Pen(Color.Black, 5)
        capPen.DashStyle = DashStyle.Dash

        ' Set the start and end caps for capPen.
        capPen.SetLineCap(LineCap.ArrowAnchor, LineCap.Flat, DashCap.Flat)

        ' Draw a line with capPen.
        e.Graphics.DrawLine(capPen, 10, 10, 200, 10)
    End Sub