---
title: "&lt;issuerMetadata&gt; of &lt;issuedTokenParameters&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1a85ca37-496d-4fa3-8d44-d6c9383d735c
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;issuerMetadata&gt; of &lt;issuedTokenParameters&gt;
\<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
\<issuedTokenParameters>  
\<issuerMetadata>  
  
## Syntax  
  
```xml  
<issuerMetaData address=String"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|address|Required. A string that specifies the address of the endpoint. The address must be an absolute URI. The default value is an empty string.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<headers>](../../../../../docs/framework/configure-apps/file-schema/wcf/headers-element.md)|A collection of address headers.|  
|[\<identity>](../../../../../docs/framework/configure-apps/file-schema/wcf/identity.md)|An identity that enables the authentication of an endpoint by other endpoints exchanging messages with it.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuedTokenParameters>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuedtokenparameters.md)|Specifies the parameters for an security token issued in a Federated security scenario.|  
  
## See Also  
 <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenParameters>  
 <xref:System.ServiceModel.Configuration.IssuedTokenParametersElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Service Identity and Authentication](../../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)  
 [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
 [Security Capabilities with Custom Bindings](../../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md)  
 [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [Custom Binding Security](../../../../../docs/framework/wcf/samples/custom-binding-security.md)
