'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim o As New ManagementObject( _
    "Win32_Service.Name=""Alerter""")

        ' or with a full path :

        Dim mObj As New ManagementObject( _
            "\\\\MyServer\\root\\MyApp:MyClass.Key=""abc""")

        Return 0
    End Function
End Class
'</Snippet1>