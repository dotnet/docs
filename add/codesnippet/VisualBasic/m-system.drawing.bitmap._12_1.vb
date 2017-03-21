    Private Sub MakeTransparent_Example2(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("Grapes.gif")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, _
            myBitmap.Height)

        ' Get the color of a background pixel.
        Dim backColor As Color = myBitmap.GetPixel(1, 1)

        ' Make backColor transparent for myBitmap.
        myBitmap.MakeTransparent(backColor)

        ' Draw the transparent bitmap to the screen.
        e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0, myBitmap.Width, _
            myBitmap.Height)
    End Sub