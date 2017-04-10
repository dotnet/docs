using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
	//<Snippet1>
	[Microsoft.SqlServer.Server.SqlProcedure]
	public static void StoredProcSendMessage()
	{
		// Send a message string back to the client.
		SqlContext.Pipe.Send("Hello World!");
	}
	//</Snippet1>
};
