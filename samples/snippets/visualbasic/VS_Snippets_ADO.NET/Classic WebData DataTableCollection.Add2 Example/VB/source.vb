imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub AddTables()
    Dim table As DataTable
    
    ' Presuming a DataGrid is displaying more than one table, get its DataSet.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)
    Dim i As Integer
    For i = 0 to 2
       thisDataSet.Tables.Add()
    Next i

    Console.WriteLine(thisDataSet.Tables.Count.ToString() & " tables")
    For Each table In thisDataSet.Tables
       Console.WriteLine(table.TableName)
    Next
 End Sub
' </Snippet1>

End Class
