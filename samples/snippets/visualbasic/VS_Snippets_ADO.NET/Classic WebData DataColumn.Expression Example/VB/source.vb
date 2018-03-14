imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected dataGrid1 As DataGrid

' <Snippet1>
Private Sub CalcColumns()
     Dim rate As Single = .0862
     dim table as DataTable = New DataTable 
 
     ' Create the first column.
     Dim priceColumn As DataColumn = New DataColumn
     With priceColumn
         .DataType = System.Type.GetType("System.Decimal")
         .ColumnName = "price"
         .DefaultValue = 50
     End With
     
     ' Create the second, calculated, column.
     Dim taxColumn As DataColumn = New DataColumn
     With taxColumn
         .DataType = System.Type.GetType("System.Decimal")
         .ColumnName = "tax"
         .Expression = "price * 0.0862"
     End With
     
    ' Create third column
     Dim totalColumn As DataColumn = New DataColumn
     With totalColumn
         .DataType = System.Type.GetType("System.Decimal")
         .ColumnName = "total"
         .Expression = "price + tax"
     End With
 
     ' Add columns to DataTable
     With table.Columns
         .Add(priceColumn)
         .Add(taxColumn)
         .Add(totalColumn)
     End With
    
     Dim row As DataRow= table.NewRow
     table.Rows.Add(row)
     Dim view As New DataView
     view.Table = table
     DataGrid1.DataSource = view
 End Sub
 ' </Snippet1>

End Class
