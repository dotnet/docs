---
title: "Queues in Windows Communication Foundation"
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
  - "queues [WCF]"
ms.assetid: 43008409-1bb4-4bd4-85d7-862c8f10ae20
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Queues in Windows Communication Foundation
The topics in this section discuss [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] support for queues. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides support for queuing by leveraging Microsoft Message Queuing (previously known as MSMQ) as a transport and enables the following scenarios:  
  
-   Loosely coupled applications. Sending applications can send messages to queues without needing to know whether the receiving application is available to process the message. The queue provides processing independence that allows a sending application to send messages to the queue at a rate that does not depend on how fast the receiving applications can process the messages. Overall system availability increases when sending messages to a queue is not tightly coupled to message processing.  
  
-   Failure isolation. Applications sending or receiving messages to a queue can fail without affecting each other. If, for example, the receiving application fails, the sending application can continue to send messages to the queue. When the receiver is up again, it can process the messages from the queue. Failure isolation increases the overall system reliability and availability.  
  
-   Load leveling. Sending applications can overwhelm receiving applications with messages. Queues can manage mismatched message production and consumption rates so that a receiver is not overwhelmed.  
  
-   Disconnected operations. Sending, receiving, and processing operations can become disconnected when communicating over high-latency networks or limited-availability networks, such as in the case of mobile devices. Queues allow these operations to continue, even when the endpoints are disconnected. When the connection is reestablished, the queue forwards messages to the receiving application.  
  
 To use the queues feature in a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, you can use one of the standard bindings, or you can create a custom binding if one of the standard bindings does not satisfy your requirements. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] relevant standard bindings and how to choose one, see [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](../../../../docs/framework/wcf/feature-details/how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating custom bindings, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
## In This Section  
 [Queues Overview](../../../../docs/framework/wcf/feature-details/queues-overview.md)  
 An overview of message queuing concepts.  
  
 [Queuing in WCF](../../../../docs/framework/wcf/feature-details/queuing-in-wcf.md)  
 An overview of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] queue support.  
  
 [How to: Exchange Queued Messages with WCF Endpoints](../../../../docs/framework/wcf/feature-details/how-to-exchange-queued-messages-with-wcf-endpoints.md)  
 Explains how to use the <xref:System.ServiceModel.NetMsmqBinding> class to communicate between a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](../../../../docs/framework/wcf/feature-details/how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md)  
 Explains how to use the <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding> to communicate between [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and Message Queuing applications.  
  
 [Grouping Queued Messages in a Session](../../../../docs/framework/wcf/feature-details/grouping-queued-messages-in-a-session.md)  
 Explains how to group messages in a queue to facilitate correlated message processing by a single receiving application.  
  
 [Batching Messages in a Transaction](../../../../docs/framework/wcf/feature-details/batching-messages-in-a-transaction.md)  
 Explains how to batch messages in a transaction.  
  
 [Using Dead-Letter Queues to Handle Message Transfer Failures](../../../../docs/framework/wcf/feature-details/using-dead-letter-queues-to-handle-message-transfer-failures.md)  
 Explains how to handle message transfer and delivery failures using dead letter queues and how to process messages from the dead letter queue.  
  
 [Poison Message Handling](../../../../docs/framework/wcf/feature-details/poison-message-handling.md)  
 Explains how to handle poison messages (messages that have exceeded the maximum number of delivery attempts to the receiving application).  
  
 [Differences in Queuing Features in Windows Vista, Windows Server 2003, and Windows XP](../../../../docs/framework/wcf/feature-details/diff-in-queue-in-vista-server-2003-windows-xp.md)  
 Summarizes the differences in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] queues feature between [!INCLUDE[wv](../../../../includes/wv-md.md)], [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], and [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
 [Securing Messages Using Transport Security](../../../../docs/framework/wcf/feature-details/securing-messages-using-transport-security.md)  
 Describes how to use transport security to secure queued messages.  
  
 [Securing Messages Using Message Security](../../../../docs/framework/wcf/feature-details/securing-messages-using-message-security.md)  
 Describes how to use message security to secure queued messages.  
  
 [Troubleshooting Queued Messaging](../../../../docs/framework/wcf/feature-details/troubleshooting-queued-messaging.md)  
 Explains how to troubleshoot common queuing problems.  
  
 [Best Practices for Queued Communication](../../../../docs/framework/wcf/feature-details/best-practices-for-queued-communication.md)  
 Explains best practices for using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] queued communication.  
  
## See Also  
 [Message Queuing](http://msdn.microsoft.com/library/ff917e87-05d5-478f-9430-0f560675ece1)
