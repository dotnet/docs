'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim p As New ManagementPath( _
            "Win32_Service.Name=""Alerter""")
        Dim o As New ManagementObject(p)

        'Now it can be used 
        Console.WriteLine(o("Name"))

        Return 0
    End Function
End Class
'</Snippet1>