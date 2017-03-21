Private Sub AddNewDataRowView(view As DataView)
    Dim rowView As DataRowView = view.AddNew

    ' Change values in the DataRow.
    rowView("ColumnName") = "New value"
    rowView.EndEdit
End Sub