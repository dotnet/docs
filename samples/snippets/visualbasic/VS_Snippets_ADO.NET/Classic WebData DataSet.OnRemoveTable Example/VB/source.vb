Imports System
Imports System.Data

Public Class Sample

	Public Shared Sub Main()
		DemonstrateOnRemoveTable()
	End Sub

' <Snippet1>

Public Shared Sub DemonstrateOnRemoveTable()
	Dim dataSet As DerivedDataSet = CreateDataSet()
	If dataSet.Tables.Count > 0 Then dataSet.Tables.RemoveAt(0)
End Sub

Public Class DerivedDataSet
	Inherits DataSet
	Protected Overrides Sub OnRemoveTable(table As DataTable)
		Console.WriteLine( _
            "The '{0}' DataTable has been removed from the DataSet", _
			table.TableName)
	End Sub
End Class

Public Shared Function CreateDataSet() As DerivedDataSet
	' Create a DataSet with one table containing two columns.
	Dim derived As DerivedDataSet = New DerivedDataSet()

	' Add table to DataSet.
	Dim table As DataTable = derived.Tables.Add("Items")

	' Add two columns.
	Dim column As DataColumn = table.Columns.Add("id", _
        Type.GetType("System.Int32"))
	column.AutoIncrement = True
	table.Columns.Add("item", Type.GetType("System.Int32"))

	' Set primary key.
	table.PrimaryKey = New DataColumn() {table.Columns("id")}

	return derived
End Function
' </Snippet1>
End Class
