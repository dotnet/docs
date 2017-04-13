Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub GetParentRowForTable( _
    thisTable As DataTable, relation As String)
     If thisTable Is Nothing Then
         Return
     End If

     ' For each row in the table, print column 1 
     ' of the parent DataRow.
     Dim parentRow As DataRow
     Dim row As DataRow
     For Each row In  thisTable.Rows
         parentRow = row.GetParentRow(relation)
         Console.Write(ControlChars.Tab + " child row: " _
            + row(1).ToString())
         Console.Write(ControlChars.Tab + " parent row: " _
            + parentRow(1).ToString() + ControlChars.Cr)
     Next row
End Sub    
    
Private Sub CallGetParentRowForTable()
     ' An example of calling the function.
     Dim thisTable As DataTable = DataSet1.Tables("Products")
     Dim relation As DataRelation = thisTable.ParentRelations(0)
     GetParentRowForTable(thisTable, relation.RelationName)
End Sub
' </Snippet1>
End Class
