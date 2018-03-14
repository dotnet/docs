Option Explicit On
Option Strict On

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Try
            Dim connectString As String = _
             "Server=(local);" & _
             "Integrated Security=True"
            Dim builder As New SqlConnectionStringBuilder(connectString)
            Console.WriteLine("Original: " & builder.ConnectionString)
            Console.WriteLine("AttachDBFileName={0}", _
             builder.AttachDBFilename)
            builder.AttachDBFilename = "C:\MyDatabase.mdf"
            Console.WriteLine("Modified: " & builder.ConnectionString)

            Using connection As New SqlConnection(builder.ConnectionString)
                connection.Open()
                ' Now use the open connection.
                Console.WriteLine("Database = " & connection.Database)
            End Using

            Console.WriteLine("Press any key to finish.")
            Console.ReadLine()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Module
' </Snippet1>

