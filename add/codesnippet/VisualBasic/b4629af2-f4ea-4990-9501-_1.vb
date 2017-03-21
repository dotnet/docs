    Private Sub DrawALineOfText(ByVal e As PaintEventArgs)
        ' Declare strings to render on the form.
        Dim stringsToPaint() As String = {"Tail", "Spin", " Toys"}

        ' Declare fonts for rendering the strings.
        Dim fonts() As Font = {New Font("Arial", 14, FontStyle.Regular), _
            New Font("Arial", 14, FontStyle.Italic), _
            New Font("Arial", 14, FontStyle.Regular)}

        Dim startPoint As New Point(10, 10)

        ' Set TextFormatFlags to no padding so strings are drawn together.
        Dim flags As TextFormatFlags = TextFormatFlags.NoPadding

        ' Declare a proposed size with dimensions set to the maximum integer value.
        Dim proposedSize As Size = New Size(Integer.MaxValue, Integer.MaxValue)

        ' Measure each string with its font and NoPadding value and draw it to the form.
        For i As Integer = 0 To stringsToPaint.Length - 1
            Dim size As Size = TextRenderer.MeasureText(e.Graphics, _
                stringsToPaint(i), fonts(i), proposedSize, flags)
            Dim rect As Rectangle = New Rectangle(startPoint, size)
            TextRenderer.DrawText(e.Graphics, stringsToPaint(i), fonts(i), _
                startPoint, Color.Black, flags)
            startPoint.X += size.Width
        Next
    End Sub