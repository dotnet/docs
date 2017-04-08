
Imports System
Imports System.Collections.Generic
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Tokens
Imports System.IdentityModel.Selectors
Imports System.ServiceModel
Imports System.Security.Permissions



<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
' <snippet1>
Public Class MyServiceAuthorizationManager
    Inherits ServiceAuthorizationManager

    Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean

        ' Extract the action URI from the OperationContext. Match this against the claims
        ' in the AuthorizationContext.
        Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action
        Console.WriteLine("action: {0}", action)

        ' Iterate through the various claim sets in the AuthorizationContext.
        Dim cs As ClaimSet

        For Each cs In operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
            ' Examine only those claim sets issued by System.
            If cs.Issuer Is ClaimSet.System Then
                ' Iterate through claims of type "http://example.org/claims/allowedoperation".
                Dim c As Claim
                ' <snippet2>
                For Each c In cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty)
                    ' </snippet2>
                    ' Write the claim resource to the console.
                    Console.WriteLine("resource: {0}", c.Resource.ToString())

                    ' If the claim resource matches the action URI then return true to allow access
                    If action = c.Resource.ToString() Then
                        Return True
                    End If
                Next c
            End If
        Next cs
        ' 
        ' If this point is reached, return false to deny access.
        Return False

    End Function 
    ' </snippet1>
End Class 
 
Public Class MyAuthorizationPolicy
    Implements IAuthorizationPolicy
    Private value_id As String


    Public Sub New()
        value_id = Guid.NewGuid().ToString()

    End Sub 

    Public Function Evaluate(ByVal evaluationContext As EvaluationContext, _
        ByRef state As Object) As Boolean Implements IAuthorizationPolicy.Evaluate

        Dim bRet As Boolean = False
        Dim customstate As CustomAuthState = Nothing

        ' If the state is null, then the method has not been called before, so 
        ' set up a custom state.
        If state Is Nothing Then
            customstate = New CustomAuthState()
            state = customstate
        Else
            customstate = CType(state, CustomAuthState)
        End If
        Console.WriteLine("Inside MyAuthorizationPolicy::Evaluate")

        ' If claims have not been added yet...
        If Not customstate.ClaimsAdded Then
            ' Create an empty list of Claims.
            Dim claims As New List(Of Claim)

            ' Iterate through each of the claim sets in the evaluation context.
            Dim cs As ClaimSet
            For Each cs In evaluationContext.ClaimSets
                ' Look for Name claims in the current claim set.
                Dim c As Claim
                For Each c In cs.FindClaims(ClaimTypes.Name, Rights.PossessProperty)
                    ' Get the list of operations that the given username is allowed to call.
                    Dim s As String
                    For Each s In GetAllowedOpList(c.Resource.ToString())
 
                       ' Add claims to the list.
                        claims.Add(New Claim("http://example.org/claims/allowedoperation", _
                                   s, Rights.PossessProperty))
                        Console.WriteLine("Claim added {0}", s)
                    Next s
                Next c
            Next cs 

            ' Add claims to the evaluation context.
            evaluationContext.AddClaimSet(Me, New DefaultClaimSet(Me.Issuer, claims))

            ' Record that the claims have been added.
            customstate.ClaimsAdded = True

            ' Return true, which indicates the method need not be called again.
            bRet = True
        Else
            ' This point should not be reached, but just in case...
            bRet = True
        End If


        Return bRet

    End Function 

    Public ReadOnly Property Issuer() As ClaimSet Implements IAuthorizationPolicy.Issuer

        Get
            Return ClaimSet.System
        End Get
    End Property

    Public ReadOnly Property Id() As String Implements IAuthorizationPolicy.Id

        Get
            Return value_id
        End Get
    End Property

    ' This method returns a collection of action strings that indicate the 
    ' operations that the specified username is allowed to call.
    Private Shared Function GetAllowedOpList(ByVal username As String) As IEnumerable(Of String)


        Dim ret As New List(Of String)

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

    ' This is an internal class for recording state.

    Class CustomAuthState
        Private bClaimsAdded As Boolean


        Public Sub New()

        End Sub 'New


        Public Property ClaimsAdded() As Boolean
            Get
                Return bClaimsAdded
            End Get
            Set(ByVal value As Boolean)
                bClaimsAdded = value
            End Set
        End Property
    End Class 
End Class 
' 