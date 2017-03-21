   ' This method calls the ToolStripDropDown control's Show 
   ' method to display the ContextMenuStrip relative to the
   ' owning control.
   Private Sub button1_MouseUp(sender As Object, e As MouseEventArgs) Handles button1.MouseUp
        Dim c As Control = CType(sender, Control)
      
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.contextMenuStrip1.Show(c, e.Location, Me.dropDownDirection)
        End If
    End Sub