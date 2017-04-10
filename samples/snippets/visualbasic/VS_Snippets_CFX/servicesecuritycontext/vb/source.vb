Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Claims

<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
Public Class Test
    Private Sub New() 
    
    End Sub 
     
    Shared Sub Main() 
      ' empty, must for FXCop.
    End Sub 
End Class 


<ServiceContract([Namespace]:="Microsoft.ServiceModel.Samples")> _
Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface


Public Class Calculator
    Implements ICalculator
    '<snippet1>
    ' When this method runs, the caller must be an authenticated user and the ServiceSecurityContext 
    ' is not a null instance. 
    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
        ' Write data from the ServiceSecurityContext to a file using the StreamWriter class.
        Dim sw As New StreamWriter("c:\ServiceSecurityContextInfo.txt")
        Try
            ' Write the primary identity and Windows identity. The primary identity is derived from 
            ' the credentials used to authenticate the user. The Windows identity may be a null string.
            sw.WriteLine("PrimaryIdentity: {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
            sw.WriteLine("WindowsIdentity: {0}", ServiceSecurityContext.Current.WindowsIdentity.Name)

            ' Write the claimsets in the authorization context. By default, there is only one claimset
            ' provided by the system. 
            Dim claimset As ClaimSet
            For Each claimset In ServiceSecurityContext.Current.AuthorizationContext.ClaimSets
                Dim claim As Claim
                For Each claim In claimset
                    ' Write out each claim type, claim value, and the right. There are two
                    ' possible values for the right: "identity" and "possessproperty". 
                    sw.WriteLine("Claim Type: {0}, Resource: {1} Right: {2}", _
                    claim.ClaimType, _
                    claim.Resource.ToString(), _
                    claim.Right)
                    sw.WriteLine()
                Next claim
            Next claimset
        Finally
            sw.Dispose()
        End Try
        Return n1 + n2
    End Function
    '</snippet1>
End Class

'<snippet2>
Public Class MyServiceAuthorizationManager
    Inherits ServiceAuthorizationManager
    
    Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean 
        ' Extract the action URI from the OperationContext. Match this against the claims
        ' in the AuthorizationContext.
        Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action
        Console.WriteLine("action: {0}", action)
        
        ' Iterate through the various claimsets in the authorizationcontext.
        Dim cs As ClaimSet
        For Each cs In  operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
            ' Examine only those claim sets issued by System.
            If cs.Issuer Is ClaimSet.System Then
                ' Iterate through claims of type "http://example.org/claims/allowedoperation".
                Dim c As Claim
                For Each c In  cs.FindClaims("http://example.org/claims/allowedoperation", _
                        Rights.PossessProperty)
                    ' Write the Claim resource to the console.
                    Console.WriteLine("resource: {0}", c.Resource.ToString())
                    
                    ' If the Claim resource matches the action URI then return true to allow access.
                    If action = c.Resource.ToString() Then
                        Return True
                    End If
                Next c
            End If
        Next cs 
        ' If we get here, return false, denying access.
        Return False
    
    End Function 
End Class 
'</snippet2>