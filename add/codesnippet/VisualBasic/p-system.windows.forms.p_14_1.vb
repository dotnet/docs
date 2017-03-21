    Private pictureBox1 As New PictureBox()
    
    Public Sub CreateBitmapAtRuntime() 
        pictureBox1.Size = New Size(210, 110)
        Me.Controls.Add(pictureBox1)
        
        
        Dim flag As New Bitmap(200, 100)
        Dim flagGraphics As Graphics = Graphics.FromImage(flag)
        Dim red As Integer = 0
        Dim white As Integer = 11
        While white <= 100
            flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10)
            flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10)
            red += 20
            white += 20
        End While
        pictureBox1.Image = flag
    
    End Sub 