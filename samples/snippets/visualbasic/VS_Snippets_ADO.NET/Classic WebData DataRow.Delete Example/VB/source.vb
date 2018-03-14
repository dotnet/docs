Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub DemonstrateDeleteRow()
     ' Create a simple DataTable with two columns and ten rows.
     Dim table As New DataTable("table")
     Dim idColumn As New DataColumn("id", Type.GetType("System.Int32"))
     idColumn.AutoIncrement = True
     Dim itemColumn As New DataColumn("item", Type.GetType("System.String"))
     table.Columns.Add(idColumn)
     table.Columns.Add(itemColumn)

     ' Add ten rows.
     Dim newRow As DataRow
     
     Dim i As Integer
     For i = 0 To 9
         newRow = table.NewRow()
         newRow("item") = "Item " & i.ToString()
         table.Rows.Add(newRow)
     Next i
     table.AcceptChanges()

     Dim itemColumns As DataRowCollection = table.Rows
     itemColumns(0).Delete()
     itemColumns(2).Delete()
     itemColumns(3).Delete()
     itemColumns(5).Delete()
     Console.WriteLine(itemColumns(3).RowState.ToString())

     ' Reject changes on one deletion.
     itemColumns(3).RejectChanges()

     ' Change the value of the column so it stands out.
     itemColumns(3)("item") = "Deleted, Undeleted, Edited"

     ' Accept changes on others.
     table.AcceptChanges()

     ' Print the remaining row values.
     Dim row As DataRow
     For Each row In  table.Rows
         Console.WriteLine(row(0).ToString() & ControlChars.Tab _
            & row(1).ToString())
     Next row
End Sub
' </Snippet1>
End Class
