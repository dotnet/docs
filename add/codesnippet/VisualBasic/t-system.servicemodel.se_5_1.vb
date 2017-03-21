			Dim abe As AsymmetricSecurityBindingElement = CType(SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10), AsymmetricSecurityBindingElement)

			abe.SetKeyDerivation(False)

			Dim istp As X509SecurityTokenParameters = TryCast(abe.InitiatorTokenParameters, X509SecurityTokenParameters)
			If istp IsNot Nothing Then
				istp.X509ReferenceStyle = X509KeyIdentifierClauseType.IssuerSerial
			End If