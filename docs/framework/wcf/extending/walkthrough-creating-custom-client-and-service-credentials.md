---
title: "Walkthrough: Creating Custom Client and Service Credentials"
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
ms.assetid: 2b5ba5c3-0c6c-48e9-9e46-54acaec443ba
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Walkthrough: Creating Custom Client and Service Credentials
This topic shows how to implement custom client and service credentials and how to use custom credentials from application code.  
  
## Credentials Extensibility Classes  
 The <xref:System.ServiceModel.Description.ClientCredentials> and <xref:System.ServiceModel.Description.ServiceCredentials> classes are the main entry points to the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] security extensibility. These credentials classes provide the APIs that enable application code to set credentials information and to convert credential types into security tokens. (*Security tokens* are the form used to transmit credential information inside SOAP messages.) The responsibilities of these credentials classes can be divided into two areas:  
  
-   Provide the APIs for applications to set credentials information.  
  
-   Perform as a factory for <xref:System.IdentityModel.Selectors.SecurityTokenManager> implementations.  
  
 Both the <xref:System.ServiceModel.Description.ClientCredentials> and the <xref:System.ServiceModel.Description.ServiceCredentials> classes inherit from the abstract <xref:System.ServiceModel.Security.SecurityCredentialsManager> class that defines the contract for returning the <xref:System.IdentityModel.Selectors.SecurityTokenManager>.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the credentials classes and how they fit into the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security architecture, see [Security Architecture](http://msdn.microsoft.com/library/16593476-d36a-408d-808c-ae6fd483e28f).  
  
 The default implementations provided in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] support the system-provided credential types and create a security token manager that is capable of handling those credentials types.  
  
## Reasons to Customize  
 There are multiple reasons for customizing either client or service credential classes. Foremost is the requirement to change the default [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security behavior with regard to handling system-provided credential types, especially for the following reasons:  
  
-   Changes that are not possible using other extensibility points.  
  
-   Adding new credential types.  
  
-   Adding new custom security token types.  
  
 This topic describes how to implement custom client and service credentials and how to use them from application code.  
  
## First in a Series  
 Creating a custom credentials class is only the first step, because the reason for customizing credentials is to change [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] behavior regarding credentials provisioning, security token serialization, or authentication. Other topics in this section describe how to create custom serializers and authenticators. In this regard, creating custom credential class is the first topic in the series. Subsequent actions (creating custom serializers and authenticators) can be done only after creating custom credentials. Additional topics that build upon this topic include:  
  
-   [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md)  
  
-   [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md)  
  
-   [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md).  
  
## Procedures  
  
#### To implement custom client credentials  
  
1.  Define a new class derived from the <xref:System.ServiceModel.Description.ClientCredentials> class.  
  
2.  Optional. Add new methods or properties for new credential types. If you do not add new credential types, skip this step. The following example adds a `CreditCardNumber` property.  
  
3.  Override the <xref:System.ServiceModel.Security.SecurityCredentialsManager.CreateSecurityTokenManager%2A> method. This method is automatically called by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure when the custom client credential is used. This method is responsible for creating and returning an instance of an implementation of the <xref:System.IdentityModel.Selectors.SecurityTokenManager> class.  
  
    > [!IMPORTANT]
    >  It is important to note that the <xref:System.ServiceModel.Security.SecurityCredentialsManager.CreateSecurityTokenManager%2A> method is overridden to create a custom security token manager. The security token manager, derived from <xref:System.ServiceModel.ClientCredentialsSecurityTokenManager>, must return a custom security token provider, derived from <xref:System.IdentityModel.Selectors.SecurityTokenProvider>, to create the actual security token. If you do not follow this pattern for creating security tokens, your application may function incorrectly when <xref:System.ServiceModel.ChannelFactory> objects are cached (which is the default behavior for WCF client proxies), potentially resulting in an elevation of privilege attack. The custom credential object is cached as part of the <xref:System.ServiceModel.ChannelFactory>. However, the custom <xref:System.IdentityModel.Selectors.SecurityTokenManager> is created on every invocation, which mitigates the security threat as long as the token creation logic is placed in the <xref:System.IdentityModel.Selectors.SecurityTokenManager>.  
  
4.  Override the <xref:System.ServiceModel.Description.ClientCredentials.CloneCore%2A> method.  
  
     [!code-csharp[c_CustomCredentials#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcredentials/cs/source.cs#1)]
     [!code-vb[c_CustomCredentials#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcredentials/vb/client/client.vb#1)]  
  
#### To implement a custom client security token manager  
  
1.  Define a new class derived from <xref:System.ServiceModel.ClientCredentialsSecurityTokenManager>.  
  
2.  Optional. Override the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenProvider%28System.IdentityModel.Selectors.SecurityTokenRequirement%29> method if a custom <xref:System.IdentityModel.Selectors.SecurityTokenProvider> implementation must be created. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security token providers, see [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md).  
  
3.  Optional. Override the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenAuthenticator%28System.IdentityModel.Selectors.SecurityTokenRequirement%2CSystem.IdentityModel.Selectors.SecurityTokenResolver%40%29> method if a custom <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator> implementation must be created. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security token authenticators, see [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md).  
  
4.  Optional. Override the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenSerializer%2A> method if a custom <xref:System.IdentityModel.Selectors.SecurityTokenSerializer> must be created. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security tokens and custom security token serializers, see [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md).  
  
     [!code-csharp[c_CustomCredentials#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcredentials/cs/source.cs#2)]
     [!code-vb[c_CustomCredentials#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcredentials/vb/client/client.vb#2)]  
  
#### To use a custom client credentials from application code  
  
1.  Either create an instance of the generated client that represents the service interface, or create an instance of the <xref:System.ServiceModel.ChannelFactory> pointing to a service you want to communicate with.  
  
2.  Remove the system-provided client credentials behavior from the <xref:System.ServiceModel.Description.ServiceEndpoint.Behaviors%2A> collection, which can be accessed through the <xref:System.ServiceModel.ChannelFactory.Endpoint%2A> property.  
  
3.  Create a new instance of a custom client credentials class and add it to the <xref:System.ServiceModel.Description.ServiceEndpoint.Behaviors%2A> collection, which can be accessed through the <xref:System.ServiceModel.ChannelFactory.Endpoint%2A> property.  
  
     [!code-csharp[c_CustomCredentials#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcredentials/cs/source.cs#3)]
     [!code-vb[c_CustomCredentials#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcredentials/vb/client/client.vb#3)]  
  
 The previous procedure shows how to use client credentials from application code. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] credentials can also be configured using the application configuration file. Using application configuration is often preferable to hard-coding because it enables modification of application parameters without having to modify the source, recompiling, and redeployment.  
  
 The next procedure describes how to provide support for configuration of custom credentials.  
  
#### Creating a configuration handler for custom client credentials  
  
1.  Define a new class derived from <xref:System.ServiceModel.Configuration.ClientCredentialsElement>.  
  
2.  Optional. Add properties for all additional configuration parameters that you want to expose through application configuration. The example below adds one property named `CreditCardNumber`.  
  
3.  Override the <xref:System.ServiceModel.Configuration.BehaviorExtensionElement.BehaviorType%2A> property to return the type of the custom client credentials class created with the configuration element.  
  
4.  Override the <xref:System.ServiceModel.Configuration.BehaviorExtensionElement.CreateBehavior%2A> method. The method is responsible for creating and returning an instance of the custom credential class based on the settings loaded from the configuration file. Call the base <xref:System.ServiceModel.Configuration.ClientCredentialsElement.ApplyConfiguration%28System.ServiceModel.Description.ClientCredentials%29> method from this method to retrieve the system-provided credentials settings loaded into your custom client credentials instance.  
  
5.  Optional. If you added additional properties in step 2, you need to override the <xref:System.Configuration.ConfigurationElement.Properties%2A> property in order to register your additional configuration settings for the configuration framework to recognize them. Combine your properties with the base class properties to allow the system-provided settings to be configured through this custom client credentials configuration element.  
  
     [!code-csharp[c_CustomCredentials#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcredentials/cs/source.cs#7)]
     [!code-vb[c_CustomCredentials#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcredentials/vb/service/service.vb#7)]  
  
 Once you have the configuration handler class, it can be integrated into the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] configuration framework. That enables the custom client credentials to be used in the client endpoint behavior elements, as shown in the next procedure.  
  
#### To register and use a custom client credentials configuration handler in the application configuration  
  
1.  Add an <`extensions`> element and a <`behaviorExtensions`> element to the configuration file.  
  
2.  Add an <`add`> element to the <`behaviorExtensions`> element and set the `name` attribute to an appropriate value.  
  
3.  Set the `type` attribute to the fully-qualified type name. Also include the assembly name and other assembly attributes.  
  
    ```xml  
    <system.serviceModel>  
      <extensions>  
        <behaviorExtensions>  
          <add name="myClientCredentials" type="Microsoft.ServiceModel.Samples.MyClientCredentialsConfigHandler, CustomCredentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />  
        </behaviorExtensions>  
      </extensions>  
    <system.serviceModel>  
    ```  
  
4.  After registering your configuration handler, the custom credentials element can be used inside the same configuration file instead of the system-provided <`clientCredentials`> element. You can use both the system-provided properties and any new properties that you have added to your configuration handler implementation. The following example sets the value of a custom property using the `creditCardNumber` attribute.  
  
    ```xml  
    <behaviors>  
      <endpointBehaviors>  
        <behavior name="myClientCredentialsBehavior">  
          <myClientCredentials creditCardNumber="123-123-123"/>  
        </behavior>  
      </endpointBehaviors>  
    </behaviors>  
    ```  
  
#### To implement custom service credentials  
  
1.  Define a new class derived from <xref:System.ServiceModel.Description.ServiceCredentials>.  
  
2.  Optional. Add new properties to provide APIs for new credential values that are being added. If you do not add new credential values, skip this step. The following example adds an `AdditionalCertificate` property.  
  
3.  Override the <xref:System.ServiceModel.Security.SecurityCredentialsManager.CreateSecurityTokenManager%2A> method. This method is automatically called by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure when the custom client credential is used. The method is responsible for creating and returning an instance of an implementation of the <xref:System.IdentityModel.Selectors.SecurityTokenManager> class (described in the next procedure).  
  
4.  Optional. Override the <xref:System.ServiceModel.Description.ServiceCredentials.CloneCore%2A> method. This is required only if adding new properties or internal fields to the custom client credentials implementation.  
  
     [!code-csharp[c_CustomCredentials#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcredentials/cs/source.cs#4)]
     [!code-vb[c_CustomCredentials#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcredentials/vb/service/service.vb#4)]  
  
#### To implement a custom service security token manager  
  
1.  Define a new class derived from the <xref:System.ServiceModel.Security.ServiceCredentialsSecurityTokenManager> class.  
  
2.  Optional. Override the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenProvider%2A> method if a custom <xref:System.IdentityModel.Selectors.SecurityTokenProvider> implementation must be created. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security token providers, see [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md).  
  
3.  Optional. Override the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenAuthenticator%2A> method if a custom <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator> implementation must be created. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security token authenticators, see [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md) topic.  
  
4.  Optional. Override the <xref:System.IdentityModel.Selectors.SecurityTokenManager.CreateSecurityTokenSerializer%28System.IdentityModel.Selectors.SecurityTokenVersion%29> method if a custom <xref:System.IdentityModel.Selectors.SecurityTokenSerializer> must be created. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom security tokens and custom security token serializers, see [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md).  
  
     [!code-csharp[c_CustomCredentials#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcredentials/cs/source.cs#5)]
     [!code-vb[c_CustomCredentials#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcredentials/vb/service/service.vb#5)]  
  
#### To use custom service credentials from application code  
  
1.  Create an instance of the <xref:System.ServiceModel.ServiceHost>.  
  
2.  Remove the system-provided service credentials behavior from the <xref:System.ServiceModel.Description.ServiceDescription.Behaviors%2A> collection.  
  
3.  Create a new instance of the custom service credentials class and add it to the <xref:System.ServiceModel.Description.ServiceDescription.Behaviors%2A> collection.  
  
     [!code-csharp[c_CustomCredentials#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcredentials/cs/source.cs#6)]
     [!code-vb[c_CustomCredentials#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcredentials/vb/service/service.vb#6)]  
  
 Add support for configuration using the steps described previously in the procedures "`To create a configuration handler for custom client credentials`" and "`To register and use a custom client credentials configuration handler in the application configuration`." The only difference is to use the <xref:System.ServiceModel.Configuration.ServiceCredentialsElement> class instead of the <xref:System.ServiceModel.Configuration.ClientCredentialsElement> class as a base class for the configuration handler. The custom service credential element can then be used wherever the system-provided `<serviceCredentials>` element is used.  
  
## See Also  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 <xref:System.ServiceModel.Description.ServiceCredentials>  
 <xref:System.ServiceModel.Security.SecurityCredentialsManager>  
 <xref:System.IdentityModel.Selectors.SecurityTokenManager>  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement>  
 <xref:System.ServiceModel.Configuration.ServiceCredentialsElement>  
 [How to: Create a Custom Security Token Provider](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-provider.md)  
 [How to: Create a Custom Security Token Authenticator](../../../../docs/framework/wcf/extending/how-to-create-a-custom-security-token-authenticator.md)  
 [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md)
