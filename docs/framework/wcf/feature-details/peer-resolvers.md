---
title: "Peer Resolvers"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d86d12a1-7358-450f-9727-b6afb95adb9c
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Peer Resolvers
In order to connect to a mesh, a peer node requires the IP addresses of other nodes. IP addresses are obtained by contacting a resolver service, which takes the mesh ID and returns a list of addresses corresponding to nodes registered with that particular mesh ID. The resolver keeps a list of registered addresses, which it creates by having each node in the mesh register with the service.  
  
 You can specify which PeerResolver service to use through the `Resolver` property of the <xref:System.ServiceModel.NetPeerTcpBinding>.  
  
## Supported Peer Resolvers  
 Peer Channel supports two types of resolvers: Peer Name Resolution Protocol (PNRP), and custom resolver services.  
  
 By default, Peer Channel uses the PNRP peer resolver service for discovery of peers and neighbors in the mesh. For situations/platforms where PNRP is not available or feasible, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides an alternative, server-based discovery service - the <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService>. You can also explicitly define a custom resolver service by writing a class that implements the <xref:System.ServiceModel.PeerResolvers.IPeerResolverContract> interface.  
  
### Peer Name Resolution Protocol (PNRP)  
 PNRP, the default resolver for [!INCLUDE[wv](../../../../includes/wv-md.md)], is a distributed, serverless name resolver service. PNRP can also be used on [!INCLUDE[wxpsp2](../../../../includes/wxpsp2-md.md)] by installing the Advanced Networking Pack. Any two clients running the same version of PNRP can locate each other using this protocol, provided they meet certain conditions (such as the lack of an intervening corporate firewall). Note that the version of PNRP that ships with [!INCLUDE[wv](../../../../includes/wv-md.md)] is newer than the version included in the Advanced Networking Pack. Check the Microsoft Download Center for updates to PNRP for [!INCLUDE[wxpsp2](../../../../includes/wxpsp2-md.md)].  
  
### Custom Resolver Services  
 When the PNRP service is unavailable, or you want complete control over mesh shaping, you can use a custom, server-based resolver service. You can explicitly define this service by writing a resolver class implementing the <xref:System.ServiceModel.PeerResolvers.IPeerResolverContract> interface, or by using the in-box default implementation, <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService>.  
  
 Under the default implementation of the service, client registrations expire after a certain amount of time if the client does not explicitly refresh the registration. Clients using the resolver service must be aware of the upper bound on client-server latency in order to successfully refresh registrations in time. This involves choosing an appropriate refresh time-out (`RefreshInterval`) on the resolver service. (For more information, see [Inside the CustomPeerResolverService: Client Registrations](../../../../docs/framework/wcf/feature-details/inside-the-custompeerresolverservice-client-registrations.md).)  
  
 The application writer must also consider securing the connection between clients and the custom resolver service. You may do this by using security settings on the <xref:System.ServiceModel.NetTcpBinding> that clients use to contact the resolver service. You must specify credentials (if used) on the `ChannelFactory` used to create Peer Channel. These credentials are passed to the `ChannelFactory` used to create channels to the custom resolver.  
  
> [!NOTE]
>  When using local and impromptu networks with a custom resolver, it is strongly advised that applications using or supporting link-local or impromptu networks include logic that selects a single link-local address to use when connecting. This prevents any confusion potentially caused by computers with multiple link-local addresses. In accordance with this, Peer Channel only supports using a single link-local address at any one time. You may specify this address with the `ListenIpAddress` property on the <xref:System.ServiceModel.NetPeerTcpBinding>.  
  
 For a demonstration of how to implement a custom resolver, see [Peer Channel Custom Peer Resolver](http://msdn.microsoft.com/library/5b75a2bb-7ff1-4a14-abe7-3debf0537d23).  
  
## In This Section  
 [Inside the CustomPeerResolverService: Client Registrations](../../../../docs/framework/wcf/feature-details/inside-the-custompeerresolverservice-client-registrations.md)  
  
## See Also  
 [Peer Channel Concepts](../../../../docs/framework/wcf/feature-details/peer-channel-concepts.md)  
 [Peer Channel Security](../../../../docs/framework/wcf/feature-details/peer-channel-security.md)  
 [Building a Peer Channel Application](../../../../docs/framework/wcf/feature-details/building-a-peer-channel-application.md)
