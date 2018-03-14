imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
    Private Sub MakeTable()
        ' Create a DataTable. 
        Dim table As DataTable = new DataTable("Product") 

        ' Create a DataColumn and set various properties. 
        Dim column As DataColumn = New DataColumn 
        column.DataType = System.Type.GetType("System.Decimal") 
        column.AllowDBNull = False 
        column.Caption = "Price"  
        column.ColumnName = "Price" 
        column.DefaultValue = 25 

        ' Add the column to the table. 
        table.Columns.Add(column) 

        ' Add 10 rows and set values. 
        Dim row As DataRow 
        Dim i As Integer  
        For i = 0 to 9 
            row = table.NewRow() 
            row("Price") = i + 1 

            ' Be sure to add the new row to 
            ' the DataRowCollection. 
            table.Rows.Add(row) 
        Next i 
    End Sub
' </Snippet1>

End Class
