   ' This method handles the DropDownOpened event from a 
   ' ToolStripDropDownItem. It displays the value of the 
   ' item's Text property in the form's StatusStrip control.
    Private Sub toolStripDropDownItem_DropDownOpened(ByVal sender As Object, ByVal e As EventArgs)

        Dim item As ToolStripDropDownItem = CType(sender, ToolStripDropDownItem)

        Dim msg As String = String.Format("Item opened: {0}", item.Text)
        Me.toolStripStatusLabel1.Text = msg

    End Sub