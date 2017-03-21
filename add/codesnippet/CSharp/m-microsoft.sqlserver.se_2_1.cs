	[Microsoft.SqlServer.Server.SqlProcedure]
	public static void StoredProcSendMessage()
	{
		// Send a message string back to the client.
		SqlContext.Pipe.Send("Hello World!");
	}