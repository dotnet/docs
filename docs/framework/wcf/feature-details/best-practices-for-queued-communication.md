---
title: "Best Practices for Queued Communication"
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
  - "queues [WCF], best practices"
  - "best practices [WCF], queued communication"
ms.assetid: 446a6383-cae3-4338-b193-a33c14a49948
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Best Practices for Queued Communication
This topic provides recommended practices for queued communication in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. The following sections discuss recommended practices from a scenario perspective.  
  
## Fast, Best-Effort Queued Messaging  
 For scenarios that require separation that queued messaging provides and fast, high-performance messaging with best-effort assurances, use a non-transactional queue and set the <xref:System.ServiceModel.MsmqBindingBase.ExactlyOnce%2A> property to `false`.  
  
 In addition, you can choose not to incur the cost of disk writes by setting the <xref:System.ServiceModel.MsmqBindingBase.Durable%2A> property to `false`.  
  
 Security has implications on performance. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Performance Considerations](../../../../docs/framework/wcf/feature-details/performance-considerations.md).  
  
## Reliable End-to-End Queued Messaging  
 The following sections describe recommended practices for scenarios that require end-to-end reliable messaging.  
  
### Basic Reliable Transfer  
 For end-to-end reliability, set the <xref:System.ServiceModel.MsmqBindingBase.ExactlyOnce%2A> property to `true` to ensure transfer. The <xref:System.ServiceModel.MsmqBindingBase.Durable%2A> property can be set to `true` or `false` depending on your requirements (the default is `true`). Generally, the <xref:System.ServiceModel.MsmqBindingBase.Durable%2A> property is set to `true` as part of end-to-end reliability. The compromise is a performance cost, but makes the message durable so that the message is not lost if a queue manager crashes.  
  
### Use of Transactions  
 You must use transactions to ensure end-to-end reliability. `ExactlyOnce` assurances only ensure that messages are delivered to the target queue. To ensure that the message is received, use transactions. Without transactions, if the service crashes, you lose the message that is being delivered but is actually delivered to the application.  
  
### Use of Dead-letter Queues  
 Dead-letter queues ensure that you are notified if a message fails to be delivered to the target queue. You can use the system-provided dead-letter queue or a custom dead-letter queue. In general, using a custom dead-letter queue is best because it enables you to send dead-letter messages from one application into a single dead-letter queue. Otherwise, all dead-letter messages that occur for all applications running on the system are delivered to a single queue. Each application must then search though the dead-letter queue to find the dead-letter messages that are relevant to that application. Sometimes, using a custom dead-letter queue is not feasible, such as when using MSMQ 3.0.  
  
 Turning off dead-letter queues for end-to-end reliable communication is not recommended.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using Dead-Letter Queues to Handle Message Transfer Failures](../../../../docs/framework/wcf/feature-details/using-dead-letter-queues-to-handle-message-transfer-failures.md).  
  
### Use of Poison-Message Handling  
 Poison-message handling provides the ability to recover from the failure to process messages.  
  
 When using the poison-message handling feature, ensure that the <xref:System.ServiceModel.MsmqBindingBase.ReceiveErrorHandling%2A> property is set to the appropriate value. Setting it to <xref:System.ServiceModel.ReceiveErrorHandling.Drop> means the data is lost. On the other hand, setting it to <xref:System.ServiceModel.ReceiveErrorHandling.Fault> faults the service host when it detects a poison message. Using MSMQ 3.0, <xref:System.ServiceModel.ReceiveErrorHandling.Fault> is the best option to avoid data loss and move the poison message out of the way. Using MSMQ 4.0, <xref:System.ServiceModel.ReceiveErrorHandling.Move> is the recommended approach. <xref:System.ServiceModel.ReceiveErrorHandling.Move> moves a poisoned message out of the queue so the service can continue to process new messages. The poison-message service can then process the poison message separately.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Poison Message Handling](../../../../docs/framework/wcf/feature-details/poison-message-handling.md).  
  
## Achieving High Throughput  
 To achieve high throughput on a single endpoint, use the following:  
  
-   Transacted batching. Transacted batching ensures that many messages can be read in a single transaction. This optimizes transaction commits, increasing overall performance. The cost of batching is that if a failure occurs in a single message within a batch, then the entire batch is rolled back and the messages must be processed one at a time until it is safe to batch again. In most cases, poison messages are rare, so batching is the preferred way to increase system performance, particularly when you have other resource managers that participate in the transaction. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Batching Messages in a Transaction](../../../../docs/framework/wcf/feature-details/batching-messages-in-a-transaction.md).  
  
-   Concurrency. Concurrency increases throughput, but concurrency also affects contention to shared resources. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Concurrency](../../../../docs/framework/wcf/samples/concurrency.md).  
  
-   Throttling. For optimal performance, throttle the number of messages in the dispatcher pipeline. For an example of how to do this, see [Throttling](../../../../docs/framework/wcf/samples/throttling.md).  
  
 When using batching, be aware that concurrency and throttling translate to concurrent batches.  
  
 To achieve higher throughput and availability, use a farm of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services that read from the queue. This requires that all of these services expose the same contract on the same endpoint. The farm approach works best for applications that have high production rates of messages because it enables a number of services to all read from the same queue.  
  
 When using farms, be aware that MSMQ 3.0 does not support remote transacted reads. MSMQ 4.0 does support remote transacted reads.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Batching Messages in a Transaction](../../../../docs/framework/wcf/feature-details/batching-messages-in-a-transaction.md) and [Differences in Queuing Features in Windows Vista, Windows Server 2003, and Windows XP](../../../../docs/framework/wcf/feature-details/diff-in-queue-in-vista-server-2003-windows-xp.md).  
  
## Queuing with Unit of Work Semantics  
 In some scenarios a group of messages in a queue may be related and, therefore, the ordering of these messages is significant. In such scenarios, process a group of related messages together as a single unit: either all of the messages are processed successfully or none are. To implement such behavior, use sessions with queues.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Grouping Queued Messages in a Session](../../../../docs/framework/wcf/feature-details/grouping-queued-messages-in-a-session.md).  
  
## Correlating Request-Reply Messages  
 Though queues are typically one-way, in some scenarios you may want to correlate a reply received to a request sent earlier. If you require such correlation, it is recommended that you apply your own SOAP message header that contains correlation information with the message. Typically, the sender attaches this header with the message, and the receiver, upon processing the message and replying back with a new message on a reply queue, attaches the sender's message header that contains the correlation information so that the sender can identify the reply message with the request message.  
  
## Integrating with Non-WCF Applications  
 Use `MsmqIntegrationBinding` when integrating [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services or clients with non-[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services or clients. The non-[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application can be an MSMQ application written using System.Messaging, COM+, [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)], or C++.  
  
 When using `MsmqIntegrationBinding`, be aware of the following:  
  
-   A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message body is not the same as a MSMQ message body. When sending a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message using a queued binding, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message body is placed inside of a MSMQ message. The MSMQ infrastructure is oblivious to this extra information; it sees only the MSMQ message.  
  
-   `MsmqIntegrationBinding` supports popular serialization types. Based on the serialization type, the body type of the generic message, <xref:System.ServiceModel.MsmqIntegration.MsmqMessage%601>, takes different type parameters. For example, <xref:System.ServiceModel.MsmqIntegration.MsmqMessageSerializationFormat.ByteArray> requires `MsmqMessage\<byte[]>` and <xref:System.ServiceModel.MsmqIntegration.MsmqMessageSerializationFormat.Stream> requires `MsmqMessage<Stream>`.  
  
-   With XML serialization, you can specify the known type using the `KnownTypes` attribute on the [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-servicebehaviors.md) element that is then used to determine how to deserialize the XML message.  
  
## See Also  
 [Queuing in WCF](../../../../docs/framework/wcf/feature-details/queuing-in-wcf.md)  
 [How to: Exchange Queued Messages with WCF Endpoints](../../../../docs/framework/wcf/feature-details/how-to-exchange-queued-messages-with-wcf-endpoints.md)  
 [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](../../../../docs/framework/wcf/feature-details/how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md)  
 [Grouping Queued Messages in a Session](../../../../docs/framework/wcf/feature-details/grouping-queued-messages-in-a-session.md)  
 [Batching Messages in a Transaction](../../../../docs/framework/wcf/feature-details/batching-messages-in-a-transaction.md)  
 [Using Dead-Letter Queues to Handle Message Transfer Failures](../../../../docs/framework/wcf/feature-details/using-dead-letter-queues-to-handle-message-transfer-failures.md)  
 [Poison Message Handling](../../../../docs/framework/wcf/feature-details/poison-message-handling.md)  
 [Differences in Queuing Features in Windows Vista, Windows Server 2003, and Windows XP](../../../../docs/framework/wcf/feature-details/diff-in-queue-in-vista-server-2003-windows-xp.md)  
 [Securing Messages Using Transport Security](../../../../docs/framework/wcf/feature-details/securing-messages-using-transport-security.md)  
 [Securing Messages Using Message Security](../../../../docs/framework/wcf/feature-details/securing-messages-using-message-security.md)  
 [Troubleshooting Queued Messaging](../../../../docs/framework/wcf/feature-details/troubleshooting-queued-messaging.md)
