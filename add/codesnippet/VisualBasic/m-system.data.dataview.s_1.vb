Private Sub MakeDataView()
    Dim view As DataView = New DataView

    view.Table = DataSet1.Tables("Suppliers")
    view.AllowDelete = True
    view.AllowEdit = True
    view.AllowNew = True
    view.RowFilter = "City = 'Berlin'"
    view.RowStateFilter = DataViewRowState.ModifiedCurrent
    view.Sort = "CompanyName DESC"
    
    ' Simple-bind to a TextBox control
    Text1.DataBindings.Add("Text", view, "CompanyName")
End Sub