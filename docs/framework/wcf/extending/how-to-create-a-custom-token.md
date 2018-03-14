---
title: "How to: Create a Custom Token"
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
  - "SecurityTokenParameters class"
  - "security [WCF], creating custom tokens"
  - "WSSecurityTokenSerializer class"
  - "SecurityToken class"
ms.assetid: 6d892973-1558-4115-a9e1-696777776125
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Custom Token
This topic shows how to create a custom security token using the <xref:System.IdentityModel.Tokens.SecurityToken> class, and how to integrate it with a custom security token provider and authenticator. For a complete code example see the [Custom Token](../../../../docs/framework/wcf/samples/custom-token.md) sample.  
  
 A *security token* is essentially an XML element that is used by the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] security framework to represent claims about a sender inside the SOAP message. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security provides various tokens for system-provided authentication modes. Examples include an X.509 certificate security token represented by the <xref:System.IdentityModel.Tokens.X509SecurityToken> class or a Username security token represented by the <xref:System.IdentityModel.Tokens.UserNameSecurityToken> class.  
  
 Sometimes an authentication mode or credential is not supported by the provided types. In that case, it is necessary to create a custom security token to provide an XML representation of the custom credential inside the SOAP message.  
  
 The following procedures show how to create a custom security token and how to integrate it with the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure. This topic creates a credit card token that is used to pass information about the client's credit card to the server.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom credentials and security token manager, see [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md).  
  
 See the <xref:System.IdentityModel.Tokens> namespace for more classes that represent security tokens.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] credentials, security token manager, and provider and authenticator classes, see [Security Architecture](http://msdn.microsoft.com/library/16593476-d36a-408d-808c-ae6fd483e28f).  
  
## Procedures  
 A client application must be provided with a way to specify credit card information for the security infrastructure. This information is made available to the application by a custom client credentials class. The first step is to create a class to represent the credit card information for custom client credentials.  
  
#### To create a class that represents credit card information inside client credentials  
  
1.  Define a new class that represents the credit card information for the application. The following example names the class `CreditCardInfo`.  
  
2.  Add appropriate properties to the class to allow an application set the necessary information required for the custom token. In this example, the class has three properties: `CardNumber`, `CardIssuer`, and `ExpirationDate`.  
  
     [!code-csharp[c_CustomToken#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#4)]
     [!code-vb[c_CustomToken#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#4)]  
  
 Next, a class that represents the custom security token must be created. This class is used by the security token provider, authenticator, and serializer classes to pass information about the security token to and from the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure.  
  
#### To create a custom security token class  
  
1.  Define a new class derived from the <xref:System.IdentityModel.Tokens.SecurityToken> class. This example creates a class named `CreditCardToken`.  
  
2.  Override the <xref:System.IdentityModel.Tokens.SecurityToken.Id%2A> property. This property is used to get the local identifier of the security token that is used to point to the security token XML representation from other elements inside the SOAP message. In this example, a token identifier can be either passed to it as a constructor parameter or a new random one is generated every time a security token instance is created.  
  
3.  Implement the <xref:System.IdentityModel.Tokens.SecurityToken.SecurityKeys%2A> property. This property returns a collection of security keys that the security token instance represents. Such keys can be used by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to sign or encrypt parts of the SOAP message. In this example, the credit card security token cannot contain any security keys; therefore, the implementation always returns an empty collection.  
  
4.  Override the <xref:System.IdentityModel.Tokens.SecurityToken.ValidFrom%2A> and <xref:System.IdentityModel.Tokens.SecurityToken.ValidTo%2A> properties. These properties are used by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to determine the validity of the security token instance. In this example, the credit card security token has only an expiration date, so the `ValidFrom` property returns a <xref:System.DateTime> that represents the date and time of the instance creation.  
  
     [!code-csharp[c_CustomToken#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#1)]
     [!code-vb[c_CustomToken#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#1)]  
  
 When a new security token type is created, it requires an implementation of the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters> class. The implementation is used in the security binding element configuration to represent the new token type. The security token parameters class serves as a template that is used to match the actual security token instance to when a message is processed. The template provides additional properties that an application can use to specify criteria that the security token must match to be used or authenticated. The following example does not add any additional properties, so only the security token type is matched when the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure searches for a security token instance to use or to validate.  
  
#### To create a custom security token parameters class  
  
1.  Define a new class derived from the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters> class.  
  
2.  Implement the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters.CloneCore%2A> method. Copy all internal fields defined in your class, if any. This example does not define any additional fields.  
  
3.  Implement the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters.SupportsClientAuthentication%2A> read-only property. This property returns `true` if the security token type represented by this class can be used to authenticate a client to a service. In this example, the credit card security token can be used to authenticate a client to a service.  
  
4.  Implement the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters.SupportsServerAuthentication%2A> read-only property. This property returns `true` if the security token type represented by this class can be used to authenticate a service to a client. In this example, the credit card security token cannot be used to authenticate a service to a client.  
  
5.  Implement the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters.SupportsClientWindowsIdentity%2A> read-only property. This property returns `true` if the security token type represented by this class can be mapped to a Windows account. If so, the authentication result is represented by a <xref:System.Security.Principal.WindowsIdentity> class instance. In this example, the token cannot be mapped to a Windows account.  
  
6.  Implement the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters.CreateKeyIdentifierClause%28System.IdentityModel.Tokens.SecurityToken%2CSystem.ServiceModel.Security.Tokens.SecurityTokenReferenceStyle%29> method. This method is called by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security framework when it requires a reference to the security token instance represented by this security token parameters class. Both the actual security token instance and <xref:System.ServiceModel.Security.Tokens.SecurityTokenReferenceStyle> that specifies the type of the reference that is being requested are passed to this method as arguments. In this example, only internal references are supported by the credit card security token. The <xref:System.IdentityModel.Tokens.SecurityToken> class has functionality to create internal references; therefore, the implementation does not require additional code.  
  
7.  Implement the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters.InitializeSecurityTokenRequirement%28System.IdentityModel.Selectors.SecurityTokenRequirement%29> method. This method is called by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to convert the security token parameters class instance into an instance of the <xref:System.IdentityModel.Selectors.SecurityTokenRequirement> class. The result is used by security token providers to create the appropriate security token instance.  
  
     [!code-csharp[c_CustomToken#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#2)]
     [!code-vb[c_CustomToken#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#2)]  
  
 Security tokens are transmitted inside SOAP messages, which requires a translation mechanism between the in-memory security token representation and the on-the-wire representation. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses a security token serializer to accomplish this task. Every custom token must be accompanied by a custom security token serializer that can serialize and deserialize the custom security token from the SOAP message.  
  
> [!NOTE]
>  Derived keys are enabled by default. If you create a custom security token and use it as the primary token, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] derives a key from it. While doing so, it calls the custom security token serializer to write the <xref:System.IdentityModel.Tokens.SecurityKeyIdentifierClause> for the custom security token while serializing the `DerivedKeyToken` to the wire. On the receiving end, when deserializing the token off the wire, the `DerivedKeyToken` serializer expects a `SecurityTokenReference` element as the top-level child under itself. If the custom security token serializer did not add a `SecurityTokenReference` element while serializing its clause type, an exception is thrown.  
  
#### To create a custom security token serializer  
  
1.  Define a new class derived from the <xref:System.ServiceModel.Security.WSSecurityTokenSerializer> class.  
  
2.  Override the <xref:System.ServiceModel.Security.WSSecurityTokenSerializer.CanReadTokenCore%28System.Xml.XmlReader%29> method, which relies on an <xref:System.Xml.XmlReader> to read the XML stream. The method returns `true` if the serializer implementation can deserialize the security token based given its current element. In this example, this method checks whether the XML reader's current XML element has the correct element name and namespace. If it does not, it calls the base class implementation of this method to handle the XML element.  
  
3.  Override the <xref:System.ServiceModel.Security.WSSecurityTokenSerializer.ReadTokenCore%28System.Xml.XmlReader%2CSystem.IdentityModel.Selectors.SecurityTokenResolver%29> method. This method reads the XML content of the security token and constructs the appropriate in-memory representation for it. If it does not recognize the XML element on which the passed-in XML reader is standing, it calls the base class implementation to process the system-provided token types.  
  
4.  Override the <xref:System.ServiceModel.Security.WSSecurityTokenSerializer.CanWriteTokenCore%28System.IdentityModel.Tokens.SecurityToken%29> method. This method returns `true` if it can convert the in-memory token representation (passed in as an argument) to the XML representation. If it cannot convert, it calls the base class implementation.  
  
5.  Override the <xref:System.ServiceModel.Security.WSSecurityTokenSerializer.WriteTokenCore%28System.Xml.XmlWriter%2CSystem.IdentityModel.Tokens.SecurityToken%29> method. This method converts an in-memory security token representation into an XML representation. If the method cannot convert, it calls the base class implementation.  
  
     [!code-csharp[c_CustomToken#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#3)]
     [!code-vb[c_CustomToken#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#3)]  
  
 After completing the four previous procedures, integrate the custom security token with the security token provider, authenticator, manager, and client and service credentials.  
  
#### To integrate the custom security token with a security token provider  
  
1.  The security token provider creates, modifies (if necessary), and returns an instance of the token. To create a custom provider for the custom security token, create a class that inherits from the <xref:System.IdentityModel.Selectors.SecurityTokenProvider> class. The following example overrides the <xref:System.IdentityModel.Selectors.SecurityTokenProvider.GetTokenCore%2A> method to return an instance of the `CreditCardToken`. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security token providers, see [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md).  
  
     [!code-csharp[c_CustomToken#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#6)]
     [!code-vb[c_CustomToken#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#6)]  
  
#### To integrate the custom security token with a security token authenticator  
  
1.  The security token authenticator validates the content of the security token when it is extracted from the message. To create a custom authenticator for the custom security token, create a class that inherits from the <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator> class. The following example overrides the <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator.ValidateTokenCore%2A> method. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security token authenticators, see [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md).  
  
     [!code-csharp[c_CustomToken#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#7)]
     [!code-vb[c_CustomToken#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#7)]  
  
     [!code-csharp[c_CustomToken#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#12)]
     [!code-vb[c_CustomToken#12](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#12)]  
  
#### To integrate the custom security token with a security token manager  
  
1.  The security token manager creates the appropriate token provider, security authenticator, and token serializer instances. To create a custom token manager, create a class that inherits from the <xref:System.ServiceModel.ClientCredentialsSecurityTokenManager> class. The primary methods of the class use a <xref:System.IdentityModel.Selectors.SecurityTokenRequirement> to create the appropriate provider and client or service credentials. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security token managers, see [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md).  
  
     [!code-csharp[c_CustomToken#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#8)]
     [!code-vb[c_CustomToken#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#8)]  
  
     [!code-csharp[c_CustomToken#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#9)]
     [!code-vb[c_CustomToken#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#9)]  
  
#### To integrate the custom security token with custom client and service credentials  
  
1.  The custom client and service credentials must be added to provide an API for the application to allow specifying custom token information that is used by the custom security token infrastructure created previously to provide and authenticate the custom security token content. The following samples show how this can be done. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom client and service credentials, see [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md).  
  
     [!code-csharp[c_CustomToken#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#10)]
     [!code-vb[c_CustomToken#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#10)]  
  
     [!code-csharp[c_customToken#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#11)]
     [!code-vb[c_customToken#11](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#11)]  
  
 The custom security token parameters class created previously is used to tell the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security framework that a custom security token must be used when communicating with a service. The following procedure shows how this can be done.  
  
#### To integrate the custom security token with the binding  
  
1.  The custom security token parameters class must be specified in one of the token parameters collections that are exposed on the <xref:System.ServiceModel.Channels.SecurityBindingElement> class. The following example uses the collection returned by `SignedEncrypted`. The code adds the credit card custom token to every message sent from the client to the service with its content automatically signed and encrypted.  
  
     [!code-csharp[c_CustomToken#13](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customtoken/cs/source.cs#13)]
     [!code-vb[c_CustomToken#13](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customtoken/vb/source.vb#13)]  
  
 This topic shows the various pieces of code necessary to implement and use a custom token. To see a complete example of how all these pieces of code fit together see, [Custom Token](../../../../docs/framework/wcf/samples/custom-token.md).  
  
## See Also  
 <xref:System.IdentityModel.Tokens.SecurityToken>  
 <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters>  
 <xref:System.ServiceModel.Security.WSSecurityTokenSerializer>  
 <xref:System.IdentityModel.Selectors.SecurityTokenProvider>  
 <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator>  
 <xref:System.IdentityModel.Policy.IAuthorizationPolicy>  
 <xref:System.IdentityModel.Selectors.SecurityTokenRequirement>  
 <xref:System.IdentityModel.Selectors.SecurityTokenManager>  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 <xref:System.ServiceModel.Description.ServiceCredentials>  
 <xref:System.ServiceModel.Channels.SecurityBindingElement>  
 [Walkthrough: Creating Custom Client and Service Credentials](../../../../docs/framework/wcf/extending/walkthrough-creating-custom-client-and-service-credentials.md)  
 [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md)  
 [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md)  
 [Security Architecture](http://msdn.microsoft.com/library/16593476-d36a-408d-808c-ae6fd483e28f)
