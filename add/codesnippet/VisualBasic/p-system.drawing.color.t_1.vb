    Private Sub UseTransparentProperty()

        ' Set up the PictureBox to display the entire image, and
        ' to cover the entire client area.
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Dock = DockStyle.Fill

        Try
            ' Set the Image property of the PictureBox to an image retrieved
            ' from the file system.
            PictureBox1.Image = _
                Image.FromFile("C:\Documents and Settings\All Users\" _
                & "Documents\My Pictures\Sample Pictures\sunset.jpg")

            ' Set the Parent property of Button1 and Button2 to the 
            ' PictureBox.
            Button1.Parent = PictureBox1
            Button2.Parent = PictureBox1

            ' Set the Color property of both buttons to transparent. 
            ' With this setting, the buttons assume the color of their
            ' parent.
            Button1.BackColor = Color.Transparent
            Button2.BackColor = Color.Transparent

        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("There was an error." _
            & "Make sure the image file path is valid.")
        End Try


    End Sub