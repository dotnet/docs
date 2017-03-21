   ' This method hides the drop-down for the first item
   ' in the form's ToolStrip.
    Private Sub hideButton_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) _
    Handles hideButton.Click

        Dim item As ToolStripDropDownItem = CType(Me.toolStrip1.Items(0), ToolStripDropDownItem)

        item.HideDropDown()
    End Sub