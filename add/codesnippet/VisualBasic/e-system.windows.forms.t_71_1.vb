   ' This method handles the DropDownClosed event from a 
   ' ToolStripDropDownItem. It displays the value of the 
   ' item's Text property in the form's StatusStrip control.
    Private Sub toolStripDropDownItem_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs)

        Dim item As ToolStripDropDownItem = CType(sender, ToolStripDropDownItem)

        Dim msg As String = String.Format("Item closed: {0}", item.Text)
        Me.toolStripStatusLabel1.Text = msg

    End Sub