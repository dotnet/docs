Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.Odbc
    
Module Module1

  Sub Main()
    Dim builder As New OdbcConnectionStringBuilder
    builder.ConnectionString = GetConnectionString()

    ' Call TryGetValue method for multiple
    ' key names. Demonstrate that the search is not
    ' case sensitive.
    DisplayValue(builder, "Driver")
    DisplayValue(builder, "SERVER")
    ' How about a property you did not set?
    DisplayValue(builder, "DNS")
    ' Invalid keys?
    DisplayValue(builder, "Invalid Key")
    ' Null values?
    DisplayValue(builder, Nothing)

    Console.WriteLine("Press any key to continue.")
    Console.ReadLine()
  End Sub

  Private Sub DisplayValue( _
   ByVal builder As OdbcConnectionStringBuilder, ByVal key As String)
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
    Return "Driver={SQL Server};Server=(local);" & _
      "Database=AdventureWorks;Trusted_Connection=yes;"
  End Function
End Module
' </Snippet1>

