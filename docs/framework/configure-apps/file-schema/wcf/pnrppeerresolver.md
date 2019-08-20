---
title: "<pnrpPeerResolver>"
ms.date: "03/30/2017"
ms.assetid: c1b34f3b-68e5-4911-a367-de49fb61dbc6
---
# \<pnrpPeerResolver>
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
|[\<binding>](../../../misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Example  
  
```xml  
<pnrpResolver resolverType="String" />
```  
  
## See also

- <xref:System.ServiceModel.Configuration.PnrpPeerResolverElement>
- <xref:System.ServiceModel.Channels.PnrpPeerResolverBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Bindings](../../bindings.md)
- [Extending Bindings](../../extending/extending-bindings.md)
- [Custom Bindings](../../extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
- [Peer Resolvers](../../feature-details/peer-resolvers.md)
