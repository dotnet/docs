Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim s As String = GetConnectionString()
        Dim c As SqlConnection = New SqlConnection(s)
        GetSchemaInfo(c)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub GetSchemaInfo(ByVal connection As SqlConnection)
        Using connection
            Dim command As SqlCommand = New SqlCommand( _
              "SELECT CategoryID, CategoryName FROM Categories;", _
              connection)
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()
            Dim schemaTable As DataTable = reader.GetSchemaTable()

            Dim row As DataRow
            Dim column As DataColumn

            For Each row In schemaTable.Rows
                For Each column In schemaTable.Columns
                    Console.WriteLine(String.Format("{0} = {1}", _
                      column.ColumnName, row(column)))
                Next
                Console.WriteLine()
            Next
            reader.Close()
        End Using
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function
End Module
