---
description: "Learn more about: Extending Security"
title: "Extending Security"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "security [WCF], extending"
ms.assetid: a015a040-9fdf-4147-9ea9-f83b570be1d4
---
# Extending Security

To accommodate new claim types and custom tokens, you can extend the security infrastructure of Windows Communication Foundation (WCF). The topics in this section show you how this is done.  
  
## In This Section  
  
 [Custom Credential and Credential Validation](custom-credential-and-credential-validation.md)  
 Explains how the Identity Model is used when validating custom credentials.  
  
 [Custom Tokens](custom-tokens.md)  
 Issued tokens from a Security Token Service (STS) are typically SAML tokens. This topic explains how to create a custom token type.  
  
 [Custom Authorization](custom-authorization.md)  
 Explains how to implement custom authorization.  
  
 [Overriding the Identity of a Service for Authentication](overriding-the-identity-of-a-service-for-authentication.md)  
 Describes how to override the identity of a service for authentication.  
  
 [How to: Create a Custom Client Identity Verifier](how-to-create-a-custom-client-identity-verifier.md)  
 Demonstrates how to validate a custom endpoint identity.  
  
 [How to: Use Separate X.509 Certificates for Signing and Encryption](how-to-use-separate-x-509-certificates-for-signing-and-encryption.md)  
 Messages are typically signed and encrypted with a single certificate. This topic explains how two certificates can be used, when required.  
  
 [How to: Change the Cryptographic Provider for an X.509 Certificate's Private Key](change-cryptographic-provider-x509-certificate-private-key.md)  
 Explains how to change the cryptographic provider used to provide an X.509 certificate's private key and how to integrate the provider into the Windows Communication Foundation (WCF) framework.  
  
## Reference  

 <xref:System.ServiceModel.ServiceAuthorizationManager>  
  
 <xref:System.ServiceModel.Security>  
  
 <xref:System.IdentityModel.Claims>  
  
 <xref:System.IdentityModel.Policy>  
  
 <xref:System.IdentityModel.Tokens>  
  
 <xref:System.IdentityModel.Selectors>  
  
## Related Sections  

 [Security](../feature-details/security.md)  
  
 [Basic WCF Programming](../basic-wcf-programming.md)  
  
## See also

- [Security Overview](../feature-details/security-overview.md)
