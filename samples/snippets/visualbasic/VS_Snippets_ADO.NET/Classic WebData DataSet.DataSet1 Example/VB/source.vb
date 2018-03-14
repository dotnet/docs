imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub CreateDataSet()
    Dim  dataSet As DataSet = New DataSet("aNewDataSet")

    ' Create two DataTable objects using a function.
    Dim table1 As DataTable = MakeTable("idTable1", "thing1")
    Dim table2 As DataTable = MakeTable("idTable2", "thing2")

    dataSet.Tables.Add(table1)
    dataSet.Tables.Add(table2)
    Console.WriteLine(dataSet.DataSetName, dataSet.Tables.Count)
End Sub


Private Function MakeTable(c1Name As String, c2Name As String) _
    As DataTable
    Dim table As New DataTable
    
    ' Add two DataColumns
    Dim column As DataColumn = New DataColumn( _
        c1Name, System.Type.GetType("System.Integer"))
    table.Columns.Add(column)
    column = New DataColumn(c2Name, _
        System.Type.GetType("System.String"))
    table.Columns.Add(column)
    MakeTable = table
End Function
' </Snippet1>

End Class
