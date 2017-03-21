    Private Sub IconToBitmap(ByVal e As PaintEventArgs)

        ' Construct an Icon.
        Dim icon1 As New Icon(SystemIcons.Exclamation, 40, 40)

        ' Call ToBitmap to convert it.
        Dim bmp As Bitmap = icon1.ToBitmap()

        ' Draw the bitmap.
        e.Graphics.DrawImage(bmp, New Point(30, 30))
    End Sub