    ' The DrawItem event handler.
    Private Sub MenuItem1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MenuItem1.DrawItem


        Dim MyCaption As String = "Owner Draw Item1"

        ' Create a Brush and a Font with which to draw the item.
        Dim MyBrush As System.Drawing.Brush = System.Drawing.Brushes.AliceBlue
        Dim MyFont As New Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel)
        Dim MySizeF As SizeF = e.Graphics.MeasureString(MyCaption, MyFont)

        ' Draw the item, and then draw a Rectangle around it.
        e.Graphics.DrawString(MyCaption, MyFont, MyBrush, e.Bounds.X, e.Bounds.Y)
        e.Graphics.DrawRectangle(Drawing.Pens.Black, New Rectangle(e.Bounds.X, e.Bounds.Y, MySizeF.Width, MySizeF.Height))

    End Sub
