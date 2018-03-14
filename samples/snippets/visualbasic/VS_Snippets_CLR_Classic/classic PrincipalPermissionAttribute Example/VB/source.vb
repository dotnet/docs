'<Snippet1>
Imports System
Imports System.Threading
Imports System.Security.Permissions
Imports System.Security.Principal



Class SecurityPrincipalDemo

    Public Shared Sub Main()
        Try
            ' PrincipalPolicy must be set to WindowsPrincipal to check roles.
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
            ' Check using the PrincipalPermissionAttribute
            CheckAdministrator()
            ' Check using PrincipalPermission class.
            Dim principalPerm As New PrincipalPermission(Nothing, "Administrators")
            principalPerm.Demand()
            Console.WriteLine("Demand succeeded.")
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub 'Main

    <PrincipalPermission(SecurityAction.Demand, Role:="Administrators")> _
    Shared Sub CheckAdministrator()
        Console.WriteLine("User is an administrator")

    End Sub 'CheckAdministrator
End Class 'SecurityPrincipalDemo
'</Snippet1>