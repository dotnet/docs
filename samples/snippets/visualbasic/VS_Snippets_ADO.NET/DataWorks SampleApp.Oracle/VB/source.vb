' <Snippet1>
Option Explicit On
Option Strict On
Imports Oracle.ManagedDataAccess.Client

Public Class Program
    Public Shared Sub Main()

        Dim connectionString As String =
            "..."

        Dim queryString As String =
            "SELECT CUSTOMER_ID, NAME FROM DEMO.CUSTOMER"

        Using connection As New OracleConnection(connectionString)
            Dim command As OracleCommand = connection.CreateCommand()
            command.CommandText = queryString
            Try
                connection.Open()
                Dim dataReader As OracleDataReader =
                 command.ExecuteReader()
                Do While dataReader.Read()
                    Console.WriteLine(vbTab & "{0}" & vbTab & "{1}",
                     dataReader(0), dataReader(1))
                Loop
                dataReader.Close()

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub
End Class
' </Snippet1>
