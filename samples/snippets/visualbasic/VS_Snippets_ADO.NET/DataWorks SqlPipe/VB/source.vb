Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Server

Partial Public Class StoredProcedures
    '<Snippet1>
    <Microsoft.SqlServer.Server.SqlProcedure()> _
    Public Shared Sub StoredProcExecuteCommand(ByVal rating As Integer)
        Dim command As SqlCommand

        ' Connect through the context connection
        Using connection As New SqlConnection("context connection=true")
            connection.Open()

            command = New SqlCommand( _
                "SELECT VendorID, AccountNumber, Name FROM Purchasing.Vendor " & _
                "WHERE CreditRating <= @rating", connection)
            command.Parameters.AddWithValue("@rating", rating)

            ' Execute the command and send the results directly to the client
            SqlContext.Pipe.ExecuteAndSend(command)
        End Using
    End Sub
    '</Snippet1>
End Class
