'<Snippet1>
Imports System
Imports System.Management
Public Class RemoteConnect

    Public Overloads Shared Function Main( _
    ByVal args() As String) As Integer

        Dim opt As EnumerationOptions
        Opt = New EnumerationOptions( _
            Nothing, System.TimeSpan.MaxValue, _
            1, True, True, False, _
            True, False, False, True)

        Dim mngmtClass As New ManagementClass("CIM_Service")
        Dim o As ManagementObject
        For Each o In mngmtClass.GetInstances(opt)
            Console.WriteLine(o("Name"))
        Next o

        Return 0
    End Function
End Class
'</Snippet1>