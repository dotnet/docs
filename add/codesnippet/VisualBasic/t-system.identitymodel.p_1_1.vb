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

        ' If state is null, then this method has not been called before, so 
        ' set up a custom state.
        If state Is Nothing Then
            customstate = New CustomAuthState()
            state = customstate
        Else
            customstate = CType(state, CustomAuthState)
        End If
        Console.WriteLine("Inside MyAuthorizationPolicy::Evaluate")

        ' If the claims have not been added yet...
        If Not customstate.ClaimsAdded Then
            ' Create an empty list of Claims
            Dim claims As New List(Of Claim)

            ' Iterate through each of the claimsets in the evaluation context.
            Dim cs As ClaimSet
            For Each cs In evaluationContext.ClaimSets
                ' Look for Name claims in the current claim set.
                Dim c As Claim
                For Each c In cs.FindClaims(ClaimTypes.Name, Rights.PossessProperty)
                    ' Get the list of operations the given username is allowed to call.
                    Dim s As String
                    For Each s In GetAllowedOpList(c.Resource.ToString())

                        ' Add claims to the list
                        claims.Add(New Claim("http://example.org/claims/allowedoperation", _
                                    s, Rights.PossessProperty))
                        Console.WriteLine("Claim added {0}", s)
                    Next s
                Next c
            Next cs 
            
            ' Add claims to the evaluation context.
            evaluationContext.AddClaimSet(Me, New DefaultClaimSet(Me.Issuer, claims))

            ' Record that claims have been added.
            customstate.ClaimsAdded = True

            ' Return true, which indicates the method need not to be called again.
            bRet = True
        Else
            ' Should never get here, but just in case...
            bRet = True
        End If


        Return bRet

    End Function 'Evaluate

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

    ' This is an internal class for state.
    Class CustomAuthState
        Private bClaimsAdded As Boolean


        Public Sub New()

        End Sub 


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