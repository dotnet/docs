    Private Sub MakeTransparent_Example1(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("Grapes.gif")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, _
        myBitmap.Height)

        ' Make the default transparent color transparent for myBitmap.
        myBitmap.MakeTransparent()

        ' Draw the transparent bitmap to the screen.
        e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0, myBitmap.Width, _
        myBitmap.Height)
    End Sub