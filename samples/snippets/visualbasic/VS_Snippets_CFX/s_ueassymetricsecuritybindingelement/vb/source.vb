Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security.Tokens
Namespace HowToReferenceCertificates
	Public Class Test
		Shared Sub Main()
		End Sub

		'<snippet1>
		Public Function CreateClientBinding() As Binding
			'<snippet5>
			'<snippet4>
			'<snippet3>
			'<snippet2>
			Dim abe As AsymmetricSecurityBindingElement = CType(SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10), AsymmetricSecurityBindingElement)
			'</snippet2>

			abe.SetKeyDerivation(False)
			'</snippet3>

			Dim istp As X509SecurityTokenParameters = TryCast(abe.InitiatorTokenParameters, X509SecurityTokenParameters)
			If istp IsNot Nothing Then
				istp.X509ReferenceStyle = X509KeyIdentifierClauseType.IssuerSerial
			End If
			'</snippet4>
			Dim rstp As X509SecurityTokenParameters = TryCast(abe.RecipientTokenParameters, X509SecurityTokenParameters)
			If rstp IsNot Nothing Then
				rstp.X509ReferenceStyle = X509KeyIdentifierClauseType.IssuerSerial
			End If
			'</snippet5>

			Dim transport As New HttpTransportBindingElement()

			Return New CustomBinding(abe, transport)
		End Function
		'</snippet1>
	End Class
End Namespace