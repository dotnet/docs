
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.DirectoryServices.ActiveDirectory
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Security.Authentication
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.Security.Principal
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens

Namespace ServerInitiatedNego

	Public Class IdentitySamples
		Shared Sub Main(ByVal args() As String)
		End Sub
		Friend Const UpgradeString As String = "application/reverse-negotiate"

		Private identityVerifier As IdentityVerifier = IdentityVerifier.CreateDefault()


	   ' <snippet1>
	   Private Shared Function CreateIdentity() As EndpointIdentity
			Dim self As WindowsIdentity = WindowsIdentity.GetCurrent()
			Dim sid As SecurityIdentifier = self.User

			Dim identity As EndpointIdentity = Nothing

			If sid.IsWellKnown(WellKnownSidType.LocalSystemSid) OrElse sid.IsWellKnown(WellKnownSidType.NetworkServiceSid) OrElse sid.IsWellKnown(WellKnownSidType.LocalServiceSid) Then
				identity = EndpointIdentity.CreateSpnIdentity(String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()))
			Else
				' Need an UPN string here
				Dim domain As String = GetPrimaryDomain()
				If domain IsNot Nothing Then
					Dim split() As String = self.Name.Split("\"c)
					If split.Length = 2 Then
						identity = EndpointIdentity.CreateUpnIdentity(split(1) & "@" & domain)
					End If
				End If
			End If

			Return identity
	   End Function
		' </snippet1>

		' <snippet2>
		Private Function CreateIdentityFromClaimSet(ByVal claims As ClaimSet) As SpnEndpointIdentity
			For Each claim As Claim In claims.FindClaims(Nothing, Rights.Identity)
				Return New SpnEndpointIdentity(claim)
			Next claim
			Return Nothing
		End Function
		' </snippet2>

		' <snippet3>
		Private Shared Function CreateSpnIdentity() As EndpointIdentity
			Dim self As WindowsIdentity = WindowsIdentity.GetCurrent()
			Dim sid As SecurityIdentifier = self.User

			Dim identity As SpnEndpointIdentity = Nothing

			identity = New SpnEndpointIdentity(String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()))

			Return identity
		End Function
		Private Shared Function GetMachineName() As String
			Return Dns.GetHostEntry(String.Empty).HostName
		End Function
		' </snippet3>

		Private Shared Function GetPrimaryDomain() As String
			Dim currentDomain As String = Nothing
			Try
				currentDomain = Domain.GetCurrentDomain().Name
			Catch e1 As ActiveDirectoryObjectNotFoundException
				' ignore
			Catch e2 As ActiveDirectoryOperationException
				' ignore
			Catch e3 As ActiveDirectoryServerDownException
				' ignore
			End Try
			Return currentDomain
		End Function
	End Class


	Friend Class SimpleAuthorizationPolicy
		Implements IAuthorizationPolicy
		Private id_Renamed As String = Guid.NewGuid().ToString()
		Private primaryIdentity As Claim

		Public Sub New(ByVal primaryIdentity As Claim)
			Me.primaryIdentity = primaryIdentity
		End Sub

		Public ReadOnly Property Id() As String Implements System.IdentityModel.Policy.IAuthorizationComponent.Id
			Get
				Return Me.id_Renamed
			End Get
		End Property

		Public ReadOnly Property Issuer() As ClaimSet Implements IAuthorizationPolicy.Issuer
			Get
				Return ClaimSet.System
			End Get
		End Property

		Public Function Evaluate(ByVal evaluationContext As EvaluationContext, ByRef state As Object) As Boolean Implements IAuthorizationPolicy.Evaluate
			evaluationContext.AddClaimSet(Me, New DefaultClaimSet(ClaimSet.System, Me.primaryIdentity))
			If (Not evaluationContext.Properties.ContainsKey("PrimaryIdentity")) Then
				evaluationContext.Properties.Add("PrimaryIdentity", Me.primaryIdentity)
			End If
			Return True
		End Function
	End Class
End Namespace
