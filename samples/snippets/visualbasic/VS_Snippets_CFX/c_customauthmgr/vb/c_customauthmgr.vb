'<snippet0>
'<snippet1>
Imports System.IdentityModel.Claims
Imports System.ServiceModel
Imports System.Security.Permissions

'</snippet1>


'<snippet2>
'<snippet5>

Public Class MyServiceAuthorizationManager
    Inherits ServiceAuthorizationManager

    '</snippet5>
    '<snippet6>
    Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean
        ' Extract the action URI from the OperationContext. Match this against the claims.
        ' in the AuthorizationContext.
        Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action

        ' Iterate through the various claimsets in the AuthorizationContext.
        Dim cs As ClaimSet
        For Each cs In operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
            ' Examine only those claim sets issued by System.
            If cs.Issuer Is ClaimSet.System Then
                ' Iterate through claims of type "http://www.contoso.com/claims/allowedoperation".
                Dim c As Claim
                For Each c In cs.FindClaims("http://www.contoso.com/claims/allowedoperation", _
                     Rights.PossessProperty)
                    ' If the Claim resource matches the action URI then return true to allow access.
                    If action = c.Resource.ToString() Then
                        Return True
                    End If
                Next c
            End If
        Next cs
        ' If this point is reached, return false to deny access.
        Return False

    End Function
    '</snippet6>
End Class

'</snippet2>
' Define a service contract.
<ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface


Public Class CalculatorService
    Implements ICalculator

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
        Implements ICalculator.Add

        Dim result As Double = n1 + n2
        Console.WriteLine("Received Add({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function
End Class



Class Program

    Public Shared Sub Main()
        '<snippet3>
        Dim serviceHost As New ServiceHost(GetType(CalculatorService))
        '<snippet4>
        ' Add a custom authorization manager to the service authorization behavior.
        serviceHost.Authorization.ServiceAuthorizationManager = _
            New MyServiceAuthorizationManager()

        '</snippet4>
        ' Open the ServiceHost to create listeners and start listening for messages.
        serviceHost.Open()

        ' The service can now be accessed.
        Console.WriteLine("The service is ready.")
        Console.WriteLine("Press <ENTER> to terminate service.")
        Console.WriteLine()
        Console.ReadLine()

        ' Close the ServiceHost to shutdown the service.
        serviceHost.Close()

    End Sub
    '</snippet3>
End Class
'</snippet0>
