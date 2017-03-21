    Private Sub MakeDataView(ByVal dataSet As DataSet)
        Dim view As New DataView(dataSet.Tables("Suppliers"), _
            "Country = 'UK'", "CompanyName", _
            DataViewRowState.CurrentRows)
        view.AllowEdit = True
        view.AllowNew = True
        view.AllowDelete = True
    End Sub