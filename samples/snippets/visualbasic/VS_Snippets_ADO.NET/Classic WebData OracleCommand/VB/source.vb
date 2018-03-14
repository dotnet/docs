Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub ReadMyData(ByVal connectionString As String)
        Dim queryString As String = "SELECT EmpNo, DeptNo FROM Scott.Emp"
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString, connection)
            connection.Open()
            Dim reader As OracleDataReader = command.ExecuteReader()
            Try
                While reader.Read()
                    Console.WriteLine(reader.GetInt32(0) & ", " _
                       & reader.GetInt32(1))
                End While
            Finally
                ' always call Close when done reading.
                reader.Close()
            End Try
        End Using
    End Sub
    ' </Snippet1>
End Module
