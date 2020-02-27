imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub AddNew()
    Dim table As New DataTable()

    ' Not shown: code to populate DataTable.

    Dim view As New DataView(table)
    view.AllowNew = True
    Dim rowView As DataRowView
    rowView = view.AddNew
    rowView("ProductName") = "New Product Name"
End Sub
' </Snippet1>

End Class
