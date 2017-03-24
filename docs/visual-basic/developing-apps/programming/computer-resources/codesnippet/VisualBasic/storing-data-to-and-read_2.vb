    If My.Computer.Clipboard.ContainsImage() Then
      Dim grabpicture As System.Drawing.Image
      grabpicture = My.Computer.Clipboard.GetImage()
      picturebox1.Image = grabpicture
    End If