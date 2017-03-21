    Dim image1 As Bitmap

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        Try
            ' Retrieve the image.
            image1 = New Bitmap( _
                "C:\Documents and Settings\All Users\Documents\My Music\music.bmp", _
                True)

            Dim x, y As Integer

            ' Loop through the images pixels to reset color.
            For x = 0 To image1.Width - 1
                For y = 0 To image1.Height - 1
                    Dim pixelColor As Color = image1.GetPixel(x, y)
                    Dim newColor As Color = _
                        Color.FromArgb(pixelColor.R, 0, 0)
                    image1.SetPixel(x, y, newColor)
                Next
            Next

            ' Set the PictureBox to display the image.
            PictureBox1.Image = image1

            ' Display the pixel format in Label1.
            Label1.Text = "Pixel format: " + image1.PixelFormat.ToString()

        Catch ex As ArgumentException
            MessageBox.Show("There was an error." _
                & "Check the path to the image file.")
        End Try
    End Sub