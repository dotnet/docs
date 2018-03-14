'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
' <snippet0>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.Security.Principal
Imports System.ServiceModel.Security
Imports System.Text.RegularExpressions



Class MyTokenAuthenticator
    Inherits UserNameSecurityTokenAuthenticator

    Shared Function IsRogueDomain(ByVal domain As String) As Boolean
        Return False

    End Function 'IsRogueDomain

    Shared Function IsEmail(ByVal inputEmail As String) As Boolean

        Dim strRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + "\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim re As New Regex(strRegex)
        If re.IsMatch(inputEmail) Then
            Return True
        Else
            Return False
        End If

    End Function 'IsEmail

    Function ValidateUserNameFormat(ByVal UserName As String) As Boolean
        If Not IsEmail(UserName) Then
            Console.WriteLine("Not a valid email")
            Return False
        End If
        Dim emailAddress As String() = UserName.Split("@"c)
        Dim user As String = emailAddress(0)
        Dim domain As String = emailAddress(1)
        If IsRogueDomain(domain) Then
            Return False
        End If
        Return True

    End Function

    ' <snippet1>
    Protected Overrides Function ValidateUserNamePasswordCore(ByVal userName As String, ByVal password As String) As ReadOnlyCollection(Of IAuthorizationPolicy)

        If Not ValidateUserNameFormat(userName) Then
            Throw New SecurityTokenValidationException("Incorrect UserName format")
        End If
        Dim setOfClaims As New DefaultClaimSet(ClaimSet.System, New Claim(ClaimTypes.Name, userName, Rights.PossessProperty))
        Dim identities As New List(Of IIdentity)(1)

        identities.Add(New GenericIdentity(userName))
        Dim policies As New List(Of IAuthorizationPolicy)(1)
        policies.Add(New UnconditionalPolicy(ClaimSet.System, setOfClaims, DateTime.MaxValue.ToUniversalTime(), identities))
        Return policies.AsReadOnly()

    End Function 'New
End Class
' </snippet1>


Class UnconditionalPolicy
    Implements IAuthorizationPolicy
    Private idValue As String = Guid.NewGuid().ToString()
    Private issuerValue As ClaimSet
    Private issuance As ClaimSet
    Private expirationTimeValue As DateTime
    Private identities As IList(Of IIdentity)
    Public Sub New(ByVal issuer As ClaimSet, ByVal issuance As ClaimSet, ByVal expirationTime As DateTime, ByVal identities As IList(Of IIdentity))

        If issuer Is Nothing Then
            Throw New ArgumentNullException("issuer")
        End If
        If issuance Is Nothing Then
            Throw New ArgumentNullException("issuance")
        End If
        Me.issuerValue = issuer
        Me.issuance = issuance
        Me.identities = identities
        Me.expirationTimeValue = expirationTime
    End Sub
    Public ReadOnly Property Id() As String Implements IAuthorizationPolicy.Id
        Get
            Return Me.idValue
        End Get
    End Property
    Public ReadOnly Property Issuer() As ClaimSet Implements IAuthorizationPolicy.Issuer
        Get
            Return Me.issuerValue
        End Get
    End Property
    Public ReadOnly Property ExpirationTime() As DateTime
        Get
            Return Me.expirationTimeValue
        End Get
    End Property
    Public Function Evaluate(ByVal evalContext As evaluationContext, ByRef state As Object) As Boolean Implements IAuthorizationPolicy.Evaluate
        evalContext.AddClaimSet(Me, Me.issuance)

        If Not (Me.identities Is Nothing) Then
            Dim value As Object = Nothing
            Dim contextIdentities As IList(Of IIdentity)
            If Not evalContext.Properties.TryGetValue("Identities", value) Then
                contextIdentities = New List(Of IIdentity)(Me.identities.Count) '
                evalContext.Properties.Add("Identities", contextIdentities)
            Else
                contextIdentities = CType(value, IList(Of IIdentity))
            End If
            Dim identity As IIdentity
            For Each identity In Me.identities
                contextIdentities.Add(identity)
            Next identity
        End If

        evalContext.RecordExpirationTime(Me.expirationTimeValue)
        Return True

    End Function
End Class
' </snippet0>