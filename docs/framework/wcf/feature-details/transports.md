---
description: "Learn more about: Transports in Windows Communication Foundation"
title: "Transports in Windows Communication Foundation"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "transports [WCF]"
  - "WCF, transports"
  - "Windows Communication Foundation, transports"
ms.assetid: 005c894b-af70-48aa-a1c1-c99338083c27
---
# Transports in Windows Communication Foundation

The transport layer is at the lowest level of the channel stack. The main transports used in Windows Communication Foundation (WCF) are HTTP, HTTPS, TCP, and named pipes. The topics in this section discuss choosing among these transports, configuring the transport, and setting tuning properties.  
  
 WCF includes additional transports. For information about Message Queuing (also known as MSMQ) transport, see [Queues and Reliable Sessions](queues-and-reliable-sessions.md). For information about peer-to-peer transport, see [Peer-to-Peer Networking](peer-to-peer-networking.md).  
  
## In This Section  

 [Choosing a Transport](choosing-a-transport.md)  
 Describes the three main transports and considerations in selecting one.  
  
 [Choosing a Message Encoder](choosing-a-message-encoder.md)  
 Describes factors to consider when choosing a message-encoding binding element.  
  
 [Streaming Message Transfer](streaming-message-transfer.md)  
 Describes how to configure the transport layer to do streaming.  
  
 [Configuring HTTP and HTTPS](configuring-http-and-https.md)  
 Describes how to configure the HTTP and HTTPS transport binding elements.  
  
 [How to: Replace the WCF URL Reservation with a Restricted Reservation](how-to-replace-the-wcf-url-reservation-with-a-restricted-reservation.md)  
 Describes how to use WCFURL restricted reservations.  
  
 [Transport Quotas](transport-quotas.md)  
 Describes considerations in setting the quotas available in the transport layer.  
  
 [Working with NATs and Firewalls](working-with-nats-and-firewalls.md)  
 Describes how to configure the transport layer when messages are sent or received behind a firewall or when network address translation (NAT) is present.  
  
 [Net.TCP Port Sharing](net-tcp-port-sharing.md)  
 Describes how to use the Net.TCP Port Sharing component of WCF.  
  
## Reference  

 <xref:System.ServiceModel.Channels.HttpTransportBindingElement>  
  
 <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>  
  
 <xref:System.ServiceModel.Channels.TcpTransportBindingElement>  
  
 <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement>  
  
## Related Sections  

 [Bindings](bindings.md)  
  
 [Extending Bindings](../extending/extending-bindings.md)
