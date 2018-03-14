Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
        Dim connectionString As String = "Provider=sqloledb;Data Source=(local);Initial Catalog=Northwind;" _
                & "Integrated Security=SSPI"
        Dim queryString As String = _
        "UPDATE Shippers SET CompanyName = 'Speedy Express' WHERE ShipperID = 1"
        CreateOleDbCommand(queryString, connectionString)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub CreateOleDbCommand( _
        ByVal queryString As String, ByVal connectionString As String)
        Using connection As New OleDbConnection(connectionString)
            connection.Open()
            Dim command As New OleDbCommand(queryString, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub
    ' </Snippet1>
End Module
