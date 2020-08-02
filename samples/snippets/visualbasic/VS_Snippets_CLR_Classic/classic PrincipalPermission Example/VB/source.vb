'<Snippet1>
Imports System.Security.Permissions
Imports System.Security.Principal
Imports System.Threading



Class SecurityPrincipalDemo


    Public Shared Sub Main()
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim principalPerm As New PrincipalPermission(Nothing, "Administrators")
        principalPerm.Demand()
        Console.WriteLine("Demand succeeded.")

    End Sub
End Class
'</Snippet1>
