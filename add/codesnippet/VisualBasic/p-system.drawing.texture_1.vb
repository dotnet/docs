    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim image1 As Bitmap = _
                CType(Image.FromFile("C:\Documents and Settings\" _
                & "All Users\Documents\My Music\music.bmp", True), Bitmap)

            Dim texture As New TextureBrush(image1)
            texture.WrapMode = Drawing2D.WrapMode.Tile
            Dim formGraphics As Graphics = Me.CreateGraphics()
            formGraphics.FillEllipse(texture, _
                New RectangleF(90.0F, 110.0F, 100, 100))
            formGraphics.Dispose()

        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("There was an error opening the bitmap." _
                & "Please check the path.")
        End Try

    End Sub