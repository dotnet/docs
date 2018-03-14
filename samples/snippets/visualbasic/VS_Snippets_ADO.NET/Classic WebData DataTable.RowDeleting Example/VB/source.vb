Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample

Shared Sub Main()
  DataTableRowDeleting()
End Sub

' <Snippet1>
Private Shared Sub DataTableRowDeleting()
	Dim customerTable As DataTable = New DataTable("Customers")
	' add columns
	customerTable.Columns.Add( "id", Type.GetType("System.Int32"))
	customerTable.Columns.Add( "name", Type.GetType("System.String"))
	customerTable.Columns.Add( "address", Type.GetType("System.String"))

	' set PrimaryKey
	customerTable.Columns( "id").Unique = true
	customerTable.PrimaryKey = New DataColumn() { customerTable.Columns("id") }

	' add a RowDeleting event handler for the table.
	AddHandler customerTable.RowDeleting, New _
        DataRowChangeEventHandler( AddressOf Row_Deleting )


	' add ten rows
	Dim id As Integer
	For id = 1 To 10
		customerTable.Rows.Add( _
			New Object() { id, string.Format("customer{0}", id), _
            string.Format("address{0}", id) })
	Next
	
	customerTable.AcceptChanges()

	' Delete all the rows
	Dim row As DataRow
	For Each row In customerTable.Rows 
		row.Delete()
	Next
End Sub

Private Shared Sub Row_Deleting(sender As Object, _
    e As DataRowChangeEventArgs)
	Console.WriteLine( "Row_Deleting Event: name={0}; action={1}", _
		e.Row("name"), e.Action) 
End Sub
' </Snippet1>
End Class