---
title: "How to: Change the Cryptographic Provider for an X.509 Certificate&#39;s Private Key"
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
  - "cryptographic provider [WCF], changing"
  - "cryptographic provider [WCF]"
ms.assetid: b4254406-272e-4774-bd61-27e39bbb6c12
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Change the Cryptographic Provider for an X.509 Certificate&#39;s Private Key
This topic shows how to change the cryptographic provider used to provide an X.509 certificate's private key and how to integrate the provider into the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] security framework. For more information about using certificates, see [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security framework provides a way to introduce new security token types as described in [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md). It is also possible to use a custom token to replace existing system-provided token types.  
  
 In this topic, the system-provided X.509 security token is replaced by a custom X.509 token that provides a different implementation for the certificate private key. This is useful in scenarios where the actual private key is provided by a different cryptographic provider than the default Windows cryptographic provider. One example of an alternative cryptographic provider is a hardware security module that performs all private key related cryptographic operations, and does not store the private keys in memory, thus improving security of the system.  
  
 The following example is for demonstration purposes only. It does not replace the default Windows cryptographic provider, but it shows where such a provider could be integrated.  
  
## Procedures  
 Every security token that has an associated security key or keys must implement the <xref:System.IdentityModel.Tokens.SecurityToken.SecurityKeys%2A> property, which returns a collection of keys from the security token instance. If the token is an X.509 security token, the collection contains a single instance of the <xref:System.IdentityModel.Tokens.X509AsymmetricSecurityKey> class that represents both public and private keys associated with the certificate. To replace the default cryptographic provider used to provide the certificate's keys, create a new implementation of this class.  
  
#### To create a custom X.509 asymmetric key  
  
1.  Define a new class derived from the <xref:System.IdentityModel.Tokens.X509AsymmetricSecurityKey> class.  
  
2.  Override the <xref:System.IdentityModel.Tokens.SecurityKey.KeySize%2A> read-only property. This property returns the actual key size of the certificate's public/private key pair.  
  
3.  Override the <xref:System.IdentityModel.Tokens.SecurityKey.DecryptKey%2A> method. This method is called by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security framework to decrypt a symmetric key with the certificate's private key. (The key was previously encrypted with the certificate's public key.)  
  
4.  Override the <xref:System.IdentityModel.Tokens.AsymmetricSecurityKey.GetAsymmetricAlgorithm%2A> method. This method is called by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security framework to obtain an instance of the <xref:System.Security.Cryptography.AsymmetricAlgorithm> class that represents the cryptographic provider for either the certificate's private or public key, depending on the parameters passed to the method.  
  
5.  Optional. Override the <xref:System.IdentityModel.Tokens.AsymmetricSecurityKey.GetHashAlgorithmForSignature%2A> method. Override this method if a different implementation of the <xref:System.Security.Cryptography.HashAlgorithm> class is required.  
  
6.  Override the <xref:System.IdentityModel.Tokens.AsymmetricSecurityKey.GetSignatureFormatter%2A> method. This method returns an instance of the <xref:System.Security.Cryptography.AsymmetricSignatureFormatter> class that is associated with the certificate's private key.  
  
7.  Override the <xref:System.IdentityModel.Tokens.SecurityKey.IsSupportedAlgorithm%2A> method. This method is used to indicate whether a particular cryptographic algorithm is supported by the security key implementation.  
  
     [!code-csharp[c_CustomX509Token#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customx509token/cs/source.cs#1)]
     [!code-vb[c_CustomX509Token#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customx509token/vb/source.vb#1)]  
  
 The following procedure shows how to integrate the custom X.509 asymmetric security key implementation created in the preceding procedure with the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security framework in order to replace the system-provided X.509 security token.  
  
#### To replace the system-provided X.509 security token with a custom X.509 asymmetric security key token  
  
1.  Create a custom X.509 security token that returns the custom X.509 asymmetric security key instead of the system-provided security key, as shown in the following example. For more information about custom security tokens, see [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md).  
  
     [!code-csharp[c_CustomX509Token#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customx509token/cs/source.cs#2)]
     [!code-vb[c_CustomX509Token#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customx509token/vb/source.vb#2)]  
  
2.  Create a custom security token provider that returns a custom X.509 security token, as shown in the example. For more information about custom security token providers, see [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md).  
  
     [!code-csharp[c_CustomX509Token#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customx509token/cs/source.cs#3)]
     [!code-vb[c_CustomX509Token#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customx509token/vb/source.vb#3)]  
  
3.  If the custom security key needs to be used on the initiator side, create a custom client security token manager and custom client credentials classes, as shown in the following example. For more information about custom client credentials and client security token managers, see [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md).  
  
     [!code-csharp[c_CustomX509Token#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customx509token/cs/source.cs#4)]
     [!code-vb[c_CustomX509Token#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customx509token/vb/source.vb#4)]  
  
     [!code-csharp[c_CustomX509Token#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customx509token/cs/source.cs#6)]
     [!code-vb[c_CustomX509Token#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customx509token/vb/source.vb#6)]  
  
4.  If the custom security key needs to be used on the recipient side, create a custom service security token manager and custom service credentials, as shown in the following example. For more information about custom service credentials and service security token managers, see [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md).  
  
     [!code-csharp[c_CustomX509Token#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customx509token/cs/source.cs#5)]
     [!code-vb[c_CustomX509Token#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customx509token/vb/source.vb#5)]  
  
     [!code-csharp[c_CustomX509Token#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customx509token/cs/source.cs#7)]
     [!code-vb[c_CustomX509Token#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customx509token/vb/source.vb#7)]  
  
## See Also  
 <xref:System.IdentityModel.Tokens.X509AsymmetricSecurityKey>  
 <xref:System.IdentityModel.Tokens.AsymmetricSecurityKey>  
 <xref:System.IdentityModel.Tokens.SecurityKey>  
 <xref:System.Security.Cryptography.AsymmetricAlgorithm>  
 <xref:System.Security.Cryptography.HashAlgorithm>  
 <xref:System.Security.Cryptography.AsymmetricSignatureFormatter>  
 [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md)  
 [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md)  
 [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md)  
 [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md)  
 [Security Architecture](http://msdn.microsoft.com/library/16593476-d36a-408d-808c-ae6fd483e28f)
