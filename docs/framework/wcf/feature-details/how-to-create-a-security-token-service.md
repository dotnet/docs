---
title: "How to: Create a Security Token Service"
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
ms.assetid: 98e82101-4cff-4bb8-a220-f7abed3556e5
caps.latest.revision: 12
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Create a Security Token Service
A security token service implements the protocol defined in the WS-Trust specification. This protocol defines message formats and message exchange patterns for issuing, renewing, canceling, and validating security tokens. A given security token service provides one or more of these capabilities. This topic looks at the most common scenario: implementing token issuance.  
  
## Issuing Tokens  
 WS-Trust defines message formats, based on the `RequestSecurityToken` XML Schema definition language (XSD) schema element, and `RequestSecurityTokenResponse` XSD schema element for performing token issuance. In addition, it defines the associated Action Uniform Resource Identifiers (URIs). The action URI associated with the `RequestSecurityToken` message is http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue. The action URI associated with the `RequestSecurityTokenResponse` message is   http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue.  
  
### Request Message Structure  
 The issue request message structure typically consists of the following items:  
  
-   A request type URI with a value of    http://schemas.xmlsoap.org/ws/2005/02/trust/Issue.  
  
-   A token type URI. For Security Assertions Markup Language (SAML) 1.1 tokens, the value of this URI is http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1.  
  
-   A key size value that indicates the number of bits in the key to be associated with the issued token.  
  
-   A key type URI. For symmetric keys, the value of this URI is http://schemas.xmlsoap.org/ws/2005/02/trust/SymmetricKey.  
  
 In addition, a couple of other items might be present:  
  
-   Key material provided by the client.  
  
-   Scope information that indicates the target service that the issued token will be used with.  
  
 The security token service uses the information in the issue request message when it constructs the Issue Response message.  
  
## Response Message Structure  
 The issue response message structure typically consists of the following items;  
  
-   The issued security token, for example, a SAML 1.1 assertion.  
  
-   A proof token associated with the security token. For symmetric keys, this is often an encrypted form of the key material.  
  
-   References to the issued security token. Typically, the security token service returns a reference that can be used when the issued token appears in a subsequent message sent by the client and another that can be used when the token is not present in subsequent messages.  
  
 In addition, a couple of other items might be present:  
  
-   Key material provided by the security token service.  
  
-   The algorithm needed to compute the shared key.  
  
-   Lifetime information for the issued token.  
  
## Processing Request Messages  
 The security token service processes the issue request by examining the various pieces of the request message and ensuring that it can issue a token that satisfies the request. The security token service must determine the following before it constructs the token to be issued:  
  
-   The request really is a request for a token to be issued.  
  
-   The security token service supports the requested token type.  
  
-   The requester is authorized to make the request.  
  
-   The security token service can meet the requester's expectations with respect to key material.  
  
 Two vital parts of constructing a token are determining what key to sign the token with and what key to encrypt the shared key with. The token needs to be signed so that when the client presents the token to the target service, that service can determine that the token was issued by a security token service that it trusts. The key material needs to be encrypted in such a way that the target service can decrypt that key material.  
  
 Signing a SAML assertion involves creating a <xref:System.IdentityModel.Tokens.SigningCredentials> instance. The constructor for this class takes the following:  
  
-   A <xref:System.IdentityModel.Tokens.SecurityKey> for the key to use to sign the SAML assertion.  
  
-   A string identifying the signature algorithm to use.  
  
-   A string identifying the digest algorithm to use.  
  
-   Optionally, a <xref:System.IdentityModel.Tokens.SecurityKeyIdentifier> that identifies the key to use to sign the assertion.  
  
 [!code-csharp[c_CreateSTS#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#1)]
 [!code-vb[c_CreateSTS#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#1)]  
  
 Encrypting the shared key involves taking the key material and encrypting it with a key that the target service can use to decrypt the shared key. Typically, the public key of the target service is used.  
  
 [!code-csharp[c_CreateSTS#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#2)]
 [!code-vb[c_CreateSTS#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#2)]  
  
 In addition, a <xref:System.IdentityModel.Tokens.SecurityKeyIdentifier> for the encrypted key is needed.  
  
 [!code-csharp[c_CreateSTS#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#3)]
 [!code-vb[c_CreateSTS#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#3)]  
  
 This <xref:System.IdentityModel.Tokens.SecurityKeyIdentifier> is then used to create a `SamlSubject` as part of the `SamlToken`.  
  
 [!code-csharp[c_CreateSTS#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#4)]
 [!code-vb[c_CreateSTS#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#4)]  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Federation Sample](../../../../docs/framework/wcf/samples/federation-sample.md).  
  
## Creating Response Messages  
 Once the security token service processes the issue request and constructs the token to be issued along with the proof key, the response message needs to be constructed, including at least the requested token, the proof token, and the issued token references. The issued token is typically a <xref:System.IdentityModel.Tokens.SamlSecurityToken> created from the <xref:System.IdentityModel.Tokens.SamlAssertion>, as shown in the following example.  
  
 [!code-csharp[c_CreateSTS#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#5)]
 [!code-vb[c_CreateSTS#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#5)]  
  
 In the case where the security token service provides the shared key material, the proof token is constructed by creating a <xref:System.ServiceModel.Security.Tokens.BinarySecretSecurityToken>.  
  
 [!code-csharp[c_CreateSTS#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#6)]
 [!code-vb[c_CreateSTS#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#6)]  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to construct the proof token when the client and the security token service both provide key material for the shared key, see [Federation Sample](../../../../docs/framework/wcf/samples/federation-sample.md).  
  
 The issued token references are constructed by creating instances of the <xref:System.IdentityModel.Tokens.SecurityKeyIdentifierClause> class.  
  
 [!code-csharp[c_CreateSTS#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#7)]
 [!code-vb[c_CreateSTS#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#7)]  
  
 These various values are then serialized into the response message returned to the client.  
  
## Example  
 For full code for a security token service, see [Federation Sample](../../../../docs/framework/wcf/samples/federation-sample.md).  
  
## See Also  
 <xref:System.IdentityModel.Tokens.SigningCredentials>  
 <xref:System.IdentityModel.Tokens.SecurityKey>  
 <xref:System.IdentityModel.Tokens.SecurityKeyIdentifier>  
 <xref:System.IdentityModel.Tokens.SamlSecurityToken>  
 <xref:System.IdentityModel.Tokens.SamlAssertion>  
 <xref:System.ServiceModel.Security.Tokens.BinarySecretSecurityToken>  
 <xref:System.IdentityModel.Tokens.SecurityKeyIdentifierClause>  
 [Federation Sample](../../../../docs/framework/wcf/samples/federation-sample.md)
