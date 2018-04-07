---
title: "What Is Windows Communication Foundation"
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
  - "Windows Communication Foundation [WCF], technology overview"
  - "technology overview [WCF]"
  - "WCF [WCF], technology overview"
ms.assetid: 40e1009d-ef15-450b-9848-62eabe5e5738
caps.latest.revision: 51
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# What Is Windows Communication Foundation
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] is a framework for building service-oriented applications. Using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], you can send data as asynchronous messages from one service endpoint to another. A service endpoint can be part of a continuously available service hosted by IIS, or it can be a service hosted in an application. An endpoint can be a client of a service that requests data from a service endpoint. The messages can be as simple as a single character or word sent as XML, or as complex as a stream of binary data. A few sample scenarios include:  
  
-   A secure service to process business transactions.  
  
-   A service that supplies current data to others, such as a traffic report or other monitoring service.  
  
-   A chat service that allows two people to communicate or exchange data in real time.  
  
-   A dashboard application that polls one or more services for data and presents it in a logical presentation.  
  
-   Exposing a workflow implemented using Windows Workflow Foundation as a WCF service.  
  
-   A Silverlight application to poll a service for the latest data feeds.  
  
 While creating such applications was possible prior to the existence of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] makes the development of endpoints easier than ever. In summary, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] is designed to offer a manageable approach to creating Web services and Web service clients.  
  
## Features of WCF  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] includes the following set of features. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [WCF Feature Details](../../../docs/framework/wcf/feature-details/index.md).  
  
-   **Service Orientation**  
  
     One consequence of using WS standards is that [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] enables you to create *service oriented* applications. Service-oriented architecture (SOA) is the reliance on Web services to send and receive data. The services have the general advantage of being loosely-coupled instead of hard-coded from one application to another. A loosely-coupled relationship implies that any client created on any platform can connect to any service as long as the essential contracts are met.  
  
-   **Interoperability**  
  
     [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] implements modern industry standards for Web service interoperability. [!INCLUDE[crabout](../../../includes/crabout-md.md)] the supported standards, see [Interoperability and Integration](../../../docs/framework/wcf/feature-details/interoperability-and-integration.md).  
  
-   **Multiple Message Patterns**  
  
     Messages are exchanged in one of several patterns. The most common pattern is the request/reply pattern, where one endpoint requests data from a second endpoint. The second endpoint replies. There are other patterns such as a one-way message in which a single endpoint sends a message without any expectation of a reply. A more complex pattern is the duplex exchange pattern where two endpoints establish a connection and send data back and forth, similar to an instant messaging program. [!INCLUDE[crabout](../../../includes/crabout-md.md)] how to implement different message exchange patterns using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] see [Contracts](../../../docs/framework/wcf/feature-details/contracts.md).  
  
-   **Service Metadata**  
  
     [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] supports publishing service metadata using formats specified in industry standards such as WSDL, XML Schema and WS-Policy. This metadata can be used to automatically generate and configure clients for accessing [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services. Metadata can be published over HTTP and HTTPS or using the Web Service Metadata Exchange standard. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Metadata](../../../docs/framework/wcf/feature-details/metadata.md).  
  
-   **Data Contracts**  
  
     Because [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] is built using the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], it also includes code-friendly methods of supplying the contracts you want to enforce. One of the universal types of contracts is the data contract. In essence, as you code your service using Visual C# or Visual Basic, the easiest way to handle data is by creating classes that represent a data entity with properties that belong to the data entity. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] includes a comprehensive system for working with data in this easy manner. Once you have created the classes that represent data, your service automatically generates the metadata that allows clients to comply with the data types you have designed. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Using Data Contracts](../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
  
-   **Security**  
  
     Messages can be encrypted to protect privacy and you can require users to authenticate themselves before being allowed to receive messages. Security can be implemented using well-known standards such as SSL or WS-SecureConversation. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Security](../../../docs/framework/wcf/feature-details/security.md).  
  
-   **Multiple Transports and Encodings**  
  
     Messages can be sent on any of several built-in transport protocols and encodings. The most common protocol and encoding is to send text encoded SOAP messages using the HyperText Transfer Protocol (HTTP) for use on the World Wide Web. Alternatively, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] allows you to send messages over TCP, named pipes, or MSMQ. These messages can be encoded as text or using an optimized binary format.  Binary data can be sent efficiently using the MTOM standard. If none of the provided transports or encodings suit your needs you can create your own custom transport or encoding. [!INCLUDE[crabout](../../../includes/crabout-md.md)] transports and encodings supported by [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] see [Transports](../../../docs/framework/wcf/feature-details/transports.md).  
  
-   **Reliable and Queued Messages**  
  
     [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] supports reliable message exchange using reliable sessions implemented over WS-Reliable Messaging and using MSMQ. [!INCLUDE[crabout](../../../includes/crabout-md.md)] reliable and queued messaging support in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] see [Queues and Reliable Sessions](../../../docs/framework/wcf/feature-details/queues-and-reliable-sessions.md).  
  
-   **Durable Messages**  
  
     A durable message is one that is never lost due to a disruption in the communication. The messages in a durable message pattern are always saved to a database. If a disruption occurs, the database allows you to resume the message exchange when the connection is restored. You can also create a durable message using the [!INCLUDE[wf](../../../includes/wf-md.md)]. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Workflow Services](../../../docs/framework/wcf/feature-details/workflow-services.md).  
  
-   **Transactions**  
  
     WCF also supports transactions using one of three transaction models: WS-AtomicTtransactions, the APIs in the <xref:System.Transactions> namespace, and Microsoft Distributed Transaction Coordinator. [!INCLUDE[crabout](../../../includes/crabout-md.md)] transaction support in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] see [Transactions](../../../docs/framework/wcf/feature-details/transactions-in-wcf.md).  
  
-   **AJAX and REST Support**  
  
     REST is an example of an evolving Web 2.0 technology. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] can be configured to process "plain" XML data that is not wrapped in a SOAP envelope. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] can also be extended to support specific XML formats, such as ATOM (a popular RSS standard), and even non-XML formats, such as JavaScript Object Notation (JSON).  
  
-   **Extensibility**  
  
     The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] architecture has a number of extensibility points. If extra capability is required, there are a number of entry points that allow you to customize the behavior of a service. [!INCLUDE[crabout](../../../includes/crabout-md.md)] available extensibility points see [Extending WCF](../../../docs/framework/wcf/extending/index.md).  
  
## WCF Integration with Other Microsoft Technologies  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] is a flexible platform. Because of this extreme flexibility, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] is also used in several other Microsoft products. By understanding the basics of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], you have an immediate advantage if you also use any of these products.  
  
 The first technology to pair with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] was the Windows Workflow Foundation (WF). Workflows simplify application development by encapsulating steps in the workflow as "activities." In the first version of [!INCLUDE[wf2](../../../includes/wf2-md.md)], a developer had to create a host for the workflow. The next version of [!INCLUDE[wf2](../../../includes/wf2-md.md)] was integrated with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]. That allowed any workflow to be easily hosted in a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service; you can do this by automatically choosing the WF/WCF a project type in [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)].  
  
 Microsoft BizTalk Server R2 also utilizes [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] as a communication technology. BizTalk is designed to receive and transform data from one standardized format to another. Messages must be delivered to its central message box where the message can be transformed using either a strict mapping or by using one of the BizTalk features such as its workflow engine. BizTalk can now use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Line of Business (LOB) adapter to deliver messages to the message box.  
  
 Microsoft Silverlight is a platform for creating interoperable, rich Web applications that allow developers to create media-intensive Web sites (such as streaming video). Beginning with version 2, Silverlight has incorporated [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] as a communication technology to connect Silverlight applications to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] endpoints.  
  
 The [!INCLUDE[dublin](../../../includes/dublin-md.md)] application server is specifically built for deploying and managing applications that use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] for communication. The [!INCLUDE[dublin2](../../../includes/dublin2-md.md)] includes rich tooling and configuration options specifically designed for [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]-enabled applications.  
  
## See Also  
 <xref:System.ServiceModel>  
 [Fundamental Windows Communication Foundation Concepts](../../../docs/framework/wcf/fundamental-concepts.md)  
 [Windows Communication Foundation Architecture](../../../docs/framework/wcf/architecture.md)  
 [Guidelines and Best Practices](../../../docs/framework/wcf/guidelines-and-best-practices.md)  
 [Getting Started Tutorial](../../../docs/framework/wcf/getting-started-tutorial.md)  
 [Guide to the Documentation](../../../docs/framework/wcf/guide-to-the-documentation.md)  
 [Basic WCF Programming](../../../docs/framework/wcf/basic-wcf-programming.md)  
 [Windows Communication Foundation Samples](http://msdn.microsoft.com/library/8ec9d192-5d81-4f64-bfd3-90c5e5858c91)
