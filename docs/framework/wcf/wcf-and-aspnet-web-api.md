---
title: "WCF and ASP.NET Web API"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 08ceded3-fd9a-4467-9715-c4cbd9c7228e
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF and ASP.NET Web API
WCF is Microsoft’s unified programming model for building service-oriented applications. It enables developers to build secure, reliable, transacted solutions that integrate across platforms and interoperate with existing investments. [ASP.NET Web API](http://www.asp.net/web-api) is a framework that makes it easy to build HTTP services that reach a broad range of clients, including browsers and mobile devices. ASP.NET Web API is an ideal platform for building RESTful applications on the .NET Framework. This topic presents some guidance to help you decide which technology will best meet your needs.  
  
## Choosing which technology to use  
 The following table describes the major features of each technology.  
  
|WCF|ASP.NET Web API|  
|---------|---------------------|  
|Enables building services that support multiple transport protocols (HTTP, TCP, UDP, and custom transports) and allows switching between them.|HTTP only. First-class programming model for HTTP. More suitable for access from various browsers, mobile devices etc enabling wide reach.|  
|Enables building services that support multiple encodings (Text, MTOM, and Binary) of the same message type and allows switching between them.|Enables building Web APIs that support wide variety of media types including XML, JSON etc.|  
|Supports building services with WS-* standards like Reliable Messaging, Transactions, Message Security.|Uses basic protocol and formats such as HTTP, WebSockets, SSL, JSON, and XML. There is no support for higher level protocols such as Reliable Messaging or Transactions.|  
|Supports Request-Reply, One Way, and Duplex message exchange patterns.|HTTP is request/response but additional patterns can be supported through [SignalR](https://github.com/SignalR/SignalR) and WebSockets integration.|  
|WCF SOAP services can be described in WSDL allowing automated tools to generate client proxies even for services with complex schemas.|There is a variety of ways to describe a Web API ranging from auto-generated HTML help page describing snippets to structured metadata for OData integrated APIs.|  
|Ships with the .NET framework.|Ships with .NET framework but is open-source and is also available out-of-band as independent download.|  
  
 Use WCF to create reliable, secure web services that accessible over a variety of transports. Use ASP.NET Web API to create HTTP-based services that are accessible from a wide variety of clients. Use ASP.NET Web API if you are creating and designing new REST-style services. Although WCF provides some support for writing REST-style services, the support for REST in ASP.NET Web API is more complete and all future REST feature improvements will be made in ASP.NET Web API. If you have an existing WCF service and you want to expose additional REST endpoints, use WCF and the <xref:System.ServiceModel.WebHttpBinding>.  
  
## See Also  
 [What Is Windows Communication Foundation](../../../docs/framework/wcf/whats-wcf.md)  
 [Fundamental Windows Communication Foundation Concepts](../../../docs/framework/wcf/fundamental-concepts.md)  
