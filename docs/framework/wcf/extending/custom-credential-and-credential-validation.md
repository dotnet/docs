---
title: "Custom Credential and Credential Validation"
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
  - "credentials [WCF], custom"
  - "credentials [WCF]"
  - "custom credentials [WCF]"
  - "credential validation [WCF]"
  - "credentials [WCF], validation"
ms.assetid: da831bec-e281-4d44-b343-437b5eef688e
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Credential and Credential Validation
Security in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is based on the exchange of credentials between services and clients. Most security scenarios can be satisfied using common credential types, such as Windows (Kerberos), username and passwords, and certificates. However, if a new type of credential is required, the topics in this section explain how to handle and validate new types.  
  
## In This Section  
 [How to: Create a Service that Employs a Custom Certificate Validator](../../../../docs/framework/wcf/extending/how-to-create-a-service-that-employs-a-custom-certificate-validator.md)  
 Explains how to customize [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] validation by inheriting from the <xref:System.IdentityModel.Selectors.X509CertificateValidator> class.  
  
 [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md)  
 Demonstrates how to extend the <xref:System.ServiceModel.Description.ClientCredentials> and <xref:System.ServiceModel.Description.ServiceCredentials> classes to accommodate new credential types. This is first in a series of topics that enable creation of custom credential types.  
  
 [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md)  
 Explains how to create a security token provider to handle new credential types and return new tokens for the credential. This is the second topic in the series.  
  
 [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md)  
 Explains how to create a custom authenticator to authenticate a new credential type. This is the third topic in the series.  
  
## Reference  
 <xref:System.ServiceModel.Security>  
  
 <xref:System.IdentityModel.Claims>  
  
 <xref:System.IdentityModel.Policy>  
  
 <xref:System.IdentityModel.Tokens>  
  
 <xref:System.IdentityModel.Selectors>  
  
 <xref:System.IdentityModel.Selectors.X509CertificateValidator>  
  
 <xref:System.ServiceModel.Description.ClientCredentials>  
  
 <xref:System.ServiceModel.Description.ServiceCredentials>  
  
## Related Sections  
 [Authentication](../../../../docs/framework/wcf/feature-details/authentication-in-wcf.md)  
  
 [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
  
 [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md)  
  
## See Also  
 [Security](../../../../docs/framework/wcf/feature-details/security.md)
