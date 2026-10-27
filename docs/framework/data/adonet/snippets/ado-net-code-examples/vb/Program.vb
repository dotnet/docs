' <SqlClient>
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports Microsoft.Data.SqlClient

Module Program
    Sub Main()
        Dim connectionString As String = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")
        If String.IsNullOrWhiteSpace(connectionString) Then
            Throw New InvalidOperationException("Set the SQL_CONNECTION_STRING environment variable.")
        End If

        Const queryString As String =
            "SELECT ProductID, UnitPrice, ProductName FROM dbo.Products " &
            "WHERE UnitPrice > @pricePoint ORDER BY UnitPrice DESC;"

        Using connection As New SqlConnection(connectionString),
              command As New SqlCommand(queryString, connection)
            command.Parameters.Add("@pricePoint", SqlDbType.Money).Value = 5D
            connection.Open()

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Console.WriteLine($"{reader.GetInt32(0)}{vbTab}{reader.GetDecimal(1)}{vbTab}{reader.GetString(2)}")
                End While
            End Using
        End Using
    End Sub
End Module
' </SqlClient>
