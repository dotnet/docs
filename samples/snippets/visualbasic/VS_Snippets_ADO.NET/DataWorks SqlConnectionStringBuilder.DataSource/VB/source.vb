Option Explicit On
Option Strict On

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim builder As _
         New SqlConnectionStringBuilder( _
         "Network Address=(local);Integrated Security=SSPI;" & _
         "Initial Catalog=AdventureWorks")

        ' Display the connection string, which should now 
        ' contain the "Data Source" key, as opposed to the 
        ' supplied "Network Address".
        Console.WriteLine(builder.ConnectionString)

        ' Retrieve the DataSource property:
        Console.WriteLine("DataSource = " & builder.DataSource)

        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()
    End Sub
End Module
' </Snippet1>

