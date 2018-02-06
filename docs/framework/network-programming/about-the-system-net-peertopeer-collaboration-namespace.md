---
title: "About the System.Net.PeerToPeer.Collaboration Namespace"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b5d8c1c1-6844-4947-9759-c7f1b564bded
caps.latest.revision: 4
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# About the System.Net.PeerToPeer.Collaboration Namespace
The <xref:System.Net.PeerToPeer.Collaboration> namespace provides classes and APIs that are used to implement peer collaboration activities using the Peer-to-Peer Collaboration Infrastructure.  
  
## Classes  
 The main classes used in the implementation of a Peer-to-Peer Collaboration activity are:  
  
-   The <xref:System.Net.PeerToPeer.Collaboration.ContactManager>, which can be used to store peer contacts.  
  
-   The <xref:System.Net.PeerToPeer.Collaboration.PeerApplication> in which to collaborate, such as a game, chat client, or conferencing solution.  
  
-   The peers that will be collaborating in an activity.  These peers can be represented as <xref:System.Net.PeerToPeer.Collaboration.PeerContact>, <xref:System.Net.PeerToPeer.Collaboration.PeerNearMe>, or <xref:System.Net.PeerToPeer.Collaboration.PeerEndPoint> objects.  
  
-   The static <xref:System.Net.PeerToPeer.Collaboration.PeerCollaboration> class itself, which specifies which applications are available and which peers are participating in them.  
  
 The <xref:System.Net.PeerToPeer.Collaboration.PeerContact.Invite%2A> methods are used to invite peers to a collaboration session.  A calling peer can subscribe to another peer for events that signal updates to application, object, or presence information affiliated with the collaboration session. Presence classes specify whether a <xref:System.Net.PeerToPeer.Collaboration.Peer> is available for collaboration, and the <xref:System.Net.PeerToPeer.Collaboration.PeerScope> class is used to specify how much participation is allowed for a peer:  <xref:System.Net.PeerToPeer.Collaboration.PeerScope.Internet> (global), <xref:System.Net.PeerToPeer.Collaboration.PeerScope.NearMe>, (subnet) or <xref:System.Net.PeerToPeer.Collaboration.PeerScope.None>.  
  
 A collaboration session is comprised of four steps:  
  
-   Discovery. Discover or publish applications, peers, and presence information.  For instance, find other people on the local subnet that have the same games installed.  
  
-   Invitation. Send and accept secure invitations for remote peer(s) to start or join <xref:System.Net.PeerToPeer.Collaboration.PeerCollaboration> sessions.  
  
-   Contact Management. Add discovered peers as a contact to a <xref:System.Net.PeerToPeer.Collaboration.ContactManager>.  
  
-   Communication. When communication is established, use the <xref:System.Net> APIs, the <xref:System.Net.PeerToPeer> API, or the Windows Communication Foundation Peer Channel classes for multiparty communications.  
  
 For example, the host peer starts a collaboration session, and utilizes the <xref:System.Net.PeerToPeer.Collaboration.ContactManager.CreateContact%2A> method to add a remote peer and one of its local peers to the Contact Manager of the host peer.  The three users will then participate in their own private collaboration session.  
  
 Typical P2P applications are: conference calls for collaborative note-taking or whiteboarding, serverless chat applications, interactive advertisements, and online gaming sessions.  
  
## See Also  
 <xref:System.Net.PeerToPeer.Collaboration>
