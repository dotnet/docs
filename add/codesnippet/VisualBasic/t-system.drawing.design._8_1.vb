    <EditorAttribute(GetType(System.Drawing.Design.BitmapEditor), _
        GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property testBitmap() As Bitmap
        Get
            Return testBmp
        End Get
        Set(ByVal Value As Bitmap)
            testBmp = Value
        End Set
    End Property

    Private testBmp As Bitmap