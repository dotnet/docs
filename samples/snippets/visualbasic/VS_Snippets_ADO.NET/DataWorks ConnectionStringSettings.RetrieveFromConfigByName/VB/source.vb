Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Imports System.Configuration

Class Program
    Shared Sub Main()
        Dim s As String = GetConnectionStringByName("NorthwindSQL")
        Console.WriteLine(s)
        Console.ReadLine()
    End Sub
    ' <Snippet1>
    ' Retrieves a connection string by name.
    ' Returns Nothing if the name is not found.
    Private Shared Function GetConnectionStringByName( _
        ByVal name As String) As String

        ' Assume failure
        Dim returnValue As String = Nothing

        ' Look for the name in the connectionStrings section.
        Dim settings As ConnectionStringSettings = _
           ConfigurationManager.ConnectionStrings(name)

        ' If found, return the connection string.
        If Not settings Is Nothing Then
            returnValue = settings.ConnectionString
        End If

        Return returnValue
    End Function
    ' </Snippet1>
End Class

