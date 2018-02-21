---
title: "PNRP Caches"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 270068d9-1b6b-4eb9-9e14-e02326bb88df
caps.latest.revision: 4
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# PNRP Caches
Peer Name Resolution Protocol (PNRP) caches are local collections of algorithmically selected peer endpoints maintained on the peer.  
  
## PNRP Cache Initialization  
 To initialize the PNRP cache, or Peer Name Record Collection, when a peer node starts up, a node can use the following methods:  
  
-   Persistent cache entries that were present when the node was shut down are loaded from hard disk storage.  
  
-   If an application uses the P2P collaboration infrastructure, collaboration information is available in the Contact Manager for that node.  
  
## Scaling Peer Name Resolution with a Multi-Level Cache  
 To keep the sizes of the PNRP caches small, peer nodes use a multi-level cache, in which each level contains a maximum number of entries. Each level in the cache represents a one tenth smaller portion of the PNRP ID number space (2<sup>256</sup>). The lowest level in the cache contains a locally registered PNRP ID and other PNRP IDs that are numerically close to it. As a level of the cache is filled with a maximum of 20 entries, a new lower level is created. The maximum number of levels in the cache is on the order of log10(Total number of PNRP IDs in the cloud). For example, for a global cloud with 100 million PNRP IDs, there are no more than 8 (=log10(100,000,000)) levels in the cache and a similar number of hops to resolve a PNRP ID during name resolution. This mechanism allows for a distributed hash table for which an arbitrary PNRP ID can be resolved by forwarding PNRP Request messages to the next-closest peer until the peer with the corresponding CPA is found.  
  
 To ensure that resolution can complete, each time a node adds an entry to the lowest level of its cache, it floods a copy of the entry to all the nodes within the last level of the cache.  
  
 The cache entries are refreshed over time. Cache entries that are stale are removed from the cache. The result is that the distributed hash table of PNRP IDs is based on active endpoints, unlike DNS in which address records and the DNS protocol provide no guarantee that the node associated with the address is actively on the network.  
  
## Other PNRP Caches  
 Another persistent data store is the local cache.  In addition to the other objects needed for PNRP activity, it may include the records associated with a PNRP cloud or collaboration session that is securely published and synchronized between all the members of the cloud. This replicated store represents the view of the group data, which should be the same for all group members. Technically, these objects are not records per se, but rather application, presence, and object data destined for a local cache. Use of the PNRP cloud ensures that objects are propagated to all nodes in the collaboration session or PNRP cloud.  Record replication between cloud members uses SSL to provide encryption and data integrity.  
  
 When a peer joins a cloud, they do not automatically receive local cache data from the host peer to which they attach; they have to subscribe to the host peer to receive updates in application, presence, and object data. After the initial synchronization, peers periodically resynchronize their replicated stores to ensure that all group members consistently have the same view.  The collaboration session or applications within the collaboration session may also perform the same function.  
  
 After a collaboration session has begun for a cloud, applications can register peers and begin publishing their information using the security defined by the cloud scope. When a peer joins a cloud, the security mechanisms for the cloud are applied to the peer, giving it a scope in which to participate.  Its records can then be published securely within the scope of the cloud. Note that cloud scope may not be the same as collaboration application scope.  
  
 Peers can register interest in receiving objects from other peers. When an object is updated, the collaboration application is notified and the new object is passed to all subscribers of the application. For example, a peer in a group chat application can register interest in receiving application information, which will send it all chat records as application data.  This allows it to monitor chat activity within the cloud.  
  
## See Also  
 <xref:System.Net.PeerToPeer>
