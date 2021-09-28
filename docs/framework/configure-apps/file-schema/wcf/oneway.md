---
description: "Learn more about: <oneWay>"
title: "<oneWay>"
ms.date: "03/30/2017"
ms.assetid: 00e67e0e-77c0-4695-9138-c0997b0e5f3c
---
# \<oneWay>

Enables packet routing and the use of one-way methods for a custom binding.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<oneWay>**  
  
## Syntax  
  
```xml  
<oneWay packetRoutable="Boolean">
  <channelPoolSettings idleTimeout="TimeSpan"
                       leaseTimeout="TimeSpan"
                       maxOutboundConnectionsPerEndpoint="Integer" />
</oneWay>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`packetRoutable`|A Boolean value that specifies whether packet routing is enabled. The default is `false`.|  
|`MaxAcceptedChannels`|An integer that specifies the maximum number of channels that can be accepted.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<channelPoolSettings>](channelpoolsettings.md)|A <xref:System.ServiceModel.Configuration.ChannelPoolSettingsElement> object that contains properties of the channel pool for the current channel.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  

 To enable packet routing, a one-way conversion layer is required, which this element provides. A user can create a custom binding that layers this binding over a session-aware or request-reply transport to make it packet routable. This element is also useful when you want to expose one-way methods in a more native fashion. More transformations can be applied over this layer, such as Composite Duplex and Reliable Messaging.  
  
## See also

- <xref:System.ServiceModel.Channels.OneWayBindingElement>
- <xref:System.ServiceModel.Configuration.OneWayElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
