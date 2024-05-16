'<snippet0>
'<snippet1>
Imports System.Collections.Generic
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.ServiceModel
Imports System.Security.Permissions

'</snippet1>


'<snippet2>

Public Class MyServiceAuthorizationManager
    Inherits ServiceAuthorizationManager

    Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean
        ' Extract the action URI from the OperationContext. Use this to match against the claims
        ' in the AuthorizationContext.
        Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action

        ' Iterate through the various claimsets in the AuthorizationContext.
        Dim cs As ClaimSet
        For Each cs In operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
            ' Only look at claimsets issued by System.
            If cs.Issuer is ClaimSet.System Then
                ' Iterate through claims of type "http://example.org/claims/allowedoperation".
                Dim c As Claim
                For Each c In cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty)
                    ' If the Claim resource matches the action URI, then return true to allow access.
                    If action = c.Resource.ToString() Then
                        Return True
                    End If
                Next c
            End If
        Next cs
        ' If this point is reached, return false, denying access.
        Return False

    End Function 'CheckAccessCore
End Class
'</snippet2>

'<snippet5>

Public Class MyAuthorizationPolicy
    Implements IAuthorizationPolicy
    Private id_Value As String


    Public Sub New()
        id_Value = Guid.NewGuid().ToString()

    End Sub


    '<snippet6>
    Public Function Evaluate(ByVal evaluationContext As EvaluationContext, ByRef state As Object) As Boolean _
        Implements IAuthorizationPolicy.Evaluate
        Dim bRet As Boolean = False
        Dim customstate As CustomAuthState = Nothing

        ' If the state is null, then this has not been called before, so set up
        ' our custom state.
        If state Is Nothing Then
            customstate = New CustomAuthState()
            state = customstate
        Else
            customstate = CType(state, CustomAuthState)
        End If
        ' If claims have not been added yet...
        If Not customstate.ClaimsAdded Then
            ' Create an empty list of Claims.
            Dim claims as IList(Of Claim) = New List(Of Claim)()

            ' Iterate through each of the claimsets in the evaluation context.
            Dim cs As ClaimSet
            For Each cs In evaluationContext.ClaimSets
                ' Look for Name claims in the current claimset...
                Dim c As Claim
                For Each c In cs.FindClaims(ClaimTypes.Name, Rights.PossessProperty)
                    ' Get the list of operations that the given username is allowed to call.
                    Dim s As String
                    For Each s In GetAllowedOpList(c.Resource.ToString())
                        ' Add claims to the list.
                        claims.Add(New Claim("http://example.org/claims/allowedoperation", s, Rights.PossessProperty))
                        Console.WriteLine("Claim added {0}", s)
                    Next s
                Next c
            Next cs ' Add claims to the evaluation context.
            evaluationContext.AddClaimSet(Me, New DefaultClaimSet(Me.Issuer, claims))

            ' Record that claims were added.
            customstate.ClaimsAdded = True

            ' Return true, indicating that this does not need to be called again.
            bRet = True
        Else
            ' Should never get here, but just in case...
            bRet = True
        End If


        Return bRet

    End Function
    '</snippet6>

    Public ReadOnly Property Issuer() As ClaimSet Implements IAuthorizationPolicy.Issuer
        Get
            Return ClaimSet.System
        End Get
    End Property

    Public ReadOnly Property Id() As String Implements IAuthorizationPolicy.Id
        Get
            Return id_Value
        End Get
    End Property
    ' This method returns a collection of action strings that indicate the
    ' operations the specified username is allowed to call.

    ' Operations the specified username is allowed to call.
    Private Function GetAllowedOpList(ByVal userName As String) As IEnumerable(Of String)
        Dim ret As IList(Of String) = new List(Of String)()
        If username = "test1" Then
            ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Add")
            ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Multiply")
            ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Subtract")
        ElseIf username = "test2" Then
            ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Add")
            ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Subtract")
        End If
        Return ret
    End Function

    '<snippet7>
    ' internal class for keeping track of state

    Class CustomAuthState
        Private bClaimsAdded As Boolean


        Public Sub New()
            bClaimsAdded = False

        End Sub


        Public Property ClaimsAdded() As Boolean
            Get
                Return bClaimsAdded
            End Get
            Set
                bClaimsAdded = value
            End Set
        End Property
    End Class
    '</snippet7>
End Class

'</snippet5>

' Define a service contract.
<ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface ' ICalculator


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
        Try
            '<snippet4>
            ' Add custom authorization manager to service authorization behavior.
            serviceHost.Authorization.ServiceAuthorizationManager = New MyServiceAuthorizationManager()
            '</snippet4>
            '<snippet8>
            ' Add custom authorization policy to service authorization behavior.
            Dim policies As List(Of IAuthorizationPolicy) = New List(Of IAuthorizationPolicy)()
            policies.Add(New MyAuthorizationPolicy())
            serviceHost.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly()
            '</snippet8>
            ' Open the ServiceHost to create listeners and start listening for messages.
            serviceHost.Open()

            ' The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()

            ' Close the ServiceHost to shut down the service.
            serviceHost.Close()
        Finally
            serviceHost.Close()
        End Try
        '</snippet3>
    End Sub
End Class
'</snippet0>
