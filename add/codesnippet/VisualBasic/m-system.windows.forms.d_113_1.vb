   ' On Click of Button "Unselect Row" this event is raised.
    Private Sub UnselectRow_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        ' Unselect the current row from the Datagrid
        myDataGrid.UnSelect(myDataGrid.CurrentRowIndex)
    End Sub 'UnselectRow_Clicked