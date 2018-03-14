---
title: "Poison Message Handling"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8d1c5e5a-7928-4a80-95ed-d8da211b8595
caps.latest.revision: 29
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Poison Message Handling
A *poison message* is a message that has exceeded the maximum number of delivery attempts to the application. This situation can arise when a queue-based application cannot process a message because of errors. To meet reliability demands, a queued application receives messages under a transaction. Aborting the transaction in which a queued message was received leaves the message in the queue so that the message is retried under a new transaction. If the problem that caused the transaction to abort is not corrected, the receiving application can get stuck in a loop receiving and aborting the same message until the maximum number of delivery attempts has been exceeded and a poison message results.  
  
 A message can become a poison message for many reasons. The most common reasons are application specific. For example, if an application reads a message from a queue and performs some database processing, the application may fail to get a lock on the database, causing it to abort the transaction. Because the database transaction was aborted, the message remains in the queue, which causes the application to reread the message a second time and make another attempt to acquire a lock on the database. Messages can also become poison if they contain invalid information. For example, a purchase order may contain an invalid customer number. In these cases, the application may voluntarily abort the transaction and force the message to become a poison message.  
  
 On rare occasions, messages can fail to get dispatched to the application. The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] layer may find a problem with the message, such as if the message has the wrong frame, invalid message credentials attached to it, or an invalid action header. In these cases, the application never receives the message; however, the message can still become a poison message and be processed manually.  
  
## Handling Poison Messages  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], poison message handling provides a mechanism for a receiving application to deal with messages that cannot be dispatched to the application, or messages that are dispatched to the application but which fail to be processed because of application-specific reasons. Poison message handling is configured by the following properties in each of the available queued bindings:  
  
-   `ReceiveRetryCount`. An integer value that indicates the maximum number of times to retry delivery of a message from the application queue to the application. The default value is 5. This is sufficient in cases where an immediate retry fixes the problem, such as with a temporary deadlock on a database.  
  
-   `MaxRetryCycles`. An integer value that indicates the maximum number of retry cycles. A retry cycle consists of transferring a message from the application queue to the retry subqueue and, after a configurable delay, from the retry subqueue back into the application queue to reattempt delivery. The default value is 2. On [!INCLUDE[wv](../../../../includes/wv-md.md)], the message is tried a maximum of (`ReceiveRetryCount` +1) * (`MaxRetryCycles` + 1) times. `MaxRetryCycles` is ignored on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
-   `RetryCycleDelay`. The time delay between retry cycles. The default value is 30 minutes. `MaxRetryCycles` and `RetryCycleDelay` together provide a mechanism to address the problem where a retry after a periodic delay fixes the problem. For example, this handles a locked row set in SQL Server pending transaction commit.  
  
-   `ReceiveErrorHandling`. An enumeration that indicates the action to take for a message that has failed delivery after the maximum number of retries has been attempted. The values can be Fault, Drop, Reject, and Move. The default option is Fault.  
  
-   Fault. This option sends a fault to the listener that caused the `ServiceHost` to fault. The message must be removed from the application queue by some external mechanism before the application can continue to process messages from the queue.  
  
-   Drop. This option drops the poison message and the message is never delivered to the application. If the message's `TimeToLive` property has expired at this point, then the message may appear in the sender's dead-letter queue. If not, the message does not appear anywhere. This option indicates that the user has not specified what to do if the message is lost.  
  
-   Reject. This option is available only on [!INCLUDE[wv](../../../../includes/wv-md.md)]. This instructs Message Queuing (MSMQ) to send a negative acknowledgement back to the sending queue manager that the application cannot receive the message. The message is placed in the sending queue manager's dead-letter queue.  
  
-   Move. This option is available only on [!INCLUDE[wv](../../../../includes/wv-md.md)]. This moves the poison message to a poison-message queue for later processing by a poison-message handling application. The poison-message queue is a subqueue of the application queue. A poison-message handling application can be a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that reads messages out of the poison queue. The poison queue is a subqueue of the application queue and can be addressed as net.msmq://\<*machine-name*>/*applicationQueue*;poison, where *machine-name* is the name of the computer on which the queue resides and the *applicationQueue* is the name of the application-specific queue.  
  
 The following are the maximum number of delivery attempts made for a message:  
  
-   ((ReceiveRetryCount+1) * (MaxRetryCycles + 1)) on [!INCLUDE[wv](../../../../includes/wv-md.md)].  
  
-   (ReceiveRetryCount + 1) on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
> [!NOTE]
>  No retries are made for a message that is delivered successfully.  
  
 To keep track of the number of times a message read is attempted, [!INCLUDE[wv](../../../../includes/wv-md.md)] maintains a durable message property that counts the number of aborts and a move count property that counts the number of times the message moves between the application queue and subqueues. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel uses these to compute the receive retry count and the retry cycles count. On [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)], the abort count is maintained in memory by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel and is reset if the application fails. Also, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel can hold the abort counts for up to 256 messages in memory at any time. If a 257th message is read, then the oldest message's abort count is reset.  
  
 The abort count and move count properties are available to the service operation through the operation context. The following code example shows how to access them.  
  
 [!code-csharp[S_UE_MSMQ_Poison#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ue_msmq_poison/cs/service.cs#1)]  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides two standard queued bindings:  
  
-   <xref:System.ServiceModel.NetMsmqBinding>. A [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] binding suitable for performing queue-based communication with other [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoints.  
  
-   <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>. A binding suitable for communicating with existing Message Queuing applications.  
  
> [!NOTE]
>  You can alter properties in these bindings based on the requirements of your [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service. The entire poison message handling mechanism is local to the receiving application. The process is invisible to the sending application unless the receiving application ultimately stops and sends a negative acknowledgment back to the sender. In that case, the message is moved to the sender's dead-letter queue.  
  
## Best Practice: Handling MsmqPoisonMessageException  
 When the service determines that a message is poison, the queued transport throws a <xref:System.ServiceModel.MsmqPoisonMessageException> that contains the `LookupId` of the poison message.  
  
 A receiving application can implement the <xref:System.ServiceModel.Dispatcher.IErrorHandler> interface to handle any errors that the application requires. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Extending Control Over Error Handling and Reporting](../../../../docs/framework/wcf/samples/extending-control-over-error-handling-and-reporting.md).  
  
 The application may require some kind of automated handling of poison messages that moves the poison messages to a poison message queue so that the service can access the rest of the messages in the queue. The only scenario for using the error-handler mechanism to listen for poison-message exceptions is when the <xref:System.ServiceModel.Configuration.MsmqBindingElementBase.ReceiveErrorHandling%2A> setting is set to <xref:System.ServiceModel.ReceiveErrorHandling.Fault>. The poison-message sample for Message Queuing 3.0 demonstrates this behavior. The following outlines the steps to take to handle poison messages, including best practices:  
  
1.  Ensure your poison settings reflect the requirements of your application. When working with the settings, ensure that you understand the differences between the capabilities of Message Queuing on [!INCLUDE[wv](../../../../includes/wv-md.md)], [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], and [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
2.  If required, implement the `IErrorHandler` to handle poison-message errors. Because setting `ReceiveErrorHandling` to `Fault` requires a manual mechanism to move the poison message out of the queue or to correct an external dependent issue, the typical usage is to implement `IErrorHandler` when `ReceiveErrorHandling` is set to `Fault`, as shown in the following code.  
  
     [!code-csharp[S_UE_MSMQ_Poison#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ue_msmq_poison/cs/poisonerrorhandler.cs#2)]  
  
3.  Create a `PoisonBehaviorAttribute` that the service behavior can use. The behavior installs the `IErrorHandler` on the dispatcher. See the following code example.  
  
     [!code-csharp[S_UE_MSMQ_Poison#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ue_msmq_poison/cs/poisonbehaviorattribute.cs#3)]  
  
4.  Ensure that your service is annotated with the poison behavior attribute.  
  
  
  
 In addition, if the `ReceiveErrorHandling` is set to `Fault`, the `ServiceHost` faults when encountering the poison message. You can hook up to the faulted event and shut down the service, take corrective actions, and restart. For example, the `LookupId` in the <xref:System.ServiceModel.MsmqPoisonMessageException> propagated to the `IErrorHandler` can be noted and when the service host faults, you could use the `System.Messaging` API to receive the message from the queue using the `LookupId` to remove the message from the queue and store the message in some external store or another queue. You can then restart `ServiceHost` to resume normal processing. The [Poison Message Handling in MSMQ 4.0](../../../../docs/framework/wcf/samples/poison-message-handling-in-msmq-4-0.md) demonstrates this behavior.  
  
## Transaction Time-Out and Poison Messages  
 A class of errors can occur between the queued transport channel and the user code. These errors can be detected by layers in-between, such as the message security layer or the service dispatching logic. For example, a missing X.509 certificate detected in the SOAP security layer and a missing action are cases where the message does get dispatched to the application. When this happens, the service model drops the message. Because the message is read in a transaction and an outcome for that transaction cannot be provided, the transaction eventually times out, aborts, and the message is put back into the queue. In other words, for a certain class of errors, the transaction does not immediately abort but waits until the transaction times out. You can modify the transaction time-out for a service using <xref:System.ServiceModel.ServiceBehaviorAttribute>.  
  
 To change the transaction time-out on a computer-wide basis, modify the machine.config file and set the appropriate transaction time-out. It is important to note that, depending on the time-out set in the transaction, the transaction eventually aborts and goes back to the queue and its abort count is incremented. Eventually, the message becomes poison and the right disposition is made according to the user settings.  
  
## Sessions and Poison Messages  
 A session undergoes the same retry and poison-message handling procedures as a single message. The properties previously listed for poison messages apply to the entire session. This means that the entire session is retried and goes to a final poison-message queue or the sender’s dead-letter queue if the message is rejected.  
  
## Batching and Poison Messages  
 If a message becomes a poison message and is part of a batch, then the entire batch is rolled back and the channel returns to reading one message at a time. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] batching, see [Batching Messages in a Transaction](../../../../docs/framework/wcf/feature-details/batching-messages-in-a-transaction.md)  
  
## Poison-message Handling for Messages in a Poison Queue  
 Poison-message handling does not end when a message is placed in the poison-message queue. Messages in the poison-message queue must still be read and handled. You can use a subset of the poison-message handling settings when reading messages from the final poison subqueue. The applicable settings are `ReceiveRetryCount` and `ReceiveErrorHandling`. You can set `ReceiveErrorHandling` to Drop, Reject, or Fault. `MaxRetryCycles` is ignored and an exception is thrown if `ReceiveErrorHandling` is set to Move.  
  
## Windows Vista, Windows Server 2003, and Windows XP Differences  
 As noted earlier, not all poison-message handling settings apply to [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)]. The following key differences between Message Queuing on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], [!INCLUDE[wxp](../../../../includes/wxp-md.md)], and [!INCLUDE[wv](../../../../includes/wv-md.md)] are relevant to poison-message handling:  
  
-   Message Queuing in [!INCLUDE[wv](../../../../includes/wv-md.md)] supports subqueues, while [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)] do not support subqueues. Subqueues are used in poison-message handling. The retry queues and the poison queue are subqueues to the application queue that is created based on the poison-message handling settings. The `MaxRetryCycles` dictates how many retry subqueues to create. Therefore, when running on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] or [!INCLUDE[wxp](../../../../includes/wxp-md.md)], `MaxRetryCycles` are ignored and `ReceiveErrorHandling.Move` is not allowed.  
  
-   Message Queuing in [!INCLUDE[wv](../../../../includes/wv-md.md)] supports negative acknowledgment, while [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)] do not. A negative acknowledgment from the receiving queue manager causes the sending queue manager to place the rejected message in the dead-letter queue. As such, `ReceiveErrorHandling.Reject` is not allowed with [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
-   Message Queuing in [!INCLUDE[wv](../../../../includes/wv-md.md)] supports a message property that keeps count of the number of times message delivery is attempted. This abort count property is not available on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)]. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] maintains the abort count in memory, so it is possible that this property may not contain an accurate value when the same message is read by more than one [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service in a farm.  
  
## See Also  
 [Queues Overview](../../../../docs/framework/wcf/feature-details/queues-overview.md)  
 [Differences in Queuing Features in Windows Vista, Windows Server 2003, and Windows XP](../../../../docs/framework/wcf/feature-details/diff-in-queue-in-vista-server-2003-windows-xp.md)  
 [Specifying and Handling Faults in Contracts and Services](../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)
