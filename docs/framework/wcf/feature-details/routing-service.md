---
title: "Routing Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ca7c216a-5141-4132-8193-102c181d2eba
caps.latest.revision: 13
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Routing Service
The Routing Service is a generic SOAP intermediary that acts as a message router. The core functionality of the Routing Service is the ability to route messages based on message content, which allows a message to be forwarded to a client endpoint based on a value within the message itself, in either the header or the message body.  
  
 The <xref:System.ServiceModel.Routing.RoutingService> is implemented as a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service in the <xref:System.ServiceModel.Routing> namespace. The Routing Service exposes one or more service endpoints that receive messages and then routes each message to one or more client endpoints based on the message content. The service provides the following features:  
  
-   Content-based routing  
  
    -   Service aggregation  
  
    -   Service versioning  
  
    -   Priority routing  
  
    -   Dynamic configuration  
  
-   Protocol bridging  
  
-   SOAP processing  
  
-   Advanced error handling  
  
-   Backup endpoints  
  
 While it is possible to create an intermediary service that accomplishes one or more of these goals, often such an implementation is tied to a specific scenario or solution and cannot be readily applied to new applications.  
  
 The Routing Service provides a generic, dynamically configurable, pluggable SOAP intermediary that is compatible with the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Service and Channel models and allows you to perform content-based routing of SOAP-based messages.  
  
> [!NOTE]
>  The Routing Service does not currently support routing of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] REST services.  To route REST calls, consider using <xref:System.Web.Routing> or [Application Request Routing](http://go.microsoft.com/fwlink/?LinkId=164589) (http://go.microsoft.com/fwlink/?LinkId=164589).  
  
## Content-Based Routing  
 Content-based routing is the ability to route a message based on one or more values contained within the message. The Routing Service inspects each message and routes it to the destination endpoint based on the message contents and the routing logic you create. Content-based routing provides the basis for service aggregation, service versioning, and priority routing.  
  
 To implement content-based routing, the Routing Service relies on <xref:System.ServiceModel.Dispatcher.MessageFilter> implementations that are used to match specific values within the messages to be routed. If a **MessageFilter** matches a message, the message is routed to the destination endpoint associated with the **MessageFilter**.  Message filters are grouped together into filter tables (<xref:System.ServiceModel.Routing.Configuration.FilterTableCollection>) to construct complex routing logic. For example, a filter table might contain five mutually exclusive message filters that cause messages to be routed to only one of the five destination endpoints.  
  
 The Routing Service allows you to configure the logic that is used to perform content-based routing, as well as dynamically update the routing logic at run time.  
  
 Through the grouping of message filters into filter tables, routing logic can be constructed that allows you to handle multiple routing scenarios such as:  
  
-   Service aggregation  
  
-   Service versioning  
  
-   Priority routing  
  
-   Dynamic configuration  
  
 For more information about message filters and filter tables, see [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md) and [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md).  
  
### Service Aggregation  
 By using content-based routing, you can expose one endpoint that receives messages from external client applications and then routes each message to the appropriate internal endpoint based on a value within the message. This is useful to offer one specific endpoint for a variety of back-end applications, and also to present one application endpoint to customers while factoring your application into a variety of services.  
  
### Service Versioning  
 When migrating to a new version of your solution, you may have to maintain the old version in parallel to serve existing customers. Often this requires that clients connecting to the newer version must use a different address when communicating with the solution. The Routing Service allows you to expose one service endpoint that serves both versions of your solution by routing messages to the appropriate solution based on version-specific information contained in the message. For an example of such an implementation see [How To: Service Versioning](../../../../docs/framework/wcf/feature-details/how-to-service-versioning.md).  
  
### Priority Routing  
 When providing a service for multiple clients, you may have a service level agreement (SLA) with some partners that requires all data from these partners to be processed separately from that of other clients. By using a filter that looks for customer-specific information contained in the message, you can easily route messages from specific partners to an endpoint that has been created to meet their SLA requirements.  
  
## Dynamic Configuration  
 To support mission-critical systems, where messages must be processed without any service interruptions, it is vital that you be able to modify the configuration of components within the system at run time. To support this need, the Routing Service provides an <xref:System.ServiceModel.IExtension%601> implementation, the <xref:System.ServiceModel.Routing.RoutingExtension>, which allows dynamic updating of the Routing Service configuration at run time.  
  
 For more information about dynamic configuration of the Routing Service, see [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md).  
  
## Protocol Bridging  
 One of the challenges in intermediary scenarios is that the internal endpoints may have different transport or SOAP version requirements than the endpoint that messages are received on. To support this scenario, the Routing Service can bridge protocols, including processing the SOAP message to the <xref:System.ServiceModel.Channels.MessageVersion> required by the destination endpoint(s). In this way, one protocol can be used for internal communication, while another can be used for external communication.  
  
 To support the routing of messages between endpoints with different transports, the Routing Service uses system-provided bindings that enable the service to bridge dissimilar protocols. This occurs automatically when the service endpoint exposed by the Routing Service uses a different protocol than the client endpoints that messages are routed to.  
  
## SOAP Processing  
 A common routing requirement is the ability to route messages between endpoints with differing SOAP requirements. To support this requirement, the Routing Service provides a <xref:System.ServiceModel.Routing.SoapProcessingBehavior> that automatically creates a new **MessageVersion** that meets the requirements of the destination endpoint before the message is routed to it. This behavior also creates a new **MessageVersion** for any response message before returning it to the requesting client application, to ensure that the **MessageVersion** of the response matches that of the original request.  
  
 For more information about SOAP processing, see [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md).  
  
## Error Handling  
 In a system composed of distributed services that rely on network communications, it is important to ensure that communications within your system are resistant to transient network failures.  The Routing Service implements error handling that allows you to handle many communication failure scenarios that might otherwise result in a service outage.  
  
 If the Routing Service encounters a <xref:System.ServiceModel.CommunicationException> while attempting to send a message, error handling will take place.  These exceptions typically indicate that a problem was encountered while attempting to communicate with the defined client endpoint, such as an <xref:System.ServiceModel.EndpointNotFoundException>, <xref:System.ServiceModel.ServerTooBusyException>, or <xref:System.ServiceModel.CommunicationObjectFaultedException>.  The error-handling code will also catch and attempt to retry sending when a **TimeoutException** occurs, which is another common exception that is not derived from **CommunicationException**.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] error handling, see [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md).  
  
## Backup Endpoints  
 In addition to the destination client endpoints associated with each filter definition in the filter table, you can also create a list of backup endpoints that the message will be routed to in the event of a transmission failure. If an error occurs and a backup list is defined for the filter entry, the Routing Service will attempt to send the message to the first endpoint defined in the list. If this transmission attempt fails, the service will try the next endpoint, and continue this process until the transmission attempt succeeds, returns a non-transmission related error, or all endpoints in the backup list have returned a transmission error.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] backup endpoints, see [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md) and [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md).  
  
## Streaming  
 The routing service can successfully stream messages if you set the binding to support streaming.  However, there are some conditions under which messages may need to buffered:  
  
-   Multicast (buffer to create additional message copies)  
  
-   Failover (buffer in case the message needs to be sent to a backup)  
  
-   System.ServiceModel.Routing.RoutingConfiguration.RouteOnHeadersOnly is false (buffer to present the MessageFilterTable with a MessageBuffer so that filters can inspect the body)  
  
-   Dynamic configuration  
  
## See Also  
 [Routing Introduction](../../../../docs/framework/wcf/feature-details/routing-introduction.md)  
 [Routing Contracts](../../../../docs/framework/wcf/feature-details/routing-contracts.md)  
 [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md)
