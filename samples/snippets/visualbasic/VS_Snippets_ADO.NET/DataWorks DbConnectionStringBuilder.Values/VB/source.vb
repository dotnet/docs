Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common
Module Module1
    ' <Snippet1>
    Sub Main()
        Dim builder As New DbConnectionStringBuilder
        builder.ConnectionString = _
         "Provider=MSDataShape.1;Persist Security Info=False;" & _
         "Data Provider=MSDAORA;Data Source=orac;" & _
         "user id=username;password=*******"

        For Each value As String In builder.Values
            Console.WriteLine(value)
        Next
    End Sub
    ' </Snippet1>
End Module
