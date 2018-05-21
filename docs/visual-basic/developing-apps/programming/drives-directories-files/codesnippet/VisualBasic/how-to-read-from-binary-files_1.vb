        Dim bytes = My.Computer.FileSystem.ReadAllBytes(
                      "C:/Documents and Settings/selfportrait.jpg")
        PictureBox1.Image = Image.FromStream(New IO.MemoryStream(bytes))