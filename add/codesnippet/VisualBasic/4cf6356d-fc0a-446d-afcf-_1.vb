    ' Handle the timer tick; draw each progressively larger rectangle.
    Private Sub progressTimer_Tick(ByVal myObject As [Object], ByVal e As EventArgs) 
        If ticks < NumberChunks Then
            Dim g As Graphics = Me.CreateGraphics()
            Try
                ProgressBarRenderer.DrawVerticalChunks(g, progressBarRectangles(ticks))
                ticks += 1
            Finally
                g.Dispose()
            End Try
        Else
            progressTimer.Enabled = False
        End If
    
    End Sub 'progressTimer_Tick
    