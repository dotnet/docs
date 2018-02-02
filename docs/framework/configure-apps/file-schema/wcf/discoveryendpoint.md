---
title: "&lt;discoveryEndpoint&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fae2f48b-a635-4e4b-859d-a1432ac37e1c
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# &lt;discoveryEndpoint&gt;

This configuration element defines a standard endpoint with a fixed discovery contract. When added to the service configuration, it specifies where to listen for the discovery messages. When added to the client configuration it specifies where to send the discovery queries.  
  
\<system.serviceModel>  
\<standardEndpoints>  
  
## Syntax

```xml
<system.serviceModel>
  <standardEndpoints>
    <discoveryEndpoint>
      <standardEndpoint discoveryMode="Adhoc/Managed" 
                        discoveryVersion="WSDiscovery11/WSDiscoveryApril2005" 
                        maxResponseDelay="Timespan" 
                        name="String" />
    </discoveryEndpoint>
  </standardEndpoints>
</system.serviceModel>  
```  
  
## Attributes and elements

The following sections describe attributes, child elements, and parent elements.  
  
### Attributes

| Attribute        | Description |  
| ---------------- | ----------- |  
| discoveryMode    | A string that specifies the mode of discovery protocol. Valid values are "Adhoc" and "Managed". In managed mode the protocol relies on a Discovery Proxy, which acts as a repository of Discoverable services. Adhoc mode requires the protocol to use UDP multicast mechanism to find available services. For more information on the property, see <xref:System.ServiceModel.Discovery.DiscoveryEndpoint.DiscoveryMode%2A>. |  
| discoveryVersion | A string that specifies one of the two versions of WS-Discovery protocol. Valid values are WSDiscovery11 and WSDiscoveryApril2005. This value is of type <xref:System.ServiceModel.Discovery.DiscoveryVersion>. |  
| maxResponseDelay | A Timespan value that specifies the maximum value for the delay the Discovery protocol will wait before sending certain messages such as Probe Match or Resolve Match.<br /><br /> If all ProbeMatches are sent at the same time, a network storm may result. To prevent this from occurring, ProbeMatches are sent with a random delay between each ProbeMatch. The random delay is in the range of 0 to the value set by this attribute. If this attribute is set to 0, then the ProbeMatches messages are sent in a tight loop without any delay. Otherwise, the ProbeMatches messages are sent with some random delay such that the total time taken to send all ProbeMatches messages does not exceed the maxResponseDelay. This value is only relevant for services, it is not used by clients. |  
| `name`           | A String that specifies the name of the configuration of the standard endpoint. The name is used in the `endpointConfiguration` attribute of the service endpoint to link a standard endpoint to its configuration. |  
  
### Child elements

None.  
  
### Parent elements

| Element | Description |  
| ------- | ----------- |  
| [\<standardEndpoints>](../../../../../docs/framework/configure-apps/file-schema/wcf/standardendpoints.md) | A collection of standard endpoints that are pre-defined endpoints with one or more of their properties (address, binding, contract) fixed. |  
  
## Example

The following example demonstrates a service listening on the discovery messages over a peer net multicast transport. The example explicitly specifies WS-Discovery April 2005 version.  
  
The standard endpoint configuration is defined per service and cannot be shared across the service. If another service would like to have the same discovery endpoint, the same configuration needs to be added to that service’s section.  
  
```xml
<services>  
  <service name="CalculatorService"
           behaviorConfiguration="CalculatorServiceBehavior">
    <endpoint binding="basicHttpBinding" 
              address="calculator" 
              contract="ICalculatorService" />  
    <endpoint name="peerNetDiscovery"  
              binding="peerTcpBinding"  
              address="net.p2p://discoveryMesh/multicast"  
              kind="discoveryEndpoint"  
              endpointConfiguration="peerTcpDiscoveryEndpointConfiguration"  
              bindingConfiguration="discoveryPeerTcpBindingConfig" />      
  </service>  
</services>  
<standardEndpoints>  
  <discoveryEndpoint>  
    <standardEndpoint name="peerTcpDiscoveryEndpointConfiguration"                         
                      version="WSDiscoveryApril2005" />  
  </discoveryEndpoint>  
</standardEndpoints>  
```  
  
## See also

<xref:System.ServiceModel.Discovery.DiscoveryEndpoint>
