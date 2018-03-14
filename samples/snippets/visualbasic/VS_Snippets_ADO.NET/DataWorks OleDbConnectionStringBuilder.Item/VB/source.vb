Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.OleDb    

Module Module1
  Sub Main()
    Dim builder As New OleDbConnectionStringBuilder
    builder.Provider = "Microsoft.Jet.Oledb.4.0"
    builder.DataSource = "C:\Sample.mdb"
    ' Set properties using the Item property.
    builder.Item("Jet OLEDB:Database Password") = "DataPassword"
    builder.Item("Jet OLEDB:Encrypt Database") = True

    ' Because Item is the default property, you can leave out
    ' the explicit reference.
    builder("Jet OLEDB:System database") = "C:\Workgroup.mdw"

    Console.WriteLine(builder.ConnectionString)
    Console.WriteLine()

    ' Use the Item property to retrieve values, as well.
    Console.WriteLine(builder.Item("Jet OLEDB:System database"))
    Console.WriteLine(builder("Jet OLEDB:Encrypt Database"))

    ' You can set or retrieve any of the "default" values for the 
    ' provider, as well, even if you did not set their values. Again, 
    ' explicitly specifying the Item property name is optional.
    Console.WriteLine(builder.Item("Jet OLEDB:Database Locking Mode"))
    Console.WriteLine(builder("Jet OLEDB:Global Partial Bulk Ops"))

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

