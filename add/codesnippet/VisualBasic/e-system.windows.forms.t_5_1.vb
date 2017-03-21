   ' This method handles the DropDownItemClicked event from a 
   ' ToolStripDropDownItem. It displays the value of the clicked
   ' item's Text property in the form's StatusStrip control.
    Private Sub toolStripDropDownItem_DropDownItemClicked( _
    ByVal sender As Object, _
    ByVal e As ToolStripItemClickedEventArgs)

        Dim msg As String = String.Format("Item clicked: {0}", e.ClickedItem.Text)
        Me.toolStripStatusLabel1.Text = msg

    End Sub