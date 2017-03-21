 Private Sub ShowColumn3()
     Dim view As DataView = CType(dataGrid1.DataSource, DataView)

     ' Set the filter to display only those rows that were modified.
     view.RowStateFilter = DataViewRowState.ModifiedCurrent

     ' Change the value of the CompanyName column for each modified row.
     Dim rowView As DataRowView
     For Each rowView In  view
         Console.WriteLine(rowView.Row(2))
     Next rowView
 End Sub