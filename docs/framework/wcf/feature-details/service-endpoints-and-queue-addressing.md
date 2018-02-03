---
title: "Service Endpoints and Queue Addressing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7d2d59d7-f08b-44ed-bd31-913908b83d97
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service Endpoints and Queue Addressing
This topic discusses how clients address services that read from queues and how service endpoints map to queues. As a reminder, the following illustration shows the classic [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] queued application deployment.  
  
 ![Queued Application Diagram](../../../../docs/framework/wcf/feature-details/media/distributed-queue-figure.jpg "Distributed-Queue-Figure")  
  
 For the client to send the message to the service, the client addresses the message to the Target Queue. For the service to read messages from the queue, it sets its listen address to the Target Queue. Addressing in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is Uniform Resource Identifier (URI)-based while Message Queuing (MSMQ) queue names are not URI-based. It is therefore essential to understand how to address queues created in MSMQ using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## MSMQ Addressing  
 MSMQ uses paths and format names to identify a queue. Paths specify a host name and a `QueueName`. Optionally, there can be a `Private$` between the host name and the `QueueName` to indicate a private queue that is not published in the Active Directory directory service.  
  
 Path names are mapped to "FormatNames" to determine additional aspects of the address, including routing and queue manager transfer protocol. The Queue Manager supports two transfer protocols: native MSMQ protocol and SOAP Reliable Messaging Protocol (SRMP).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] MSMQ path and format names, see [About Message Queuing](http://go.microsoft.com/fwlink/?LinkId=94837).  
  
## NetMsmqBinding and Service Addressing  
 When addressing a message to a service, the scheme in the URI is chosen based on the transport used for communication. Each transport in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] has a unique scheme. The scheme must reflect the nature of transport used for communication. For example, net.tcp, net.pipe, HTTP, and so on.  
  
 The MSMQ queued transport in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] exposes a net.msmq scheme. Any message addressed using the net.msmq scheme is sent using the `NetMsmqBinding` over the MSMQ queued transport channel.  
  
 The addressing of a queue in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is based on the following pattern:  
  
 net.msmq: // \<*host-name*> / [private/] \<*queue-name*>  
  
 where:  
  
-   \<*host-name*> is the name of the machine that hosts the Target Queue.  
  
-   [private] is optional. It is used when addressing a Target Queue that is a private queue. To address a public queue, you must not specify private. Note that, unlike MSMQ paths, there is no "$" in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] URI form.  
  
-   \<*queue-name*> is the name of the queue. The queue name can also refer to a subqueue. Thus, \<*queue-name*> = \<*name-of-queue*>[;*sub-queue-name*].  
  
 Example1: To address a private queue PurchaseOrders hosted on computer abc atadatum.com, the URI would be net.msmq://abc.adatum.com/private/PurchaseOrders.  
  
 Example2: To address a public queue AccountsPayable hosted on computer def atadatum.com, the URI would be net.msmq://def.adatum.com/AccountsPayable.  
  
 The queue address is used as the Listen URI by the Listener to read messages from. In other words, the queue address is equivalent to the listen port of TCP socket.  
  
 An endpoint that reads from a queue must specify the address of the queue using the same scheme specified previously when opening the ServiceHost. For examples, see [Net MSMQ Binding](../../../../docs/framework/wcf/samples/net-msmq-binding.md) and [Message Queuing Integration Binding Samples](http://msdn.microsoft.com/library/997d11cb-f2c5-4ba0-9209-92843d4d0e1a).  
  
### Multiple Contracts in a Queue  
 Messages in a queue can implement different contracts. In this case, it is essential that one of the following is true to successfully read and process all messages:  
  
-   Specify an endpoint for a service that implements all the contracts. This is the recommended approach.  
  
-   Specify multiple endpoints with different contracts, but ensure that all the endpoints use the same `NetMsmqBinding` object. The dispatching logic in ServiceModel uses a message pump that reads messages out of the transport channel for dispatch, which eventually de-multiplexes messages based on the contract to different endpoints. A message pump is created for a listen URI/Binding pair. The queue address is used as the Listen URI by the queued listener. Having all the endpoints use the same binding object ensures that a single message pump is used to read the message and de-multiplex to relevant endpoints based on the contract.  
  
### SRMP Messaging  
 As previously discussed, you can use the SRMP protocol for queue-to-queue transfers. This is commonly used when an HTTP transport transmits messages between the Transmission Queue and the Target Queue.  
  
 To use the SRMP transfer protocol, address messages using the net.msmq URI scheme, as mentioned previously, and specify the choice of SRMP or Secured SRMP in the `QueueTransferProtocol` property of the `NetMsmqBinding`.  
  
 Specifying the `QueueTransferProtocol` property is a send-only feature. This is an indication by the client which kind of queue transfer protocol to use.  
  
### Using Active Directory  
 MSMQ comes with support for Active Directory integration. When MSMQ is installed with Active Directory integration, the machine must be part of a Windows domain. Active Directory is used to publish queues for discovery; such queues are called *public queues*. When addressing a queue, the queue can be resolved using Active Directory. This is similar to how Domain Name System (DNS) is used to resolve the IP address of a network name. The `UseActiveDirectory` property in `NetMsmqBinding` is a Boolean that indicates whether the queued channel must use Active Directory to resolve the queue URI. By default it is set to `false`. If the `UseActiveDirectory` property is set to `true`, then the queued channel uses Active Directory to convert the net.msmq:// URI to format name.  
  
 The `UseActiveDirectory` property is meaningful only for the client that is sending the message because it is used to resolve the address of the queue when sending messages.  
  
### Mapping net.msmq URI to Message Queuing Format Names  
 The queued channel handles mapping the net.msmq URI name provided to the channel to MSMQ format names. The following table summarizes the rules used to map between them.  
  
|WCF URI-based queue address|Use Active Directory property|Queue Transfer Protocol property|Resulting MSMQ format names|  
|----------------------------------|-----------------------------------|--------------------------------------|---------------------------------|  
|Net.msmq://\<machine-name>/private/abc|False (default)|Native (default)|DIRECT=OS:machine-name\private$\abc|  
|Net.msmq://\<machine-name>/private/abc|False|SRMP|DIRECT=http://machine/msmq/private$/abc|  
|Net.msmq://\<machine-name>/private/abc|True|Native|PUBLIC=some-guid (the GUID of the queue)|  
  
### Reading Messages from the Dead-Letter Queue or the Poison-Message Queue  
 To read messages from a poison-message queue that is a subqueue of the target queue, open the `ServiceHost` with the address of the subqueue.  
  
 Example: A service that reads from the poison-message queue of the PurchaseOrders private queue from the local machine would address net.msmq://localhost/private/PurchaseOrders;poison.  
  
 To read messages from a system transactional dead-letter queue, the URI must be of the form: net.msmq://localhost/system$;DeadXact.  
  
 To read messages from a system nontransactional dead-letter queue, the URI must be of the form: net.msmq://localhost/system$;DeadLetter.  
  
 When using a custom dead-letter queue, note that the dead-letter queue must reside on the local computer. As such, the URI for the dead-letter queue is restricted to the form:  
  
 net.msmq: //localhost/ [private/]  \<*custom-dead-letter-queue-name*>.  
  
 A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service verifies that all messages it receives were addressed to the particular queue it is listening on. If the message’s destination queue does not match the queue it is found in, the service does not process the message. This is an issue that services listening to a dead-letter queue must address because any message in the dead-letter queue was meant to be delivered elsewhere. To read messages from a dead-letter queue, or from a poison queue, a `ServiceBehavior` with the <xref:System.ServiceModel.AddressFilterMode.Any> parameter must be used. For an example, see [Dead Letter Queues](../../../../docs/framework/wcf/samples/dead-letter-queues.md).  
  
## MsmqIntegrationBinding and Service Addressing  
 The `MsmqIntegrationBinding` is used for communication with traditional MSMQ applications. To ease interoperation with an existing MSMQ application, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports only format name addressing. Thus, messages sent using this binding must conform to the URI scheme:  
  
 msmq.formatname:\<*MSMQ-format-name*>>  
  
 The MSMQ-format-name is of the form specified by MSMQ in [About Message Queuing](http://go.microsoft.com/fwlink/?LinkId=94837).  
  
 Note that you can only use direct format names, and public and private format names (requires Active Directory integration) when receiving messages from a queue using `MsmqIntegrationBinding`. However, it is advised that you use direct format names. For example, on [!INCLUDE[wv](../../../../includes/wv-md.md)], using any other format name causes an error because the system attempts to open a subqueue, which can only be opened with direct format names.  
  
 When addressing SRMP using `MsmqIntegrationBinding`, there is no requirement to add /msmq/ in the direct format name to help Internet Information Services (IIS) with dispatching. For example: When addressing a queue abc using the SRMP protocol, instead of DIRECT=http://adatum.com/msmq/private$/abc, you should use DIRECT=http://adatum.com/private$/abc.  
  
 Note that you cannot use net.msmq:// addressing with `MsmqIntegrationBinding`. Because `MsmqIntegrationBinding` supports free-form MSMQ format name addressing, you can use a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that uses this binding to use multicast and distribution list features in MSMQ. One exception is specifying `CustomDeadLetterQueue` when using the `MsmqIntegrationBinding`. It must be of the form net.msmq://, similar to how it is specified using the `NetMsmqBinding`.  
  
## See Also  
 [Web Hosting a Queued Application](../../../../docs/framework/wcf/feature-details/web-hosting-a-queued-application.md)
