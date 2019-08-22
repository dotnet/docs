---
title: "<announcementEndpoint>"
ms.date: "03/30/2017"
ms.assetid: 034b7c69-a770-4502-8cef-38007bbcd025
---
# \<announcementEndpoint>
This configuration element defines a standard endpoint with a fixed announcement contract. A service can optionally announce its availability by sending an online and offline announcement message when it is opened or closed respectively. A Windows Communication Foundation (WCF) service specifies the announcement endpoints in the [\<serviceDiscovery>](servicediscovery.md) element and uses the AnnouncementClient to perform the announcements. A client wishing to listen for the announcement from other service is actually acting as a WCF service; thus you have to configure the announcement endpoints for that client in the [\<services>](services.md) section.  
  
\<system.ServiceModel>  
\<standardEndpoints>  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <standardEndpoints>
    <announcementEndpoint>
      <standardEndpoint discoveryVersion="WSDiscovery11/WSDiscoveryApril2005"
                        maxAnnouncementDelay="Timespan"
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
|name|A String that specifies the name of the configuration of the standard endpoint. The name is used in the `endpointConfiguration` attribute of the service endpoint to link a standard endpoint to its configuration.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<standardEndpoints>](standardendpoints.md)|A collection of standard endpoints that are pre-defined endpoints with one or more of their properties (address, binding, contract) fixed.|  
  
## Example  
 The following example demonstrates a client listening for announcements messages over http and peernet.  
  
```xml  
<services>
  <service name="ServiceAnnouncementListener">
    <endpoint name="httpAnnouncementEndpoint"
              kind="announcementEndpoint"
              binding="basicHttpBinding"
              address="announcements" />
    <endpoint name="peerNetAnnouncementEndpoint"
              kind="announcementEndpoint"
              binding="peerTcpBinding"
              address="net.p2p://discoveryMesh/multicast"
              bindingConfiguration="discoveryPeerTcpBindingConfig" />
  ...
  </service>
</services>

<standardEndpoints>
  <announcementEndpoint>
    <standardEndpoint name="httpAnnouncementEndpoint"
                      version="WSDiscoveryApril2005" />
    <standardEndpoint name="peerNetAnnouncementEndpoint"
                      version="WSDiscoveryApril2005" />
  </announcementEndpoint>
</standardEndpoints>
```  
  
## See also

- <xref:System.ServiceModel.Discovery.AnnouncementEndpoint>
