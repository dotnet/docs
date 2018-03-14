Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Sub AddSqlParameter(ByVal command As SqlCommand)

        Dim parameter As New SqlParameter("@Description", _
            SqlDbType.VarChar, 88, "Description")
        With parameter
            .IsNullable = True
            .Direction = ParameterDirection.Output
        End With

        command.Parameters.Add(parameter)
    End Sub
    ' </Snippet1>

End Module
