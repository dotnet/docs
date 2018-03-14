---
title: "Using Dead-Letter Queues to Handle Message Transfer Failures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 9e891c6a-d960-45ea-904f-1a00e202d61a
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Dead-Letter Queues to Handle Message Transfer Failures
Queued messages can fail delivery. These failed messages are recorded in a dead-letter queue. The failed delivery can be caused by reasons such as network failures, a deleted queue, a full queue, authentication failure, or a failure to deliver on time.  
  
 Queued messages can remain in the queue for a long time if the receiving application does not read them from the queue in a timely fashion. This behavior may not be appropriate for time-sensitive messages. Time-sensitive messages have a Time to Live (TTL) property set in the queued binding, which indicates how long the messages can be in the queue before they must expire. Expired messages are sent to a special queue called the dead-letter queue. Messages can also be put in a dead-letter queue for other reasons, such as exceeding a queue quota or because of authentication failure.  
  
 Generally, applications write compensation logic to read messages from the dead-letter queue and failure reasons. The compensation logic depends on the cause of the failure. For example, in the case of authentication failure, you can correct the certificate attached with the message and resend the message. If delivery failed because the target queue quota was reached, you can reattempt delivery in the hope that the quota problem was resolved.  
  
 Most queuing systems have a system-wide dead-letter queue where all failed messages from that system are stored. Message Queuing (MSMQ) provides two system-wide dead-letter queues: a transactional system-wide dead-letter queue that stores messages that failed delivery to the transactional queue and a non-transactional system-wide dead-letter queue that stores messages that failed delivery to the non-transactional queue. If two clients are sending messages to two different services, and therefore different queues in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] are sharing the same MSMQ service to send, then it is possible to have a mix of messages in the system dead-letter queue. This is not always optimal. In several cases (security, for example), you may not want one client to read another client's messages from a dead-letter queue. A shared dead-letter queue also requires clients to browse through the queue to find a message that they sent, which can be prohibitively expensive based on the number of messages in the dead-letter queue. Therefore, in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]`NetMsmqBinding`, `MsmqIntegrationBinding,` and MSMQ on [!INCLUDE[wv](../../../../includes/wv-md.md)] provide a custom dead-letter queue (sometimes referred to as an application-specific dead-letter queue).  
  
 The custom dead-letter queue provides isolation between clients that share the same MSMQ service to send messages.  
  
 On [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)], [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides a system-wide dead-letter queue for all queued client applications. On [!INCLUDE[wv](../../../../includes/wv-md.md)], [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a dead-letter queue for each queued client application.  
  
## Specifying Use of the Dead-Letter Queue  
 A dead-letter queue is in the queue manager of the sending application. It stores messages that have expired or that have failed transfer or delivery.  
  
 The binding has the following dead-letter queue properties:  
  
-   <xref:System.ServiceModel.MsmqBindingBase.DeadLetterQueue%2A>  
  
-   <xref:System.ServiceModel.MsmqBindingBase.CustomDeadLetterQueue%2A>  
  
## Reading Messages from the Dead-Letter Queue  
 An application that reads messages out of a dead-letter queue is similar to a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that reads from an application queue, except for the following minor differences:  
  
-   To read messages from a system transactional dead-letter queue, the Uniform Resource Identifier (URI) must be of the form: net.msmq://localhost/system$;DeadXact.  
  
-   To read messages from a system non-transactional dead-letter queue, the URI must be of the form: net.msmq://localhost/system$;DeadLetter.  
  
-   To read messages from a custom dead-letter queue, the URI must be of the form:net.msmq://localhost/private/\<*custom-dlq-name*> where *custom-dlq-name* is the name of the custom dead-letter queue.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to address queues, see [Service Endpoints and Queue Addressing](../../../../docs/framework/wcf/feature-details/service-endpoints-and-queue-addressing.md).  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] stack on the receiver matches addresses that the service is listening on with the address on the message. If the addresses match, the message is dispatched; if not, the message is not dispatched. This can cause problems when reading from the dead-letter queue, because messages in the dead-letter queue are typically addressed to the service and not the dead-letter queue service. Therefore, the service reading from the dead-letter queue must install an address filter `ServiceBehavior` that instructs the stack to match all messages in the queue independently of the addressee. Specifically, you must add a `ServiceBehavior` with the <xref:System.ServiceModel.AddressFilterMode.Any> parameter to the service reading messages from the dead-letter queue.  
  
## Poison Message Handling from the Dead-Letter Queue  
 Poison message handling is available on dead-letter queues, with some conditions. Because you cannot create sub-queues from system queues, when reading from the system dead-letter queue, the `ReceiveErrorHandling` cannot be set to `Move`. Note that if you are reading from a custom dead-letter queue, you can have sub-queues and, therefore, `Move` is a valid disposition for the poison message.  
  
 When `ReceiveErrorHandling` is set to `Reject`, when reading from the custom dead letter queue, the poison message is put in the system dead-letter queue. If reading from the system dead-letter queue, the message is dropped (purged). A reject from a system dead-letter queue in MSMQ drops (purges) the message.  
  
## Example  
 The following example shows how to create a dead-letter queue and how to use it to process expired messages. The example is based on the example in [How to: Exchange Queued Messages with WCF Endpoints](../../../../docs/framework/wcf/feature-details/how-to-exchange-queued-messages-with-wcf-endpoints.md). The following example shows how to write the client code to the order processing service that uses a dead-letter queue for each application. The example also shows how to process messages from the dead-letter queue.  
  
 The following is code for a client that specifies a dead-letter queue for each application.  
  
 [!code-csharp[S_DeadLetter#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_deadletter/cs/client.cs#1)]
 [!code-vb[S_DeadLetter#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_deadletter/vb/client.vb#1)]  
  
 The following is code for the client configuration file.  
  
  
  
 The following is code for a service processing messages from a dead-letter queue.  
  
 [!code-csharp[S_DeadLetter#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_deadletter/cs/dlservice.cs#3)]
 [!code-vb[S_DeadLetter#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_deadletter/vb/dlservice.vb#3)]  
  
 The following is code for the dead-letter queue service configuration file.  
  
  
  
## See Also  
 [Queues Overview](../../../../docs/framework/wcf/feature-details/queues-overview.md)  
 [How to: Exchange Queued Messages with WCF Endpoints](../../../../docs/framework/wcf/feature-details/how-to-exchange-queued-messages-with-wcf-endpoints.md)  
 [Poison Message Handling](../../../../docs/framework/wcf/feature-details/poison-message-handling.md)
