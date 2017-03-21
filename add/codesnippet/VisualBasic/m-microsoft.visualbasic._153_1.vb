If My.Computer.Clipboard.ContainsImage() Then
   Dim grabpicture = My.Computer.Clipboard.GetImage()
   PictureBox1.Image = grabpicture
End If