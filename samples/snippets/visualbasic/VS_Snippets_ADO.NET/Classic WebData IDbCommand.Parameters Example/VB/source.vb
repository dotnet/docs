Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub CreateSqlCommand(ByVal connection As SqlConnection, _
    ByVal queryString As String, ByVal params() As SqlParameter)

        Dim command As New SqlCommand(queryString, connection)
        command.CommandText = _
           "SELECT CustomerID, CompanyName FROM Customers " _
           & "WHERE Country = @Country AND City = @City"
        command.UpdatedRowSource = UpdateRowSource.Both
        command.Parameters.AddRange(params)

        Dim message As String = ""
        For i As Integer = 0 To command.Parameters.Count - 1
            message += command.Parameters(i).ToString() & ControlChars.Cr
        Next 

        Console.WriteLine(message)
    End Sub
    ' </Snippet1>
End Module
