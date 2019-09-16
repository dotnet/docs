---
title: "Extending the Channel Layer"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "extending channels [WCF]"
ms.assetid: 4238db74-2fb6-4dc8-a326-f58527230810
---
# Extending the Channel Layer
The channel layer is responsible for the exchange of messages between clients and services. Channel extensions can implement new protocol functionality, such as security, or transport functionality, such as implementing a new network transport to carry SOAP messages.  
  
## In This Section  
 [Channel Model Overview](channel-model-overview.md)  
 Provides a high-level overview of what channels are, the features that they provide and how they work both in a service and a client application.  
  
 [Developing Channels](developing-channels.md)  
 Describes in depth the roles that the various channel infrastructure types play, how the state engine and state lifecycle works, how to handle exceptions and faults, how to implement metadata support, and how channels work with message encoders.  
  
 [Custom Encoders](custom-encoders.md)  
 Describes the role that message encoders play in channels and how to build one.  
  
 [Custom Stream Upgrades](custom-stream-upgrades.md)  
 Describes the process of upgrading the streams provided by stream-oriented transports.
