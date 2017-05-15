Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
        Dim x As String = "Provider=SQLOLEDB;Data Source=(local);Initial Catalog=AdventureWorks;" _
        & "Integrated Security=SSPI"
        GetSchemaTable(x)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Public Function GetSchemaTable(ByVal connectionString As String) _
        As DataTable

        Using connection As New OleDbConnection(connectionString)
            connection.Open()

            Dim schemaTable As DataTable = _
                connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, _
                New Object() {Nothing, Nothing, Nothing, "TABLE"})
            Return schemaTable
        End Using
    End Function
    ' </Snippet1>
End Module
