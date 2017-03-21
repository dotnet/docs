        Dim image As New Bitmap("InputColor.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height

        ' The following matrix consists of the following transformations:
        ' red scaling factor of 2
        ' green scaling factor of 1
        ' blue scaling factor of 1
        ' alpha scaling factor of 1
        ' three translations of 0.2
        Dim colorMatrixElements As Single()() = { _
           New Single() {2, 0, 0, 0, 0}, _
           New Single() {0, 1, 0, 0, 0}, _
           New Single() {0, 0, 1, 0, 0}, _
           New Single() {0, 0, 0, 1, 0}, _
           New Single() {0.2F, 0.2F, 0.2F, 0, 1}}

        Dim colorMatrix As New ColorMatrix(colorMatrixElements)

        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(image, 10, 10)

        e.Graphics.DrawImage( _
           image, _
           New Rectangle(120, 10, width, height), _
           0, _
           0, _
           width, _
           height, _
           GraphicsUnit.Pixel, _
           imageAttributes)
