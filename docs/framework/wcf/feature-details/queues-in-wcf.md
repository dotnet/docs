---
description: "Learn more about: Queues in Windows Communication Foundation"
title: "Queues in Windows Communication Foundation"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "queues [WCF]"
ms.assetid: 43008409-1bb4-4bd4-85d7-862c8f10ae20
---
# Queues in Windows Communication Foundation

The topics in this section discuss Windows Communication Foundation (WCF) support for queues. WCF provides support for queuing by leveraging Microsoft Message Queuing (previously known as MSMQ) as a transport and enables the following scenarios:  
  
- Loosely coupled applications. Sending applications can send messages to queues without needing to know whether the receiving application is available to process the message. The queue provides processing independence that allows a sending application to send messages to the queue at a rate that does not depend on how fast the receiving applications can process the messages. Overall system availability increases when sending messages to a queue is not tightly coupled to message processing.  
  
- Failure isolation. Applications sending or receiving messages to a queue can fail without affecting each other. If, for example, the receiving application fails, the sending application can continue to send messages to the queue. When the receiver is up again, it can process the messages from the queue. Failure isolation increases the overall system reliability and availability.  
  
- Load leveling. Sending applications can overwhelm receiving applications with messages. Queues can manage mismatched message production and consumption rates so that a receiver is not overwhelmed.  
  
- Disconnected operations. Sending, receiving, and processing operations can become disconnected when communicating over high-latency networks or limited-availability networks, such as in the case of mobile devices. Queues allow these operations to continue, even when the endpoints are disconnected. When the connection is reestablished, the queue forwards messages to the receiving application.  
  
 To use the queues feature in a WCF application, you can use one of the standard bindings, or you can create a custom binding if one of the standard bindings does not satisfy your requirements. For more information about relevant standard bindings and how to choose one, see [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md). For more information about creating custom bindings, see [Custom Bindings](../extending/custom-bindings.md).  
  
## In This Section  

 [Queues Overview](queues-overview.md)  
 An overview of message queuing concepts.  
  
 [Queuing in WCF](queuing-in-wcf.md)  
 An overview of WCF queue support.  
  
 [How to: Exchange Queued Messages with WCF Endpoints](how-to-exchange-queued-messages-with-wcf-endpoints.md)  
 Explains how to use the <xref:System.ServiceModel.NetMsmqBinding> class to communicate between a WCF client and WCF service.  
  
 [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md)  
 Explains how to use the <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding> to communicate between WCF and Message Queuing applications.  
  
 [Grouping Queued Messages in a Session](grouping-queued-messages-in-a-session.md)  
 Explains how to group messages in a queue to facilitate correlated message processing by a single receiving application.  
  
 [Batching Messages in a Transaction](batching-messages-in-a-transaction.md)  
 Explains how to batch messages in a transaction.  
  
 [Using Dead-Letter Queues to Handle Message Transfer Failures](using-dead-letter-queues-to-handle-message-transfer-failures.md)  
 Explains how to handle message transfer and delivery failures using dead letter queues and how to process messages from the dead letter queue.  
  
 [Poison Message Handling](poison-message-handling.md)  
 Explains how to handle poison messages (messages that have exceeded the maximum number of delivery attempts to the receiving application).  
  
 [Differences in Queuing Features in Windows Vista, Windows Server 2003, and Windows XP](diff-in-queue-in-vista-server-2003-windows-xp.md)  
 Summarizes the differences in the WCF queues feature between Windows Vista, Windows Server 2003, and Windows XP.  
  
 [Securing Messages Using Transport Security](securing-messages-using-transport-security.md)  
 Describes how to use transport security to secure queued messages.  
  
 [Securing Messages Using Message Security](securing-messages-using-message-security.md)  
 Describes how to use message security to secure queued messages.  
  
 [Troubleshooting Queued Messaging](troubleshooting-queued-messaging.md)  
 Explains how to troubleshoot common queuing problems.  
  
 [Best Practices for Queued Communication](best-practices-for-queued-communication.md)  
 Explains best practices for using WCF queued communication.  
