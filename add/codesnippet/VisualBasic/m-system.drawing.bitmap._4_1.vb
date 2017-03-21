    Private Sub LockUnlockBitsExample(ByVal e As PaintEventArgs)

        ' Create a new bitmap.
        Dim bmp As New Bitmap("c:\fakePhoto.jpg")

        ' Lock the bitmap's bits.  
        Dim rect As New Rectangle(0, 0, bmp.Width, bmp.Height)
        Dim bmpData As System.Drawing.Imaging.BitmapData = bmp.LockBits(rect, _
            Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat)

        ' Get the address of the first line.
        Dim ptr As IntPtr = bmpData.Scan0

        ' Declare an array to hold the bytes of the bitmap.
        ' This code is specific to a bitmap with 24 bits per pixels.
        Dim bytes As Integer = Math.Abs(bmpData.Stride) * bmp.Height
        Dim rgbValues(bytes - 1) As Byte

        ' Copy the RGB values into the array.
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)

        ' Set every third value to 255. A 24bpp image will look red.
        For counter As Integer = 2 To rgbValues.Length - 1 Step 3
            rgbValues(counter) = 255
        Next

        ' Copy the RGB values back to the bitmap
        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

        ' Unlock the bits.
        bmp.UnlockBits(bmpData)

        ' Draw the modified image.
        e.Graphics.DrawImage(bmp, 0, 150)

    End Sub