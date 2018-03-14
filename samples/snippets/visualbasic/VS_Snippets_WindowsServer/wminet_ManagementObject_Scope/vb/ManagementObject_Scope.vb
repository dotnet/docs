'<Snippet1>
Imports System
Imports System.Management
Public Class Sample

    Public Overloads Shared Function Main( _
    ByVal args() As String) As Integer

        ' Create the object with the default namespace
        ' (root\cimv2)
        Dim o As New ManagementObject

        ' Change the scope (=namespace) of this object
        ' to the one specified.
        o.Scope = New ManagementScope("root\CIMV2")

        Return 0
    End Function
End Class
'</Snippet1>