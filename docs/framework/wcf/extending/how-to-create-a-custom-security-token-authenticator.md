---
title: "How to: Create a Custom Security Token Authenticator"
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
  - "WCF, authentication"
ms.assetid: 10e245f7-d31e-42e7-82a2-d5780325d372
caps.latest.revision: 12
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Create a Custom Security Token Authenticator
This topic shows how to create a custom security token authenticator and how to integrate it with a custom security token manager. A security token authenticator validates the content of a security token provided with an incoming message. If the validation succeeds, the authenticator returns a collection of <xref:System.IdentityModel.Policy.IAuthorizationPolicy> instances that, when evaluated, returns a set of claims.  
  
 To use a custom security token authenticator in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], you must first create custom credentials and security token manager implementations. For more information about creating custom credentials and a security token manager, see [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md). For more information about credentials, security token manager, and provider and authenticator classes, see [Security Architecture](http://msdn.microsoft.com/library/16593476-d36a-408d-808c-ae6fd483e28f).  
  
## Procedures  
  
#### To create a custom security token authenticator  
  
1.  Define a new class derived from the <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator> class.  
  
2.  Override the <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator.CanValidateTokenCore%2A> method. The method returns `true` or `false` depending on whether the custom authenticator can validate the incoming token type or not.  
  
3.  Override the <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator.ValidateTokenCore%2A> method. This method needs to validate the token contents appropriately. If the token passes the validation step, it returns a collection of <xref:System.IdentityModel.Policy.IAuthorizationPolicy> instances. The following example uses a custom authorization policy implementation that will be created in the next procedure.  
  
     [!code-csharp[C_CustomTokenAuthenticator#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtokenauthenticator/cs/source.cs#1)]
     [!code-vb[C_CustomTokenAuthenticator#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtokenauthenticator/vb/source.vb#1)]  
  
 The previous code returns a collection of authorization policies in the <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator.CanValidateToken%28System.IdentityModel.Tokens.SecurityToken%29> method. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not provide a public implementation of this interface. The following procedure shows how to do so for your own requirements.  
  
#### To create a custom authorization policy  
  
1.  Define a new class implementing the <xref:System.IdentityModel.Policy.IAuthorizationPolicy> interface.  
  
2.  Implement the <xref:System.IdentityModel.Policy.IAuthorizationComponent.Id%2A> read-only property. One way to implement this property is to generate a globally unique identifier (GUID) in the class constructor and return it every time the value for this property is requested.  
  
3.  Implement the <xref:System.IdentityModel.Policy.IAuthorizationPolicy.Issuer%2A> read-only property. This property needs to return an issuer of the claim sets that are obtained from the token. This issuer should correspond to the issuer of the token or an authority that is responsible for validating the token contents. The following example uses the issuer claim that passed to this class from the custom security token authenticator created in the previous procedure. The custom security token authenticator uses the system-provided claim set (returned by the <xref:System.IdentityModel.Claims.ClaimSet.System%2A> property) to represent the issuer of the username token.  
  
4.  Implement the <xref:System.IdentityModel.Policy.IAuthorizationPolicy.Evaluate%2A> method. This method populates an instance of the <xref:System.IdentityModel.Policy.EvaluationContext> class (passed in as an argument) with claims that are based on the incoming security token content. The method returns `true` when it is done with the evaluation. In cases when the implementation relies on the presence of other authorization policies that provide additional information to the evaluation context, this method can return `false` if the required information is not present yet in the evaluation context. In that case, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] will call the method again after evaluating all other authorization policies generated for the incoming message if at least one of those authorization policies modified the evaluation context.  
  
     [!code-csharp[c_CustomTokenAuthenticator#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtokenauthenticator/cs/source.cs#2)]
     [!code-vb[c_CustomTokenAuthenticator#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtokenauthenticator/vb/source.vb#2)]  
  
 [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md) describes how to create custom credentials and a custom security token manager. To use the custom security token authenticator created here, an implementation of the security token manager is modified to return the custom authenticator from the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenAuthenticator%2A> method. The method returns an authenticator when an appropriate security token requirement is passed in.  
  
#### To integrate a custom security token authenticator with a custom security token manager  
  
1.  Override the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenAuthenticator%2A> method in your custom security token manager implementation.  
  
2.  Add logic to the method to enable it to return your custom security token authenticator based on the <xref:System.IdentityModel.Selectors.SecurityTokenRequirement> parameter. The following example returns a custom security token authenticator if the token requirements token type is a user name (represented by the <xref:System.IdentityModel.Tokens.SecurityTokenTypes.UserName%2A> property) and the message direction for which the security token authenticator is being requested is input (represented by the <xref:System.ServiceModel.Description.MessageDirection.Input> field).  
  
     [!code-csharp[c_CustomTokenAuthenticator#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtokenauthenticator/cs/source.cs#3)]
     [!code-vb[c_CustomTokenAuthenticator#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtokenauthenticator/vb/source.vb#3)]  
  
## See Also  
 <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator>  
 <xref:System.IdentityModel.Selectors.SecurityTokenRequirement>  
 <xref:System.IdentityModel.Selectors.SecurityTokenManager>  
 <xref:System.IdentityModel.Tokens.UserNameSecurityToken>  
 [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md)  
 [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md)  
 [Security Architecture](http://msdn.microsoft.com/library/16593476-d36a-408d-808c-ae6fd483e28f)
