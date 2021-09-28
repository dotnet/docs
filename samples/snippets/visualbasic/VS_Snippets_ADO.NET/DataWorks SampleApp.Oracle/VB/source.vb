' <Snippet1>
Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OracleClient

Public Class Program
    Public Shared Sub Main()

        Dim connectionString As String = _
            "Data Source=ThisOracleServer;Integrated Security=yes;"

        Dim queryString As String = _
            "SELECT CUSTOMER_ID, NAME FROM DEMO.CUSTOMER"

        Using connection As New OracleConnection(connectionString)
            Dim command As OracleCommand = connection.CreateCommand()
            command.CommandText = queryString
            Try
                connection.Open()
                Dim dataReader As OracleDataReader = _
                 command.ExecuteReader()
                Do While dataReader.Read()
                    Console.WriteLine(vbTab & "{0}" & vbTab & "{1}", _
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
