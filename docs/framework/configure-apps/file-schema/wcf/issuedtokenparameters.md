---
title: "&lt;issuedTokenParameters&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 120b3f37-7331-4816-b712-d6aab39655a4
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;issuedTokenParameters&gt;
Specifies the parameters for a security token issued in a Federated security scenario.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
\<issuedTokenParameters>  
  
## Syntax  
  
```xml  
<issuedTokenParameters   
      DefaultMessageSecurityVersion="System.ServiceModel.MessageSecurityVersion"  
      inclusionMode="AlwaysToInitiator/AlwaysToRecipient/Never/Once"  
      keySize="Integer"  
   keyType="AsymmetricKey/BearerKey/SymmetricKey"  
      tokenType="String" >  
   <additionalRequestParameters />  
      <claimTypeRequirements>  
            <add claimType="URI"  
           isOptional="Boolean" />  
      </claimTypeRequirements>  
      <issuer address="String"   
                      binding=" " />  
      <issuerMetadata address="String" />   
</issuedTokenParameters>  
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|defaultMessageSecurityVersion|Specifies the versions of the security specifications, (WS-Security, WS-Trust, WS-Secure Conversation and WS-Security Policy) that must be supported by the binding. This value is of type <xref:System.ServiceModel.MessageSecurityVersion>.|  
|inclusionMode|Specifies the token inclusion requirements. This attribute is of type <xref:System.ServiceModel.Security.Tokens.SecurityTokenInclusionMode>.|  
|keySize|An integer that specifies the token key size. The default value is 256.|  
|keyType|A valid value of <xref:System.IdentityModel.Tokens.SecurityKeyType> that specifies the key type. The default is `SymmetricKey`.|  
|tokenType|A string that specifies the token type. The default is "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAML".|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<additionalRequestParameters>](../../../../../docs/framework/configure-apps/file-schema/wcf/additionalrequestparameters-element.md)|A collection of configuration elements that specify additional request parameters.|  
|[\<claimTypeRequirements>](../../../../../docs/framework/configure-apps/file-schema/wcf/claimtyperequirements-element.md)|Specifies a collection of required claim types.<br /><br /> In a federated scenario, services state the requirements on incoming credentials. For example, the incoming credentials must possess a certain set of claim types. Each element in this collection specifies the types of required and optional claims expected to appear in a federated credential.|  
|[\<issuer>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuer-of-issuedtokenparameters.md)|A configuration element that specifies the endpoint that issues the current token.|  
|[\<issuerMetadata>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuermetadata-of-issuedtokenparameters.md)|A configuration element that specifies the endpoint address of the token issuer's metadata.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<secureConversationBootstrap>](../../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md)|Specifies the default values used for initiating a secure conversation service.|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md)|Specifies the security options for a custom binding.|  
  
## See Also  
 <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenParameters>  
 <xref:System.ServiceModel.Configuration.IssuedTokenParametersElement>  
 <xref:System.ServiceModel.Configuration.SecurityElementBase.IssuedTokenParameters%2A>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [Custom Binding Security](../../../../../docs/framework/wcf/samples/custom-binding-security.md)  
 [Service Identity and Authentication](../../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)  
 [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
 [Security Capabilities with Custom Bindings](../../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md)  
 [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)
