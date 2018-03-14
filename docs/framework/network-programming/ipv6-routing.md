---
title: "IPv6 Routing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c98731b4-b542-46a2-9947-1cea63c186b2
caps.latest.revision: 4
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# IPv6 Routing
A flexible routing mechanism is a benefit of IPv6. Due to the way in which IPv4 network IDs were and are allocated, large routing tables need to be maintained by the routers that are on the Internet backbones. These routers must know all the routes in order to forward packets that are potentially directed to any node on the Internet. With its ability to aggregate addresses, IPv6 allows flexible addressing and drastically reduces the size of routing tables. In this new addressing architecture, intermediate routers must keep track only of the local portion of their network in order to forward the messages appropriately.  
  
## Neighbor Discovery  
 Some of the features provided by Neighbor Discovery are:  
  
-   Router discovery. This allows hosts to identify local routers.  
  
-   Address resolution. This allows nodes to resolve a link-layer address for a corresponding next-hop address (a replacement for Address Resolution Protocol [ARP]).  
  
-   Address auto-configuration. This allows hosts to automatically configure site-local and global addresses.  
  
 Neighbor Discovery uses Internet Control Message Protocol for IPv6 (ICMPv6) messages that include:  
  
-   Router advertisement. Sent by a router on a pseudo-periodic basis or in response to a router solicitation. IPv6 routers use router advertisements to advertise their availability, address prefixes, and other parameters.  
  
-   Router solicitation. Sent by a host to request that routers on the link send a router advertisement immediately.  
  
-   Neighbor solicitation. Sent by nodes for address resolution, duplicate address detection, or to verify that a neighbor is still reachable.  
  
-   Neighbor advertisement. Sent by nodes to respond to a neighbor solicitation or to notify neighbors of a change in link-layer address.  
  
-   Redirect. Sent by routers to indicate a better next-hop address to a particular destination for a sending node.  
  
## See Also  
 [Internet Protocol Version 6](../../../docs/framework/network-programming/internet-protocol-version-6.md)  
 [Sockets](../../../docs/framework/network-programming/sockets.md)
