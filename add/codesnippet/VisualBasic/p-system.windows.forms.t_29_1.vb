      ' This method renders the GridStrip control's background.
      Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
         MyBase.OnRenderToolStripBackground(e)
         
         ' This late initialization is a workaround. The gradient
         ' depends on the bounds of the GridStrip control. The bounds 
         ' are dependent on the layout engine, which hasn't fully
         ' performed layout by the time the Initialize method runs.
         If Me.backgroundBrush Is Nothing Then
            Me.backgroundBrush = New LinearGradientBrush(e.ToolStrip.ClientRectangle, SystemColors.ControlLightLight, SystemColors.ControlDark, 90, True)
         End If
         
         ' Paint the GridStrip control's background.
         e.Graphics.FillRectangle(Me.backgroundBrush, e.AffectedBounds)
        End Sub