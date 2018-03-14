Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Odbc

Module Module1

    Sub Main()

    End Sub

    ' <Snippet1>
    Public Sub ReadData(ByVal connectionString As String)
        Dim queryString As String = "SELECT DISTINCT CustomerID FROM Orders"

        Using connection As New OdbcConnection(connectionString)
            Dim command As New OdbcCommand(queryString, connection)

            connection.Open()

            Dim reader As OdbcDataReader = command.ExecuteReader()

            Dim customerID As Integer = reader.GetOrdinal("CustomerID")

            While reader.Read()
                Console.WriteLine("CustomerID={0}", reader.GetString(customerID))
            End While

            ' Call Close when done reading.
            reader.Close()
        End Using
    End Sub
    ' </Snippet1>

End Module
