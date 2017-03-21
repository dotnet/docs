    Private Sub ConvertRectangleToRectangleF( _
        ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rectangle1 As New Rectangle(30, 40, 50, 100)

        ' Convert it to a RectangleF.
        Dim convertedRectangle As RectangleF = _
            RectangleF.op_Implicit(rectangle1)

        ' Create a new RectangleF.
        Dim rectangle2 As New RectangleF(New PointF(30.0F, 40.0F), _
            New SizeF(50.0F, 100.0F))

        ' Create a custom, partially transparent brush.
        Dim redBrush As New SolidBrush(Color.FromArgb(40, Color.Red))

        ' Compare the converted rectangle with the new one.  If they 
        ' are equal, draw and fill the rectangles on the form.
        If (RectangleF.op_Equality(convertedRectangle, rectangle2)) Then
            e.Graphics.FillRectangle(redBrush, rectangle2)
        End If

        ' Dispose of the custom brush.
        redBrush.Dispose()
    End Sub