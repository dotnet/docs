Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Module Module1

    Sub Main()
        Dim str As String = GetConnectionString()
        CreateOleDbDataAdapter(str)
    End Sub
    ' <Snippet1>
    ' Assumes a valid connection string to an Access database.
    Private Sub CreateOleDbDataAdapter(ByVal connectionString As String)
        Dim adapter As New OleDbDataAdapter()
        adapter.SelectCommand = _
           New OleDbCommand("SELECT * FROM Categories ORDER BY CategoryID")
        adapter.SelectCommand.Connection = New OleDbConnection _
           (connectionString)
        adapter.MissingMappingAction = MissingMappingAction.Error
        adapter.MissingSchemaAction = MissingSchemaAction.Error
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND_RW.MDB"
    End Function
End Module
