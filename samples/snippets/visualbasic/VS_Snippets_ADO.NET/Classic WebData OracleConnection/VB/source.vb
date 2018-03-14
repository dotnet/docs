Imports System.Data
Imports System.Data.OracleClient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub InsertRow(ByVal connectionString As String)
        Dim queryString As String = _
          "INSERT INTO Dept (DeptNo, Dname, Loc) values (50, 'TECHNOLOGY', 'DENVER')"

        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString)
            command.Connection = connection
            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub
    ' </Snippet1>

End Module
