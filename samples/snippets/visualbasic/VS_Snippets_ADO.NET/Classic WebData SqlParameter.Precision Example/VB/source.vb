Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Sub AddSqlParameter(ByVal command As SqlCommand)

        Dim parameter As New SqlParameter("@Price", SqlDbType.Decimal)
        With parameter
            .Value = 3.1416
            .Precision = 8
            .Scale = 4
        End With

        command.Parameters.Add(parameter)
    End Sub
    ' </Snippet1>

End Module
