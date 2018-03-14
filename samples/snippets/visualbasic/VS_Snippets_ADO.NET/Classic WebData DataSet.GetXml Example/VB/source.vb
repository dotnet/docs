Imports System
Imports System.Data

public class Sample
	public Shared Sub Main()
		DemonstrateGetXml()
	End Sub

' <Snippet1>
Private Shared Sub DemonstrateGetXml()
	' Create a DataSet with one table 
    ' containing two columns and 10 rows.
	Dim dataSet As DataSet = New DataSet("dataSet")
	Dim table As DataTable = dataSet.Tables.Add("Items")
	table.Columns.Add("id", Type.GetType("System.Int32"))
	table.Columns.Add("Item", Type.GetType("System.String"))

	' Add ten rows.
	Dim row As DataRow
	Dim i As Integer
	For i = 0 To 9
		row = table.NewRow()
		row("id") = i
		row("Item")= "Item" & i
		table.Rows.Add(row)
	Next

	' Display the DataSet contents as XML.
	Console.WriteLine( dataSet.GetXml() )
End Sub
' </Snippet1>
End Class