---
title: "IPv6 Auto-Configuration"
description: Learn how IPv6 supports node Plug and Play, where a node joins an IPv6 network and is configured without human intervention. 
ms.date: "03/30/2017"
ms.assetid: 581c1d21-1013-43a3-bf3e-2d9ead62b79c
---
# IPv6 Auto-Configuration

One important goal for IPv6 is to support node Plug and Play. That is, it should be possible to plug a node into an IPv6 network and have it automatically configured without any human intervention.  
  
## Type of Auto-Configuration  

 IPv6 supports the following types of auto-configuration:  
  
- **Stateful auto-configuration**. This type of configuration requires a certain level of human intervention because it needs a Dynamic Host Configuration Protocol for IPv6 (DHCPv6) server for the installation and administration of the nodes. The DHCPv6 server keeps a list of nodes to which it supplies configuration information. It also maintains state information so the server knows how long each address is in use, and when it might be available for reassignment.  
  
- **Stateless auto-configuration**. This type of configuration is suitable for small organizations and individuals. In this case, each host determines its addresses from the contents of received router advertisements. Using the IEEE EUI-64 standard to define the network ID portion of the address, it is reasonable to assume the uniqueness of the host address on the link.  
  
 Regardless of how the address is determined, the node must verify that its potential address is unique to the local link. This is done by sending a neighbor solicitation message to the potential address. If the node receives any response, it knows that the address is already in use and must determine another address.  
  
## IPv6 Mobility  

 The proliferation of mobile devices has introduced a new requirement: A device must be able to arbitrarily change locations on the IPv6 Internet and still maintain existing connections. To provide this functionality, a mobile node is assigned a home address at which it can always be reached. When the mobile node is at home, it connects to the home link and uses its home address. When the mobile node is away from home, a home agent, which is usually a router, relays messages between the mobile node and nodes with which it is communicating.  
  
## See also

- [Internet Protocol Version 6](internet-protocol-version-6.md)
- [Sockets](sockets.md)
