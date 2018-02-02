---
title: "Peer Name Publication and Resolution"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f0370e08-9fa6-4ee5-ab78-9a58a20a7da2
caps.latest.revision: 5
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Peer Name Publication and Resolution
## Publishing a Peer Name  
 To publish a new PNRP ID, a peer performs the following:  
  
-   Sends PNRP publication messages to its cache neighbors (the peers that have registered PNRP IDs in the lowest level of the cache) to seed their caches.  
  
-   Chooses random nodes in the cloud that are not its neighbors and sends them PNRP name resolution requests for its own P2P ID. The resulting endpoint determination process seeds the caches of random nodes in the cloud with the PNRP ID of the publishing peer.  
  
-  
  
 PNRP version 2 nodes do not publish PNRP IDs if they are only resolving other P2P IDs. The HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\PeerNet\PNRP\IPV6-Global\SearchOnly=1 registry value (REG_DWORD type) specifies that peers only use PNRP for name resolution, never for name publication. This registry value can also be configured through Group Policy.  
  
## Resolving a Peer Name  
 Locating other peers in a PNRP network or cloud is a process comprised of two phases:  
  
1.  Endpoint Determination  
  
2.  PNRP ID Resolution  
  
 In the endpoint determination phase, a peer that is attempting to resolve the PNRP ID of a service on another computer determines the IPv6 address of that remote peer.  The remote peer is the one that published, or is associated with, the PNRP ID of the computer or service.  
  
 After confirming that the remote endpoint has been registered into the PNRP cloud, the requesting peer in the PNRP ID resolution phase sends a request to that peer endpoint for the PNRP ID of the desired service. The endpoint sends a reply confirming the PNRP ID of the service, a comment, and up to 4 kilobytes of additional information that the requesting peer can use for future communication. For example, if the desired endpoint is a gaming server, the additional peer name record data can contain information about the game, the level of play, and the current number of players.  
  
 In the endpoint determination phase, PNRP uses an iterative process for locating the node that published the PNRP ID, in which the node performing the resolution is responsible for contacting nodes that are successively closer to the target PNRP ID.  
  
 To perform name resolution in PNRP, the peer examines the entries in its own cache for an entry that matches the target PNRP ID. If found, the peer sends a PNRP Request message to the peer and waits for a response. If an entry for the PNRP ID is not found, the peer sends a PNRP Request message to the peer that corresponds to the entry that has a PNRP ID that most closely matches the target PNRP ID. The node that receives the PNRP Request message examines its own cache and does the following:  
  
-   If the PNRP ID is found, the requested endpoint peer replies directly to the requesting peer.  
  
-   If the PNRP ID is not found and a PNRP ID in the cache is closer to the target PNRP ID, the requested peer sends a response to the requesting peer containing the IPv6 address of the peer that represents the entry with a PNRP ID that more closely matches the target PNRP ID. Using the IP address in the response, the requesting node sends another PNRP Request message to the IPv6 address to respond or examine its cache.  
  
-   If the PNRP ID is not found and there is no PNRP ID in its cache that is closer to the target PNRP ID, the requested peer sends the requesting peer a response that indicates this condition. The requesting peer then chooses the next-closest PNRP ID.  
  
-  
  
 The requesting peer continues this process with successive iterations, eventually locating the node that registered the PNRP ID.  
  
 Within the <xref:System.Net.PeerToPeer> namespace, there is a many-to-many relationship between the <xref:System.Net.PeerToPeer.PeerName> records that contain endpoints and PNRP clouds or meshes in which they communicate. When there are duplicate or stale entries, or multiple nodes with the same peer name, PNRP nodes can obtain current information using the <xref:System.Net.PeerToPeer.PeerNameResolver> class. The <xref:System.Net.PeerToPeer.PeerNameResolver> methods use a single peer name to simplify the perspective to one peer-to-many peer name records and the same one peer to many clouds. This is similar to a query performed using a relational-table join. Upon successful completion, the Resolver object returns a <xref:System.Net.PeerToPeer.PeerNameRecordCollection> for the specified peer name.  For example, a peer name would occur in all the peer name records in the collection, ordered by cloud. These are the instances of the peer name whose supporting data may be requested by a PNRP-based application.  
  
## See Also  
 <xref:System.Net.PeerToPeer>
