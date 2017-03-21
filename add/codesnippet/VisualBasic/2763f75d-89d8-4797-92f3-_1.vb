    Sub Grid_Change(sender As Object, e As DataGridPageChangedEventArgs)
        Dim page_change_args As New DataGridPageChangedEventArgs(e.CommandSource, e.NewPageIndex)
    End Sub 'Grid_Change