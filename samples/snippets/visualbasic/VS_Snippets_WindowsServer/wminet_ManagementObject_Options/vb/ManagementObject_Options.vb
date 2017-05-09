'<Snippet1>
Imports System
Imports System.Management
Public Class Sample

    Public Overloads Shared Function Main( _
    ByVal args() As String) As Integer

        'Contains default options
        Dim o As New ManagementObject( _
            "Win32_Process.Name=""notepad.exe""")

        ' Replace default options, 
        ' in this case requesting retrieval of
        ' amended qualifiers along with the WMI object.
        o.Options = New ObjectGetOptions( _
            Nothing, System.TimeSpan.MaxValue, True)

        Return 0
    End Function
End Class
'</Snippet1>