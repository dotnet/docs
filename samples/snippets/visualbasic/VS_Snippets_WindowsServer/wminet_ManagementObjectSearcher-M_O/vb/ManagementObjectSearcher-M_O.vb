'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim myScope As New ManagementScope("root\CIMV2")
        Dim q As New SelectQuery("Win32_LogicalDisk")
        Dim s As New ManagementObjectSearcher(myScope, q)

        For Each disk As ManagementObject In s.Get()
            'show the disk instance
            Console.WriteLine(disk.ToString())
        Next


    End Function 'Main
End Class 'Sample
'</Snippet1>