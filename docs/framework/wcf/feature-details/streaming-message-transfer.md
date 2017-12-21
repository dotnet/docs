---
title: "Streaming Message Transfer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 72a47a51-e5e7-4b76-b24a-299d51e0ae5a
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Streaming Message Transfer
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] transports support two modes for transferring messages:  
  
-   Buffered transfers hold the entire message in a memory buffer until the transfer is complete. A buffered message must be completely delivered before a receiver can read it.  
  
-   Streamed transfers expose the message as a stream. The receiver starts processing the message before it is completely delivered.  
  
-   Streamed transfers can improve the scalability of a service by eliminating the requirement for large memory buffers. Whether changing the transfer mode improves scalability depends on the size of the messages being transferred. Large message sizes favor using streamed transfers.  
  
 By default, the HTTP, TCP/IP, and named pipe transports use buffered transfers. This document describes how to switch these transports from a buffered to streamed transfer mode and the consequences of doing so.  
  
## Enabling Streamed Transfers  
 Selecting between buffered and streamed transfer modes is done on the binding element of the transport. The binding element has a <xref:System.ServiceModel.TransferMode> property that can be set to `Buffered`, `Streamed`, `StreamedRequest`, or `StreamedResponse`. Setting the transfer mode to `Streamed` enables streaming communication in both directions. Setting the transfer mode to `StreamedRequest` or `StreamedResponse` enables streaming communication in the indicated direction only.  
  
 The <xref:System.ServiceModel.BasicHttpBinding>, <xref:System.ServiceModel.NetTcpBinding>, and <xref:System.ServiceModel.NetNamedPipeBinding> bindings expose the <xref:System.ServiceModel.TransferMode> property. For other transports, you must create a custom binding to set the transfer mode.  
  
 The decision to use either buffered or streamed transfers is a local decision of the endpoint. For HTTP transports, the transfer mode does not propagate across a connection, or to servers and other intermediaries. Setting the transfer mode is not reflected in the description of the service interface. After generating a client class for a service, you must edit the configuration file for services intended to be used with streamed transfers to set the mode. For TCP and named pipe transports, the transfer mode is propagated as a policy assertion.  
  
 For code samples, see [How to: Enable Streaming](../../../../docs/framework/wcf/feature-details/how-to-enable-streaming.md).  
  
## Enabling Asynchronous Streaming  
 To enable asynchronous streaming, add the  <xref:System.ServiceModel.Description.DispatcherSynchronizationBehavior> endpoint behavior to the service host and set its <xref:System.ServiceModel.Description.DispatcherSynchronizationBehavior.AsynchronousSendEnabled%2A> property to `true`.  
  
 This version of WCF also adde the capability of true asynchronous streaming on the send side. This improves scalability of the service in scenarios where it is streaming messages to multiple clients some of which are slow in reading; possibly due to network congestion or are not reading at all. In these scenarios WCF no longer blocks individual threads on the service per client. This ensures that the service is able to process many more clients thereby improving the scalability of the service.  
  
## Restrictions on Streamed Transfers  
 Using the streamed transfer mode causes the run time to enforce additional restrictions.  
  
 Operations that occur across a streamed transport can have a contract with at most one input or output parameter. That parameter corresponds to the entire body of the message and must be a <xref:System.ServiceModel.Channels.Message>, a derived type of <xref:System.IO.Stream>, or an <xref:System.Xml.Serialization.IXmlSerializable> implementation. Having a return value for an operation is equivalent to having an output parameter.  
  
 Some [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] features, such as reliable messaging, transactions, and SOAP message-level security, rely on buffering messages for transmissions. Using these features may reduce or eliminate the performance benefits gained by using streaming. To secure a streamed transport, use transport-level security only or use transport-level security plus authentication-only message security.  
  
 SOAP headers are always buffered, even when the transfer mode is set to streamed. The headers for a message must not exceed the size of the `MaxBufferSize` transport quota. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] this setting, see [Transport Quotas](../../../../docs/framework/wcf/feature-details/transport-quotas.md).  
  
## Differences Between Buffered and Streamed Transfers  
 Changing the transfer mode from buffered to streamed also changes the native channel shape of the TCP and named pipe transports. For buffered transfers, the native channel shape is <xref:System.ServiceModel.Channels.IDuplexSessionChannel>. For streamed transfers, the native channels are <xref:System.ServiceModel.Channels.IRequestChannel> and <xref:System.ServiceModel.Channels.IReplyChannel>. Changing the transfer mode in an existing application that uses these transports directly (that is, not through a service contract) requires changing the expected channel shape for channel factories and listeners.  
  
## See Also  
 [How to: Enable Streaming](../../../../docs/framework/wcf/feature-details/how-to-enable-streaming.md)
