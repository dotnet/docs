Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Principal
Imports System.ServiceModel
Imports System.Security.Permissions

Namespace Design2
    Friend Class Program

        Shared Sub Main(ByVal args() As String)
        End Sub

        Private Sub Run()
            '<snippet1>
            Dim identity = ServiceSecurityContext.Current.WindowsIdentity
            Using identity.Impersonate()
                ' Run code under the caller's identity.
            End Using
            '</snippet1>
        End Sub
    End Class

End Namespace
