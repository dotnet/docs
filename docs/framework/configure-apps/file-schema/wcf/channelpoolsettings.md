---
description: "Learn more about: <channelPoolSettings>"
title: "<channelPoolSettings>"
ms.date: "03/30/2017"
ms.assetid: 4755f3d3-4213-4c68-ae7f-45b67d744459
---
# \<channelPoolSettings>

Specifies the channel pool settings for a custom binding.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<oneWay>**](oneway.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<channelPoolSettings>**  
  
## Syntax  
  
```xml  
<channelPoolSettings idleTimeout="TimeSpan"
                     leaseTimeout="TimeSpan"
                     maxOutboundConnectionsPerEndpoint="Integer" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`idleTimeout`|A positive <xref:System.TimeSpan> that specifies the maximum time the channels in the pool can be idle before being disconnected. The default is 00:02:00.|  
|`leaseTimeout`|A <xref:System.TimeSpan> that specifies the interval of time after which a channel, when returned to the pool, is closed. The default is 00:10:00.|  
|`maxOutboundChannelsPerEndpoint`|A positive integer that specifies the maximum number of channels that can be stored in the pool for each remote endpoint. The default is 10.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<oneWay>](oneway.md)|Enables packet routing for a custom binding.|  
  
## Remarks  

 Quotas are used as a policy mechanism to prevent the consumption of excessive resources. They prevent Denial of Service (DOS) attacks that are either malicious or unintentional. Use this element when setting channel quotas on a custom channel.  
  
 `ChannelPoolSettings` specifies three quotas:  
  
- The `idleTimeout` quota is used to mitigate Denial of Service (DOS) attacks on the server that rely on tying up resources for an extended period of time. On the client, setting the correct value can increase the reliability of connecting with the service. The default value is based on a conservatively modest allocation of resources. It is suitable for a development environment and small installation scenarios. Service administrators should review the value if an installation is running out of resources or if connections are being limited despite the availability of additional resources.  
  
- The `leaseTimeout` quota is used to for integration with load balancers and for improving reliability. The default value is based on a conservative allocation of resources. It is suitable for a development environment and small installation scenarios. Service administrators should review the value if an installation is running out of resources or if connections are being limited despite the availability of additional resources.  
  
- The `maxOutboundChannelsPerEndpoint` quota sets cache limits on both the server and the client and is used to improve reliability. The default value is based on a conservatively modest allocation of resources that is suitable for a development environment and small installation scenarios. Service administrators should review the value if an installation is running out of resources or if connections are being limited despite the availability of additional resources.  
  
## See also

- <xref:System.ServiceModel.Channels.OneWayBindingElement.ChannelPoolSettings%2A>
- <xref:System.ServiceModel.Channels.ChannelPoolSettings>
- <xref:System.ServiceModel.Configuration.OneWayElement.ChannelPoolSettings%2A>
- <xref:System.ServiceModel.Configuration.ChannelPoolSettingsElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [\<oneWay>](oneway.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
