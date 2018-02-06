---
title: "Extending Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security [WCF], extending"
ms.assetid: a015a040-9fdf-4147-9ea9-f83b570be1d4
caps.latest.revision: 23
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Extending Security
To accommodate new claim types and custom tokens, you can extend the security infrastructure of [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. The topics in this section show you how this is done.  
  
## In This Section  
 [Security Architecture](http://msdn.microsoft.com/library/16593476-d36a-408d-808c-ae6fd483e28f)  
 Walks through the architecture of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security system.  
  
 [Custom Credential and Credential Validation](../../../../docs/framework/wcf/extending/custom-credential-and-credential-validation.md)  
 Explains how the Identity Model is used when validating custom credentials.  
  
 [Custom Tokens](../../../../docs/framework/wcf/extending/custom-tokens.md)  
 Issued tokens from a Security Token Service (STS) are typically SAML tokens. This topic explains how to create a custom token type.  
  
 [Custom Authorization](../../../../docs/framework/wcf/extending/custom-authorization.md)  
 Explains how to implement custom authorization.  
  
 [Overriding the Identity of a Service for Authentication](../../../../docs/framework/wcf/extending/overriding-the-identity-of-a-service-for-authentication.md)  
 Describes how to override the identity of a service for authentication.  
  
 [How to: Create a Custom Client Identity Verifier](../../../../docs/framework/wcf/extending/how-to-create-a-custom-client-identity-verifier.md)  
 Demonstrates how to validate a custom endpoint identity.  
  
 [How to: Use Separate X.509 Certificates for Signing and Encryption](../../../../docs/framework/wcf/extending/how-to-use-separate-x-509-certificates-for-signing-and-encryption.md)  
 Messages are typically signed and encrypted with a single certificate. This topic explains how two certificates can be used, when required.  
  
 [How to: Change the Cryptographic Provider for an X.509 Certificate's Private Key](../../../../docs/framework/wcf/extending/change-cryptographic-provider-x509-certificate-private-key.md)  
 Explains how to change the cryptographic provider used to provide an X.509 certificate's private key and how to integrate the provider into the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] framework.  
  
## Reference  
 <xref:System.ServiceModel.ServiceAuthorizationManager>  
  
 <xref:System.ServiceModel.Security>  
  
 <xref:System.IdentityModel.Claims>  
  
 <xref:System.IdentityModel.Policy>  
  
 <xref:System.IdentityModel.Tokens>  
  
 <xref:System.IdentityModel.Selectors>  
  
## Related Sections  
 [Security](../../../../docs/framework/wcf/feature-details/security.md)  
  
 [Basic WCF Programming](../../../../docs/framework/wcf/basic-wcf-programming.md)  
  
## See Also  
 [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md)
