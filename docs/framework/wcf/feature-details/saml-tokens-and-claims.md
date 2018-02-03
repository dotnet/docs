---
title: "SAML Tokens and Claims"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF, federation"
  - "federation"
  - "issued tokens"
  - "SAML token"
ms.assetid: 930b6e34-9eab-4e95-826c-4e06659bb977
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SAML Tokens and Claims
Security Assertions Markup Language (SAML) *tokens* are XML representations of claims. By default, SAML tokens [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses in federated security scenarios are *issued tokens*.  
  
 SAML tokens carry statements that are sets of claims made by one entity about another entity. For example, in federated security scenarios, the statements are made by a security token service about a user in the system. The security token service signs the SAML token to indicate the veracity of the statements contained in the token. In addition, the SAML token is associated with cryptographic key material that the user of the SAML token proves knowledge of. This proof satisfies the relying party that the SAML token was, in fact, issued to that user. For example, in a typical scenario:  
  
1.  A client requests a SAML token from a security token service, authenticating to that security token service by using Windows credentials.  
  
2.  The security token service issues a SAML token to the client. The SAML token is signed with a certificate associated with the security token service and contains a proof key encrypted for the target service.  
  
3.  The client also receives a copy of the *proof key*. The client then presents the SAML token to the application service (the *relying party*) and signs the message with that proof key.  
  
4.  The signature over the SAML token tells the relying party that the security token service issued the token. The message signature created with the proof key tells the relying party that the token was issued to the client.  
  
## From Claims to SamlAttributes  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], statements in SAML tokens are modeled as <xref:System.IdentityModel.Tokens.SamlAttribute> objects, which can be populated directly from <xref:System.IdentityModel.Claims.Claim> objects, provided the <xref:System.IdentityModel.Claims.Claim> object has a <xref:System.IdentityModel.Claims.Claim.Right%2A> property of <xref:System.IdentityModel.Claims.Rights.PossessProperty%2A> and the <xref:System.IdentityModel.Claims.Claim.Resource%2A> property is of type <xref:System.String>. For example:  
  
 [!code-csharp[c_CreateSTS#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#8)]
 [!code-vb[c_CreateSTS#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#8)]  
  
> [!NOTE]
>  When SAML tokens are serialized in messages, either when they are issued by a security token service or when they are presented by clients to services as part of authentication, the maximum message size quota must be sufficiently large to accommodate the SAML token and the other message parts. In normal cases, the default message size quotas are sufficient. However, in cases where a SAML token is large because it contains hundreds of claims, you may need to increase the quotas to accommodate the serialized token. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Security Considerations for Data](../../../../docs/framework/wcf/feature-details/security-considerations-for-data.md).  
  
## From SamlAttributes to Claims  
 When SAML tokens are received in messages, the various statements in the SAML token are turned into <xref:System.IdentityModel.Policy.IAuthorizationPolicy> objects that are placed into the <xref:System.IdentityModel.Policy.AuthorizationContext>. The claims from each SAML statement are returned by the <xref:System.IdentityModel.Policy.AuthorizationContext.ClaimSets%2A> property of the <xref:System.IdentityModel.Policy.AuthorizationContext> and can be examined to determine whether to authenticate and authorize the user.  
  
## See Also  
 <xref:System.IdentityModel.Policy.AuthorizationContext>  
 <xref:System.IdentityModel.Policy.IAuthorizationPolicy>  
 <xref:System.IdentityModel.Claims.ClaimSet>  
 [Federation](../../../../docs/framework/wcf/feature-details/federation.md)  
 [How to: Create a Federated Client](../../../../docs/framework/wcf/feature-details/how-to-create-a-federated-client.md)  
 [How to: Configure Credentials on a Federation Service](../../../../docs/framework/wcf/feature-details/how-to-configure-credentials-on-a-federation-service.md)  
 [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md)  
 [Claims and Tokens](../../../../docs/framework/wcf/feature-details/claims-and-tokens.md)  
 [Claim Creation and Resource Values](../../../../docs/framework/wcf/feature-details/claim-creation-and-resource-values.md)  
 [How to: Create a Custom Claim](../../../../docs/framework/wcf/extending/how-to-create-a-custom-claim.md)
