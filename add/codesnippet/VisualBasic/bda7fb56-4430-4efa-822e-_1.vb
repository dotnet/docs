    ' Draw the group box in the current state.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs) 
        MyBase.OnPaint(e)
        
        GroupBoxRenderer.DrawGroupBox(e.Graphics, ClientRectangle, Me.Text, Me.Font, state)
        
        ' Draw an additional inner border if visual styles are enabled.
        If Application.RenderWithVisualStyles Then
            GroupBoxRenderer.DrawGroupBox(e.Graphics, innerRectangle, state)
        End If
    
    End Sub 'OnPaint
    