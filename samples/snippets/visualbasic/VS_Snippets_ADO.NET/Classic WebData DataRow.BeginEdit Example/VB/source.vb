Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub DemonstrateRowBeginEdit()
     Dim table As New DataTable("table1")
     Dim column As New DataColumn("col1", Type.GetType("System.Int32"))
     AddHandler table.RowChanged, AddressOf Row_Changed
     table.Columns.Add(column)

     ' Add a UniqueConstraint to the table.
     table.Constraints.Add(New UniqueConstraint(column))

     ' Add five rows.
     Dim newRow As DataRow
        
     Dim i As Integer
     For i = 0 To 4
         ' RowChanged event will occur for every addition.
         newRow = table.NewRow()
         newRow(0) = i
         table.Rows.Add(newRow)
     Next i

     ' AcceptChanges.
     table.AcceptChanges()

     ' Invoke BeginEdit on each.
     Console.WriteLine(ControlChars.Cr _
        & " Begin Edit and print original and proposed values " _
        & ControlChars.Cr)
     Dim row As DataRow
     For Each row In  table.Rows           
         row.BeginEdit()
         row(0) = CInt(row(0)) & 10
         Console.Write(ControlChars.Tab & " Original " & ControlChars.Tab _
            & row(0, DataRowVersion.Original).ToString())
         Console.Write(ControlChars.Tab & " Proposed " & ControlChars.Tab _
            & row(0, DataRowVersion.Proposed).ToString() & ControlChars.Cr)
     Next row
     Console.WriteLine(ControlChars.Cr)

     ' Accept changes
     table.AcceptChanges()

     ' Change two rows to identical values after invoking BeginEdit.
     table.Rows(0).BeginEdit()
     table.Rows(1).BeginEdit()
     table.Rows(0)(0) = 100
     table.Rows(1)(0) = 100
     Try
         ' Now invoke EndEdit. This will cause the UniqueConstraint
         ' to be enforced.
         table.Rows(0).EndEdit()
         table.Rows(1).EndEdit()
     Catch e As Exception
	 ' Process exception and return.
         Console.WriteLine("Exception of type {0} occurred.", _
            e.GetType().ToString())
     End Try
 End Sub
 
 Private Sub Row_Changed _
 (sender As Object, e As System.Data.DataRowChangeEventArgs)
     Dim table As DataTable = CType(sender, DataTable)
     Console.WriteLine("RowChanged " & e.Action.ToString() _
        & ControlChars.Tab & e.Row.ItemArray(0).ToString())
 End Sub
' </Snippet1>
End Class
