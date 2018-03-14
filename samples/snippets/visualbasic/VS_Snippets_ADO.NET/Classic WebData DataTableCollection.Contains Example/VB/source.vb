imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub TestForTableName()
    ' Get the DataSet of a DataGrid.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)

    ' Get the DataTableCollection through the Tables property.
    Dim tablesCol As DataTableCollection = thisDataSet.Tables

    ' Check if the named table exists.
    If tablesCol.Contains("Suppliers") Then 
       Console.WriteLine("Table named Suppliers exists")
    End If
 End Sub
' </Snippet1>

End Class
