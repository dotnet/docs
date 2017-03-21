    Public Sub ToString_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Draw a string representation of myFontFamily to the screen.
        e.Graphics.DrawString(myFontFamily.ToString(), _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub