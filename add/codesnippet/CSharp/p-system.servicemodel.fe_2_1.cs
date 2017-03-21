	// This method creates a WSFederationHttpBinding.
	public static WSFederationHttpBinding 
        CreateWSFederationHttpBinding(bool isClient)
	{
	  // Create an instance of the WSFederationHttpBinding.
	  WSFederationHttpBinding b = new WSFederationHttpBinding();

	  // Set the security mode to Message.
	  b.Security.Mode = WSFederationHttpSecurityMode.Message;
	  
	  // Set the Algorithm Suite to Basic256Rsa15.
	  b.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15;

	  // Set NegotiateServiceCredential to true.
	  b.Security.Message.NegotiateServiceCredential = true;

	  // Set IssuedKeyType to Symmetric.
	  b.Security.Message.IssuedKeyType = SecurityKeyType.SymmetricKey;

	  // Set IssuedTokenType to SAML 1.1
	  b.Security.Message.IssuedTokenType = 
          "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#samlv1.1";