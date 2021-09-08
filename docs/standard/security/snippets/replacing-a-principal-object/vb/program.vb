'<Snippet1>
Imports System.Threading
Imports System.Security.Permissions
Imports System.Security.Principal



Class SecurityPrincipalDemo

    ' Create a generic principal based on values from the current
    ' WindowsIdentity.
    Private Shared Function GetGenericPrincipal() As GenericPrincipal
        ' Use values from the current WindowsIdentity to construct
        ' a set of GenericPrincipal roles.
        Dim windowsIdentity As WindowsIdentity = windowsIdentity.GetCurrent()
        Dim roles(9) As String
        If windowsIdentity.IsAuthenticated Then
            ' Add custom NetworkUser role.
            roles(0) = "NetworkUser"
        End If

        If windowsIdentity.IsGuest Then
            ' Add custom GuestUser role.
            roles(1) = "GuestUser"
        End If

        If windowsIdentity.IsSystem Then
            ' Add custom SystemUser role.
            roles(2) = "SystemUser"
        End If

        ' Construct a GenericIdentity object based on the current Windows
        ' identity name and authentication type.
        Dim authenticationType As String = windowsIdentity.AuthenticationType
        Dim userName As String = windowsIdentity.Name
        Dim genericIdentity As New GenericIdentity(userName, authenticationType)

        ' Construct a GenericPrincipal object based on the generic identity
        ' and custom roles for the user.
        Dim genericPrincipal As New GenericPrincipal(genericIdentity, roles)

        Return genericPrincipal

    End Function 'GetGenericPrincipal

    Public Shared Sub Main()
        ' Retrieve a GenericPrincipal that is based on the current user's
        ' WindowsIdentity.
        Dim genericPrincipal As GenericPrincipal = GetGenericPrincipal()

        ' Retrieve the generic identity of the GenericPrincipal object.
        Dim principalIdentity As GenericIdentity = CType(genericPrincipal.Identity, GenericIdentity)

        ' Display the identity name and authentication type.
        If principalIdentity.IsAuthenticated Then
            Console.WriteLine(principalIdentity.Name)
            Console.WriteLine("Type:" + principalIdentity.AuthenticationType)
        End If

        ' Verify that the generic principal has been assigned the
        ' NetworkUser role.
        If genericPrincipal.IsInRole("NetworkUser") Then
            Console.WriteLine("User belongs to the NetworkUser role.")
        End If

        Thread.CurrentPrincipal = genericPrincipal

    End Sub



End Class
'</Snippet1>
