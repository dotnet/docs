'<Snippet1>
Imports System
Imports System.Management
Public Class Sample

    Public Overloads Shared Function Main( _
    ByVal args() As String) As Integer

        Dim o As New ManagementObject

        ' Specify the WMI path to which 
        ' this object should be bound to
        o.Path = New ManagementPath( _
            "Win32_Process.Name=""calc.exe""")

        Return 0
    End Function
End Class
'</Snippet1>