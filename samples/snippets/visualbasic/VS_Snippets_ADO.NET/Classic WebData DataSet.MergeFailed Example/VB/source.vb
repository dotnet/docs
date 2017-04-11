Imports System
Imports System.Data

public class Sample
	public Shared Sub Main()
		DemonstrateMergeFailedEvent()
	End Sub

' <Snippet1>

Private Shared Sub DemonstrateMergeFailedEvent()
	' Create a DataSet with one table containing two columns.
	Dim dataSet AS DataSet = New DataSet("dataSet")
	Dim table As DataTable = New DataTable("Items")
	
	' Add table to the DataSet.
	dataSet.Tables.Add(table)

	' Add two columns to the DataTable.
	table.Columns.Add("id", Type.GetType("System.Int32"))
	table.Columns.Add("item", Type.GetType("System.Int32"))

	' Set the primary key to the first column.
	table.PrimaryKey = new DataColumn() { table.Columns("id") }

	' Add MergeFailed event handler for the table.
	AddHandler dataSet.MergeFailed, _
        New MergeFailedEventHandler(AddressOf Merge_Failed)

	' Create a second DataTable identical to the first, 
	Dim t2 As DataTable = table.Clone()

	' Set the primary key of the new table to the second column.
	' This will cause the MergeFailed event to be raised when the
	' table is merged into the DataSet.
	t2.PrimaryKey = New DataColumn() { t2.Columns("item") }
	
	' Merge table into the DataSet.
	Console.WriteLine("Merging...")
	dataSet.Merge(t2, false, MissingSchemaAction.Add)
End Sub

Private Shared Sub Merge_Failed(sender As object, _
    e As MergeFailedEventArgs)
	Console.WriteLine("Merge_Failed Event: '{0}'", e.Conflict)
End Sub

' </Snippet1>
End Class