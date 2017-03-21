   ' This method calls the ToolStripDropDown control's Show 
   ' method to display the ContextMenuStrip at a fixed point.
   Private Sub showAtPointButton_Click(sender As Object, e As EventArgs) Handles showAtPointButton.Click, button2.Click
      Me.contextMenuStrip1.Show(23, 55)
    End Sub