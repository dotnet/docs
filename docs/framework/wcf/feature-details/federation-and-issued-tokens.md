---
title: "Federation and Issued Tokens"
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
  - "WCF, federation"
  - "issued tokens [WCF]"
  - "federation [WCF], issued tokens"
ms.assetid: 4c31ee7d-a820-4067-8b84-a83049021bb6
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Federation and Issued Tokens
With [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], you can create clients that communicate securely with services that implement the WS-Federation and WS-Trust specifications. The specifications use XML, SOAP, and Web Services Description Language (WSDL) to provide mechanisms that enable authentication and authorization across different trust realms.  
  
## In This Section  
 [Federation](../../../../docs/framework/wcf/feature-details/federation.md)  
 Provides an overview of federation.  
  
 [Federation and Trust](../../../../docs/framework/wcf/feature-details/federation-and-trust.md)  
 Lists the design issues to be aware of when creating federated services or clients.  
  
 [How to: Create a Federated Client](../../../../docs/framework/wcf/feature-details/how-to-create-a-federated-client.md)  
 Describes the basics of creating a federated client with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 [How to: Configure Credentials on a Federation Service](../../../../docs/framework/wcf/feature-details/how-to-configure-credentials-on-a-federation-service.md)  
 Describes the steps of creating a federated service.  
  
 [How to: Create a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-create-a-wsfederationhttpbinding.md)  
 Describes how to configure clients and services that use the `WSFederationHttpBinding`.  
  
 [How to: Create a Security Token Service](../../../../docs/framework/wcf/feature-details/how-to-create-a-security-token-service.md)  
 Describes the steps of creating a security token service.  
  
 [Security Assertions Markup Language (SAML) Tokens and Claims](../../../../docs/framework/wcf/feature-details/saml-tokens-and-claims.md)  
 Describes Security Assertions Markup Language (SAML) tokens, which are extensible and enable you to create rich claim types.  
  
 [How to: Configure a Local Issuer](../../../../docs/framework/wcf/feature-details/how-to-configure-a-local-issuer.md)  
 Describes how to create a local issuer of security tokens.  
  
 [How to: Disable Secure Sessions on a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-disable-secure-sessions-on-a-wsfederationhttpbinding.md)  
 Describes how to disable secure sessions on a `WSFederationHttpBinding`. Disabling secure sessions is necessary when creating a Web farm that requires a session for each client.  
  
## Reference  
 <xref:System.IdentityModel.Claims>  
  
 <xref:System.ServiceModel.ServiceAuthorizationManager>  
  
 <xref:System.IdentityModel.Tokens.SamlSecurityToken>  
  
 <xref:System.ServiceModel.Security.IssuedTokenClientCredential>  
  
 <xref:System.ServiceModel.Security.IssuedTokenServiceCredential>  
  
 <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenParameters>  
  
 <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenProvider>  
  
 <xref:System.ServiceModel.WSFederationHttpBinding>  
  
## See Also  
 [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md)  
 [Custom Tokens](../../../../docs/framework/wcf/extending/custom-tokens.md)  
 [Security Model for Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
