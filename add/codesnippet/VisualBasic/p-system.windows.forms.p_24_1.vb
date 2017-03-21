    ' Initialize the rectangles used to paint the states of the 
    ' progress bar.
    Private Sub SetupProgressBar() 
        If Not ProgressBarRenderer.IsSupported Then
            Return
        End If
        
        ' Determine the size of the progress bar frame.
        Me.Size = New Size(ClientRectangle.Width, NumberChunks *(ProgressBarRenderer.ChunkThickness + 2 * ProgressBarRenderer.ChunkSpaceThickness) + 6)
        
        ' Initialize the rectangles to draw each step of the 
        ' progress bar.
        progressBarRectangles = New Rectangle(NumberChunks) {}
        
        Dim i As Integer
        For i = 0 To NumberChunks
            ' Use the thickness defined by the current visual style 
            ' to calculate the height of each rectangle. The size 
            ' adjustments ensure that the chunks do not paint over 
            ' the frame.
            Dim filledRectangleHeight As Integer = (i + 1)  _
		*(ProgressBarRenderer.ChunkThickness + 2 * ProgressBarRenderer.ChunkSpaceThickness)
            
            progressBarRectangles(i) = New Rectangle(ClientRectangle.X + 3, _
                ClientRectangle.Y + ClientRectangle.Height - 3 - filledRectangleHeight, _
                ClientRectangle.Width - 6, filledRectangleHeight)
        Next i
    
    End Sub 'SetupProgressBar
    