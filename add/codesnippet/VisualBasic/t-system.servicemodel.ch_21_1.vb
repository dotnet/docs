		Public Function CreateClientBinding() As Binding
			Dim abe As AsymmetricSecurityBindingElement = CType(SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10), AsymmetricSecurityBindingElement)

			abe.SetKeyDerivation(False)

			Dim istp As X509SecurityTokenParameters = TryCast(abe.InitiatorTokenParameters, X509SecurityTokenParameters)
			If istp IsNot Nothing Then
				istp.X509ReferenceStyle = X509KeyIdentifierClauseType.IssuerSerial
			End If
			Dim rstp As X509SecurityTokenParameters = TryCast(abe.RecipientTokenParameters, X509SecurityTokenParameters)
			If rstp IsNot Nothing Then
				rstp.X509ReferenceStyle = X509KeyIdentifierClauseType.IssuerSerial
			End If

			Dim transport As New HttpTransportBindingElement()

			Return New CustomBinding(abe, transport)
		End Function