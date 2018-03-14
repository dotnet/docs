Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
    
Module Module1
    Sub Main()
        Dim builder As _
         New SqlConnectionStringBuilder(GetConnectionString())

        ' Loop through each of the values, displaying the contents.
        For Each value As Object In builder.Values
            Console.WriteLine(value)
        Next

        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file. 
        Return "Data Source=(local);Integrated Security=SSPI;" & _
          "Initial Catalog=AdventureWorks; Asynchronous Processing=True"
    End Function
End Module
' </Snippet1>

