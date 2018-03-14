using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

static class Module1
{

	public static void Main()
	{
		CheckVersionBeforeAccept();
		Console.ReadLine();

	}
	// <Snippet1>
	private static void CheckVersionBeforeAccept()
	{
		//Run a function to create a DataTable with one column.
		DataTable dataTable = MakeTable();

		DataRow dataRow = dataTable.NewRow();
		dataRow["FirstName"] = "Marcy";
		dataTable.Rows.Add(dataRow);

		dataRow.BeginEdit();
		// Edit data but keep the same value.
		dataRow[0] = "Marcy";
		// Uncomment the following line to add a new value.
		// dataRow(0) = "Richard"
		Console.WriteLine(string.Format("FirstName {0}", dataRow[0]));

		// Compare the proposed version with the current.
		if (dataRow.HasVersion(DataRowVersion.Proposed)) {
			if (object.ReferenceEquals(dataRow[0, DataRowVersion.Current], dataRow[0, DataRowVersion.Proposed])) {
				Console.WriteLine("The original and the proposed are the same.");
				dataRow.CancelEdit();
			} else {
				dataRow.AcceptChanges();
				Console.WriteLine("The original and the proposed are different.");
			}
		}
	}

	private static DataTable MakeTable()
	{
		// Make a simple table with one column.
		DataTable dt = new DataTable("dataTable");
		DataColumn firstName = new DataColumn("FirstName", Type.GetType("System.String"));
		dt.Columns.Add(firstName);
		return dt;
	}
	// </Snippet1>
}