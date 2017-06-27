'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim s As New SelectQuery( _
            True, "__CLASS = ""Win32_Service""")

        Dim searcher As ManagementObjectSearcher
        searcher = New ManagementObjectSearcher(s)

        For Each service As ManagementObject In searcher.Get()
            'show the class
            Console.WriteLine(service.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>