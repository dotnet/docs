    Public Sub ConstructAdjArrowCap1(ByVal e As PaintEventArgs)
        Dim myArrow As New AdjustableArrowCap(6, 6)
        Dim customArrow As CustomLineCap = myArrow
        Dim capPen As New Pen(Color.Black)
        capPen.CustomStartCap = myArrow
        capPen.CustomEndCap = myArrow
        e.Graphics.DrawLine(capPen, 50, 50, 200, 50)
    End Sub