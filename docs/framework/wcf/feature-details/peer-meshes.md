---
title: "Peer Meshes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d93e312e-ac04-40f8-baea-5da1cacb546e
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Peer Meshes
A *mesh* is a named collection (an interconnected graph) of peer nodes that can communicate among themselves and that are identified by a unique mesh ID. Each node is connected to multiple other nodes. In a well-connected mesh, there is a path between any two nodes, with relatively few hops between the nodes on the furthest edges of the mesh, and the mesh will remain connected even if some nodes or connections drop out. Active nodes in the mesh publish their endpoint information with a corresponding mesh ID so that other peers can find them.  
  
## Characteristics of a Mesh Created Using Peer Channel  
  
#### Uniquely Identified  
  
-   A unique ID identifies each mesh. The name of the mesh (or mesh ID) is in the same format as a Domain Name System (DNS) host name. As such, this mesh ID must be unique for the intended client of the application within the scope of the resolver being used. A common name such as "MyFamilysPeers" or "KevinsPokerTable," may easily collide with other user names and may return unintended peer endpoint information, which could result in privacy issues or increase connection latency. One way to avoid these issues may be to add a unique ID as a postfix to the nickname for the mesh (for example, "KevinsPokerTable90210").  
  
#### Message Flooding  
  
-   The mesh allows messages to be propagated from one or more senders to all other peer nodes in the same mesh. Messages flooded by peer nodes use headers specified in the namespace at `http://schemas.microsoft.com/net/2006/05/peer`.  
  
#### Optimized Connections  
  
-   A Peer Channel mesh automatically adjusts when nodes join and leave, ensuring that all nodes have good connectivity with little chance of creating partitions (groups of nodes isolated from each other). Connections in the mesh are also dynamically optimized based on current traffic patterns so that message latency from sender to receiver is as small as possible.  
  
#### Popular Network Features That Peer Channel Does Not Provide  
 It is important to be aware of popular network features that Peer Channel does not provide. These features, which may all be built on top of Peer Channel, include the following:  
  
-   **Message ordering:** Messages originating from a single source may not arrive at all other parties in the same order or in the order that the source sent. Applications that require messages be delivered in a certain order must build it into their applications (for example, by including a monotonically increasing ID with all messages).  
  
-   **Reliable messaging:** Peer Channel does not include a mechanism to ensure message reception by all peers. To guarantee message delivery, you must write a reliability layer on top of Peer Channel.
