    Private Sub ChangePageScaleAndTranslateTransform(ByVal e As _
        PaintEventArgs)

        ' Create a rectangle.
        Dim rectangle1 As New Rectangle(20, 20, 50, 100)

        ' Draw its outline.
        e.Graphics.DrawRectangle(Pens.SlateBlue, rectangle1)

        ' Change the page scale.  
        e.Graphics.PageScale = 2.0F

        ' Call TranslateTransform to change the origin of the
        '  Graphics object.
        e.Graphics.TranslateTransform(10.0F, 10.0F)

        ' Draw the rectangle again.
        e.Graphics.DrawRectangle(Pens.Tomato, rectangle1)

        ' Set the page scale and origin back to their original values.
        e.Graphics.PageScale = 1.0F
        e.Graphics.ResetTransform()

        Dim transparentBrush As New SolidBrush(Color.FromArgb(50, Color.Yellow))

        ' Create a new rectangle with the coordinates you expect
        ' after setting PageScale and calling TranslateTransform:
        ' x = (10 + 20) * 2
        ' y = (10 + 20) * 2
        ' Width = 50 * 2
        ' Length = 100 * 2
        Dim newRectangle As Rectangle = New Rectangle(60, 60, 100, 200)

        ' Fill in the rectangle with a semi-transparent color.
        e.Graphics.FillRectangle(transparentBrush, newRectangle)
    End Sub