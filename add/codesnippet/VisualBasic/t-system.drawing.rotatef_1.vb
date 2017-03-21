    Dim bitmap1 As Bitmap

    Private Sub InitializeBitmap()
        Try
            bitmap1 = CType(Bitmap.FromFile("C:\Documents and Settings\All Users\" _
                & "Documents\My Music\music.bmp"), Bitmap)
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            PictureBox1.Image = bitmap1
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("There was an error. Check the path to the bitmap.")
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        If bitmap1 IsNot Nothing Then
            bitmap1.RotateFlip(RotateFlipType.Rotate180FlipY)
            PictureBox1.Image = bitmap1
        End If

    End Sub