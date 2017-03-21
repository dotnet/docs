
    Public Function ThumbnailCallback() As Boolean 
      Return False 
    End Function 

    Public Sub Example_GetThumb(ByVal e As PaintEventArgs) 
        Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback) 
        Dim myBitmap As New Bitmap("Climber.jpg") 
        Dim myThumbnail As Image = myBitmap.GetThumbnailImage(40, 40, myCallback, IntPtr.Zero) 
        e.Graphics.DrawImage(myThumbnail, 150, 75) 
    End Sub 
