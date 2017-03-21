   ' This method shows the drop-down for the first item
   ' in the form's ToolStrip.
    Private Sub showButton_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) _
    Handles showButton.Click

        Dim item As ToolStripDropDownItem = CType(Me.toolStrip1.Items(0), ToolStripDropDownItem)

        If item.HasDropDownItems Then
            item.ShowDropDown()
        End If

    End Sub