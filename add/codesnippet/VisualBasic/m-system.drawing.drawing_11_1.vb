    Public Sub DrawVerticalStringFromBottomUp(ByVal e As PaintEventArgs)

        ' Create the string to draw on the form.
        Dim text As String = "Can you read this?"

        ' Create a GraphicsPath.
        Dim path As New System.Drawing.Drawing2D.GraphicsPath

        ' Add the string to the path; declare the font, font style, size, and
        ' vertical format for the string.
        path.AddString(text, Me.Font.FontFamily, 1, 15, New PointF(0.0F, 0.0F), _
            New StringFormat(StringFormatFlags.DirectionVertical))

        ' Declare a matrix that will be used to rotate the text.
        Dim rotateMatrix As New System.Drawing.Drawing2D.Matrix

        ' Set the rotation angle and starting point for the text.
        rotateMatrix.RotateAt(180.0F, New PointF(10.0F, 100.0F))

        ' Transform the text with the matrix.
        path.Transform(rotateMatrix)

        ' Set the SmoothingMode to high quality for best readability.
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        ' Fill in the path to draw the string.
        e.Graphics.FillPath(Brushes.Red, path)

        ' Dispose of the path.
        path.Dispose()

    End Sub