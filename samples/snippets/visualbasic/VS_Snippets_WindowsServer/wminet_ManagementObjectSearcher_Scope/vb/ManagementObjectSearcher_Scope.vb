'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim ms As ManagementScope
        ms = New ManagementScope("\\localhost\root\cimv2")
        ms.Connect()
        Dim searcher As ManagementObjectSearcher
        searcher = New ManagementObjectSearcher( _
            "SELECT * FROM Win32_Service")
        searcher.Scope = ms

        For Each service As ManagementObject In searcher.Get()
            'show the instance
            Console.WriteLine(service.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>