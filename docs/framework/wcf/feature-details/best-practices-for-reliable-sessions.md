---
title: "Best Practices for Reliable Sessions"
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
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Best Practices for Reliable Sessions

This topic discusses best practices for reliable sessions.

## Setting MaxTransferWindowSize

Reliable sessions in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] use a transfer window to hold messages on the client and service. The configurable property <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.MaxTransferWindowSize%2A> indicates how many messages the transfer window can hold.

On the sender, this indicates how many messages the transfer window can hold while waiting for acknowledgements; on the receiver, it indicates how many messages to buffer for the service.

Choosing the right size impacts the efficiency of the network and the optimal capacity of the service. The following sections detail what to consider when choosing a value for this property and the impact of the value.

The default transfer window size is eight messages.

### Efficient use of the network

In this context, the term *network* corresponds to everything used as the basis of communication between a client (sender) and a service (receiver). This includes the transport connections and any intermediary or bridges in between, including SOAP routers or HTTP proxies/firewalls.

Efficient use of the network ensures that network capacity is fully used. Both the amount of data that can be transferred per second over the network (*data rate*) and the time it takes to transfer data from the sender to the receiver (*latency*) impact how effectively the network is utilized.

On the sender, the property <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.MaxTransferWindowSize%2A> indicates how many messages its transfer window can hold while waiting for acknowledgements. If the network latency is high and in order to ensure a responsive sender and effective network utilization, you should increase the transfer window size.

For example even if the sender keeps up with data rate, latency could be high if several intermediaries exist between the sender and receiver or the data must pass through a lossy intermediary or network. Thus, the sender has to wait for acknowledgements for the messages in its transfer window before accepting new messages to send on the wire. The smaller the buffer with high latency, the less effective the network utilization. On the other hand, too high a transfer window size may impact the service because the service may need to catch up to the high rate of data sent by the client.

### Running the service to capacity

As much as the network is used efficiently, ideally you also want the service to run at optimal capacity. The transfer window size property on the receiver indicates how many messages the receiver can buffer. This message buffering helps not only the network flow control but also enables the service to run to full capacity. For example if the buffer is one message and messages arrive faster than the service can process them, then the network might drop messages and capacity might be wasted or underutilized.

Using a buffer increases the availability of the service as it concurrently receives and buffers a message while processing the previously received messages.

We recommended that you use the same `MaxTransferWindowSize` on both the sender and receiver.

### Enabling flow control

*Flow control* is a mechanism that ensures that the sender and receiver keep pace with each other, that is, the messages are consumed and acted upon as fast as they're produced. The transfer window size on the client and service ensures that the sender and receiver are within a reasonable window of synchronization.

We highly recommended that you set the property <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.FlowControlEnabled%2A> to `true` when you're using a reliable session between a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client and a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.

## Setting MaxPendingChannels

When writing a service that enables reliable session communication from different clients, it's possible to have many clients establish a reliable session to the service at the same time. The response of the service in these situations depends on the `MaxPendingChannels` property.

When the sender creates a reliable session channel to a receiver, a handshake between them establishes a reliable session. After the reliable session is established, the channel is put in a pending channel queue for acceptance by the service. The `MaxPendingChannels` property indicates how many channels can be in this state.

It's possible for the service to be in a state where it can't accept more channels. If the queue is full, an attempt to establish a reliable session is rejected, and the client must retry.

It's also possible that the pending channels in the queue remain in the queue for a longer duration. In the meantime, an inactivity timeout on the reliable session may occur, causing the channel to transition to a faulted state.

When writing a service that services multiple clients simultaneously, you should set a value that's suitable for your needs. Setting too high a value for the `MaxPendingChannels` property impacts your working set.

The default value for <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.MaxPendingChannels%2A> is four channels.

## Reliable sessions and hosting

When web hosting a service that uses reliable sessions, you should keep the following important considerations in mind:

- Reliable sessions are stateful, and state is maintained in the AppDomain. This means that all messages that are part of a reliable session must be processed in the same AppDomain. Web farms and web gardens where the size of the farm or garden is greater than one node can't guarantee this constraint.

- Reliable sessions using dual HTTP channels (for example, using `WsDualHttpBinding`) can require more than the default of two HTTP connections per-client. This means a duplex reliable session can require up to two connections each way because concurrent application and protocol messages may be transferring each way at any given time. Under certain conditions depending on the message exchange pattern of the service, this means that it's possible to deadlock a web-hosted service using dual HTTP and reliable sessions. To increase the number of allowable HTTP connections per client, add the following to the relevant configuration file (for example, *web.config* of the service in question):

  ```xml
  <configuration>
    <system.net>
      <connectionManagement>
        <add name="*" maxconnection="4" />
      </connectionManagement>
    </system.net>
  </configuration>
  ```

  The value of the `maxconnection` attribute is the number of connections needed. The minimum in this case should be four connections.
