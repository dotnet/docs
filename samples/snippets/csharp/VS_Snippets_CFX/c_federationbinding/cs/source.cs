//<snippet0>
//<snippet1>
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Security.Permissions;
namespace Samples
{
  //</snippet1>
  public sealed class CustomBindingCreator
  {
	//<snippet2>
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
	  	
	  // Extract the STS certificate from the certificate store.
	  X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser);
	  store.Open(OpenFlags.ReadOnly);
	  X509Certificate2Collection certs = store.Certificates.Find(
          X509FindType.FindByThumbprint, "0000000000000000000000000000000000000000", false);
	  store.Close();
	
	  // Create an EndpointIdentity from the STS certificate.
	  EndpointIdentity identity = EndpointIdentity.CreateX509CertificateIdentity ( certs[0] );
	
	  // Set the IssuerAddress using the address of the STS and the previously created
      // EndpointIdentity.
	  b.Security.Message.IssuerAddress =
          new EndpointAddress(new Uri("http://localhost:8000/sts/x509"), identity);

	  // Set the IssuerBinding to a WSHttpBinding loaded from configuration.
      // The IssuerBinding is only used on federated clients.
      if (isClient)
      {
          b.Security.Message.IssuerBinding = new WSHttpBinding("Issuer");
      }

      // Set the IssuerMetadataAddress using the metadata address of the STS and the
      // previously created EndpointIdentity. The IssuerMetadataAddress is only used
      // on federated services.
      else
      {
          b.Security.Message.IssuerMetadataAddress =
              new EndpointAddress(new Uri("http://localhost:8001/sts/mex"), identity);
      }
	  // Create a ClaimTypeRequirement.
	  ClaimTypeRequirement ctr = new ClaimTypeRequirement
          ("http://example.org/claim/c1", false);

	  // Add the ClaimTypeRequirement to ClaimTypeRequirements
	  b.Security.Message.ClaimTypeRequirements.Add(ctr);
	
	  // Return the created binding
	  return b;
	}
	//</snippet2>
	
	// It is a good practice to create a private constructor for a class that only
	// defines static methods.
	private CustomBindingCreator() { }
  }
  //</snippet0>
}
