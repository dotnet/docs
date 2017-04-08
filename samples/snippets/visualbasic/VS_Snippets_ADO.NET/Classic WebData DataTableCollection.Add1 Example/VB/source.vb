imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub AddTable()
    ' Presuming a DataGrid is displaying more than one table, 
    ' get its DataSet.
    Dim thisDataSet As DataSet = _
        CType(DataGrid1.DataSource, DataSet)

    ' Use the Add method to add a new table with a given name.
    Dim table As DataTable = thisDataSet.Tables.Add("NewTable")

    ' Code to add columns and rows not shown here.

    Console.WriteLine(table.TableName)
    Console.WriteLine(thisDataSet.Tables.Count.ToString())
End Sub
' </Snippet1>

End Class
