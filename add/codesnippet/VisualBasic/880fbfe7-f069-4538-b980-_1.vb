    Private Sub BitmapConstructorEx(ByVal e As PaintEventArgs)

        ' Create a bitmap.
        Dim bmp As New Bitmap("c:\fakePhoto.jpg")

        ' Retrieve the bitmap data from the the bitmap.
        Dim bmpData As System.Drawing.Imaging.BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), _
            ImageLockMode.ReadOnly, bmp.PixelFormat)

        'Create a new bitmap.
        Dim newBitmap As New Bitmap(200, 200, bmpData.Stride, bmp.PixelFormat, bmpData.Scan0)

        bmp.UnlockBits(bmpData)

        ' Draw the new bitmap.
        e.Graphics.DrawImage(newBitmap, 10, 10)

    End Sub