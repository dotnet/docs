---
title: "Reliable Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF [WCF], reliable messaging"
  - "Windows Communication Foundation [WCF], reliable messaging"
  - "WCF [WCF], reliable sessions"
  - "Windows Communication Foundation [WCF], reliable sessions"
  - "service contracts [WCF], reliable services"
ms.assetid: 07814ed0-0775-47f2-987b-d8134fdd5099
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Reliable Services
Queues and reliable sessions are the [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] features that implement reliable messaging. This topic explains the reliable messaging features of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)].  
  
 *Reliable messaging* is how a reliable messaging source (called the *source*) transfers messages reliably to a reliable messaging destination (called the *destination*).  
  
 Reliable messaging performs the following functions:  
  
-   Transfers assurances for messages sent from a source to a destination regardless of message transfer or transport failures.  
  
-   Separates the source and the destination from each other. This provides independent failure and recovery of the source and the destination, as well as reliable transfer and delivery of messages, even when the source or destination is unavailable.  
  
 Reliable messaging frequently comes at the cost of high latency. *Latency* is the time it takes for the message to reach the destination from the source. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], therefore, provides the following types of reliable messaging:  
  
-   [Reliable Sessions](../../../docs/framework/wcf/feature-details/reliable-sessions.md), which offers reliable transfer without the cost of high latency.  
  
-   [Queues in WCF](../../../docs/framework/wcf/feature-details/queues-in-wcf.md), which offers both reliable transfers and separation between the source and the destination.  
  
## Reliable Sessions  
 Reliable sessions provide end-to-end reliable transfer of messages between a source and a destination using the WS-Reliable Messaging protocol, regardless of the number or type of intermediaries that separate the messaging (source and destination) endpoints. This includes any transport intermediaries that do not use SOAP (for example, HTTP proxies) or intermediaries that use SOAP (for example, SOAP-based routers or bridges) that are required for messages to flow between the endpoints. Reliable sessions use an in-memory transfer window to mask SOAP message-level failures and re-establish connections in the case of transport failures.  
  
 Reliable sessions provide low-latency reliable message transfers. They provide for SOAP messages over any proxies or intermediaries, equivalent to what TCP provides for packets over IP bridges. [!INCLUDE[crabout](../../../includes/crabout-md.md)] reliable sessions, see [Reliable Sessions](../../../docs/framework/wcf/feature-details/reliable-sessions.md).  
  
### Queues  
 Queues in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] provide both reliable transfers of messages and separation between sources and destinations at the cost of high latency. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] queued communication is built on top of Message Queuing (MSMQ).  
  
 MSMQ ships as an optional component with Windows. The MSMQ service runs as a Windows Service. It captures messages for transmission in a transmission queue on behalf of the source and delivers it to a target queue. The target queue accepts messages on behalf of the destination for later delivery whenever the destination requests messages. The MSMQ managers implement a reliable message-transfer protocol so that messages are not lost in transmission. The protocol can be native or a SOAP-based protocol called SOAP Reliable Messaging Protocol (SRMP).  
  
 The separation, coupled with reliable message transfers between queues, enables applications that are loosely coupled to communicate reliably. Unlike reliable sessions, the source and destination do not have to be running at the same time. This implicitly enables scenarios where queues are, in effect, used as a load-leveling mechanism when the source's rate of message production and the destination's rate of the message consumption do not match. [!INCLUDE[crabout](../../../includes/crabout-md.md)] queues, see [Queues in WCF](../../../docs/framework/wcf/feature-details/queues-in-wcf.md).  
  
## See Also  
 [Reliable Sessions Overview](../../../docs/framework/wcf/feature-details/reliable-sessions-overview.md)  
 [Queuing in WCF](../../../docs/framework/wcf/feature-details/queuing-in-wcf.md)
