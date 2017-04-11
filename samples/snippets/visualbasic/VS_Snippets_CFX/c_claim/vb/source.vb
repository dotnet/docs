'
Imports System.Security.Permissions
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.IO
Imports System.IdentityModel.Claims
'
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>



Public Class Calculator
    
    '
    ' Only members of the CalculatorClients group can call this method.
    <PrincipalPermission(SecurityAction.Demand, Role:="CalculatorClients")> _
    Public Function Add(ByVal a As Double, ByVal b As Double) As Double
        Return a + b
    End Function

    '

    '
    ' Only a client authenticated with a valid certificate that has the 
    ' specified subject name and thumbprint can call this method.
    <PrincipalPermission(SecurityAction.Demand, Name:="CN=ReplaceWithSubjectName; 123456712345677E8E230FDE624F841B1CE9D41E")> _
    Public Function Multiply(ByVal a As Double, ByVal b As Double) As Double
        Return a * b
    End Function
    '

    ' <snippet1>
    ' Run this method from within a method protected by the PrincipalPermissionAttribute
    ' to see the security context data, including the primary identity.
    Public Sub WriteServiceSecurityContextData(ByVal fileName As String)
        Dim sw As New StreamWriter(fileName)
        Try
            ' Write the primary identity and Windows identity. The primary identity is derived from the
            ' the credentials used to authenticate the user. The Windows identity may be a null string.
            sw.WriteLine("PrimaryIdentity: {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            sw.WriteLine("WindowsIdentity: {0}", ServiceSecurityContext.Current.WindowsIdentity.Name)
            sw.WriteLine()
            ' <snippet2>
            ' Write the claimsets in the authorization context. By default, there is only one claimset
            ' provided by the system. 
            Dim claimset As ClaimSet
            For Each claimset In ServiceSecurityContext.Current.AuthorizationContext.ClaimSets
                Dim claim As Claim
                For Each claim In claimset
                    ' Write out each claim type, claim value, and the right. There are two
                    ' possible values for the right: "identity" and "possessproperty". 
                    sw.WriteLine("Claim Type = {0}", claim.ClaimType)
                    sw.WriteLine(vbTab + " Resource = {0}", claim.Resource.ToString())
                    sw.WriteLine(vbTab + " Right = {0}", claim.Right)
                Next claim
            Next claimset
            ' </snippet2>
        Finally
            sw.Dispose()
        End Try

    End Sub
    ' </snippet1>
    '
End Class


Public Class Test
    Shared Sub Main()
        Dim baseUri As New Uri("http://ServiceModelSamples")

        Dim myServiceHost As New ServiceHost(GetType(Calculator), baseUri)
        '
        Dim myServiceBehavior As ServiceAuthorizationBehavior
        myServiceBehavior = _
           myServiceHost.Description.Behaviors.Find(Of ServiceAuthorizationBehavior)()
        myServiceBehavior.PrincipalPermissionMode = _
           PrincipalPermissionMode.UseAspNetRoles
        '
    End Sub
End Class
