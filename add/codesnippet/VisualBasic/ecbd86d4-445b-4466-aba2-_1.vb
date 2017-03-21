    Protected Sub DrawCaps(ByVal e As PaintEventArgs)
        Dim hPath As New GraphicsPath()

        ' Create the outline for our custom end cap.
        hPath.AddLine(New Point(0, 0), New Point(0, 5))
        hPath.AddLine(New Point(0, 5), New Point(5, 1))
        hPath.AddLine(New Point(5, 1), New Point(3, 1))

        ' Construct the hook-shaped end cap.
        Dim HookCap As New CustomLineCap(Nothing, hPath)

        ' Set the start cap and end cap of the HookCap to be rounded.
        HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round)

        ' Create a pen and set end custom start and end
        ' caps to the hook cap.
        Dim customCapPen As New Pen(Color.Black, 5)
        customCapPen.CustomStartCap = HookCap
        customCapPen.CustomEndCap = HookCap

        ' Create a second pen using the start and end caps from
        ' the hook cap.
        Dim capPen As New Pen(Color.Red, 10)
        Dim startCap As LineCap
        Dim endCap As LineCap
        HookCap.GetStrokeCaps(startCap, endCap)
        capPen.StartCap = startCap
        capPen.EndCap = endCap

        ' Create a line to draw.
        Dim points As Point() = {New Point(100, 100), New Point(200, 50), _
            New Point(250, 300)}

        ' Draw the lines.
        e.Graphics.DrawLines(capPen, points)
        e.Graphics.DrawLines(customCapPen, points)

    End Sub