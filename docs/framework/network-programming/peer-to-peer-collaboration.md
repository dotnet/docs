---
title: "Peer-to-Peer Collaboration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b6216d88-bccb-4a59-9f1c-9f751708e811
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Peer-to-Peer Collaboration
Peer-to-peer networking is the utilization of the relatively powerful computers (personal computers) that exist at the edge of the Internet for more than just client-based computing tasks. The modern personal computer (PC) has a very fast processor, vast memory, and a large hard disk, none of which are being fully utilized when performing common computing tasks such as email and Web browsing. The modern PC can easily act as both a client and server (a peer) for many types of applications.  
  
-   The Peer-to-Peer Collaboration Infrastructure is a simplified implementation of the Microsoft Windows Peer-to-Peer Infrastructure that leverages the People Near Me service in Windows Vista and later platforms. It is best used for peer-enabled applications within a subnet for which the People Near Me service operates, although it can service internet endpoints or contacts as well. It incorporates the common Contact Manager that is used by Live Messenger and other Live-aware applications to determine contact endpoints, availability, and presence.  
  
-  
  
## Collaboration Applications  
 A typical peer-to-peer collaboration application is comprised of the following steps:  
  
-   Peer determines the identity of a peer who is interested in hosting a collaboration session  
  
-   A request to host a session is sent, somehow, and the host peer agrees to manage collaboration activity.  
  
-   The host invites contacts on the subnet (including the requestor) to a session.  
  
-   All peers who want to collaborate may add the host to their contact managers.  
  
-   Most peers will send invitation responses, whether accepted or declined, back to the host peer in a timely fashion.  
  
-   All peers who want to collaborate will subscribe to the host peer.  
  
-   While the peers are performing their initial collaboration activity, the host peer may add remote peers to its contact manager. It also processes all invitation responses to determine who has accepted, who has declined, and who has not answered.  It may cancel invitations to those who have not answered, or perform some other activity.  
  
-   At this point, the host peer can start a collaboration session with all invited peers, or register an application with the collaboration infrastructure.  P2P applications use the Peer-to-Peer Collaboration Infrastructure and the <xref:System.Net.PeerToPeer.Collaboration> namespace to coordinate communications for games, bulletin boards, conferencing, and other serverless presence applications.  
  
-  
  
## Peer-to-Peer Networking Security  
 In an Active Directory domain, domain controllers provide authentication services using Kerberos. In a serverless peer environment, the peers must provide their own authentication. For Peer-to-Peer Networking, any node can act as a CA, removing the requirement of a root certificate in each peer's trusted root store. Authentication is provided using self-signed certificates, formatted as X.509 certificates. These are certificates that are created by each peer, which generates the public key/private key pair and the certificate that is signed using the private key. The self-signed certificate is used for authentication and to provide information about the peer entity. Like X.509 authentication, peer networking authentication relies upon a chain of certificates tracing back to a public key that is trusted.  
  
## See Also  
 <xref:System.Net.PeerToPeer.Collaboration>  
 [About the System.Net.PeerToPeer.Collaboration Namespace](../../../docs/framework/network-programming/about-the-system-net-peertopeer-collaboration-namespace.md)
