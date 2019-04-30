---
title: "<standardEndpoints>"
ms.date: "03/30/2017"
ms.assetid: d62153d7-a6e6-462a-a784-cca61e9c2ba1
---
# \<standardEndpoints>
This configuration section allows you to define a collection of standard endpoints, which are reusable preconfigured endpoints. A standard endpoint will have one or more of the address, binding and contract attributes set to a fixed value. For example, in the discovery endpoint the contract is fixed. You can also use standard endpoints to extend service endpoint with new properties similar to defining custom bindings.  
  
 \<system.ServiceModel>  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <standardEndpoints>
  </standardEndpoints>
</system.serviceModel>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<announcementEndpoint>](announcementendpoint.md)|Defines a standard endpoint with a fixed announcement contract. A service can optionally announce its availability by sending an online and offline announcement message when it is opened or closed respectively. A Windows Communication Foundation (WCF) service specifies the announcement endpoints in the [\<serviceDiscovery>](servicediscovery.md) element and uses the AnnouncementClient to perform the announcements. A client wishing to listen for the announcement from other service is actually acting as a WCF service; thus you have to configure the announcement endpoints for that client in the [\<services>](services.md) section.|  
|[\<discoveryEndpoint>](discoveryendpoint.md)|Defines a standard endpoint with a fixed discovery contract. When added to the service configuration, it specifies where to listen for the discovery messages. When added to the client configuration it specifies where to send the discovery queries.|  
|[\<dynamicEndpoint>](dynamicendpoint.md)|This configuration element defines a standard endpoint that contains information to enable an application to function as a client program that can find the endpoint address dynamically at runtime.|  
|[\<mexEndpoint>](mexendpoint.md)|Defines a standard endpoint with a fixed IMetadataExchange contract. Since all metadata exchange endpoints specify IMetadataExchange as their contract, you can use this standard point instead of defining one for yourself.|  
|[\<udpAnnouncementEndpoint>](udpannouncementendpoint.md)|Defines a standard endpoint that is used by services to send announcement messages over a UDP binding. It has a fixed contract and supports two discovery versions. In addition it has a fixed UDP binding and a default address value as specified in the WS-Discovery specifications (WS-Discovery April 2005 or WS-Discovery version 1.1). You can specify the multicast address to use for sending and receiving the announcement messages.|  
|[\<udpDiscoveryEndpoint>](udpdiscoveryendpoint.md)|Defines a standard endpoint that is pre-configured for discovery operations over a UDP multicast binding. This endpoint has a fixed contract and supports two WS-Discovery protocol versions. In addition, it has a fixed UDP binding and a default address as specified in the WS-Discovery specifications (WS-Discovery April 2005 or WS-Discovery V1.1).|  
|[\<webHttpEndpoint>](webhttpendpoint.md)|Defines a standard endpoint with a fixed [\<webHttpBinding>](webhttpbinding.md) binding that automatically adds the [\<webHttp>](webhttp.md) behavior. Use this endpoint when writing a REST service.|  
|[\<webScriptEndpoint>](webscriptendpoint.md)|Defines a standard endpoint with a fixed [\<webHttpBinding>](webhttpbinding.md) binding that automatically adds the [\<enableWebScript>](enablewebscript.md) behavior. Use this endpoint when you are writing a service that is called from an ASP.NET AJAX application.|  
|[\<workflowControlEndpoint>](workflowcontrolendpoint.md)|Defines a standard endpoint for controlling the execution of workflow instances (create, run, suspend, terminate, etc).|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|\<system.ServiceModel>|The root element of all WCF configuration elements.|  
  
## See also

- [Standard Endpoints](../../../../../docs/framework/wcf/feature-details/standard-endpoints.md)
