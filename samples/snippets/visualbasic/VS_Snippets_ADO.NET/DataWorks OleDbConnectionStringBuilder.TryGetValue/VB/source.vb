Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.OleDb    

Module Module1
  Sub Main()
    Dim builder As New OleDbConnectionStringBuilder
    builder.ConnectionString = GetConnectionString()

    ' Call TryGetValue method for multiple
    ' key names. 
    DisplayValue(builder, "Data Source")
    DisplayValue(builder, "Extended Properties")
    ' How about implicitly added key/value pairs?
    DisplayValue(builder, "Jet OLEDB:System database")
    ' Invalid keys?
    DisplayValue(builder, "Invalid Key")
    ' Null values?
    DisplayValue(builder, Nothing)

    Console.WriteLine("Press any key to continue.")
    Console.ReadLine()
  End Sub

  Private Sub DisplayValue( _
   ByVal builder As OleDbConnectionStringBuilder, ByVal key As String)
    Dim value As Object = Nothing

    ' Although TryGetValue handles missing keys,
    ' it does not handle passing in a null (Nothing in Visual Basic)
    ' key. This example traps for that particular error, but
    ' throws any other unknown exceptions back out to the
    ' caller. 
    Try
      If builder.TryGetValue(key, value) Then
        Console.WriteLine("{0}='{1}'", key, value)
      Else
        Console.WriteLine("Unable to retrieve value for '{0}'", key)
      End If
    Catch ex As ArgumentNullException
      Console.WriteLine("Unable to retrieve value for null key.")
    End Try
  End Sub

  Private Function GetConnectionString() As String
    ' To avoid storing the connection string in your code,
    ' you can retrieve it from a configuration file using the 
    ' System.Configuration.ConfigurationSettings.AppSettings property. 
    Return "Provider=Microsoft.Jet.OLEDB.4.0;" & _
      "Data Source=C:\ExcelDemo.xls;" & _
      "Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
  End Function
End Module
' </Snippet1>

