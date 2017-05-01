'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim query As SelectQuery
        query = New SelectQuery("SELECT * " & _
            "FROM Win32_LogicalDisk " & _
            "WHERE FreeSpace < 4000000")
        ' The query is parsed so that the className property
        ' is Win32_LogicalDisk and the condition property
        ' is FreeSpace < 4000000

    End Function
End Class
'</Snippet1>