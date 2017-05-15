imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub GetIndexes()
    ' Get the DataSet of a DataGrid.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)

    ' Get the DataTableCollection through the Tables property.
    Dim tables As DataTableCollection = thisDataSet.Tables

    ' Get the index of the table named "Authors", if it exists.
    If tables.Contains("Authors") Then
       System.Diagnostics.Debug.WriteLine(tables.IndexOf("Authors"))
    End If
 End Sub
' </Snippet1>

End Class
