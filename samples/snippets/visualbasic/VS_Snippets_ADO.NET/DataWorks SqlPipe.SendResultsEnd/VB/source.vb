Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server


Partial Public Class StoredProcedures
    '<Snippet1>
    <Microsoft.SqlServer.Server.SqlProcedure()> _
    Public Shared Sub StoredProcReturnResultSet()

        ' Create the record and specify the metadata for the columns.
        Dim record As New SqlDataRecord( _
            New SqlMetaData("col1", SqlDbType.NVarChar, 100), _
            New SqlMetaData("col2", SqlDbType.Int))

        ' Mark the begining of the result-set.
        SqlContext.Pipe.SendResultsStart(record)

        ' Send 10 rows back to the client.
        Dim i As Integer
        For i = 0 To 9

            ' Set values for each column in the row.
            record.SetString(0, "row " & i.ToString())
            record.SetInt32(1, i)

            ' Send the row back to the client.
            SqlContext.Pipe.SendResultsRow(record)
        Next

        ' Mark the end of the result-set.
        SqlContext.Pipe.SendResultsEnd()
    End Sub
    '</Snippet1>
End Class
