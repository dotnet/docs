---
title: "Inside the CustomPeerResolverService: Client Registrations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 40236953-a916-4236-84a6-928859e1331a
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Inside the CustomPeerResolverService: Client Registrations
Each node in the mesh publishes its endpoint information to the resolver service through the `Register` function. The resolver service stores this information as a registration record. This record contains a unique identifier (RegistrationID) and endpoint information (PeerNodeAddress) for the node.  
  
## Stale Records and Expiration Time  
 Ideally, when a node leaves the mesh, it will call the `Unregister` function, which causes the resolver service to remove the registration entry. Sometimes, nodes shut down or become inaccessible before calling `Unregister`, leaving behind a stale registration record.  
  
 Stale records in your resolver service can cause failed connections. If a node trying to connect to a mesh receives stale connection information from the resolver service, it can take longer to successfully join the mesh. Stale records also take up memory. Without an efficient clean up process, the cache used to store registrations could eventually overflow and crash the resolver service.  
  
 The <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService> marks each record with an expiration time (DateTime), and stores that information as part of the record. The service uses the expiration time to identify stale records. Custom implementations should do something similar.  
  
## RefreshInterval and CleanupInterval  
 The `RefreshInterval` property of the <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService> defines how long registration records remain valid in the service's registration lookup table. When the amount of time supplied to this property has passed for a given record, that record becomes stale and is marked for deletion.  
  
 The `CleanupInterval` property of the <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService> tells the service how often to search for and delete stale registration records. The `CleanupInterval` should be set to a time greater than or equal to the `RefreshInterval` set on the service.  
  
 To implement your own resolver service, you need to write a maintenance function to remove stale registration records. There are several ways to do this:  
  
-   **Periodic maintenance**: Set a timer to go off periodically, and go through your data store to delete old records. The <xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService> uses this approach.  
  
-   **Passive deletion**: Instead of actively searching for stale records at regular intervals, you can identify and delete stale records when your service is already performing another function. This may potentially slow down response time to requests from the resolver clients, but it eliminates the need for a timer, and may be more efficient if few nodes are expected to leave without calling `Unregister`.  
  
## RegistrationLifetime and Refresh  
 When a node registers with a resolver service, it receives a <xref:System.ServiceModel.PeerResolvers.RegisterResponseInfo> object from the service. This object has a `RegistrationLifetime` property which indicates to the node how much time it has before the registration expires and is removed by the resolver service. If, for example, the `RegistrationLifetime` is 2 minutes, the node needs to call `Refresh` in under 2 minutes to ensure the record stays fresh and is not deleted. When the resolver service receives a `Refresh` request, it looks up the record and resets the expiration time. Refresh returns a <xref:System.ServiceModel.PeerResolvers.RefreshResponseInfo> object with a `RegistrationLifetime` property.  
  
## See Also  
 [Peer Resolvers](../../../../docs/framework/wcf/feature-details/peer-resolvers.md)
