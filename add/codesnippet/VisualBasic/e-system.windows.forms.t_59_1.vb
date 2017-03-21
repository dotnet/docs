   ' This method handles the Closing event. The ToolStripDropDown
   ' control is not allowed to close unless the Done menu item
   ' is clicked or the Close method is called explicitly.
   ' The Done menu item is enabled only after both of the other
   ' menu items have been selected.
   Private Sub contextMenuStrip_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles contextMenuStrip1.Closing
      If e.CloseReason <> ToolStripDropDownCloseReason.CloseCalled Then
         If subItem1ToolStripMenuItem.Checked AndAlso subItem2ToolStripMenuItem.Checked AndAlso doneToolStripMenuItem.Enabled Then
            ' Reset the state of menu items.
            subItem1ToolStripMenuItem.Checked = False
            subItem2ToolStripMenuItem.Checked = False
            doneToolStripMenuItem.Enabled = False
            
            ' Allow the ToolStripDropDown to close.
            ' Don't cancel the Close operation.
            e.Cancel = False
         Else
            ' Cancel the Close operation to keep the menu open.
            e.Cancel = True
            Me.toolStripStatusLabel1.Text = "Close canceled"
         End If
      End If
    End Sub