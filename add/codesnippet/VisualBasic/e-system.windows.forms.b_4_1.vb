    ' This event handler detects changes in the BindingSource 
    ' list or changes to items within the list.
    Private Sub customersBindingSource_ListChanged(ByVal sender As Object, _
        ByVal e As ListChangedEventArgs) Handles customersBindingSource.ListChanged

        status.Text = e.ListChangedType.ToString()
    End Sub