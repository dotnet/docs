---
description: "Learn more about: <resolver>"
title: "<resolver>"
ms.date: "03/30/2017"
ms.assetid: 0c00200c-f135-4e5c-a024-76b72bcbc021
---
# \<resolver>

Specifies a peer resolver that is used to resolve a peer mesh ID to a set of peer node addresses that represents several nodes that participate in the mesh.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netPeerTcpBinding>**](netpeertcpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<resolver>**  
  
## Syntax  
  
```xml  
<resolver mode="Auto/Custom/Pnrp"
          referralPolicy="DoNotShare/Service/Share">
</resolver>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`mode`|A string that specifies whether the peer resolver instance associated with this service is either PNRP-specific, a custom resolver, or automatically determined. This attribute is of type <xref:System.ServiceModel.PeerResolvers.PeerResolverMode>.|  
|`referralPolicy`|A string that specifies the way referrals are shared among peers. This attribute is of type <xref:System.ServiceModel.PeerResolvers.PeerReferralPolicy>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<headers>](headers.md)|Specifies settings for a custom peer resolver service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the [\<netPeerTcpBinding>](netpeertcpbinding.md).|  
  
## Remarks  

 A peer name resolver is a discovery service used by peer channels to find peer nodes that participate in a peer mesh. It is also used to "register" a node with a peer mesh, the mechanism by which the peer node becomes known and available from the peer mesh. For more information on peer resolvers, see [Peer Resolvers](../../../wcf/feature-details/peer-resolvers.md).  
  
## See also

- <xref:System.ServiceModel.PeerResolver>
- <xref:System.ServiceModel.PeerResolvers.PeerResolverSettings>
- <xref:System.ServiceModel.NetPeerTcpBinding.Resolver%2A>
- <xref:System.ServiceModel.Configuration.NetPeerTcpBindingElement.Resolver%2A>
- <xref:System.ServiceModel.Configuration.PeerResolverElement>
- [Peer Resolvers](../../../wcf/feature-details/peer-resolvers.md)
- [Adding a Custom Resolver to a PeerChannel Application](/previous-versions/ms730105(v=vs.90))
