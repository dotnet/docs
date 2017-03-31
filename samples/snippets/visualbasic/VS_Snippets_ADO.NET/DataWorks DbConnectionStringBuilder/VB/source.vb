' This is the first code listing in the System.Data.Common.DbConnectionStringBuilder.

Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Data.SqlClient

Module Module1
' <Snippet1>
    Sub Main()
        Dim builder As New DbConnectionStringBuilder()
        builder.ConnectionString = "Data Source=c:\MyData\MyDb.mdb"
        builder.Add("Provider", "Microsoft.Jet.Oledb.4.0")
        builder.Add("Jet OLEDB:Database Password", "*******")
        builder.Add("Jet OLEDB:System Database", _
            "c:\MyData\Workgroup.mdb")

        ' Set up row-level locking.
        builder.Add("Jet OLEDB:Database Locking Mode", 1)

        ' Note that the DbConnectionStringBuilder class 
        ' is database agnostic, and it's possible to 
        ' build any type of connection string using 
        ' this class.
        ' Notice that the ConnectionString property may have been 
        ' formatted by the DbConnectionStringBuilder class.

        Dim oledbConnect As New _
            OleDbConnection(builder.ConnectionString)
        Console.WriteLine(oledbConnect.ConnectionString)

        ' Use the same DbConnectionStringBuilder to create 
        ' a SqlConnection object.
        builder.Clear()
        builder.Add("integrated security", True)
        builder.Add("Initial Catalog", "AdventureWorks")
        builder.Add("Data Source", "(local)")

        Dim sqlConnect As New SqlConnection(builder.ConnectionString)
        Console.WriteLine(sqlConnect.ConnectionString)

        ' Pass the DbConnectionStringBuilder an existing 
        ' connection string, and you can retrieve and
        ' modify any of the elements.
        builder.ConnectionString = _
            "server=(local);user id=*******;" & _
            "password=*******;initial catalog=AdventureWorks"
        builder.Item("Server") = "."
        builder.Remove("User ID")

        ' Note that calling Remove on a nonexistent item doesn't
        ' throw an exception.
        builder.Remove("BadItem")

        ' The Item property is the default for the class, 
        ' and setting the Item property adds the value if 
        ' necessary.
        builder("Integrated Security") = True
        builder.Remove("password")
        builder.Item("User ID") = "Hello"
        Console.WriteLine(builder.ConnectionString)

        Console.WriteLine("Press Enter to finish.")
        Console.ReadLine()
    End Sub
' </Snippet1>
End Module

