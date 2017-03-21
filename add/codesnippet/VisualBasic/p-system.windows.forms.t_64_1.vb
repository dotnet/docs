   ' This method defines the painting behavior of the control.
   ' It performs the following operations:
   '
   ' Computes the layout of the item's image and text.
   ' Draws the item's background image.
   ' Draws the item's image.
   ' Draws the item's text.
   '
   ' Drawing operations are implemented in the 
   ' RolloverItemRenderer class.
   Protected Overrides Sub OnPaint(e As PaintEventArgs)
      MyBase.OnPaint(e)
      
      If (Me.Owner IsNot Nothing) Then
         ' Find the dimensions of the image and the text 
         ' areas of the item. 
         Me.ComputeImageAndTextLayout()
         
         ' Draw the background. This includes drawing a highlighted 
         ' border when the mouse is in the client area.
         Dim ea As New ToolStripItemRenderEventArgs(e.Graphics, Me)
         Me.Owner.Renderer.DrawItemBackground(ea)
         
         ' Draw the item's image. 
         Dim irea As New ToolStripItemImageRenderEventArgs(e.Graphics, Me, imageRect)
         Me.Owner.Renderer.DrawItemImage(irea)
         
         ' If the item is on a drop-down, give its
         ' text a different highlighted color.
            Dim highlightColor As Color = CType(IIf(Me.IsOnDropDown, Color.Salmon, SystemColors.ControlLightLight), Color)
         
         ' Draw the text, and highlight it if the 
         ' the rollover state is true.
            Dim rea As New ToolStripItemTextRenderEventArgs( _
               e.Graphics, _
               Me, _
               MyBase.Text, _
               textRect, _
               CType(IIf(Me.rolloverValue, highlightColor, MyBase.ForeColor), Color), _
               MyBase.Font, _
               MyBase.TextAlign)
         Me.Owner.Renderer.DrawItemText(rea)
      End If
    End Sub