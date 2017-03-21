    Private Function DrawImageCallback3(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageParaFRectAttribAbort(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback3)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing original image.
        Dim ulCorner1 As New PointF(100.0F, 100.0F)
        Dim urCorner1 As New PointF(325.0F, 100.0F)
        Dim llCorner1 As New PointF(150.0F, 250.0F)
        Dim destPara1 As PointF() = {ulCorner1, urCorner1, llCorner1}

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New PointF(325.0F, 100.0F)
        Dim urCorner2 As New PointF(550.0F, 100.0F)
        Dim llCorner2 As New PointF(375.0F, 250.0F)
        Dim destPara2 As PointF() = {ulCorner2, urCorner2, llCorner2}

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
            imageAttr, imageCallback)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub