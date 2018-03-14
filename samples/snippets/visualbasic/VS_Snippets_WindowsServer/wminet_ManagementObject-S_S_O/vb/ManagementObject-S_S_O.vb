'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim opt As New ObjectGetOptions( _
            Nothing, System.TimeSpan.MaxValue, True)
        Dim o As New ManagementObject( _
            "root\MyNamespace", "MyClass", opt)

        Return 0
    End Function
End Class
'</Snippet1>