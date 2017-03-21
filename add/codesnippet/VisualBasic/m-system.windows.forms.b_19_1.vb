
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        ' If items remain in the list, remove the first item. 
        If states.Count > 0 Then
            states.RemoveAt(0)

            ' Call ResetBindings to update the textboxes.
            bindingSource1.ResetBindings(False)
        End If

    End Sub 'button1_Click
    