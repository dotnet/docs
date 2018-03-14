imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub AddNewDataRowView(view As DataView)
    Dim rowView As DataRowView = view.AddNew

    ' Change values in the DataRow.
    rowView("ColumnName") = "New value"
    rowView.EndEdit
End Sub
' </Snippet1>

End Class
