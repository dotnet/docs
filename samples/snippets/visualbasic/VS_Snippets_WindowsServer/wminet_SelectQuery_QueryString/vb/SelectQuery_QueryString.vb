'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim s As New SelectQuery
        s.QueryString = "SELECT * FROM Win32_Process"

        Dim searcher As ManagementObjectSearcher
        searcher = New ManagementObjectSearcher(s)

        For Each o As ManagementObject In searcher.Get()
            'show the class
            Console.WriteLine(o.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>