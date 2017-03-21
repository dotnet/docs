<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function DeleteObject (ByVal hObject As IntPtr) As Boolean
    End Function
   


    Private Sub DemonstrateGetHbitmap()
        Dim bm As New Bitmap("Picture.jpg")
        Dim hBitmap As IntPtr
        hBitmap = bm.GetHbitmap()

        ' Do something with hBitmap.
        DeleteObject(hBitmap)
    End Sub
