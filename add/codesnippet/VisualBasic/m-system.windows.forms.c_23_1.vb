    ' Demonstrates SetImage, ContainsImage, and GetImage.
    Public Function SwapClipboardImage( _
        ByVal replacementImage As System.Drawing.Image) _
        As System.Drawing.Image

        Dim returnImage As System.Drawing.Image = Nothing

        If Clipboard.ContainsImage() Then
            returnImage = Clipboard.GetImage()
            Clipboard.SetImage(replacementImage)
        End If

        Return returnImage
    End Function