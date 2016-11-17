    Private Sub SetEnabled()
        Dim anySelected As Boolean =
            (filesListBox.SelectedItem IsNot Nothing)

        examineButton.Enabled = anySelected
        saveCheckBox.Enabled = anySelected
    End Sub