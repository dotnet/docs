' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Security.Cryptography.X509Certificates
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Tokens
Imports System.IdentityModel.Selectors
Imports System.ServiceModel


' Service class that implements the service contract.
<ServiceBehavior(IncludeExceptionDetailInFaults:=True)> _
Public Class EchoService
    Implements IEchoService
    <ServiceContract()> _
    Public Interface IEchoService
        : Inherits IDisposable
        <OperationContract()> _
        Function Echo() As String
    End Interface 'IEchoService

    Public Function Echo() As String Implements IEchoService.Echo
        Dim userName As String = String.Empty
        Dim certificateSubjectName As String = String.Empty
        GetCallerIdentities(OperationContext.Current.ServiceSecurityContext, userName, certificateSubjectName)
        Return String.Format("Hello {0}, {1}", userName, certificateSubjectName)

    End Function 'Echo


    Public Sub Dispose() Implements IDisposable.Dispose

    End Sub 'Dispose


    

    Function TryGetClaimValue(Of TClaimResource)(ByVal claimSet As ClaimSet, ByVal claimType As String, ByRef resourceValue As TClaimResource) As Boolean
        Dim matchingClaims As IEnumerable(Of Claim) = claimSet.FindClaims(claimType, Rights.PossessProperty)
        If matchingClaims Is Nothing Then
            Return False
        End If
        Dim enumerator As IEnumerator(Of Claim) = matchingClaims.GetEnumerator()
        If enumerator.MoveNext() Then
            If enumerator.Current.Resource Is Nothing Then
                resourceValue = Nothing
            Else
                resourceValue = CType(enumerator.Current.Resource, TClaimResource)
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Sub GetCallerIdentities(ByVal callerSecurityContext As ServiceSecurityContext, ByRef userName As String, ByRef certificateSubjectName As String)
        ' Returns the username and certificate subject name provided by the client.

        userName = Nothing
        certificateSubjectName = Nothing

        ' Look in all the claimsets in the authorization context.
        Dim claimSet As ClaimSet
        For Each claimSet In callerSecurityContext.AuthorizationContext.ClaimSets
            ' Try to find a Upn claim. This has been generated from the Windows username.
            Dim tmpName As String = String.Empty
            If TryGetClaimValue(Of String)(claimSet, ClaimTypes.Upn, tmpName) Then
                userName = tmpName
            Else
                ' Try to find an X500DisinguishedName claim. This has been generated from the client certificate.
                Dim tmpDistinguishedName As X500DistinguishedName = Nothing
                If TryGetClaimValue(Of X500DistinguishedName)(claimSet, ClaimTypes.X500DistinguishedName, tmpDistinguishedName) Then
                    certificateSubjectName = tmpDistinguishedName.Name
                End If
            End If
        Next claimSet

    End Sub
End Class 'EchoService
' </snippet1>