'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim o As New ManagementObject

        Dim mp As New _
            ManagementPath("Win32_LogicalDisk='c:'")

        ' Now set the path on this object to
        ' bind it to a 'real' manageable entity
        o.Path = mp

        'Now it can be used 
        Console.WriteLine(o("FreeSpace"))

        Return 0
    End Function
End Class
'</Snippet1>