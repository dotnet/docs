Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Sub AddSqlParameter(ByVal command As SqlCommand, _
        ByVal paramValue As String)

        Dim parameter As New SqlParameter( _
            "@Description", SqlDbType.NVarChar, 16)
        parameter.Value = paramValue
        parameter.IsNullable = True
        command.Parameters.Add(parameter)
    End Sub

    Private Shared Sub SetParameterToNull(parameter As IDataParameter)
        If parameter.IsNullable Then
	    parameter.Value = DBNull.Value
        Else
            Throw New ArgumentException("Parameter provided is not nullable", "parameter")
        End If
   End Sub
    ' </Snippet1>

End Module
