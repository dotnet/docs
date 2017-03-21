    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Dim bitmap1 As Bitmap = Bitmap.FromHicon(SystemIcons.Hand.Handle)
        Dim formGraphics As Graphics = Me.CreateGraphics()
        Dim units As GraphicsUnit = GraphicsUnit.Point
        Dim bmpRectangleF As RectangleF = bitmap1.GetBounds(units)
        Dim bmpRectangle As Rectangle = Rectangle.Round(bmpRectangleF)
        formGraphics.DrawRectangle(Pens.Blue, bmpRectangle)
        formGraphics.Dispose()
    End Sub