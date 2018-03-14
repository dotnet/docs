Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub ReadData(ByVal connectionString As String)
        Dim queryString As String = _
            "SELECT OrderID, CustomerID FROM Orders"

        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString, connection)
            connection.Open()

            Dim reader As OracleDataReader
            reader = command.ExecuteReader()

            ' Always call Read before accessing data.
            While reader.Read()
                Console.WriteLine(reader.GetInt32(0) & ", " & reader.GetString(1))
            End While

            ' Always call Close when done reading.
            reader.Close()
        End Using
    End Sub
    ' </Snippet1>
End Module
