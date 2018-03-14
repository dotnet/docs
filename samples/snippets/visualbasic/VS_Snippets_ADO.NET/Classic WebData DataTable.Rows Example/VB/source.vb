Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub PrintRows(dataSet As DataSet)
     ' For each table in the DataSet, print the values of each row.
     Dim thisTable As DataTable
     For Each thisTable In  dataSet.Tables
         ' For each row, print the values of each column.
         Dim row As DataRow
         For Each row In  thisTable.Rows
             Dim column As DataColumn
             For Each column In  thisTable.Columns
                 Console.WriteLine(row(column))
             Next column
         Next row
     Next thisTable
End Sub
    
    
Private Sub AddARow(dataSet As DataSet)
    Dim table As DataTable = dataSet.Tables("Suppliers")
    ' Use the NewRow method to create a DataRow 
    'with the table's schema.
    Dim newRow As DataRow = table.NewRow()

    ' Set values in the columns:
    newRow("CompanyID") = "NewCompanyID"
    newRow("CompanyName") = "NewCompanyName"

    ' Add the row to the rows collection.
    table.Rows.Add(newRow)
End Sub
' </Snippet1>
End Class
