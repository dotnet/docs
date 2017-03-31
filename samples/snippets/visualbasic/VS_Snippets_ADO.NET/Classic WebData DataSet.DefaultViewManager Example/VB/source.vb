imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub GetDefaultDataViewManager()
    ' Get a DataSet object's DefaultViewManager.
     Dim view As DataViewManager = DataSet1.DefaultViewManager

    ' Add a DataTable to the DataTableCollection.
    Dim table As DataTable
    table = New DataTable("TableName")
    view.DataSet.Tables.Add(table)
End Sub
' </Snippet1>

End Class
