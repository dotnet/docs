Option Explicit On
Option Strict On

Imports System
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
        command.Parameters.Add(params)

        Dim j As Integer
        For j = 0 To command.Parameters.Count - 1
            command.Parameters.Add(params(j))
        Next j

        Dim message As String = ""
        Dim i As Integer
        For i = 0 To command.Parameters.Count - 1
            message += command.Parameters(i).ToString() & ControlChars.Cr
        Next i

        Console.WriteLine(message)
    End Sub
    ' </Snippet1>
End Module
