---
title: "&lt;secureConversationBootstrap&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 66b46f95-fa2d-4b5b-b6ce-0572ab0cdd50
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;secureConversationBootstrap&gt;
Specifies the default values used for initiating a secure conversation service.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
\<secureConversationBootstrap>  
  
## Syntax  
  
```xml  
<secureConversationBootstrap  
   allowSerializedSigningTokenOnReply="Boolean"  
   authenticationMode="AuthenticationMode"  
   defaultAlgorithmSuite="SecurityAlgorithmSuite"  
   includeTimestamp="Boolean"  
   requireDerivedKeys="Boolean"  
   keyEntropyMode="ClientEntropy/ServerEntropy/CombinedEntropy"   
messageProtectionOrder="SignBeforeEncrypt/SignBeforeEncryptAndEncryptSignature/EncryptBeforeSign"  
   messageSecurityVersion="WSSecurityJan2004/WSSecurityXXX2005"  
   requireDerivedKeys="Boolean"  
   requireSecurityContextCancellation="Boolean"  
   requireSignatureConfirmation="Boolean" >  
   securityHeaderLayout="Strict/Lax/LaxTimestampFirst/LaxTimestampLast"  
   includeTimestamp="Boolean" />  
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`allowSerializedSigningTokenOnReply`|Optional. A Boolean value that specifies if a serialized token can be used on reply. The default value is `false`. When using a dual binding, the setting defaults to `true` any setting made will be ignored.|  
|`authenticationMode`|Specifies the SOAP authentication mode used between the initiator and the responder.<br /><br /> The default is sspiNegotiated.<br /><br /> This attribute is of type <xref:System.ServiceModel.Configuration.AuthenticationMode>.|  
|`defaultAlgorithmSuite`|Security algorithm suite defines of a variety of algorithms such as Canonicalization, Digest, KeyWrap, Signature, Encryption, and KeyDerivation algorithms. Each of the security algorithm suites defines values for these different parameters. Message-based security is achieved using these algorithms.<br /><br /> This attribute is used when working with a different platform that opts for a set of algorithms different than the default. You should be aware of the strengths and weaknesses of the relevant algorithms when making modifications to this setting. This attribute is of type <xref:System.ServiceModel.Security.SecurityAlgorithmSuite>. The default is `Basic256`.|  
|`includeTimestamp`|A Boolean value that specifies whether time stamps are included in each message. The default is `true`.|  
|`keyEntropyMode`|Specifies the way that keys for securing messages are computed. Keys can be based on the client key material only, on the service key material only or a combination of both. Valid values are:<br /><br /> -   ClientEntropy: The session key is based off the client provided key material.<br />-   ServerEntropy: The session key is based off the service provided key material.<br />-   CombinedEntropy: The session key is based off the client and service provided keying material.<br /><br /> The default is CombinedEntropy.<br /><br /> This attribute is of type <xref:System.ServiceModel.Security.SecurityKeyEntropyMode>.|  
|`messageProtectionOrder`|Sets the order in which message level security algorithms are applied to the message. Valid values include the following:<br /><br /> -   SignBeforeEncrypt: Sign first, then encrypt.<br />-   SignBeforeEncryptAndEncryptSignature: Sign, encrypt, and encrypt signature.<br />-   EncryptBeforeSign: Encrypt first, then sign.<br /><br /> SignBeforeEncryptAndEncryptSignature is the default value when using mutual certificates with WS-Security 1.1.  SignBeforeEncrypt is the default value with WS-Security 1.0.<br /><br /> This attribute is of type <xref:System.ServiceModel.Security.MessageProtectionOrder>.|  
|`messageSecurityVersion`|Sets the version of WS-Security that is used. Valid values include the following:<br /><br /> -   WSSecurityJan2004<br />-   WSSecurityXXX2005<br /><br /> The default is WSSecurityXXX2005. This attribute is of type <xref:System.ServiceModel.MessageSecurityVersion>.|  
|`requireDerivedKeys`|A Boolean value that specifies whether keys can be derived from the original proof keys. The default is `true`.|  
|`requireSecurityContextCancellation`|A Boolean value that specifies whether security context should be cancelled and terminated when it is no longer required. The default is `true`.|  
|`requireSignatureConfirmation`|A Boolean value that specifies whether WS-Security signature confirmation is enabled. When set to `true`, message signatures are confirmed by the responder. The default is `false`.<br /><br /> Signature confirmation is used to confirm that the service is responding in full awareness of a request.|  
|`securityHeaderLayout`|Specifies the ordering of the elements in security header. Valid values are:<br /><br /> -   Strict. Items are added to the security header according to the general principle of "declare before use".<br />-   Lax. Items are added to the security header in any order that confirms to WSS: SOAP Message security.<br />-   LaxWithTimestampFirst. Items are added to the security header in any order that confirms to WSS: SOAP Message security except that the first element in the security header must be a wsse:Timestamp element.<br />-   LaxWithTimestampLast. Items are added to the security header in any order that confirms to WSS: SOAP Message security except that the last element in the security header must be a wsse:Timestamp element.<br /><br /> The default is Strict.<br /><br /> This element is of type <xref:System.ServiceModel.Channels.SecurityHeaderLayout>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuedTokenParameters>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuedtokenparameters.md)|Specifies a current issued token. This element is of type <xref:System.ServiceModel.Configuration.IssuedTokenParametersElement>.|  
|[\<localClientSettings>](../../../../../docs/framework/configure-apps/file-schema/wcf/localclientsettings-element.md)|Specifies the security settings of a local client for this binding. This element is of type <xref:System.ServiceModel.Configuration.LocalClientSecuritySettingsElement>.|  
|[\<localServiceSettings>](../../../../../docs/framework/configure-apps/file-schema/wcf/localservicesettings-element.md)|Specifies the security settings of a local service for this binding. This element is of type <xref:System.ServiceModel.Configuration.LocalServiceSecuritySettingsElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md)|Specifies the security options for a custom binding.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.LocalServiceSecuritySettingsElement>  
 <xref:System.ServiceModel.Channels.SecurityBindingElement.LocalServiceSettings%2A>  
 <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [Custom Binding Security](../../../../../docs/framework/wcf/samples/custom-binding-security.md)
