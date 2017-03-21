    Private Sub InitializePictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox1.BorderStyle = _
            System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox1.Location = New System.Drawing.Point(72, 112)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 136)
        Me.PictureBox1.TabStop = False
    End Sub

    Private Sub InitializeOpenFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog

        ' Set the file dialog to filter for graphics files.
        Me.OpenFileDialog1.Filter = _
        "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"

        ' Allow the user to select multiple images.
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "My Image Browser"
    End Sub

    Private Sub fileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles FileButton.Click
        OpenFileDialog1.ShowDialog()
    End Sub


    ' This method handles the FileOK event.  It opens each file 
    ' selected and loads the image from a stream into PictureBox1.
    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, _
    ByVal e As System.ComponentModel.CancelEventArgs) _
     Handles OpenFileDialog1.FileOk

        Me.Activate()
        Dim file, files() As String
        files = OpenFileDialog1.FileNames

        ' Open each file and display the image in PictureBox1.
        ' Call Application.DoEvents to force a repaint after each
        ' file is read.        
        For Each file In files
            Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(file)
            Dim fileStream As System.IO.FileStream = fileInfo.OpenRead()
            PictureBox1.Image = System.Drawing.Image.FromStream(fileStream)
            Application.DoEvents()
            fileStream.Close()

            ' Call Sleep so the picture is briefly displayed, 
            'which will create a slide-show effect.
            System.Threading.Thread.Sleep(2000)
        Next
        PictureBox1.Image = Nothing
    End Sub
