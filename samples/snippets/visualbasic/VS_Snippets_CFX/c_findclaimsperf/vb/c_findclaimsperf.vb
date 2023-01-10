'<snippet0>
'<snippet1>

Imports System.Collections.Generic
Imports System.IdentityModel.Claims
Imports System.Security.Permissions
'</snippet1>
Namespace Samples
    Friend Class Program

        Public Shared Sub Main()
            Dim claims As IList(Of Claim) = FindSomeClaims(ClaimSet.System, _
                                                           ClaimTypes.System, _
                                                           Rights.Identity)
        End Sub
        '<snippet2>
        ' The FindSomeClaims method looks in the provided ClaimSet for Claims of the specified type and right. 
        ' It returns such Claims in a list.
        Public Shared Function FindSomeClaims(ByVal cs As ClaimSet, _
                                              ByVal type As String, _
                                              ByVal right As String) As IList(Of Claim)
            ' Create an empty list
            Dim claims As New List(Of Claim)()

            ' Call ClaimSet.FindClaims with the specified type and right. Iterate over the result...
            For Each c In cs.FindClaims(type, right)
                '...adding each claim to the list
                claims.Add(c)
            Next c

            ' Return the list
            Return claims
        End Function
        '</snippet2>
    End Class
End Namespace
'</snippet0>
