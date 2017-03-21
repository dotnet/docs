    Private Sub AddStripToCollection() 
        ' Add the image strip.
        Dim bitmaps As New Bitmap(GetType(PrintPreviewDialog), "PrintPreviewStrip.bmp")
        imageList1.Images.AddStrip(bitmaps)
        
        ' Iterate through the images and display them on the form.
        Dim i As Integer
        For i = 0 To imageList1.Images.Count
            
            imageList1.Draw(Me.CreateGraphics(), New Point(10, 10), i)
            Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
        Next i
     
    End Sub
    
    
    