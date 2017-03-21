    <Microsoft.SqlServer.Server.SqlProcedure(Name:="StoredProcSendMessage")> _
    Public Shared Sub StoredProcSendMessage()

        ' Send a message string back to the client.
        SqlContext.Pipe.Send("Hello world!")

    End Sub