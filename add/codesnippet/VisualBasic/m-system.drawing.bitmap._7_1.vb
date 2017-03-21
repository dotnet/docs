    
    Private Sub DemonstrateGetHbitmapWithColor()
        Dim bm As New Bitmap("Picture.jpg")
        Dim hBitmap As IntPtr
        hBitmap = bm.GetHbitmap(Color.Blue)

        ' Do something with hBitmap.
        DeleteObject(hBitmap)
    End Sub
