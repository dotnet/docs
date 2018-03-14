imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub RemoveTables()
    ' Set the name of the table to test for and remove.
    Dim name As String = "Suppliers"

    ' Presuming a DataGrid is displaying more than one table, get its DataSet.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)
    Dim tablesCol As DataTableCollection = thisDataSet.Tables
    If tablesCol.Contains(name) _
    And tablesCol.CanRemove(tablesCol(name)) Then 
       tablesCol.Remove(name)
    End If
 End Sub
' </Snippet1>

End Class
