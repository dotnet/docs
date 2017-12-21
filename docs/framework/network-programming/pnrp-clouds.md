---
title: "PNRP Clouds"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a82e2bf1-62ab-4c2d-83f3-3217a6aead2e
caps.latest.revision: 4
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# PNRP Clouds
A PNRP "cloud" represents a set of nodes that can communicate with each other through the network. The term "cloud" is synonymous with "peer mesh" and "peer-to-peer graph".  
  
 Communication between nodes should never cross from one cloud to another. A <xref:System.Net.PeerToPeer.Cloud> instance is uniquely identified by its name, which is case-sensitive. A single peer or node may be connected to more than one cloud.  
  
 Clouds are tied very closely to network interfaces.  On a multi-homed machine with two network cards attached to different subnets, three clouds will be returned: one for each of the link local addresses per interface, and a single global scope cloud.  
  
 PNRP uses three cloud "scopes", in which a scope is a grouping of computers that are able to find each other:  
  
-   The global cloud corresponds to the global IPv6 address scope and global addresses and represents all the computers on the entire IPv6 Internet. There is only a single global cloud.  
  
-   The link-local cloud corresponds to the link-local IPv6 address scope and link-local addresses. A link-local cloud is for a specific link, which is typically the same as the locally attached subnet. There can be multiple link-local clouds.  
  
 A third cloud, the site-specific cloud, corresponds to the site IPv6 address scope and site-local addresses. This cloud has been deprecated, although it is still supported in PNRP.  
  
## Clouds  
 PNRP clouds are represented by instances of the <xref:System.Net.PeerToPeer.Cloud> class. Groups of clouds used a peer are represented by instances of the enumerable <xref:System.Net.PeerToPeer.CloudCollection> class. Collections of PNRP clouds known to the current peer can be obtained by calling the static <xref:System.Net.PeerToPeer.Cloud.GetAvailableClouds%2A> method.  
  
 Individual clouds have unique names, represented as a 256 character Unicode string. These names, along with the above-mentioned scope, are used to construct unique instances of the Cloud class. These instances can be serialized and reconstructed for persistent usage.  
  
 Once a Cloud instance is created or obtained, peer names can be registered with it to create a mesh of known peers.  
  
## See Also  
 <xref:System.Net.PeerToPeer.Cloud>  
 [Peer Name Resolution Protocol](../../../docs/framework/network-programming/peer-name-resolution-protocol.md)
