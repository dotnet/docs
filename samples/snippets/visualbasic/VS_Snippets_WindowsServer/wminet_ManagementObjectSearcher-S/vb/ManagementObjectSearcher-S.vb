'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim s As New _
            ManagementObjectSearcher( _
            "SELECT * FROM Win32_Service")

        For Each service As ManagementObject In s.Get()
            'show the instance
            Console.WriteLine(service.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>