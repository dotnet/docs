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
 Private Sub GetChildRowsFromDataRelation(table As DataTable)
     Dim rowArray() As DataRow
     Dim relation As DataRelation, row As DataRow
     Dim column As DataColumn, i As Integer     
     For Each relation In  table.ParentRelations
         For Each row In  table.Rows
             rowArray = row.GetParentRows(relation)
             ' Print values of rows.             
             For i = 0 To rowArray.Length - 1                 
                 For Each column In  table.Columns
                     Console.WriteLine(rowArray(i)(column))
                 Next column
             Next i
         Next row
     Next relation
 End Sub
' </Snippet1>
End Class
