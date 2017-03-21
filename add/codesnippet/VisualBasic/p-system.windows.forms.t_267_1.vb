   ' This method toggles the value of the ToolStripDropDown 
   ' control's AutoClose property.
   Private Sub autoCloseCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles autoCloseCheckBox.CheckedChanged
      Me.contextMenuStrip1.AutoClose = Me.contextMenuStrip1.AutoClose Xor True
    End Sub