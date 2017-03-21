    Private Sub ConstructFromResourceSaveAsGif(ByVal e As PaintEventArgs)

        ' Construct a bitmap from the button image resource.
        Dim bmp1 As New Bitmap(GetType(Button), "Button.bmp")

        ' Save the image as a GIF.
        bmp1.Save("c:\button.gif", System.Drawing.Imaging.ImageFormat.Gif)

        ' Construct a new image from the GIF file.
        Dim bmp2 As New Bitmap("c:\button.gif")

        ' Draw the two images.
        e.Graphics.DrawImage(bmp1, New Point(10, 10))
        e.Graphics.DrawImage(bmp2, New Point(10, 40))

        ' Dispose of the image files.
        bmp1.Dispose()
        bmp2.Dispose()
    End Sub