Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace ca2100

    Public Class SqlQueries

        Function UnsafeQuery(connection As String,
         name As String, password As String) As Object

            Dim someConnection As New SqlConnection(connection)
            Dim someCommand As New SqlCommand()
            someCommand.Connection = someConnection

            someCommand.CommandText = "SELECT AccountNumber FROM Users " &
            "WHERE Username='" & name & "' AND Password='" & password & "'"

            someConnection.Open()
            Dim accountNumber As Object = someCommand.ExecuteScalar()
            someConnection.Close()
            Return accountNumber

        End Function

        Function SaferQuery(connection As String,
         name As String, password As String) As Object

            Dim someConnection As New SqlConnection(connection)
            Dim someCommand As New SqlCommand()
            someCommand.Connection = someConnection

            someCommand.Parameters.Add(
            "@username", SqlDbType.NChar).Value = name
            someCommand.Parameters.Add(
            "@password", SqlDbType.NChar).Value = password
            someCommand.CommandText = "SELECT AccountNumber FROM Users " &
            "WHERE Username=@username AND Password=@password"

            someConnection.Open()
            Dim accountNumber As Object = someCommand.ExecuteScalar()
            someConnection.Close()
            Return accountNumber

        End Function

    End Class

    Class MaliciousCode

        Shared Sub Main2100(args As String())

            Dim queries As New SqlQueries()
            queries.UnsafeQuery(args(0), "' OR 1=1 --", "[PLACEHOLDER]")
            ' Resultant query (which is always true):
            ' SELECT AccountNumber FROM Users WHERE Username='' OR 1=1

            queries.SaferQuery(args(0), "' OR 1=1 --", "[PLACEHOLDER]")
            ' Resultant query (notice the additional single quote character):
            ' SELECT AccountNumber FROM Users WHERE Username=''' OR 1=1 --'
            '                                   AND Password='[PLACEHOLDER]'
        End Sub

    End Class

End Namespace
