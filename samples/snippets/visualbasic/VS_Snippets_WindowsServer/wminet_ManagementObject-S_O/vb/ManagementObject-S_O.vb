'<Snippet1>
Imports System
Imports System.Management

Class Sample_ManagementClass
    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer

        ' Set options for no context info, 
        ' but requests amended qualifiers
        ' to be contained in the object
        Dim opt As New ObjectGetOptions( _
            Nothing, System.TimeSpan.MaxValue, True)

        Dim o As New ManagementObject( _
            "Win32_Service", opt)

        Console.WriteLine(o.GetQualifierValue("Description"))

        Return 0
    End Function
End Class
'</Snippet1>