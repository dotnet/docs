Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample

Shared Sub Main()
  DataTableColumnChanged()
End Sub

' <Snippet1>
Private Shared Sub DataTableColumnChanged()
	Dim custTable As DataTable = New DataTable("Customers")
	' add columns
	custTable.Columns.Add("id", Type.GetType("System.Int32"))
	custTable.Columns.Add("name", Type.GetType("System.String"))
	custTable.Columns.Add("address", Type.GetType("System.String"))

	' set PrimaryKey
	custTable.Columns("id").Unique = true
	custTable.PrimaryKey = New DataColumn() { custTable.Columns("id") }

	' add a ColumnChanged event handler for the table.
	AddHandler custTable.ColumnChanged, _
        New DataColumnChangeEventHandler(AddressOf Column_Changed )


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

Private Shared Sub Column_Changed(sender As Object, _
    e As DataColumnChangeEventArgs)
	Console.WriteLine("Column_Changed Event: name={0}; Column={1}; original name={2}", _
		e.Row("name"), e.Column.ColumnName, e.Row("name", DataRowVersion.Original))
End Sub
' </Snippet1>
End Class