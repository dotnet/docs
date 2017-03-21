    ' Updated the criteria label.
    Private Sub dataGridView_AutoSizeColumnCriteriaChanged( _
        ByVal sender As Object, _
        ByVal args As DataGridViewAutoSizeColumnModeEventArgs) _
        Handles DataGridView.AutoSizeColumnModeChanged

        args.Column.DataGridView.Parent. _
        Controls("flowlayoutpanel"). _
        Controls(criteriaLabel).Text = _
            criteriaLabel & args.Column.AutoSizeMode.ToString
    End Sub