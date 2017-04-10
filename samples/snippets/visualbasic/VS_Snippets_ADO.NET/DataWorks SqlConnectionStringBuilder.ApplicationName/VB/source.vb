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
             "Server=(local);Initial Catalog=AdventureWorks;" & _
                 "Integrated Security=True"
            Dim builder As New SqlConnectionStringBuilder(connectString)
            Console.WriteLine("Original: " & builder.ConnectionString)
            Console.WriteLine("ApplicationName={0}", _
                builder.ApplicationName)
            builder.ApplicationName = "My Application"
            Console.WriteLine("Modified: " & builder.ConnectionString)

            Console.WriteLine("Press any key to finish.")
            Console.ReadLine()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Module
' </Snippet1>

