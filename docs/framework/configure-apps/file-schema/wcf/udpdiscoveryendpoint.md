---
title: "&lt;udpDiscoveryEndpoint&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1f485329-2771-43bc-88de-df8f2faa3bb7
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;udpDiscoveryEndpoint&gt;
This configuration element defines a standard endpoint that is pre-configured for discovery operations over a UDP multicast binding. This endpoint has a fixed contract and supports two WS-Discovery protocol versions. In addition, it has a fixed UDP binding and a default address as specified in the WS-Discovery specifications (WS-Discovery April 2005 or WS-Discovery V1.1)..  
  
 \<system.ServiceModel>  
\<standardEndpoints>  
  
## Syntax  
  
```xml  
<system.serviceModel>  
    <standardEndpoints>       <discoveryEndpoint>           <standardEndpoint                  discoveryMode="Adhoc/Managed"                  discoveryVersion="WSDiscovery11/WSDiscoveryApril2005"                  maxResponseDelay="Timespan"                  multicastAddress="Uri"                   name="String" />       </discoveryEndpoint>            </standardEndpoints>  
</system.serviceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|discoveryMode|A string that specifies the mode of discovery protocol. Valid values are "Adhoc" and "Managed". In managed mode the protocol relies on a Discovery Proxy, which acts as a repository of Discoverable services. Adhoc mode requires the protocol to use UDP multicast mechanism to find available services. This value is of type <xref:System.ServiceModel.Discovery.ServiceDiscoveryMode>.|  
|discoveryVersion|A string that specifies one of the two versions of WS-Discovery protocol. Valid values are WSDiscovery11 and WSDiscoveryApril2005. This value is of type <xref:System.ServiceModel.Discovery.DiscoveryVersion>.|  
|maxResponseDelay|A Timespan value that specifies the maximum value for the delay the Discovery protocol will wait before sending certain messages such as Probe Match or Resolve Match.<br /><br /> If all ProbeMatches are sent at the same time, a network storm may result. To prevent this from occurring, ProbeMatches are sent with a random delay between each ProbeMatch. The random delay is in the range of 0 to the value set by this attribute. If this attribute is set to 0, then the ProbeMatches messages are sent in a tight loop without any delay. Otherwise, the ProbeMatches messages are sent with some random delay such that the total time taken to send all ProbeMatches messages does not exceed the maxResponseDelay. This value is only relevant for services, it is not used by clients.|  
|multicastAddress|A Uri that specifies a multicast address to use for sending and receiving the discovery messages. The default value is the multicast address as conformant to the protocol specification.|  
|`name`|A String that specifies the name of the configuration of the standard endpoint. The name is used in the `endpointConfiguration` attribute of the service endpoint to link a standard endpoint to its configuration.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<udpTransportSettings>](../../../../../docs/framework/configure-apps/file-schema/wcf/udptransportsettings.md)|A collection of settings that allow you to configure UDP transport for the UDP endpoint.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<standardEndpoints>](../../../../../docs/framework/configure-apps/file-schema/wcf/standardendpoints.md)|A collection of standard endpoints that are pre-defined endpoints with one or more of their properties (address, binding, contract) fixed.|  
  
## Example  
 The following example demonstrates a service listening for discovery messages over a UDP multicast transport.  
  
```xml
<services>  
  <service name="CalculatorService"  
           behaviorConfiguration="CalculatorServiceBehavior">  
    <endpoint binding="basicHttpBinding"   
              address="calculator" 
              contract="ICalculatorService" />  
    <endpoint name="DiscoveryEndpoint"  
              kind="udpDiscoveryEndpoint" />  
  </service>  
  <standardEndpoints>  
    <udpDiscoveryEndpoint>  
      <standardEndpoint name="DiscoveryEndpoint"                         
                        version="WSDiscoveryApril2005" />  
    </udpDiscoveryEndpoint>  
  </standardEndpoints>
</services>
```  
  
## See Also  
 <xref:System.ServiceModel.Discovery.DiscoveryEndpoint>
