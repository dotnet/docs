Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample

Shared Sub Main()
  DataTableColumnChanging()
End Sub

' <Snippet1>
Private Shared Sub DataTableColumnChanging()
	Dim custTable As DataTable = New DataTable("Customers")
	' add columns
	custTable.Columns.Add("id", Type.GetType("System.Int32"))
	custTable.Columns.Add("name", Type.GetType("System.String"))
	custTable.Columns.Add("address", Type.GetType("System.String"))

	' set PrimaryKey
	custTable.Columns("id").Unique = true
	custTable.PrimaryKey = New DataColumn() { custTable.Columns("id") }

	' add a ColumnChanging event handler for the table.
	AddHandler custTable.ColumnChanging, New _
        DataColumnChangeEventHandler(AddressOf Column_Changing )

	' add ten rows
	Dim id As Integer
	For id = 1 To 10
		custTable.Rows.Add( _
			New Object() { id, string.Format("customer{0}", id), _
                string.Format("address{0}", id) })
	Next
	
	custTable.AcceptChanges()

	' change the name column in all the rows
	Dim row As DataRow
	For Each row In custTable.Rows 
		row("name") = string.Format("vip{0}", row("id"))
	Next

End Sub

Private Shared Sub Column_Changing(sender As Object, _
    e As DataColumnChangeEventArgs)
	Console.WriteLine( _
        "Column_Changing Event: name={0}; Column={1}; proposed name={2}", _
		e.Row("name"), e.Column.ColumnName, e.ProposedValue) 
End Sub
' </Snippet1>
End Class