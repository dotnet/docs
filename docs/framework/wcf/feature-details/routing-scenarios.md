---
title: "Routing Scenarios"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "rounting [WCF], scenarios"
ms.assetid: ec22f308-665a-413e-9f94-7267cb665dab
caps.latest.revision: 7
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Routing Scenarios
While the Routing Service is highly customizable, it can be a challenge to design efficient routing logic when creating a new configuration from scratch.  However, there are several common scenarios that most Routing Service configurations follow. While these scenarios may not apply directly to your specific configuration, understanding how the Routing Service can be configured to handle these scenarios will aid you in understanding the Routing Service.  
  
## Common Scenarios  
 The most basic use of the Routing Service is to aggregate multiple destination endpoints to reduce the number of endpoints exposed to the client applications, and then use message filters to route each message to the correct destination. Messages may be routed based on logical or physical processing requirements, such as a message type that must be processed by a specific service, or based on arbitrary business needs such as providing priority processing of messages from a specific source. The following table lists some of the common scenarios and when they are encountered:  
  
|Scenario|Use when|  
|--------------|--------------|  
|Service versioning|You need to support multiple versions of a service or may deploy an updated service in the future|  
|Service data partitioning|You must partition a service across multiple hosts|  
|Dynamic update|You must dynamically reconfigure routing logic at runtime to handle changing service deployments|  
|Multicast|You must send one message to multiple endpoints|  
|Protocol bridging|You receive messages over one transport protocol, and the destination endpoint uses a different protocol|  
|Error Handling|You need to provide resilience to network outages and communication failures|  
  
> [!NOTE]
>  While many of the scenarios presented are specific to certain business needs or processing requirements, planning to support dynamic updates and utilizing error handling can often be considered as best practices as they allow you to modify routing logic at runtime and recover from transient network and communication failures.  
  
### Service Versioning  
 When introducing a new version of a service, you must often maintain the previous version until all clients have transitioned to the new service. This is especially critical if the service is a long-running process that takes days, weeks, or even months to complete. Usually this requires implementing a new endpoint address for the new service while maintaining the original endpoint for the previous version.  
  
 By using the Routing Service, you can expose one endpoint to receive messages from client applications and then route each message to the correct service version based on the message content. The most basic implementation involves adding a custom header to the message that indicates the version of the service that the message is to be processed by. The Routing Service can use the XPathMessageFilter to inspect each message for the presence of the custom header and route the message to the appropriate destination endpoint.  
  
 For the steps used to create a service versioning configuration, see [How To: Service Versioning](../../../../docs/framework/wcf/feature-details/how-to-service-versioning.md). For an example of using the XPathMessageFilter to route messages based on a custom header, see the [Advanced Filters](../../../../docs/framework/wcf/samples/advanced-filters.md) sample.  
  
### Service Data Partitioning  
 When designing a distributed environment, it is often desirable to spread processing load across multiple computers in order to provide high availability, decrease processing load on individual computers, or to provide dedicated resources for a specific subset of messages. While the Routing Service does not replace a dedicated load balancing solution, its ability to perform content based routing can be used to route otherwise similar messages to specific destinations. For example, you may have a requirement to process messages from a specific client separately from messages received from other clients.  
  
 For the steps used to create a service data partitioning configuration, see [How To: Service Data Partitioning](../../../../docs/framework/wcf/feature-details/how-to-service-data-partitioning.md). For an example of using filters to partition data based on URL and custom headers, see the [Advanced Filters](../../../../docs/framework/wcf/samples/advanced-filters.md) sample.  
  
### Dynamic Routing  
 Often it is desirable to modify the routing configuration to satisfy changing business needs, such as adding a route to a newer version of a service, changing routing criteria, or changing the destination endpoint a specific message that the filter routes to. The Routing Service allows you to do this through the <xref:System.ServiceModel.Routing.RoutingExtension>, which allows you to provide a new RoutingConfiguration during run time. The new configuration takes effect immediately, but only affects any new sessions processed by the Routing Service.  
  
 For the steps used to implement dynamic routing, see [How To: Dynamic Update](../../../../docs/framework/wcf/feature-details/how-to-dynamic-update.md). For an example of using dynamic routing, see the [Dynamic Reconfiguration](../../../../docs/framework/wcf/samples/dynamic-reconfiguration.md) sample.  
  
### Multicast  
 When routing messages, usually you routing each message to one specific destination endpoint.  However, you may occasionally need to route a copy of the message to multiple destination endpoints. To perform multicast routing, the following conditions must be true:  
  
-   The channel shape must not be request-reply (though it may be one-way or duplex,) because request-reply mandates that only one reply can be received by the client application in response to the request.  
  
-   Multiple filters must return **true** when evaluating the message.  
  
 If these conditions are met, each destination endpoint that is associated with a filter that returns true will receive a copy of the message.  
  
### Protocol Bridging  
 When routing messages between dissimilar SOAP protocols, the Routing Service uses WCF APIs to convert the message from one protocol to the other. This occurs automatically when the service endpoint(s) exposed by the Routing Service use a different protocol than the client endpoint(s) that messages are routed to. It is possible to disable this behavior if the protocols in use are not standard; however, you must then provide your own bridging code.  
  
 . For an example of using the Routing Service to translate messages between protocols, see the [Bridging and Error Handling](../../../../docs/framework/wcf/samples/bridging-and-error-handling.md) sample.  
  
### Error Handling  
 In a distributed environment, it is not uncommon to encounter transient network or communication failures. Without an intermediary service such as the Routing Service, the burden of handling such failures falls on the client application. If the client application does not include specific logic to retry in the event of network or communication failures and knowledge of alternate locations, the user may encounter scenarios where a message must be submitted multiple times before it is successfully processed by the destination service. This can lead to customer dissatisfaction with the application, as it may be perceived as unreliable.  
  
 The Routing Service attempts to remedy this scenario by providing robust error handling capabilities for messages that encounter network or communication-related failures. By creating a list of possible destination endpoints and associating this list with each message filter, you remove the single point of failure incurred by having only one possible destination. In the event of a failure, the Routing Service will attempt to deliver the message to the next endpoint in the list until the message has been delivered, a non-communication failure occurs, or all endpoints have been exhausted.  
  
 For the steps used to configure error handling, see [How To: Error Handling](../../../../docs/framework/wcf/feature-details/how-to-error-handling.md). For an example of implementing error handling, see the [Bridging and Error Handling](../../../../docs/framework/wcf/samples/bridging-and-error-handling.md) and [Advanced Error Handling](../../../../docs/framework/wcf/samples/advanced-error-handling.md) samples.  
  
### In This Section  
 [How To: Service Versioning](../../../../docs/framework/wcf/feature-details/how-to-service-versioning.md)  
  
 [How To: Service Data Partitioning](../../../../docs/framework/wcf/feature-details/how-to-service-data-partitioning.md)  
  
 [How To: Dynamic Update](../../../../docs/framework/wcf/feature-details/how-to-dynamic-update.md)  
  
 [How To: Error Handling](../../../../docs/framework/wcf/feature-details/how-to-error-handling.md)  
  
## See Also  
 [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md)
