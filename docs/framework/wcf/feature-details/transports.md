---
title: "Transports in Windows Communication Foundation"
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
  - "transports [WCF]"
  - "WCF, transports"
  - "Windows Communication Foundation, transports"
ms.assetid: 005c894b-af70-48aa-a1c1-c99338083c27
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transports in Windows Communication Foundation
The transport layer is at the lowest level of the channel stack. The main transports used in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] are HTTP, HTTPS, TCP, and named pipes. The topics in this section discuss choosing among these transports, configuring the transport, and setting tuning properties.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] includes additional transports. For information about Message Queuing (also known as MSMQ) transport, see [Queues and Reliable Sessions](../../../../docs/framework/wcf/feature-details/queues-and-reliable-sessions.md). For information about peer-to-peer transport, see [Peer-to-Peer Networking](../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md).  
  
## In This Section  
 [Choosing a Transport](../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)  
 Describes the three main transports and considerations in selecting one.  
  
 [Choosing a Message Encoder](../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)  
 Describes factors to consider when choosing a message-encoding binding element.  
  
 [Streaming Message Transfer](../../../../docs/framework/wcf/feature-details/streaming-message-transfer.md)  
 Describes how to configure the transport layer to do streaming.  
  
 [Configuring HTTP and HTTPS](../../../../docs/framework/wcf/feature-details/configuring-http-and-https.md)  
 Describes how to configure the HTTP and HTTPS transport binding elements.  
  
 [How to: Replace the WCF URL Reservation with a Restricted Reservation](../../../../docs/framework/wcf/feature-details/how-to-replace-the-wcf-url-reservation-with-a-restricted-reservation.md)  
 Describes how to use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]URL restricted reservations.  
  
 [Transport Quotas](../../../../docs/framework/wcf/feature-details/transport-quotas.md)  
 Describes considerations in setting the quotas available in the transport layer.  
  
 [Working with NATs and Firewalls](../../../../docs/framework/wcf/feature-details/working-with-nats-and-firewalls.md)  
 Describes how to configure the transport layer when messages are sent or received behind a firewall or when network address translation (NAT) is present.  
  
 [Net.TCP Port Sharing](../../../../docs/framework/wcf/feature-details/net-tcp-port-sharing.md)  
 Describes how to use the Net.TCP Port Sharing component of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## Reference  
 <xref:System.ServiceModel.Channels.HttpTransportBindingElement>  
  
 <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>  
  
 <xref:System.ServiceModel.Channels.TcpTransportBindingElement>  
  
 <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement>  
  
## Related Sections  
 [Bindings](../../../../docs/framework/wcf/feature-details/bindings.md)  
  
 [Extending Bindings](../../../../docs/framework/wcf/extending/extending-bindings.md)
