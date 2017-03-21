      ' This method draws a border around the GridStrip control.
      Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
         MyBase.OnRenderToolStripBorder(e)
         
         ControlPaint.DrawFocusRectangle(e.Graphics, e.AffectedBounds, SystemColors.ControlDarkDark, SystemColors.ControlDarkDark)
      End Sub 