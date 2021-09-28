---
description: "Learn more about: <custom>"
title: "<custom>"
ms.date: "03/30/2017"
ms.assetid: a6f65a00-bd1a-4d4a-955a-fe009ec02ab8
---
# \<custom>

Specifies settings for a custom peer resolver service.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netPeerTcpBinding>**](netpeertcpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<resolver>**](resolver.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<custom>**  
  
## Syntax  
  
```xml  
<custom address="Uri"
        resolverType="String">
  <headers/>
  <identity/>
</custom>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`address`|A URI that specifies the endpoint address of the peer node that hosts the custom peer resolver service.|  
|`resolverType`|A string that specifies the type of the custom peer resolver service.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identity>](identity.md)|Specifies the identity for custom peer resolvers configured with this element. This element is of type <xref:System.ServiceModel.Configuration.IdentityElement>.|  
|[\<headers>](headers-element.md)|A collection of address header used for SOAP messages handled by the custom peer resolver.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<resolver>](resolver.md)|A peer resolver that is used to resolve a peer mesh ID to a set of peer node addresses that represents several nodes that participate in the mesh.|  
  
## Remarks  

 This element defines the basic settings for a custom peer resolver service, including the endpoint address of the peer hosting the service and any specific binding settings. For more information on creating a custom resolver, see [Adding a Custom Resolver to a PeerChannel Application](/previous-versions/ms730105(v=vs.90)).  
  
## See also

- <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService>
- <xref:System.ServiceModel.PeerResolvers.PeerCustomResolverSettings>
- <xref:System.ServiceModel.Configuration.PeerResolverElement.Custom%2A>
- <xref:System.ServiceModel.Configuration.PeerCustomResolverElement>
- [Peer Resolvers](../../../wcf/feature-details/peer-resolvers.md)
- [Adding a Custom Resolver to a PeerChannel Application](/previous-versions/ms730105(v=vs.90))
