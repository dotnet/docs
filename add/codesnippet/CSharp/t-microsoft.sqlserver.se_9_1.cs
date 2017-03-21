	[Microsoft.SqlServer.Server.SqlProcedure(Name = "StoredProcSendMessage")]
	public static void StoredProcSendMessage()
	{
		// Send a message string back to the client.
		SqlContext.Pipe.Send("Hello World!");
	}