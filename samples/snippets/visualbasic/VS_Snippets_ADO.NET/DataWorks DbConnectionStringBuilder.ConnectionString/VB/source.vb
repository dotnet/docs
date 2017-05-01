Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common

Module Module1

    ' <Snippet1>
    Sub Main()
        ' Create a new DbConnctionStringBuilder, and add items
        ' to the internal collection of key/value pairs.
        Dim builder As New DbConnectionStringBuilder()
        builder.Add("Data Source", "c:\MyData\MyDb.mdb")
        builder.Add("Provider", "Microsoft.Jet.Oledb.4.0")
        builder.Add("Jet OLEDB:Database Password", "*******")
        builder.Add("Jet OLEDB:System Database", _
            "c:\MyData\Workgroup.mdb")
        ' Set up row-level locking.
        builder.Add("Jet OLEDB:Database Locking Mode", 1)

        ' Display the contents of the connection string, which
        ' will now contain all the key/value pairs delimited with
        ' semicolons.
        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()

        ' Clear the DbConnectionStringBuilder, and assign a complete
        ' connection string to it, to demonstrate how
        ' the class parses connection strings.
        builder.Clear()
        builder.ConnectionString = _
            "Data Source=(local);Initial Catalog=AdventureWorks;" & _
            "Integrated Security=SSPI"

        ' The DbConnectionStringBuilder class has parsed the contents, 
        ' so you can work with any individual key/value pair.
        builder("Data Source") = "."
        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()

        ' Because the DbConnectionStringBuilder class doesn't 
        ' validate its key/value pairs, you can use this class
        ' to store any semicolon-delimited list. The following
        ' snippet places an arbitrary string into the ConnectionString
        ' property, changes one of the values, and then displays the
        ' resulting string.
        builder.Clear()
        builder.ConnectionString = _
            "Value1=10;Value2=20;Value3=30;Value4=40"
        builder("Value2") = 25
        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()

        builder.Clear()
        Try
            ' Assigning an invalid connection string
            ' throws an ArgumentException.
            builder.ConnectionString = "xxx"

        Catch ex As ArgumentException
            Console.WriteLine("Invalid connection string.")
        End Try

        Console.WriteLine()
        Console.WriteLine("Press Enter to finish.")
        Console.ReadLine()
    End Sub
    ' </Snippet1>
End Module

