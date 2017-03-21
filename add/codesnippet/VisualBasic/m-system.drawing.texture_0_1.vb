    Public Sub Clone_Example(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Create an exact copy of tBrush.
        Dim cloneBrush As TextureBrush = CType(tBrush.Clone(), _
        TextureBrush)

        ' Fill a rectangle with cloneBrush.
        e.Graphics.FillRectangle(cloneBrush, 0, 0, 100, 100)
    End Sub