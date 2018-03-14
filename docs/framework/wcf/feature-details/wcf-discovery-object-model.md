---
title: "WCF Discovery Object Model"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8365a152-eacd-4779-9130-bbc48fa5c5d9
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Discovery Object Model
WCF Discovery consists of a set of types that provide a unified programming model that allows you to write services that are discoverable at runtime and clients that find and use these services.  
  
## Making a Service Discoverable and Finding Services  
 To make a WCF service discoverable, add a <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> to the <xref:System.ServiceModel.Description.ServiceDescription> of the service host and add a discovery endpoint. If a service is configured to send announcement messages (by adding an <xref:System.ServiceModel.Discovery.AnnouncementEndpoint>) the announcement is sent when the service host is opened and closed.  
  
 A client that wants to listen for service announcement messages hosts an announcement service and adds one or more announcement endpoints. The announcement service receives announcement messages and raises announcement events.  
  
 A client uses the <xref:System.ServiceModel.Discovery.DiscoveryClient> class to search for available services. The client application instantiates the <xref:System.ServiceModel.Discovery.DiscoveryClient> class, passing in a discovery endpoint that specifies where to send discovery messages. The client calls the <xref:System.ServiceModel.Discovery.DiscoveryClient.Find%2A> method, which sends a `Probe` request. Services listening for discovery messages receive this `Probe` request. If the service matches the criteria specified in the `Probe`, it sends a `ProbeMatch` message back to the client.  
  
## Object Model  
 The WCF Discovery API defines the following classes:  
  
-   <xref:System.ServiceModel.Discovery.AnnouncementClient>  
  
-   <xref:System.ServiceModel.Discovery.AnnouncementEndpoint>  
  
-   <xref:System.ServiceModel.Discovery.AnnouncementService>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryClient>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryEndpoint>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryClientBindingElement>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryMessageSequenceGenerator>  
  
-   <xref:System.ServiceModel.Discovery.ServiceDiscoveryMode>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryProxy>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryService>  
  
-   <xref:System.ServiceModel.Discovery.DiscoveryVersion>  
  
-   <xref:System.ServiceModel.Discovery.DynamicEndpoint>  
  
-   <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior>  
  
-   <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata>  
  
-   <xref:System.ServiceModel.Discovery.FindCriteria>  
  
-   <xref:System.ServiceModel.Discovery.FindRequestContext>  
  
-   <xref:System.ServiceModel.Discovery.FindResponse>  
  
-   <xref:System.ServiceModel.Discovery.ResolveCriteria>  
  
-   <xref:System.ServiceModel.Discovery.ResolveResponse>  
  
-   <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior>  
  
-   <!--zz <xref:System.ServiceModel.Discovery.ServiceDiscoveryExtension> --> `ServiceDiscoveryExtension`  
  
-   <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint>  
  
-   <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint>  
  
## AnnouncementClient  
 The <xref:System.ServiceModel.Discovery.AnnouncementClient> class provides synchronous and asynchronous methods for sending announcement messages. There are two types of announcement messages, Hello and Bye. A Hello message is sent to indicate that a service has become available and a Bye message is sent to indicate that an existing service has become unavailable. The developer creates an <xref:System.ServiceModel.Discovery.AnnouncementClient> instance, passing an instance of <xref:System.ServiceModel.Discovery.AnnouncementEndpoint> as a constructor parameter.  
  
## AnnouncementEndpoint  
 <xref:System.ServiceModel.Discovery.AnnouncementEndpoint> represents a standard endpoint with a fixed announcement contract. It is used by a service or client to send and receive announcement messages. By default, the <xref:System.ServiceModel.Discovery.AnnouncementEndpoint> class is set to use the WS_Discovery 11 protocol version.  
  
## AnnouncementService  
 <xref:System.ServiceModel.Discovery.AnnouncementService> is a system-provided implementation of an announcement service that receives and processes announcement messages. When a Hello or Bye message is received, the <xref:System.ServiceModel.Discovery.AnnouncementService> instance calls the appropriate virtual method <xref:System.ServiceModel.Discovery.AnnouncementService.OnBeginOnlineAnnouncement%2A> or <xref:System.ServiceModel.Discovery.AnnouncementService.OnBeginOfflineAnnouncement%2A>, which raises announcement events.  
  
## DiscoveryClient  
 The <xref:System.ServiceModel.Discovery.DiscoveryClient> class is used by a client application to find and resolve available services. It provides synchronous and asynchronous methods for finding and resolving services based on the specified <xref:System.ServiceModel.Discovery.FindCriteria> and <xref:System.ServiceModel.Discovery.ResolveCriteria> respectively. The developer creates a <xref:System.ServiceModel.Discovery.DiscoveryClient> instance and provides an instance of <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> as a constructor parameter.  
  
 To find a service, the developer invokes the synchronous or asynchronous `Find` method, which provides a <!--zz <xref:System.ServiceModel.Discription.FindCriteria> --> `FindCriteria` instance that contains the search criteria to use. The <xref:System.ServiceModel.Discovery.DiscoveryClient> creates a `Probe` message with the appropriate headers, and sends the find request. Because there can be more than one outstanding `Find` request at any time, the client correlates the received responses and validates the response. It then delivers the results to the caller of the `Find` operation using <xref:System.ServiceModel.Discovery.FindResponse>.  
  
 To resolve a known service, the developer invokes the synchronous or asynchronous `Resolve` method that provides an instance of <!--zz <xref:System.ServiceModel.ResolveCriteria>--> `ResolveCriteria` that contains the <xref:System.ServiceModel.EndpointAddress> of the known service. The <xref:System.ServiceModel.Discovery.DiscoveryClient> creates the `Resolve` message with the appropriate headers and sends the resolve request. The received response is correlated against the outstanding resolve requests and the result is delivered to the caller of the `Resolve` operation using <xref:System.ServiceModel.Discovery.ResolveResponse>.  
  
 If a discovery proxy is present on the network and the <!--zz <xref:System.ServiceModel.Discover.DiscoveryClient> --> `DiscoveryClient` sends the discovery request in a multicast fashion, the discovery proxy can respond with the multicast suppression Hello message. The <!--zz <xref:System.ServiceModel.Discover.DiscoveryClient> --> `DiscoveryClient` raises the `ProxyAvailable` event when it receives Hello messages in response to outstanding `Find` or `Resolve` requests. The `ProxyAvailable` event contains the <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata> about the discovery proxy. It is up to the developer to use this information to switch from Ad hoc to Managed mode.  
  
## DiscoveryEndpoint  
 <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> represents a standard endpoint with a fixed discovery contract. It is used by a service or client to send or receive discovery messages. By default, <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> is set to use <!--zz <xref:System.ServiceModel.Discovery.DiscoveryMode.Managed>--> `Managed` mode and the WSDiscovery11 WS-Discovery version.  
  
## DiscoveryMessageSequenceGenerator  
 <xref:System.ServiceModel.Discovery.DiscoveryMessageSequenceGenerator> is used to generate a <xref:System.ServiceModel.Discovery.DiscoveryMessageSequence> when the service is sending out Discovery or Announcement messages.  
  
## DiscoveryService  
 The <xref:System.ServiceModel.Discovery.DiscoveryService> abstract class provides a framework for receiving and processing `Probe` and `Resolve` messages. When a `Probe` message is received, <xref:System.ServiceModel.Discovery.DiscoveryService> creates an instance of <xref:System.ServiceModel.Discovery.FindRequestContext> based on the incoming message and invokes the <xref:System.ServiceModel.Discovery.DiscoveryService.OnBeginFind%2A> virtual method. When a `Resolve` message is received, <xref:System.ServiceModel.Discovery.DiscoveryService> invokes the <xref:System.ServiceModel.Discovery.DiscoveryService.OnBeginResolve%2A> virtual method. You can inherit from this class to provide a custom Discovery Service implementation.  
  
## DiscoveryProxy  
 The <xref:System.ServiceModel.Discovery.DiscoveryProxy> abstract class provides a framework for receiving and processing discovery and announcement messages. You inherit from this class when you are implementing a custom discovery proxy. When a `Probe` message is received over multicast, the <xref:System.ServiceModel.Discovery.DiscoveryProxy> class calls the `BeginShouldRedirectFind` virtual method to determine whether a multicast suppression message should to be sent. If the developer decides not to send a multicast suppression message or if the `Probe` message was received over unicast, it creates an instance of the <xref:System.ServiceModel.Discovery.FindRequestContext> class based on the incoming message and invokes the `OnBeginFind` virtual method. When a `Resolve` message is received over multicast, The <xref:System.ServiceModel.Discovery.DiscoveryProxy> class calls the `ShouldRedirectResolve` virtual method to determine whether a multicast suppression message should to be sent. If the developer decides not to send a multicast suppression message or if the `Resolve` message was received over unicast, it creates an instance of the <xref:System.ServiceModel.Discovery.ResolveCriteria> class based on the incoming message and invokes the `OnBeginResolve` virtual method. When a Hello or Bye message is received, <xref:System.ServiceModel.Discovery.DiscoveryProxy> calls the appropriate virtual method (`OnBeginOnlineAnnouncement` or `OnBeingOfflineAnnouncement`), which raises announcement events.  
  
## DiscoveryVersion  
 The <xref:System.ServiceModel.Discovery.DiscoveryVersion> class represents the discovery protocol version to use.  
  
## EndpointDiscoveryBehavior  
 The <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior> class is used to control the discoverability of an endpoint, specify the extensions, additional contract type names. and the scopes associated with that endpoint. This behavior is added to an application endpoint to configure its <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata>. When <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> is added to the service host, all the application endpoints hosted by the service host by default become discoverable. The developer can turn off discovery for a specific endpoint by setting the <!--zz <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior.Enable%2A>--> `Enable` property to `false`.  
  
## EndpointDiscoveryMetadata  
 The <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata> class provides a version-independent representation of an endpoint published by the service. It contains endpoint addresses, listen URIs, contract type names, scopes, metadata version and extensions specified by the service developer. The <xref:System.ServiceModel.Discovery.FindCriteria> sent by the client during a `Probe` operation is matched against the <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata>. If the criteria matches, then the <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata> is returned to the client. The endpoint address in <xref:System.ServiceModel.Discovery.ResolveCriteria> is matched against the endpoint address of <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata>. If the criteria matches, then the <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata> is returned to the client.  
  
## FindCriteria  
 The <xref:System.ServiceModel.Discovery.FindCriteria> class is a version-independent class used to specify the criteria used when finding a service. It fully supports the WS-Discovery-defined criteria for matching services. It also has extensions that developers can use to specify custom values that can be used during the matching process. The developer can provide the termination criteria for the `Find` operation by specifying the <!--zz <xref:System.ServiceModel.Discovery.FindCriteria.MaxResult%2A>--> `MaxResult`, which specifies the total number of services the developer is looking for or that specifies the <xref:System.ServiceModel.Discovery.FindCriteria.Duration%2A>, which is the value that specifies how long the client waits for responses.  
  
## FindRequestContext  
 The <xref:System.ServiceModel.Discovery.FindRequestContext> class is instantiated by the discovery service based on the `Probe` message it receives when a client initiates a `Find` operation. It contains an instance of <xref:System.ServiceModel.Discovery.FindCriteria> that was specified by the client.  
  
## FindResponse  
 The <xref:System.ServiceModel.Discovery.FindResponse> class is returned to the caller of <xref:System.ServiceModel.Discovery.DiscoveryClient.Find%2A> with the responses of the `Find` operation. It is also present in <xref:System.ServiceModel.Discovery.FindCompletedEventArgs>. It contains a collection of <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata>, which is the collection of discovered endpoints and a dictionary of <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata> and <xref:System.ServiceModel.Discovery.DiscoveryMessageSequence>.  
  
## ResolveCriteria  
 The <xref:System.ServiceModel.Discovery.ResolveCriteria> class is a version-independent class used to specify the criteria used when resolving an already known service. It contains the endpoint address of the known service. The developer can provide the termination criteria for the resolve operation by specifying the <xref:System.ServiceModel.Discovery.ResolveCriteria.Duration%2A>, which specifies how long the client waits for responses.  
  
## ResolveResponse  
 The <xref:System.ServiceModel.Discovery.ResolveResponse> is returned to the caller of the <xref:System.ServiceModel.Discovery.DiscoveryClient.Resolve%2A> method with the response of the `Resolve` operation. It is also present in <xref:System.ServiceModel.Discovery.ResolveCompletedEventArgs>. It contains an instance of <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata>, which is the discovered endpoints and an instance of <xref:System.ServiceModel.Discovery.DiscoveryMessageSequence>.  
  
## ServiceDiscoveryBehavior  
 The <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> class allows the developer to add the discovery feature to a service. You add this behavior to the <xref:System.ServiceModel.ServiceHost>. The <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> class iterates over the application endpoints added to the service host and creates a collection of <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata> from the discoverable endpoints. All endpoints are discoverable by default. The discoverability of a particular endpoint can be controlled by adding the <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior> to that particular endpoint. If announcement endpoints are added to <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> then the announcement of all discoverable endpoints is sent over each of the announcement endpoints when the service host is opened or closed.  
  
## ServiceDiscoveryExtension  
 The <!--zz <xref:System.ServiceModel.Discovery.ServiceDiscoveryExtension> --> `ServiceDiscoveryExtension` class is created by the <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> class. The endpoints that are made discoverable can be obtained from <!--zz <xref:System.ServiceModel.Discovery.ServiceDiscoveryExtension> --> `ServiceDiscoveryExtension`. This class is also used to specify a custom discovery service implementation.  
  
## UdpAnnouncementEndpoint  
 The <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint> class is a standard announcement endpoint that is pre-configured for announcement over a UDP multicast binding. By default, <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint> is set to use the WSApril2005 WS_Discovery version.  
  
## UdpDiscoveryEndpoint  
 The <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> class is a standard discovery endpoint that is pre-configured for discovery over a UDP multicast binding. By default, <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> is set to use the WSDiscovery11 WS-Discovery version and <!--zz <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint.Adhoc>--> `Adhoc` mode.
