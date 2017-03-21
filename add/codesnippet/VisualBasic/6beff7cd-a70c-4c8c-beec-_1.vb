    Private Sub Clone_Example2(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from a file.
        Dim myBitmap As New Bitmap("Grapes.jpg")

        ' Clone a portion of the Bitmap object.
        Dim cloneRect As New RectangleF(0, 0, 100, 100)
        Dim format As PixelFormat = myBitmap.PixelFormat
        Dim cloneBitmap As Bitmap = myBitmap.Clone(cloneRect, format)

        ' Draw the cloned portion of the Bitmap object.
        e.Graphics.DrawImage(cloneBitmap, 0, 0)
    End Sub