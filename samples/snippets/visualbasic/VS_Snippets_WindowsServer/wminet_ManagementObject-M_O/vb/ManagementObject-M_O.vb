'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        Dim p As New ManagementPath("Win32_Service")

        ' Set options for no context info
        ' but requests amended qualifiers 
        ' to be contained in the object
        Dim opt As New ObjectGetOptions( _
            Nothing, TimeSpan.MaxValue, True)

        Dim c As New ManagementClass(p, opt)

        Console.WriteLine(c.Qualifiers("Description").Value)

        Return 0
    End Function
End Class
'</Snippet1>