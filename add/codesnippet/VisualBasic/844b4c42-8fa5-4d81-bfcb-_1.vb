   ' This method calls the ToolStripDropDown control's Show 
   ' method to display the ContextMenuStrip relative to the
   ' origin of the form. 
   Private Sub showRelativeButton_Click(sender As Object, e As EventArgs)
      Me.contextMenuStrip1.Show(Me.Location, Me.dropDownDirection)
    End Sub