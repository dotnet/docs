Option Explicit
Option Strict

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
    
Module Module1
    Sub Main()
        Try
            Dim connectString As String = _
             "Data Source=(local);" & _
             "Integrated Security=True"

            Dim builder As New SqlConnectionStringBuilder(connectString)
            Console.WriteLine("Original: " & builder.ConnectionString)

            ' Normally, you could simply set the InitialCatalog
            ' property of the SqlConnectionStringBuilder object. This
            ' example uses the default Item property (the C# indexer)
            ' and the "Database" string, simply to demonstrate that
            ' setting the value in this way results in the same
            ' connection string.
            builder("Database") = "AdventureWorks"
            Console.WriteLine("builder.InitialCatalog = " _
                & builder.InitialCatalog)
            Console.WriteLine("Modified: " & builder.ConnectionString)

            Using connection As New SqlConnection(builder.ConnectionString)
                connection.Open()
                ' Now use the open connection.
                Console.WriteLine("Database = " & connection.Database)
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.WriteLine("Press any key to finish.")
        Console.ReadLine()
    End Sub
End Module
' </Snippet1>

