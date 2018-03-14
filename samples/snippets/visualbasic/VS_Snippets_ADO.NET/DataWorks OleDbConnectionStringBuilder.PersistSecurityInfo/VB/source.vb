Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.OleDb    

Module Module1
  Sub Main()
    Dim builder As New OleDbConnectionStringBuilder()
    builder.PersistSecurityInfo = True
    builder.Provider = "Microsoft.Jet.Oledb.4.0"
    builder.DataSource = "C:\Sample.mdb"

    ' Store the connection string.
    Dim savedConnectionString As String = builder.ConnectionString
    Console.WriteLine(savedConnectionString)

    ' Reset the object. This resets all the properties to their
    ' default values.
    builder.Clear()

    ' Investigate the PersistSecurityInfo property before
    ' and after assigning a connection string value.
    Console.WriteLine("Default : " & builder.PersistSecurityInfo)
    builder.ConnectionString = savedConnectionString
    Console.WriteLine("Modified: " & builder.PersistSecurityInfo)

    Console.WriteLine("Press Enter to finish.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

