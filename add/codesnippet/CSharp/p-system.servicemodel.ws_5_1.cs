	// This method creates a WSFederationHttpBinding.
	public static WSFederationHttpBinding 
        CreateWSFederationHttpBinding(bool isClient)
	{
	  // Create an instance of the WSFederationHttpBinding.
	  WSFederationHttpBinding b = new WSFederationHttpBinding();

	  // Set the security mode to Message.
	  b.Security.Mode = WSFederationHttpSecurityMode.Message;