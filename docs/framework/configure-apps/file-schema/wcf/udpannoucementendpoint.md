---
title: "&lt;udpAnnoucementEndpoint&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5b3fa9c5-f372-4df9-a9d6-1e426063b721
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;udpAnnoucementEndpoint&gt;
This configuration element defines a standard endpoint that is used by services to send announcement messages over a UDP binding. It has a fixed contract and supports two discovery versions. In addition it has a fixed UDP binding and a default address value as specified in the WS-Discovery specifications (WS-Discovery April 2005 or WS-Discovery version 1.1). You can specify the multicast address to use for sending and receiving the announcement messages.  
  
\<system.ServiceModel>  
\<standardEndpoints>  
  
## Syntax  
  
```xml  
<system.serviceModel>  
  <standardEndpoints>
    <announcementEndpoint>
      <standardEndpoint discoveryVersion="WSDiscovery11/WSDiscoveryApril2005" 
                        maxAnnouncementDelay="Timespan"
                        multicastAddress="Uri"
                        name="String" />
    </announcementEndpoint>
  </standardEndpoints>  
</system.serviceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|discoveryVersion|A string that specifies one of the two versions of WS-Discovery protocol. Valid values are WSDiscovery11 and WSDiscoveryApril2005. This value is of type <xref:System.ServiceModel.Discovery.Configuration.AnnouncementEndpointElement.DiscoveryVersion>.|  
|maxAnnouncementDelay|A Timespan value that specifies the maximum value for the delay the Discovery protocol will wait before sending a Hello message. The messages will wait for a random time value between 0 and the value of this attribute before being sent. This attribute is used to set a small, random delay to prevent network storms when a network goes out and all services come back online at the same time.|  
|multicastAddress|A URI that specifies a multicast address to use for sending and receiving the discovery messages. The default value is the multicast address as conformant to the protocol specification.|  
|name|A String that specifies the name of the configuration of the standard endpoint. The name is used in the `endpointConfiguration` attribute of the service endpoint to link a standard endpoint to its configuration.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<udpTransportSettings>](../../../../../docs/framework/configure-apps/file-schema/wcf/udptransportsettings.md)|A collection of settings that allow you to configure UDP transport for the UDP endpoint.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<standardEndpoints>](../../../../../docs/framework/configure-apps/file-schema/wcf/standardendpoints.md)|A collection of standard endpoints that are pre-defined endpoints with one or more of their properties (address, binding, contract) fixed.|  
  
## Example  
 The following example demonstrates a client listening for announcement over a UDP multicast transport with default multicast address, and UDP multicast transport with specified multicast address.  
  
```xml  
<services>  
  <service name="ServiceAnnouncementListener">  
      <endpoint name="udpAnnouncementEndpointStandard"  
                kind="udpAnnouncementEndpoint"  
                bindingConfiguration="..." />  
      <endpoint name="udpAnnouncementEndpoint2"  
                kind="udpAnnouncementEndpoint"  
                endpointConfiguration="AnnouncementConfiguration3702"  
                bindingConfiguration="..." />  
...  
  </service>  
</services>  
<standardEndpoints>  
  <udpAnnouncementEndpoint>  
     <standardEndpoint name="AnnouncementConfiguration2"   
          version="WSDiscoveryApril2005"   
          multicastAddress="soap.udp://239.255.255.250:3703"/>          
  </udpAnnouncementEndpoint>  
</standardEndpoints>  
```  
  
## See Also  
 <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint>
