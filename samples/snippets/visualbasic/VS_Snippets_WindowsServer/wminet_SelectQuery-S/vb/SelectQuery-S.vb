'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim sQuery As New SelectQuery( _
            "SELECT * FROM Win32_Service WHERE State='Stopped'")

        'or

        'This is equivalent to "SELECT * FROM Win32_Service"
        Dim query As New SelectQuery("Win32_Service")

    End Function
End Class
'</Snippet1>