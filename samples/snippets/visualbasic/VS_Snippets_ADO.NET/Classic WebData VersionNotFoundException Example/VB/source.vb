Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
    Private Sub DemonstrateVersionNotFoundException()
        ' Create a DataTable with one column.
        Dim table As New DataTable("NewTable")
        Dim column As New DataColumn("NewColumn")
        table.Columns.Add(column)
        Dim newRow As DataRow
        
        Dim i As Integer
        For i = 0 To 9
            newRow = table.NewRow()
            newRow("NewColumn") = i
            table.Rows.Add(newRow)
        Next i
        table.AcceptChanges()

        Try
            Console.WriteLine("Trying...")
            Dim removedRow As DataRow = table.Rows(9)
            removedRow.Delete()
            removedRow.AcceptChanges()

            ' Try to get the Current row version.
            Console.WriteLine(removedRow(0, DataRowVersion.Current))
        
        Catch e As System.Data.VersionNotFoundException
            Console.WriteLine("Current version of row not found.")
        End Try
    End Sub 
    ' </Snippet1>
End Class 'Form1 
