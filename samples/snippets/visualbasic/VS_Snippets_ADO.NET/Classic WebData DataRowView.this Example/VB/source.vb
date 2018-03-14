Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub SetDataRowView()
     Dim view As DataView = CType(dataGrid1.DataSource, DataView)

     ' Set the filter to display only those rows that were modified.
     view.RowStateFilter = DataViewRowState.ModifiedCurrent

     ' Change the value of the CompanyName column for each modified row.
     Dim rowView As DataRowView
     For Each rowView In  view
         rowView.Item("CompanyName") = _
         rowView.Item("CompanyName").ToString() & " new value"
     Next rowView
End Sub
' </Snippet1>
End Class
