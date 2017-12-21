---
title: "Web Hosting a Queued Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c7a539fa-e442-4c08-a7f1-17b7f5a03e88
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Web Hosting a Queued Application
The Windows Process Activation Service (WAS) manages the activation and lifetime of the worker processes that contain applications that host [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services. The WAS process model generalizes the [!INCLUDE[iis601](../../../../includes/iis601-md.md)] process model for the HTTP server by removing the dependency on HTTP. This allows [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services to use both HTTP and non-HTTP protocols, such as net.msmq and msmq.formatname, in a hosting environment that supports message-based activation and offers the ability to host a large number of applications on a given computer.  
  
 WAS includes a Message Queuing (MSMQ) activation service that activates a queued application when one or more messages are placed in one of the queues used by the application. The MSMQ activation service is an NT service that is automatically started by default.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] WAS and its benefits, see [Hosting in Windows Process Activation Service](../../../../docs/framework/wcf/feature-details/hosting-in-windows-process-activation-service.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] MSMQ, see [Queues Overview](../../../../docs/framework/wcf/feature-details/queues-overview.md)  
  
## Queue Addressing in WAS  
 WAS applications have Uniform Resource Identifier (URI) addresses. Application addresses have two parts: a base URI prefix and an application-specific, relative address (path). These two parts provide the external address for an application when joined together. The base URI prefix is constructed from the site binding and is used for all the applications under the site, for example, "net.msmq://localhost", "msmq.formatname://localhost", or "net.tcp://localhost". Application addresses are then constructed by taking application-specific path fragments (such as "/applicationOne") and appending them to the base URI prefix to arrive at the full application URI, for example, "net.msmq://localhost/applicationOne".  
  
 The MSMQ activation service uses the application URI to match the queue that the MSMQ activation service must monitor for messages. When the MSMQ activation service starts, it enumerates all public and private queues on the computer it is configured to receive from and monitors them for messages. Every 10 minutes, the MSMQ activation service refreshes the list of queues to monitor. When a message is found in a queue, the activation service matches the queue name to the longest matching application URI for the net.msmq binding and activates the application.  
  
> [!NOTE]
>  The application being activated must match (longest match) the prefix of the queue name.  
  
 For example, a queue name is: msmqWebHost/orderProcessing/service.svc. If Application 1 has a virtual directory /msmqWebHost/orderProcessing with a service.svc under it, and Application 2 has a virtual directory /msmqWebHost with an orderProcessing.svc under it, Application 1 is activated. If Application 1 is deleted, Application 2 is activated.  
  
> [!NOTE]
>  When a queue is created, any messages sent to it do not activate an application until the MSMQ activation service refreshes the queue list, which is, at most, 10 minutes from the time the queue was created. Restarting the activation service refreshes the queue list as well.  
  
### The Effect of Private and Public Queues on Addressing  
 The MSMQ activation service does not distinguish between private and public queue monitoring. As such, you cannot have public and private queues with the same name. If you do, a Web-hosted application may get activated reading from either of the queues.  
  
### Queue Configuration for Activation  
 The MSMQ activation service runs as NETWORK SERVICE. It is the service that monitors queues to activate applications. For it to activate applications from the queue, the queue must provide for NETWORK SERVICE access to peek for messages in its access control list (ACL).  
  
### Poison Messaging  
 Poison message handling in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is handled by the channel, which not only detects that a message is poisoned but selects a disposition based on user configuration. As a result, there is a single message in the queue. The Web-hosted application aborts successive times and the message is moved to a retry queue. At a point dictated by the retry cycle delay, the message is moved from the retry queue to the main queue to try again. But this requires the queued channel to be active. If the application is recycled by WAS, then the message remains in the retry queue until another message arrives in the main queue to activate the queued application. The workaround in this case is to move the message manually from the retry queue back to the main queue to reactivate the application.  
  
### Subqueue and System Queue Caveat  
 A WAS-hosted application cannot be activated based on messages in a system queue, such as the system-wide dead-letter queue, or sub-queues, such as poison sub-queues. This is a limitation for this version of the product.  
  
## See Also  
 [Poison Message Handling](../../../../docs/framework/wcf/feature-details/poison-message-handling.md)  
 [Service Endpoints and Queue Addressing](../../../../docs/framework/wcf/feature-details/service-endpoints-and-queue-addressing.md)
