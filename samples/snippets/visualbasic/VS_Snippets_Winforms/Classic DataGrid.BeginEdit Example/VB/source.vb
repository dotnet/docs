Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub EditGrid(dataGrid1 As DataGrid)
        ' Get the selected row and column through the CurrentCell.
        Dim colNum As Integer
        Dim rowNum As Integer
        colNum = dataGrid1.CurrentCell.ColumnNumber
        rowNum = dataGrid1.CurrentCell.RowNumber
        ' Get the selected DataGridColumnStyle.
        Dim dgCol As DataGridColumnStyle
        dgCol = dataGrid1.TableStyles(0).GridColumnStyles(colNum)
        ' Invoke the BeginEdit method to see if editing can begin.
        If dataGrid1.BeginEdit(dgCol, rowNum) Then
            ' Edit row value. Get the DataTable and selected row.
            Dim myTable As DataTable
            Dim myRow As DataRow
            ' Assuming the DataGrid is bound to a DataTable.
            myTable = CType(dataGrid1.DataSource, DataTable)
            myRow = myTable.Rows(rowNum)
            ' Invoke the Row object's BeginEdit method.
            myRow.BeginEdit()
            myRow(colNum) = "New Value"
            ' You must accept changes on both DataRow and DataTable.
            myRow.AcceptChanges()
            myTable.AcceptChanges()
            dataGrid1.EndEdit(dgCol, rowNum, False)
        Else
            Console.WriteLine("BeginEdit failed")
        End If
    End Sub 'EditGrid
    ' </Snippet1>
End Class 'Form1 

