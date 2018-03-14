---
title: "Differences in Queuing Features in Windows Vista, Windows Server 2003, and Windows XP"
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
  - "queues [WCF], differences in operating systems"
ms.assetid: aa809d93-d0a3-4ae6-a726-d015cca37c04
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Differences in Queuing Features in Windows Vista, Windows Server 2003, and Windows XP
This topic summarizes the differences in the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] queues feature between [!INCLUDE[wv](../../../../includes/wv-md.md)], [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], and [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
## Application-Specific Dead-Letter Queue  
 Queued messages can remain in the queue indefinitely if the receiving application does not read them in a timely fashion. This behavior is not advisable if the messages are time-sensitive. Time-sensitive messages have a `TimeToLive` property set in the queued binding. This property indicates how long the messages can be in the queue before they expire. Expired messages are sent to a special queue called the dead-letter queue. A message can also end up in a dead-letter queue for other reasons, such as exceeding a queue quota or experiencing an authentication failure.  
  
 Typically, a single system-wide dead-letter queue exists for all queued applications that share a queue manager. A dead-letter queue for each application enables better isolation between queued applications that share a queue manager by allowing these applications to specify their own application-specific dead-letter queue. An application that shares a dead-letter queue with other applications has to browse the queue to find messages that are applicable to it. With an application-specific dead-letter queue, the application can be assured that all messages in its dead-letter queue are applicable to it.  
  
 [!INCLUDE[wv](../../../../includes/wv-md.md)] provides for application-specific dead-letter queues. Application-specific dead-letter queues are not available in [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)], and applications must use the system-wide dead-letter queue.  
  
## Poison-Message Handling  
 A poison message is a message that has exceeded the maximum number of delivery attempts to the receiving application. This situation can arise when an application that reads a message from a transactional queue cannot process the message immediately because of errors. If the application aborts the transaction in which the queued message was received, it returns the message to the queue. The application then tries to retrieve the message again in a new transaction. If the problem that causes the error is not corrected, the receiving application can get stuck in a loop receiving and aborting the same message until it exceeds the maximum number of delivery attempts, and a poison message results.  
  
 The key differences between Message Queuing (MSMQ) on [!INCLUDE[wv](../../../../includes/wv-md.md)], [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], and [!INCLUDE[wxp](../../../../includes/wxp-md.md)] that are relevant to poison handling include the following:  
  
-   MSMQ in [!INCLUDE[wv](../../../../includes/wv-md.md)] supports subqueues, while [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)] do not support subqueues. Subqueues are used in poison-message handling. The retry queues and the poison queue are subqueues to the application queue that is created based on the poison-message handling settings. The `MaxRetryCycles` dictates how many retry subqueues to create. Therefore, when running on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] or [!INCLUDE[wxp](../../../../includes/wxp-md.md)], `MaxRetryCycles` are ignored and `ReceiveErrorHandling.Move` is not allowed.  
  
-   MSMQ in [!INCLUDE[wv](../../../../includes/wv-md.md)] supports negative acknowledgment, while [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)] do not. A negative acknowledgment from the receiving queue manager causes the sending queue manager to place the rejected message in the dead-letter queue. As such, `ReceiveErrorHandling.Reject` is not allowed with [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
-   MSMQ in [!INCLUDE[wv](../../../../includes/wv-md.md)] supports a message property that keeps count of the number of times message delivery is attempted. This abort count property is not available on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)]. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] maintains the abort count in memory, so it is possible that this property may not contain an accurate value when the same message is read by more than one [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service in a Web farm.  
  
## Remote Transactional Read  
 MSMQ on [!INCLUDE[wv](../../../../includes/wv-md.md)] supports remote transactional reads. This allows an application that is reading from a queue to be hosted on a computer that is different from the computer on which the queue is hosted. This ensures the ability to have a farm of services reading from a central queue, which increases the overall throughput of the system. It also ensures that if a failure occurs when reading and processing the message, the transaction rolls back and the message remains in the queue for later processing.  
  
## See Also  
 [Using Dead-Letter Queues to Handle Message Transfer Failures](../../../../docs/framework/wcf/feature-details/using-dead-letter-queues-to-handle-message-transfer-failures.md)  
 [Poison Message Handling](../../../../docs/framework/wcf/feature-details/poison-message-handling.md)
