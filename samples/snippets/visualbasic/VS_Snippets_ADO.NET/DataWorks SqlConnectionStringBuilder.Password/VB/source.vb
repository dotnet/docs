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
                "Server=(local);Database=AdventureWorks;UID=ab;Pwd=a!Pass@@"
            Console.WriteLine("Original: " & connectString)
            Dim builder As New SqlConnectionStringBuilder(connectString)
            Console.WriteLine("Modified: " & builder.ConnectionString)
            For Each key As String In builder.Keys
                Console.WriteLine(key & "=" & builder.Item(key).ToString)
            Next
            Console.WriteLine("Press any key to finish.")
            Console.ReadLine()

        Catch ex As System.Collections.Generic.KeyNotFoundException
            Console.WriteLine("KeyNotFoundException: " & ex.Message)
        Catch ex As System.FormatException
            Console.WriteLine("Format exception: " & ex.Message)
        End Try
    End Sub
End Module 
' </Snippet1>

