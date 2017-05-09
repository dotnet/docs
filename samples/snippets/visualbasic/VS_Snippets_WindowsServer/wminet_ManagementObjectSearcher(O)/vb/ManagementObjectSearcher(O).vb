'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim q As New _
            SelectQuery("Win32_Service", "State=""Running""")
        Dim s As New ManagementObjectSearcher(q)

        For Each service As ManagementObject In s.Get()
            'show the instance
            Console.WriteLine(service.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>