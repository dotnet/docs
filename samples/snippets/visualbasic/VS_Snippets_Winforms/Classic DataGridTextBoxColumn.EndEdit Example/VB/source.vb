imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form
 Protected dataGrid1 As DataGrid
 Protected dataSet1 As DataSet
 Protected edit1 As TextBox 
' <Snippet1>
Private Sub EditGrid()
    ' Get the current DataGridColumnStyle through the CurrentCell.
    Dim dgCol As DataGridColumnStyle
    Dim colNum As Integer
    Dim rowNum As Integer
    Dim dataTable1 As DataTable
    
    With dataGrid1.CurrentCell
        colNum = .ColumnNumber
        rowNum = .RowNumber    
    End With
    dgCol = dataGrid1.TableStyles(0).GridColumnStyles(ColNum)
    ' Invoke the BeginEdit method.
     
    If dataGrid1.BeginEdit(dgCol, rowNum) Then
        ' Edit row value.
        dataTable1 = dataSet1.Tables(dataGrid1.DataMember)
        Dim myRow As DataRow
        myRow = dataTable1.Rows(rowNum)
        myRow.BeginEdit
        myRow(colNum) = edit1.Text
        myRow.AcceptChanges
        dataTable1.AcceptChanges
        Console.WriteLine("Edited?")
        dataGrid1.EndEdit(dgcol, rowNum, False)
    Else
        Console.WriteLine("BeginEdit failed.")
    End If
End Sub
' </Snippet1>
End Class
