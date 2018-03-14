---
title: "Peer Name Resolution Protocol"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 11940511-c124-4d91-ae31-d4ed6e81ee58
caps.latest.revision: 14
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Peer Name Resolution Protocol
In peer-to-peer environments, peers use specific name resolution systems to resolve each other's network locations (addresses, protocols, and ports) from names or other types of identifiers. In the past, peer name resolution has been complicated by the inherently transient connectivity as well as other shortcomings within the Domain Name System (DNS).  
  
 The Microsoft® Windows® Peer-to-Peer Networking platform solves this problem with the Peer Name Resolution Protocol (PNRP), a secure, scalable, and dynamic name registration and name resolution protocol first developed for Windows XP and then upgraded in Windows Vista™. PNRP works very differently from traditional name resolution systems, opening up exciting new possibilities for application developers.  
  
 With PNRP, peer names can be applied to the machine, or individual applications or services on the machine. A peer name resolution includes an address, port, and possibly an extended payload. Benefits of this system include fault tolerance, no bottlenecks, and name resolutions that will never return stale addresses; making the protocol an excellent solution for locating mobile users.  
  
 In terms of security, peer names can be published as secured (protected) or unsecured (unprotected). PNRP uses public key cryptography to protect secure peer names against spoofing; both computers and services can be named with PNRP.  
  
-   The Peer Name Resolution Protocol demonstrates the following properties:  
  
-   Distributed and almost entirely serverless. Servers are only required for the bootstrapping process.  
  
-   Secure name publication without the involvement of third parties. Unlike DNS name publication, PNRP name publication is instantaneous and without financial cost.  
  
-   PNRP updates in real-time, which prevents the resolution of stale addresses.  
  
-   The resolution of names via PNRP extends beyond computers by also allowing name resolution for services.  
  
-  
  
## The System.Net.PeerToPeer Namespace  
  
-   PNRP functionality is defined by the <xref:System.Net.PeerToPeer> namespace within the .NET Framework version 3.5. It provides a set of types that can be used to register and resolve peer names with an available PNRP service.  
  
-  
  
-   (PNRP and custom peer resolvers can be created and instantiated using the types provided in the <xref:System.ServiceModel.PeerResolvers> namespace.)  
  
-  
  
-   The basic types used to register and resolve names with an available PNRP service are as follows:  
  
-  
  
-   <xref:System.Net.PeerToPeer.Cloud>: Defines the information describing an available PNRP cloud, including its scope.  
  
-   <xref:System.Net.PeerToPeer.PeerName>: Defines a peer name that can be used to register and subsequently resolve a peer within a cloud.  
  
-   <xref:System.Net.PeerToPeer.PeerNameRecord>: Defines the record in PNRP cloud that contains the registration information for a peer, which includes the network endpoints at which the peer can be contacted.  
  
-   <xref:System.Net.PeerToPeer.PeerNameRegistration>: Defines the registration process for a peer name, including methods to start and stop peer name registration.  
  
-   <xref:System.Net.PeerToPeer.PeerNameResolver>: Defines the process for resolving a peer name to its network endpoint(s), including both synchronous and asynchronous methods for resolution.  
  
-  
  
-  
  
## See Also  
 <xref:System.ServiceModel.PeerResolvers>  
 <xref:System.Net.PeerToPeer>  
 [Network Programming Samples](../../../docs/framework/network-programming/network-programming-samples.md)  
 [PeerToPeer Technology Sample](http://go.microsoft.com/fwlink/?LinkID=179571)
