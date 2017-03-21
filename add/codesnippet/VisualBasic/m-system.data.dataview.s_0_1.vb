Private Sub MakeDataView()
    Dim view As DataView
    view = New DataView(DataSet1.Tables("Suppliers"))

    ' Bind a ComboBox control to the DataView.
    Combo1.DataSource = view
    Combo1.DisplayMember = "Suppliers.CompanyName"
End Sub