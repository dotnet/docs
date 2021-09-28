---
description: "Learn more about: Peer Resolvers"
title: "Peer Resolvers"
ms.date: "03/30/2017"
ms.assetid: d86d12a1-7358-450f-9727-b6afb95adb9c
---
# Peer Resolvers

In order to connect to a mesh, a peer node requires the IP addresses of other nodes. IP addresses are obtained by contacting a resolver service, which takes the mesh ID and returns a list of addresses corresponding to nodes registered with that particular mesh ID. The resolver keeps a list of registered addresses, which it creates by having each node in the mesh register with the service.  
  
 You can specify which PeerResolver service to use through the `Resolver` property of the <xref:System.ServiceModel.NetPeerTcpBinding>.  
  
## Supported Peer Resolvers  

 Peer Channel supports two types of resolvers: Peer Name Resolution Protocol (PNRP), and custom resolver services.  
  
 By default, Peer Channel uses the PNRP peer resolver service for discovery of peers and neighbors in the mesh. For situations/platforms where PNRP is not available or feasible, Windows Communication Foundation (WCF) provides an alternative, server-based discovery service - the <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService>. You can also explicitly define a custom resolver service by writing a class that implements the <xref:System.ServiceModel.PeerResolvers.IPeerResolverContract> interface.  
  
### Peer Name Resolution Protocol (PNRP)  

 PNRP, the default resolver for Windows Vista, is a distributed, serverless name resolver service. PNRP can also be used on Windows XP SP2 by installing the Advanced Networking Pack. Any two clients running the same version of PNRP can locate each other using this protocol, provided they meet certain conditions (such as the lack of an intervening corporate firewall). Note that the version of PNRP that ships with Windows Vista is newer than the version included in the Advanced Networking Pack. Check the Microsoft Download Center for updates to PNRP for Windows XP SP2.  
  
### Custom Resolver Services  

 When the PNRP service is unavailable, or you want complete control over mesh shaping, you can use a custom, server-based resolver service. You can explicitly define this service by writing a resolver class implementing the <xref:System.ServiceModel.PeerResolvers.IPeerResolverContract> interface, or by using the in-box default implementation, <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService>.  
  
 Under the default implementation of the service, client registrations expire after a certain amount of time if the client does not explicitly refresh the registration. Clients using the resolver service must be aware of the upper bound on client-server latency in order to successfully refresh registrations in time. This involves choosing an appropriate refresh time-out (`RefreshInterval`) on the resolver service. (For more information, see [Inside the CustomPeerResolverService: Client Registrations](inside-the-custompeerresolverservice-client-registrations.md).)  
  
 The application writer must also consider securing the connection between clients and the custom resolver service. You may do this by using security settings on the <xref:System.ServiceModel.NetTcpBinding> that clients use to contact the resolver service. You must specify credentials (if used) on the `ChannelFactory` used to create Peer Channel. These credentials are passed to the `ChannelFactory` used to create channels to the custom resolver.  
  
> [!NOTE]
> When using local and impromptu networks with a custom resolver, it is strongly advised that applications using or supporting link-local or impromptu networks include logic that selects a single link-local address to use when connecting. This prevents any confusion potentially caused by computers with multiple link-local addresses. In accordance with this, Peer Channel only supports using a single link-local address at any one time. You may specify this address with the `ListenIpAddress` property on the <xref:System.ServiceModel.NetPeerTcpBinding>.  
  
 For a demonstration of how to implement a custom resolver, see [Peer Channel Custom Peer Resolver](/previous-versions/dotnet/netframework-3.5/ms751466(v=vs.90)).  
  
## In This Section  

 [Inside the CustomPeerResolverService: Client Registrations](inside-the-custompeerresolverservice-client-registrations.md)  
  
## See also

- [Peer Channel Concepts](peer-channel-concepts.md)
- [Peer Channel Security](peer-channel-security.md)
- [Building a Peer Channel Application](building-a-peer-channel-application.md)
