---
description: "Learn more about: <pnrpPeerResolver>"
title: "<pnrpPeerResolver>"
ms.date: "03/30/2017"
ms.assetid: c1b34f3b-68e5-4911-a367-de49fb61dbc6
---
# \<pnrpPeerResolver>

Specifies that the PNRP (Peer Name Resolution Protocol) resolver is to be used as a resolver. This element is optional because PNRP is the default resolver.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<pnrpResolver>**  
  
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
|[\<binding>](bindings.md)|Defines all binding capabilities of the custom binding.|  
  
## Example  
  
```xml  
<pnrpResolver resolverType="String" />
```  
  
## See also

- <xref:System.ServiceModel.Configuration.PnrpPeerResolverElement>
- <xref:System.ServiceModel.Channels.PnrpPeerResolverBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
- [Peer Resolvers](../../../wcf/feature-details/peer-resolvers.md)
