'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim s As New ManagementObjectSearcher( _
            "root\MyApp", _
            "SELECT * FROM Win32_Service", _
            New EnumerationOptions( _
            Nothing, System.TimeSpan.MaxValue, 1, _
            True, False, True, True, False, _
            True, True))


        For Each service As ManagementObject In s.Get()
            'show the instance
            Console.WriteLine(service.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>