---
title: "Best Practices for Reliable Sessions | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b94f6e01-8070-40b6-aac7-a2cb7b4cb4f2
caps.latest.revision: 6
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Best Practices for Reliable Sessions
This section discusses best practices for reliable sessions.  
  
## Setting MaxTransferWindowSize  
 Reliable sessions in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] use a transfer window to hold messages on the client and service. The configurable property <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.MaxTransferWindowSize%2A>indicates how many messages the transfer window can hold.  
  
 On the sender, this indicates how many messages the transfer window can hold while waiting for acknowledgements; on the receiver it indicates how many messages to buffer for the service.  
  
 Choosing the right size impacts how efficiently the network is put to use and the optimal capacity the service is running at. The following sections detail what to consider when choosing a value for this property, and the impact of the value.  
  
 The default transfer window size is 8 messages.  
  
### Efficient Use of the Network  
 The term *network* here corresponds to everything between a client (sender) and a service (receiver) used as the basis of communication. This includes the transport connections and any intermediary or bridges in-between, including SOAP routers or HTTP proxies/firewalls.  
  
 Efficient use of the network ensures that network capacity is fully used. Both the amount of data that can be transferred per second over the network (called *data rate*) and the time it takes to transfer data from the sender to the receiver (called *latency*) impact how effectively the network is utilized.  
  
 On the sender, the property <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.MaxTransferWindowSize%2A> indicates how many messages its transfer window can hold while waiting for acknowledgements. Thus, if the network latency is high, in order to ensure a responsive sender and effective network utilization, you should increase the transfer window size.  
  
 For example, even if the sender keeps up with data rate, latency could be high if several intermediaries exist between the sender and receiver or a lossy intermediary or network. Thus the sender has to wait for acknowledgements for the messages in its transfer window before accepting new messages to send on the wire. The smaller the buffer with high latency, the less effectively the network utilization. On the other hand, too high a transfer window size may impact the service because the service may have to catch up to the high rate of send from the client.  
  
### Running the Service to Capacity  
 As much as the network is used efficiently, ideally you also want the service to run to optimal capacity. The transfer window size property on the receiver indicates how many messages the receiver can buffer. This message buffering helps not only the network flow control but also enables the service to run to full capacity. For example, if the buffer is 1 and messages arrive faster than the service can process them, then the network might drop messages, and network capacity might be wasted or underutilized.  
  
 Using a bufferincreases the availability of the service as it concurrently receives and buffers the message while processing the previously received messages.  
  
 It is recommended that you use the same `MaxTransferWindowSize` on both the sender and receiver.  
  
### Enabling Flow Control  
 Flow control is a mechanism that ensures that the sender and receiver keep pace with each other, that is,  the messages are consumed and acted upon as fast as they are produced. The transfer window size on the client and service ensures that the sender and receiver are within a reasonable window of synchronization.  
  
 It is highly recommended that you set the property <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.FlowControlEnabled%2A> to true when you are using a reliable session between a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client and a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
## Setting MaxPendingChannels  
 When writing a service that enables reliable session communication from different clients, it is possible to have many clients establish a reliable session to the service at the same time. The response of the service in these situations depends on the `MaxPendingChannels` property.  
  
 When the sender creates a reliable session channel to a receiver, a handshake between them establishes a reliable session. After the reliable session is established, the channel is put in a pending channel queue for acceptance by the service. The `MaxPendingChannels` property indicates how many channels can be in this state.  
  
 It is possible for the service to be in a state where it can accept no more channels. If the queue is full, an attempt to establish a reliable session is rejected and the client has to retry.  
  
 It is also possible that the pending channels in the queue remain in the queue for a longer duration. In the meantime, inactivity timeout on the reliable session may kick in, causing the channel to transition to a faulted state.  
  
 Therefore, when writing a service that services multiple clients simultaneously, you should set a value that is suitable for your needs. Setting too high a value for the `MaxPendingChannels` property will impact your working set.  
  
 The default value for <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.MaxPendingChannels%2A> is 4.  
  
## Reliable Sessions and Hosting  
 When Web hosting a service that uses reliable sessions, you should keep the following important considerations in mind:  
  
-   Reliable sessions are stateful, and state is maintained in the AppDomain. This means that all messages that are part of a reliable session must be processed in the same AppDomain. Web farms and Web gardens where the size of the farm or garden is > 1 can't guarantee keeping with this constraint.  
  
-   Reliable sessions using dual HTTP channels (for example, using `WsDualHttpBinding`) can require more than the default HTTP connections per-client of 2. This means a duplex reliable session can require up to 2 connections each way, because concurrent application and protocol messages may be transferring each way at any given time. This means that, under certain conditions, depending on the message exchange pattern of the service, it is possible to deadlock a Web-hosted service using dual HTTP and reliable sessions. To increase the number of allowable HTTP connections per client, add the following to the relevant configuration file (for example, web.config of the service in question):  
  
```  
<configuration>  
   <system.net>  
      <connectionManagement>  
         <add name = "*" maxconnection = "XX" />  
      </connectionManagement>  
   </system.net>  
</configuration>  
```  
  
 Where "XX" is the number of connections needed. The minimum in this case should be 4.