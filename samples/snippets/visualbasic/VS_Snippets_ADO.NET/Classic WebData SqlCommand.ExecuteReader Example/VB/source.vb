Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim str As String = "Data Source=(local);Initial Catalog=Northwind;" _
       & "Integrated Security=SSPI;"
        Dim qs As String = "SELECT OrderID, CustomerID FROM dbo.Orders;"
        CreateCommand(qs, str)
    End Sub

    ' <Snippet1>
    Public Sub CreateCommand(ByVal queryString As String, _
      ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As New SqlCommand(queryString, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                Console.WriteLine("{0}", reader(0))
            End While
        End Using
    End Sub
    ' </Snippet1>

End Module
