'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim s As New ManagementScope( _
            "\\MyMachine\root\cimv2")
        Dim p As New ManagementPath( _
            "Win32_Service")

        ' Set options for no context info,
        ' but requests amended qualifiers 
        ' to be contained in the object
        Dim opt As ObjectGetOptions
        opt = New ObjectGetOptions( _
                Nothing, TimeSpan.MaxValue, True)

        Dim o As ManagementObject
        o = New ManagementObject(s, p, opt)

        Console.WriteLine(o.Qualifiers("Description").Value)

        Return 0
    End Function
End Class
'</Snippet1>