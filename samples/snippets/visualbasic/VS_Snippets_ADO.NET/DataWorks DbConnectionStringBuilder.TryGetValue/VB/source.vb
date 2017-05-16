Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common

Module Module1
    ' <Snippet1>
    Sub Main()
        Dim builder As New DbConnectionStringBuilder
        builder.ConnectionString = _
            "Provider=sqloledb;Data Source=192.168.168.1,1433;" & _
            "Network Library=DBMSSOCN;Initial Catalog=pubs;" & _
            "Integrated Security=SSPI;"

        ' Call TryGetValue method for multiple
        ' key names.
        DisplayValue(builder, "Provider")
        DisplayValue(builder, "DATA SOURCE")
        DisplayValue(builder, "InvalidKey")
        DisplayValue(builder, Nothing)

        Console.ReadLine()
    End Sub

    Private Sub DisplayValue( _
     ByVal builder As DbConnectionStringBuilder, ByVal key As String)
        Dim value As Object

        ' Although TryGetValue handles missing keys,
        ' it doesn't handle passing in a null (Nothing in Visual Basic)
        ' key. This example traps for that particular error, but
        ' bubbles any other unknown exceptions back out to the
        ' caller. 
        Try
            If builder.TryGetValue(key, value) Then
                Console.WriteLine("{0}={1}", key, value)
            Else
                Console.WriteLine("Unable to retrieve value for '{0}'", key)
            End If
        Catch ex As ArgumentNullException
            Console.WriteLine("Unable to retrieve value for null key.")
        End Try
    End Sub
    ' </Snippet1>
End Module

