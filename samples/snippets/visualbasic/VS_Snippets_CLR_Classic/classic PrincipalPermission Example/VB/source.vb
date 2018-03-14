'<Snippet1>
Imports System
Imports System.Threading
Imports System.Security.Permissions
Imports System.Security.Principal



Class SecurityPrincipalDemo


    Public Shared Sub Main()
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim principalPerm As New PrincipalPermission(Nothing, "Administrators")
        principalPerm.Demand()
        Console.WriteLine("Demand succeeded.")

    End Sub 'Main
End Class 'SecurityPrincipalDemo
'</Snippet1>