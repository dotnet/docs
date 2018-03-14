using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
	//<Snippet1>
	[Microsoft.SqlServer.Server.SqlProcedure]
	public static void StoredProcReturnResultSet()
	{
		// Create the record and specify the metadata for the columns.
		SqlDataRecord record = new SqlDataRecord(
			new SqlMetaData("col1", SqlDbType.NVarChar, 100),
			new SqlMetaData("col2", SqlDbType.Int));

		// Mark the begining of the result-set.
		SqlContext.Pipe.SendResultsStart(record);

		// Send 10 rows back to the client.
		for (int i = 0; i < 10; i++)
		{
			// Set values for each column in the row.
			record.SetString(0, "row " + i.ToString());
			record.SetInt32(1, i);

			// Send the row back to the client.
			SqlContext.Pipe.SendResultsRow(record);
		}

		// Mark the end of the result-set.
		SqlContext.Pipe.SendResultsEnd();
	}
	//</Snippet1>
};
