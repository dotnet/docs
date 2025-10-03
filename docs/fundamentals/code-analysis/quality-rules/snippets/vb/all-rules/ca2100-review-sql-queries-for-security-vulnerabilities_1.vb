Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.Versioning

Namespace ca2100

    Public Class SqlQueries

        <SupportedOSPlatform("windows")>
        Function UnsafeQuery(connection As String,
         name As String, password As String) As Object

            Dim someConnection As New OleDbConnection(connection)
            Dim someCommand As New OleDbCommand With {
                .Connection = someConnection,
                .CommandText = "SELECT AccountNumber FROM Users " &
                "WHERE Username='" & name & "' AND Password='" & password & "'"
            }

            someConnection.Open()
            Dim accountNumber As Object = someCommand.ExecuteScalar()
            someConnection.Close()
            Return accountNumber

        End Function

        <SupportedOSPlatform("windows")>
        Function SaferQuery(connection As String,
         name As String, password As String) As Object

            Dim someConnection As New OleDbConnection(connection)
            Dim someCommand As New OleDbCommand With {
                .Connection = someConnection
            }

            someCommand.Parameters.AddWithValue(
            "@username", OleDbType.Char).Value = name
            someCommand.Parameters.AddWithValue(
            "@password", OleDbType.Char).Value = password
            someCommand.CommandText = "SELECT AccountNumber FROM Users " &
            "WHERE Username=@username AND Password=@password"

            someConnection.Open()
            Dim accountNumber As Object = someCommand.ExecuteScalar()
            someConnection.Close()
            Return accountNumber

        End Function

    End Class

    Class MaliciousCode

        <SupportedOSPlatform("windows")>
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
