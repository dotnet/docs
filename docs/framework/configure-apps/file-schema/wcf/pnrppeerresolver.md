---
title: "&lt;pnrpPeerResolver&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c1b34f3b-68e5-4911-a367-de49fb61dbc6
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;pnrpPeerResolver&gt;
Specifies that the PNRP (Peer Name Resolution Protocol) resolver is to be used as a resolver. This element is optional because PNRP is the default resolver.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<pnrpResolver>  
  
## Syntax  
  
```xml  
<pnrpResolver resolverType="String" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|resolverType|A string that specifies the resolver to be used. This attribute is optional. If it is not set, or if it is set to an empty string, PNRP is used.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Example  
  
```xml  
<pnrpResolver resolverType="" />  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.PnrpPeerResolverElement>  
 <xref:System.ServiceModel.Channels.PnrpPeerResolverBindingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [Peer Resolvers](../../../../../docs/framework/wcf/feature-details/peer-resolvers.md)
