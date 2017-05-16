Option Explicit
Option Strict

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
Module Module1
    Sub Main()
        Dim builder As New SqlConnectionStringBuilder
        builder.DataSource = "(local)"
        builder.IntegratedSecurity = True
        builder.InitialCatalog = "AdventureWorks"

        ' The connection does not allow multiple active result sets
        ' by default, so this line of code explicitly
        ' enables this feature. Note that this feature is 
        ' only available when programming against SQL Server 2005
        ' or later.
        builder.MultipleActiveResultSets = True

        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()

        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
End Module
' </Snippet1>

