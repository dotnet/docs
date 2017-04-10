Option Explicit On
Option Strict On
Imports System.Data
Imports System.Configuration

Class Program
    Shared Sub Main()
        Dim s As String = GetConnectionStringByProvider("System.Data.SqlClient")
        Console.WriteLine(s)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    ' Retrieve a connection string by specifying the providerName.
    ' Assumes one connection string per provider in the config file.
    Private Shared Function GetConnectionStringByProvider( _
        ByVal providerName As String) As String

        'Return Nothing on failure.
        Dim returnValue As String = Nothing

        ' Get the collection of connection strings.
        Dim settings As ConnectionStringSettingsCollection = _
            ConfigurationManager.ConnectionStrings

        ' Walk through the collection and return the first 
        ' connection string matching the providerName.
        If Not settings Is Nothing Then
            For Each cs As ConnectionStringSettings In settings
                If cs.ProviderName = providerName Then
                    returnValue = cs.ConnectionString
                    Exit For
                End If
            Next
        End If

        Return returnValue
    End Function
    ' </Snippet1>
End Class
