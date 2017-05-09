Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before you can run this sample.
Imports System.Data.OracleClient

Module Module1
    Sub Main()
        Dim builder As New OracleConnectionStringBuilder()
        builder.ConnectionString = GetConnectionString()

        ' Call TryGetValue method for multiple
        ' key names. Note that these keys are converted
        ' to well-known synonynms for data retrieval.
        DisplayValue(builder, "Data Source")
        DisplayValue(builder, "trusted_connection")
        DisplayValue(builder, "InvalidKey")
        DisplayValue(builder, Nothing)

        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()
    End Sub

    Private Sub DisplayValue( _
     ByVal builder As OracleConnectionStringBuilder, ByVal key As String)
        Dim value As Object = Nothing

        ' Although TryGetValue handles missing keys just fine,
        ' it doesn't handle passing in a null (Nothing in Visual Basic)
        ' key. This example traps for that particular error, but
        ' bubbles any other unknown exceptions back out to the
        ' caller. 
        Try
            If builder.TryGetValue(key, value) Then
                Console.WriteLine("{0}='{1}' ", key, value)
            Else
                Console.WriteLine("Unable to retrieve value for '{0}'", key)
            End If
        Catch ex As ArgumentNullException
            Console.WriteLine("Unable to retrieve value for null key.")
        End Try
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file. 
        Return "Server=OracleDemo;Integrated Security=True"
    End Function
End Module
' </Snippet1>

