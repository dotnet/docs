Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub ReadData(ByVal connectionString As String)
        Dim queryString As String = "SELECT EmpNo, EName FROM Emp"
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString, connection)
            connection.Open()
            Using reader As OracleDataReader = command.ExecuteReader()
                ' Always call Read before accessing data.
                While reader.Read()
                    Console.WriteLine(reader.GetInt32(0).ToString() + ", " _
                       + reader.GetString(1))
                End While
            End Using
        End Using
    End Sub
    ' </Snippet1>
End Module
