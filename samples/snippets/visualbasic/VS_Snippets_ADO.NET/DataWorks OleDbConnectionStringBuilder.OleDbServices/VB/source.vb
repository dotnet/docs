Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.OleDb    

Module Module1
  ' These constants correspond to values in the 
  ' OLE DB SDK. You can use these values to 
  ' turn features on and off.
  Private Const DBPROPVAL_OS_AGR_AFTERSESSION As Integer = 8
  Private Const DBPROPVAL_OS_AGR_RESOURCEPOOLING As Integer = 1
  Private Const DBPROPVAL_OS_AGR_TXNENLISTMENT As Integer = 2
  Private Const DBPROPVAL_OS_AGR_CLIENTCURSOR As Integer = 4
  Private Const DBPROPVAL_OS_ENABLEALL As Integer = -1
  Private Const DBPROPVAL_OS_DISABLEALL As Integer = 0

  Sub Main()
    Dim builder As New OleDbConnectionStringBuilder()
    ' Turn on all services except resource pooling.
    builder.OleDbServices = DBPROPVAL_OS_ENABLEALL _
     And Not DBPROPVAL_OS_AGR_RESOURCEPOOLING

    builder.Provider = "sqloledb"
    builder.DataSource = "(local)"
    builder("Initial Catalog") = "AdventureWorks"
    builder("Integrated Security") = "SSPI"

    ' Store the connection string.
    Dim savedConnectionString As String = builder.ConnectionString
    Console.WriteLine(savedConnectionString)

    ' Reset the object. This resets all the properties to their
    ' default values.
    builder.Clear()

    ' Investigate the OleDbServices property before
    ' and after assigning a connection string value.
    Console.WriteLine("Default : " & builder.OleDbServices)
    builder.ConnectionString = savedConnectionString
    Console.WriteLine("Modified: " & builder.OleDbServices)

    Console.WriteLine("Press Enter to finish.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

