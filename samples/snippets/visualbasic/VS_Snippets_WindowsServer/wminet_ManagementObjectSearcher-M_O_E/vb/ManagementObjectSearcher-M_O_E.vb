'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim scope As New ManagementScope("root\MyApp")
        Dim q As New SelectQuery("SELECT * FROM Win32_LogicalDisk")
        Dim o As New EnumerationOptions( _
            Nothing, System.TimeSpan.MaxValue, 1, _
            True, False, True, True, False, _
            True, True)
        Dim s As New ManagementObjectSearcher(scope, q, o)

        For Each disk As ManagementObject In s.Get()
            'show the disk instance
            Console.WriteLine(disk.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>