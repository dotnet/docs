    Private Function DrawImageCallback1(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageParaRectAttribAbort(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback1)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing original image.
        Dim ulCorner As New Point(100, 100)
        Dim urCorner As New Point(550, 100)
        Dim llCorner As New Point(150, 250)
        Dim destPara1 As Point() = {ulCorner, urCorner, llCorner}

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New Point(325, 100)
        Dim urCorner2 As New Point(550, 100)
        Dim llCorner2 As New Point(375, 250)
        Dim destPara2 As Point() = {ulCorner2, urCorner2, llCorner2}

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
            imageAttr, imageCallback)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub