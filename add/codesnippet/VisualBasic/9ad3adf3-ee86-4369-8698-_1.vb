    Private Sub ShowOutputChannels(ByVal e As PaintEventArgs)

        'Create a bitmap from a file.
        Dim bmp1 As New Bitmap("c:\fakePhoto.jpg")

        ' Create a new bitmap from the original, resizing it for this example.
        Dim bmp2 As New Bitmap(bmp1, New Size(80, 80))

        bmp1.Dispose()

        ' Create an ImageAttributes object.
        Dim imgAttributes As New System.Drawing.Imaging.ImageAttributes()

        ' Draw the image unaltered.
        e.Graphics.DrawImage(bmp2, 10, 10)

        ' Draw the image, showing the intensity of the cyan channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelC, ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(100, 10, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        ' Draw the image, showing the intensity of the magenta channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelM, ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(10, 100, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        ' Draw the image, showing the intensity of the yellow channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelY, _
            ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(100, 100, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        ' Draw the image, showing the intensity of the black channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelK, _
            ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(10, 190, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        'Dispose of the bitmap.
        bmp2.Dispose()

    End Sub
