'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim o As New ManagementObject( _
            "Win32_Service=""Alerter""")
        Dim b As ManagementObject
        For Each b In o.GetRelated("Win32_Service")
            Console.WriteLine( _
            "Service related to the Alerter service {0} is {1}", _
            b("Name"), b("State"))
        Next b

        Return 0
    End Function
End Class
'</Snippet1>