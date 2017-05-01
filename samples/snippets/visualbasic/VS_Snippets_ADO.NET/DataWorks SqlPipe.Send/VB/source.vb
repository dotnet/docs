Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server


Partial Public Class StoredProcedures
    '<Snippet1>
    <Microsoft.SqlServer.Server.SqlProcedure()> _
    Public Shared Sub StoredProcSendMessage()

        ' Send a message string back to the client.
        SqlContext.Pipe.Send("Hello world!")

    End Sub
    '</Snippet1>
End Class
