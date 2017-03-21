	// This method configures the IssuedTokenAuthentication property of a ServiceHost.
	public static void ConfigureIssuedTokenServiceCredentials( 
        ServiceHost sh, bool allowCardspaceTokens, IList<X509Certificate2> knownissuers, 
        X509CertificateValidationMode certMode, X509RevocationMode revocationMode, SamlSerializer ser )
	{
	  // Allow CardSpace tokens.
	  sh.Credentials.IssuedTokenAuthentication.AllowUntrustedRsaIssuers = allowCardspaceTokens;
	  
	  // Set up known issuer certificates.
	  foreach(X509Certificate2 cert in knownissuers)
		sh.Credentials.IssuedTokenAuthentication.KnownCertificates.Add ( cert );

	  // Set issuer certificate validation and revocation checking modes.
	  sh.Credentials.IssuedTokenAuthentication.CertificateValidationMode = 
          X509CertificateValidationMode.PeerOrChainTrust;
      sh.Credentials.IssuedTokenAuthentication.RevocationMode = X509RevocationMode.Online;
      sh.Credentials.IssuedTokenAuthentication.TrustedStoreLocation = StoreLocation.LocalMachine;

	  // Set the SamlSerializer, if one is specified.
	  if ( ser != null )
		sh.Credentials.IssuedTokenAuthentication.SamlSerializer = ser;
	}