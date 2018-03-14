Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.Odbc    

Module Module1
  Sub Main()
    Dim builder As New OdbcConnectionStringBuilder()
    builder.Driver = "Microsoft Visual FoxPro Driver"
    builder("SourceType") = "DBC"

    ' Keys you have provided return true.
    Console.WriteLine(builder.ContainsKey("SourceType"))

    ' Comparison is case insensitive.
    Console.WriteLine(builder.ContainsKey("sourcetype"))

    ' Keys added by the provider return false. This method
    ' only examines keys added explicitly.
    Console.WriteLine(builder.ContainsKey("DNS"))

    ' Keys that do not exist return false.
    Console.WriteLine(builder.ContainsKey("MyKey"))

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

