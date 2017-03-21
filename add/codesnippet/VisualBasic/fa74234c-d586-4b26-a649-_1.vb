    ' Draw the progress bar in its normal state.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs) 
        MyBase.OnPaint(e)
        
        If ProgressBarRenderer.IsSupported Then
            ProgressBarRenderer.DrawVerticalBar(e.Graphics, ClientRectangle)
            Me.Parent.Text = "VerticalProgressBar Enabled"
        Else
            Me.Parent.Text = "VerticalProgressBar Disabled"
        End If
    
    End Sub 'OnPaint
    