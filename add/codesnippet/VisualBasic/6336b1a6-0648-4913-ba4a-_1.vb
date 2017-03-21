   ' This method explicitly closes the ToolStripDropDown control
   ' and specifies the reason for closing as CloseCalled.
   Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
      Me.contextMenuStrip1.Close(ToolStripDropDownCloseReason.CloseCalled)
    End Sub