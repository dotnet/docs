Option Explicit
Option Strict

   
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        ' Create a new SqlConnectionStringBuilder and
        ' initialize it with a few name/value pairs:
        Dim builder As New SqlConnectionStringBuilder(GetConnectionString())

        ' The input connection string used the 
        ' Server key, but the new connection string uses
        ' the well-known Data Source key instead.
        Console.WriteLine(builder.ConnectionString)

        ' Pass the SqlConnectionStringBuilder an existing 
        ' connection string, and you can retrieve and
        ' modify any of the elements.
        builder.ConnectionString = _
            "server=(local);user id=ab;" & _
            "password=a!Pass113;initial catalog=AdventureWorks"
        ' Now that the connection string has been parsed,
        ' you can work with individual items.
        Console.WriteLine(builder.Password)
        builder.Password = "new@1Password"
        builder.AsynchronousProcessing = True

        ' You can refer to connection keys using strings, 
        ' as well. When you use this technique (the default
        ' Item property in Visual Basic, or the indexer in C#)
        ' you can specify any synonym for the connection string key
        ' name.
        builder("Server") = "."
        builder("Connect Timeout") = 1000

        ' The Item property is the default for the class, 
        ' and setting the Item property adds the value to the 
        ' dictionary, if necessary. 
        builder.Item("Trusted_Connection") = True
        Console.WriteLine(builder.ConnectionString)

        Console.WriteLine("Press Enter to finish.")
        Console.ReadLine()
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file. 
        Return "Server=(local);Integrated Security=SSPI;" & _
          "Initial Catalog=AdventureWorks"
    End Function
End Module
' </Snippet1>

