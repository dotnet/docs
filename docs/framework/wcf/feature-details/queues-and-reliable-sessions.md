---
description: "Learn more about: Queues and Reliable Sessions"
title: "Queues and Reliable Sessions"
ms.date: "03/30/2017"
ms.assetid: 7e794d03-141c-45ed-b6b1-6c0e104c1464
---
# Queues and Reliable Sessions

Queues and reliable sessions are the Windows Communication Foundation (WCF) features that implement reliable messaging. The topics contained in this section discuss the WCF reliable messaging features.  
  
 Reliable messaging is how a reliable messaging source (called the source) transfers messages reliably to a reliable messaging destination (called the destination).  
  
 Reliable messaging has the following key aspects:  
  
- Transfer assurances for messages sent from a source to a destination regardless of message transfer failure or transport failures.  
  
- Separation of the source and the destination from each other, which provides independent failure and recovery of the source and the destination as well as reliable transfer and delivery of messages even though the source or destination is unavailable.  
  
 Reliable messaging frequently comes at the cost of high latency. Latency is the time it takes for the message to reach the destination from the source. WCF, therefore, provides the following types of reliable messaging:  
  
- [Reliable Sessions](reliable-sessions.md), which offer reliable transfer without the cost of high latency  
  
- [Queues in WCF](queues-in-wcf.md), which offer both reliable transfers and separation between the source and the destination.  
  
## Reliable Sessions  

 Reliable sessions provide end-to-end reliable transfer of messages between a source and a destination using the WS-ReliableMessaging protocol regardless of the number or type of intermediaries that separate the messaging (source and destination) endpoints. This includes any transport intermediaries that do not use SOAP (for example, HTTP proxies) or intermediaries that use SOAP (for example, SOAP-based routers or bridges) that are required for messages to flow between the endpoints. Reliable sessions use an in-memory transfer window to mask SOAP message-level failures and re-establish connections in the case of transport failures.  
  
 Reliable sessions provide low-latency reliable message transfers. They provide for SOAP messages over any proxies or intermediaries, equivalent to what TCP provides for packets over IP bridges. For more information about reliable sessions, see [Reliable Sessions](reliable-sessions.md).  
  
## Queues  

 Queues in WCF provide both reliable transfers of messages and separation between sources and destinations at the cost of high latency. WCF queued communication is built on top of Message Queuing (also known as MSMQ).  
  
 MSMQ is shipped as an option with Windows that runs as an NT service. It captures messages for transmission in a transmission queue on behalf of the source and delivers it to a target queue. The target queue accepts messages on behalf of the destination for later delivery whenever the destination requests for messages. The MSMQ queue managers implement a reliable message-transfer protocol so that messages are not lost in transmission. The protocol can be native or SOAP-based, such as Soap Reliable Messaging Protocol (SRMP).  
  
 The separation, coupled with reliable message transfers between queues, enables applications that are loosely coupled to communicate reliably. Unlike reliable sessions, the source and destination do not have to be running at the same time. This implicitly enables scenarios where queues are, in effect, used as a load-leveling mechanism when there is a mismatch between the rate of message production by the source and the rate of the message consumption by the destination. For more information about queues, see [Queues in WCF](queues-in-wcf.md).  
  
## See also

- [Queues in WCF](queues-in-wcf.md)
- [Queuing in WCF](queuing-in-wcf.md)
- [Reliable Sessions](reliable-sessions.md)
- [Reliable Sessions Overview](reliable-sessions-overview.md)
