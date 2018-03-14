'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim m As New ManagementObject( _
            "Win32_LogicalDisk.DeviceID=""C:""")
        Console.WriteLine( _
            m.Properties("FreeSpace").Value)

        Return 0
    End Function
End Class
'</Snippet1>