    Private Sub ShowPropertiesOfSlateBlue(ByVal e As PaintEventArgs)
        Dim slateBlue As Color = Color.FromName("SlateBlue")
        Dim g As Byte = slateBlue.G
        Dim b As Byte = slateBlue.B
        Dim r As Byte = slateBlue.R
        Dim a As Byte = slateBlue.A
        Dim text As String = _
        String.Format("Slate Blue has these ARGB values: Alpha:{0}, " _
           & "red:{1}, green: {2}, blue {3}", New Object() {a, r, g, b})
        e.Graphics.DrawString(text, New Font(Me.Font, FontStyle.Italic), _
            New SolidBrush(slateBlue), _
            New RectangleF(New PointF(0.0F, 0.0F), _
            Size.op_Implicit(Me.Size)))
    End Sub