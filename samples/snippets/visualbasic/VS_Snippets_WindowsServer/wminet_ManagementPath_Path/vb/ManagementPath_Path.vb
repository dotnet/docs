'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class path
        Dim p As ManagementPath = _
            New ManagementPath( _
            "\\ComputerName\root" & _
            "\cimv2:Win32_LogicalDisk.DeviceID=""C:""")

        Console.WriteLine("IsClass: " & _
            p.IsClass)
        ' Should be False (because it is an instance)

        Console.WriteLine("IsInstance: " & _
            p.IsInstance)
        ' Should be True

        Console.WriteLine("ClassName: " & _
            p.ClassName)
        ' Should be "Win32_LogicalDisk"

        Console.WriteLine("NamespacePath: " & _
            p.NamespacePath)
        ' Should be "ComputerName\cimv2"

        Console.WriteLine("Server: " & _
            p.Server)
        ' Should be "ComputerName"

        Console.WriteLine("Path: " & _
            p.Path)
        ' Should be "ComputerName\root\cimv2:
        ' Win32_LogicalDisk.DeviceId="C:""

        Console.WriteLine("RelativePath: " & _
            p.RelativePath)
        ' Should be "Win32_LogicalDisk.DeviceID="C:""

    End Function
End Class
'</Snippet1>