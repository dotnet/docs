Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()

    End Sub

    ' <Snippet1>
    Private Sub CreateSqlParameterOutput()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.Direction = ParameterDirection.Output
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Private Sub CreateSqlParameterNullable()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.IsNullable = True
        parameter.Direction = ParameterDirection.Output
    End Sub
    ' </Snippet2>

    ' <Snippet3>
    Private Sub CreateSqlParameterOffset()
        Dim parameter As New SqlParameter("pDName", SqlDbType.VarChar)
        parameter.IsNullable = True
        parameter.Offset = 3
    End Sub
    ' </Snippet3>

    ' <Snippet4>
    Private Sub CreateSqlParameterPrecisionScale()
        Dim parameter As New SqlParameter("Price", SqlDbType.Decimal)
        parameter.Value = 3.1416
        parameter.Precision = 8
        parameter.Scale = 4
    End Sub
    ' </Snippet4>

    ' <Snippet5>
    Private Sub CreateSqlParameterSize()
        Dim description As String = "12 foot scarf - multiple colors, one previous owner"
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar)
        parameter.Direction = ParameterDirection.InputOutput
        parameter.Size = description.Length
        parameter.Value = description
    End Sub
    ' </Snippet5>

    ' <Snippet6>
    Private Sub CreateSqlParameterSourceColumn()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.SourceColumn = "Description"
    End Sub
    ' </Snippet6>

    ' <Snippet7>
    Private Sub CreateSqlParameterSourceVersion()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.SourceColumn = "Description"
        parameter.SourceVersion = DataRowVersion.Current
    End Sub
    ' </Snippet7>

    ' <Snippet8>
    Private Sub CreateSqlParameterVersion()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.Value = "garden hose"
    End Sub
    ' </Snippet8>

End Module
