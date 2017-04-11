using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
	//<Snippet1>
	[Microsoft.SqlServer.Server.SqlProcedure()]
	public static void StoredProcExecuteCommand(int rating)
	{
		// Connect through the context connection.
		using (SqlConnection connection = new SqlConnection("context connection=true"))
		{
			connection.Open();

			SqlCommand command = new SqlCommand(
				"SELECT VendorID, AccountNumber, Name FROM Purchasing.Vendor " +
				"WHERE CreditRating <= @rating", connection);
			command.Parameters.AddWithValue("@rating", rating);

			// Execute the command and send the results directly to the client.
			SqlContext.Pipe.ExecuteAndSend(command);
			
		}
	}
	//</Snippet1>
}

