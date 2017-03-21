    Public Sub DisplayScrollBars()
        ' Display or hide the scroll bars based upon  
        ' whether the image is larger than the PictureBox.
        If pictureBox1.Width > pictureBox1.Image.Width Then
            hScrollBar1.Visible = False
        Else
            hScrollBar1.Visible = True
        End If
        
        If pictureBox1.Height > pictureBox1.Image.Height Then
            vScrollBar1.Visible = False
        Else
            vScrollBar1.Visible = True
        End If
    End Sub 'DisplayScrollBars